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

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWorkJson jsUnitOfWork = new UnitOfWorkJson();
        UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            //var model = jsUnitOfWork.ProgramRepository.ListOfJsonProgram("2017-11-01", "tv3");
            return View();
        }
        //public ActionResult Program(string title, string starttime)
        //{
        //    IndexHomeVM ivm = new IndexHomeVM();
        //    var model = ivm.GetProgramDetails(title, starttime);

        //    return PartialView("PwPopup", model);
        //}

        public ActionResult Shows(string channel, string date = "2017-11-01")
        {
            var indexHome = jsUnitOfWork.ProgramRepository.ListOfJsonProgram(date, channel);

            return PartialView("Shows", indexHome);
        }

        public ActionResult ShowsPop(Programme program)
        {
            Program p = new Program();
            p.Title = program.title.sv;
            p.Start_time = program.start;
            p.End_time = program.stop;
            p.Channel = program.channel;
            p.Click = 1;


            //var test = unitOfWork.ProgramRepository.Find(x => x.Title == title && x.Start_time == start);

            //if (!test.Any())
            //{

            //    unitOfWork.ProgramRepository.Create(p);
            //    unitOfWork.Commit();
            //}
            //else
            //{
            //    p = (Program)test.FirstOrDefault();
            //    p.Click += 1;
            //    unitOfWork.ProgramRepository.Update(p);
            //    unitOfWork.Commit();
            //}

            Programme pj = new Programme();
            
            //pj.start = start;
            //pj.title.sv = title;
            //pj.stop = stop;
            //pj.channel = channel;
            //pj.desc.sv = description;
            //pj.category.en = categoryList;

            return PartialView("PwPopup", pj);
        }

        public ActionResult LoadPopularPrograms()
        {
            var indexHome = unitOfWork.ProgramRepository.GetMostPopular(5);

            return PartialView("PopularShows", indexHome);
        }
    }
    
}