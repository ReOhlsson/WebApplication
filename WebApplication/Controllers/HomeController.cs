﻿using Newtonsoft.Json;
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
            IndexHomeVM model = new IndexHomeVM(jsUnitOfWork, date, channel);
            return PartialView("Shows", model);
        }

        public ActionResult ShowsPop(string title, string start, string stop,  string desc, string channel, string category)
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

            var c = category.Split('/').ToArray();

            Programme pj = new Programme();

            pj.start = start;
            pj.title.sv = title;
            pj.stop = stop;
            pj.channel = channel;
            pj.desc.sv = desc;
            pj.category.en = c.ToList();

            JsonProgramModel model = new JsonProgramModel(unitOfWork, p, pj);

            return PartialView("PwPopup", model);
        }

        public ActionResult LoadPopularPrograms()
        {
            var indexHome = unitOfWork.ProgramRepository.GetMostPopular(5);

            return PartialView("PopularShows", indexHome);
        }

        [Authorize]
        public ActionResult MyPage()
        {
            //var model = jsUnitOfWork.ProgramRepository.ListOfJsonProgram("2017-11-01", "tv3");
            return View();
        }
        public ActionResult ShowDays()
        {
            DaysVM model = new DaysVM();
            return PartialView("", model);
        }

    }
    
}