using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoAndUnitOfWorkJSON.Entites
{
    public class Credits
    {
        public List<Person> writer { get; set; }
        public List<Person> director { get; set; }
        public List<Person> actor { get; set; }
    }
}