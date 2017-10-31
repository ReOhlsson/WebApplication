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

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
            IndexHomeVM indexHome = new IndexHomeVM();
            return View(indexHome);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Program(string title, string starttime)
        {
            IndexHomeVM ivm = new IndexHomeVM();
            var model = ivm.GetProgramDetails(title, starttime);

            return PartialView("PwPopup", model);
        }
    }
}