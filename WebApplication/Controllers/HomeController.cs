using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Models.ViewModels;
using RepoAndUnitOfWork.Entities;
using RepoAndUnitOfWorkJSON.Concrete;
using RepoAndUnitOfWorkJSON.Entites;
using RepoAndUnitOfWork.Concrete;
using WebApplication.Models.Models;
using RepoAndUnitOfWork.Security;
using System.Globalization;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWorkJson jsUnitOfWork = new UnitOfWorkJson();
        UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shows(string channel, string date)
        {
            var result = jsUnitOfWork.ProgramRepository.ListOfJsonProgram(date, channel);
            IndexHomeVM model = new IndexHomeVM(channel) {
                ProgramJsonList = result,
            };
            return PartialView("Shows", model);
        }

        public ActionResult ShowsPop(string title, long start, long stop,  string desc, string channel, string category, string starttime, string endtime)
        {
            Program p = new Program();
            p.Title = title;
            p.Start_time = start;
            p.End_time = stop;
            p.Channel = channel;
            p.Click = 1;
            p.Description = desc;
            p.Categories = category;
            p.Picture = "https://images.pexels.com/photos/239533/pexels-photo-239533.jpeg?w=1260&h=750&auto=compress&cs=tinysrgb";
            p.Start_Time_String = starttime;
            p.End_time_string = endtime;

            var c = category.Split('/').ToArray();

            Programme pj = new Programme();

            pj.start = start.ToString();
            pj.title.sv = title;
            pj.stop = stop.ToString();
            pj.channel = channel;
            pj.desc.sv = desc;
            pj.category.en = c.ToList();

            var result = unitOfWork.ProgramRepository.Find(x => x.Title == p.Title && x.Start_time == p.Start_time);
            if (!result.Any())
            {
                try
                {
                    unitOfWork.ProgramRepository.Create(p);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                try
                {
                    p = (Program)result.FirstOrDefault();
                    p.Click += 1;
                    unitOfWork.ProgramRepository.Update(p);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            JsonProgramModel model = new JsonProgramModel() {
                ProgramJson = pj
            };
            model.SetTime();
            return PartialView("PwPopup", model);
        }

        public ActionResult LoadPopularPrograms()
        {
            var indexHome = unitOfWork.ProgramRepository.GetMostPopular(5);

            foreach(var item in indexHome)
            {
                item.Channel = item.Channel.Trim();
            }

            return PartialView("PopularShows", indexHome);
        }

        [Authorize]
        public ActionResult MyPage()
        {
            return View();
        }

        public ActionResult ShowDays()
        {
            DaysVM model = new DaysVM();
            return PartialView("", model);
        }

        public ActionResult LoadProgramNews()
        {
            var indexHome = unitOfWork.ProgramRepository.GetProgramNews(4);

            foreach (var item in indexHome)
            {
                item.Channel = item.Channel.Trim();
            }
            return PartialView("_NewsShows", indexHome); 
        }

        public ActionResult CreateViewList(string title, long start, long stop, string desc, string channel, string category, string starttime, string endtime)
        {
            Person person = new Person();
            person = unitOfWork.PersonRepository.Find(x => x.Username == User.Identity.Name).FirstOrDefault();

            
            Program program = new Program();
            program = unitOfWork.ProgramRepository.Find(p => p.Title == title && p.Start_time == start).FirstOrDefault();

            
            var result = unitOfWork.PersonProgramRepository.Find(x => x.Person_Id == person.Id && x.Program_id == program.Id);

            if (!result.Any())
            {
                try
                {
                    DateTime date = DateTime.Now;
                    PersonProgram personProgram = new PersonProgram()
                    {
                        Person_Id = person.Id,
                        Program_id = program.Id,
                        SavedDate = date
                    };
                    unitOfWork.PersonProgramRepository.Create(personProgram);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {
                    //Skicka ett error message
                    throw;
                }
                
            }
            return View();
        }

        public ActionResult GetViewList()
        {
            Person person = new Person();
            person = unitOfWork.PersonRepository.Find(x => x.Username == User.Identity.Name).FirstOrDefault();

            ProgramDbContext db = new ProgramDbContext();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            var program = from c in db.PersonProgram
                          join o in db.Program on c.Program_id equals o.Id
                          where ((c.Person_Id == person.Id) && (o.End_time > unixTimestamp))
                          select c.Program as Program;

            var newList = program.ToList();

            foreach (var item in newList)
            {
                item.Channel = item.Channel.Trim();
            }

            return PartialView("_ViewList", newList);
        }
     
        public ActionResult DeleteProgram(int id)
        {
            var person = unitOfWork.PersonRepository.Find(x => x.Username == User.Identity.Name).FirstOrDefault();
            var result = unitOfWork.PersonProgramRepository.Find(x => x.Program_id == id && x.Person_Id == person.Id).FirstOrDefault();
            if(result != null)
            {
                try
                {
                    unitOfWork.PersonProgramRepository.Delete(result);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {
                    //Error message
                    throw;
                }
            }

            return RedirectToAction("GetViewList");
        }

        public ActionResult GetEditorList()
        {
            //List<Program> newList = unitOfWork.ProgramRepository.Find(x => x.Editor_recommendation == true).ToList();
            var newList = unitOfWork.ProgramRepository.GetEditorPrograms();

            foreach (var item in newList)
            {
                item.Channel = item.Channel.Trim();
            }

            return PartialView("_EditorRecommendation", newList);
        }
   
        public ActionResult RemoveEditorRecommendation(int id)
        {
            Program program = unitOfWork.ProgramRepository.Find(x => x.Id == id).FirstOrDefault();
            program.Editor_recommendation = false;
            unitOfWork.ProgramRepository.Update(program);
            unitOfWork.Commit();

            return RedirectToAction("GetEditorList");
        }

        public ActionResult CreateEditorRecommendationList(string title, long start, long stop, string desc, string channel, string category, string starttime, string endtime)
        {
            Program program = new Program();
            program = unitOfWork.ProgramRepository.Find(p => p.Title == title && p.Start_time == start).FirstOrDefault();


            if (program == null)
            {
                program.Title = title;
                program.Start_time = start;
                program.End_time = stop;
                program.Description = desc;
                program.Channel = channel;
                program.Categories = category;
                program.Editor_recommendation = true;
                program.Click += 1;
                program.Picture = "https://images.pexels.com/photos/239533/pexels-photo-239533.jpeg?w=1260&h=750&auto=compress&cs=tinysrgb";
                program.Start_Time_String = starttime;
                program.End_time_string = endtime;

                try
                {
                    unitOfWork.ProgramRepository.Create(program);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            else
            {
                program.Editor_recommendation = true;

                try
                {
                    unitOfWork.ProgramRepository.Update(program);
                    unitOfWork.Commit();
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return View();
        }

    }
}