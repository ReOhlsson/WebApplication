using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoAndUnitOfWorkJSON.Entites
{
    public class Credits
    {
        public List<CreditPerson> writer { get; set; } = new List<CreditPerson>();
        public List<CreditPerson> director { get; set; } = new List<CreditPerson>();
        public List<CreditPerson> actor { get; set; } = new List<CreditPerson>();
    }
}