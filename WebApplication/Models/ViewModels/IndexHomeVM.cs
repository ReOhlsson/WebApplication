using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Data;

namespace WebApplication.Models.ViewModels
{
    public class IndexHomeVM
    {
        public List<JsonProgram> listSvt { get; set; }
        public List<JsonProgram> listTv4 { get; set; }
        public List<JsonProgram> listTv3 { get; set; }

        //public User user { get; set; }

        private List<JsonProgram> programList = new List<JsonProgram>();

        public IndexHomeVM()
        {
            DateTime date = DateTime.Now;
            var dateNow = date.ToShortDateString();
            ProgramOperations po;
            po = new ProgramOperations(dateNow);
            programList = po.GetAllPrograms();
        }
        public void SeperateProgramList()
        {
            listSvt = programList.Where(x => x.jsontv.programme.Select(s => s.channel == "svt1.svt.se").ToList());
        }
    }
}