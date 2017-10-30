using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.JsonModel
{
    public class Credits
    {
        public List<Person> writer { get; set; }
        public List<Person> director { get; set; }
        public List<Person> actor { get; set; }
    }
}