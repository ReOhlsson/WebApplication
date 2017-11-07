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
            var result = jsUnitOfWork.ProgramRepository.ListOfJsonProgram(date, channel);
            IndexHomeVM model = new IndexHomeVM(channel) {
                ProgramJsonList = result,
            };
            return PartialView("Shows", model);
        }

        public ActionResult ShowsPop(string title, long start, long stop,  string desc, string channel, string category)
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

            pj.start = start.ToString();
            pj.title.sv = title;
            pj.stop = stop.ToString();
            pj.channel = channel;
            pj.desc.sv = desc;
            pj.category.en = c.ToList();

            var result = unitOfWork.ProgramRepository.Find(x => x.Title == p.Title && x.Start_time == p.Start_time);
            if (!result.Any())
            {
                unitOfWork.ProgramRepository.Create(p);
                unitOfWork.Commit();
            }
            else
            {
                p = (Program)result.FirstOrDefault();
                p.Click += 1;
                unitOfWork.ProgramRepository.Update(p);
                unitOfWork.Commit();
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