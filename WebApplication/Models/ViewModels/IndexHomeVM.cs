using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Data;
using System.Data.Entity;
using RepoAndUnitOfWorkJSON.Entites;
using RepoAndUnitOfWork.Concrete;
using RepoAndUnitOfWorkJSON.Concrete;

namespace WebApplication.Models.ViewModels
{
    public class IndexHomeVM
    {
        public List<Programme> ProgramJsonList { get; set; } = new List<Programme>();

        public IndexHomeVM(UnitOfWorkJson unit, string date, string channel)
        {
            ProgramJsonList = unit.ProgramRepository.ListOfJsonProgram(date, channel);


            string defaultText = "Ingen text finns";
            foreach (var p in ProgramJsonList)
            {
                if (p.desc.sv == "")
                {
                    p.desc.sv += defaultText;
                }
            }
        }
    }
}