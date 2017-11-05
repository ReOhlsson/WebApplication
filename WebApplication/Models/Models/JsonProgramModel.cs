using RepoAndUnitOfWork.Concrete;
using RepoAndUnitOfWork.Entities;
using RepoAndUnitOfWorkJSON.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Models
{
    public class JsonProgramModel
    {
        public Programme ProgramJson { get; set; } = new Programme();
        private Program Program { get; set; } = new Program();

        public JsonProgramModel(UnitOfWork unit, Program pr, Programme jsPr)
        {
            unit.InsertOrUpdateClicks(pr);
            this.ProgramJson = jsPr;
        }
    }
}