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

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

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

        public ActionResult ShowsPop(string title, string start, string stop, string channel)
        {
            Program p = new Program();

            var test = unitOfWork.ProgramRepository.GetByStartTimeAndTitle(x => x.Title == title && x.Start_time == start);

            if (!test.Any())
            {

                p.Title = title;
                p.Start_time = start;
                p.End_time = stop;
                p.Channel = channel;
                p.Click = 1;

                unitOfWork.ProgramRepository.Create(p);
                unitOfWork.Commit();
            }
            else
            {
                var i = test.Sum(x => x.Click);
                p = (Program)test;
                p.Click = i + 1;
                unitOfWork.ProgramRepository.Update(p);
                unitOfWork.Commit();
            }

            return PartialView("Shows");
        }

        //public ActionResult PopularShows(string channel, string date, string title)
        //{
        //    //När man klickar på länk skickas man hit
        //    //Hämtar data från json och sätter objekt
        //    //Skickar objekt till databasen


        //    //Hämta 5 mest klickade (index?)
        //    var indexHome;

        //    return PartialView("PopularShows", indexHome);
    }
    
}