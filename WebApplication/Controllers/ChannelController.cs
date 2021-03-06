﻿using RepoAndUnitOfWorkJSON.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class ChannelController : Controller
    {
        private UnitOfWorkJson jsUnitOfWork = new UnitOfWorkJson();
        // GET: Channel
        public ActionResult Index(string channel)
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get("date");

            var result = jsUnitOfWork.ProgramRepository.ListOfJsonProgram(cookie.Value, channel);
            IndexHomeVM model = new IndexHomeVM(channel) {
                ProgramJsonList = result
            };
            return View(model);
        }
        public ActionResult ShowDays()
        {
            DaysVM model = new DaysVM();
            return PartialView("", model);
        }
    }
}