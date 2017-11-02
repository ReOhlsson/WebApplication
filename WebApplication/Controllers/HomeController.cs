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

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        UnitOfWorkJson jsUnitOfWork = new UnitOfWorkJson();
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
    }
}