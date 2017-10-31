﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Data;
using WebApplication.Models.JsonModel;
using System.Data.Entity;

namespace WebApplication.Models.ViewModels
{
    public class IndexHomeVM
    {
        public List<JsonProgram> listSvt { get; set; } = new List<JsonProgram>();
        public List<JsonProgram> listTv4 { get; set; } = new List<JsonProgram>();
        public List<JsonProgram> listTv3 { get; set; } = new List<JsonProgram>();
        public List<Days> listOfDays { get; set; } = new List<Days>();
        //public User user { get; set; }

        private List<JsonProgram> programList = new List<JsonProgram>();

        public IndexHomeVM()
        {
            DaysData dd = new DaysData();
            listOfDays = dd.GetAllDays();
        }
        public void GetAllProgramByDate(string date)
        {
            //var dateNow = date.ToShortDateString();
            ProgramOperations po;
            po = new ProgramOperations(date);
            programList = po.GetAllPrograms();

            SeperateProgramList();
        }

        private void SeperateProgramList()
        {
            listSvt = programList.Where(x => x.jsontv.programme.All(s => s.channel.Contains("svt1.svt.se"))).ToList();
            listTv4 = programList.Where(x => x.jsontv.programme.All(s => s.channel.Contains("tv4.se"))).ToList();
            listTv3 = programList.Where(x => x.jsontv.programme.All(s => s.channel.Contains("tv3.se"))).ToList();
        }

        public Programme GetProgramDetails(string title, string starttime)
        {
            ProgramOperations po = new ProgramOperations("2017-10-31");
            Programme js = new Programme();

            List<JsonProgram> jpList = new List<JsonProgram>();
            jpList = po.GetAllPrograms();

            var item = jpList.SelectMany(a => a.jsontv.programme).FirstOrDefault(b => b.title.sv == title && b.start == starttime);

            return item;
        }
    }
}