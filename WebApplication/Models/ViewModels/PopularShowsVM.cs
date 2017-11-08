using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class PopularShowsVM
    {
        public List<Program> listOfProgram { get; set; }  = new List<Program>();
    }
}