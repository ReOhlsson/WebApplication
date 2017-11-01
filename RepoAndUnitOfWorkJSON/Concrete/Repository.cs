using RepoAndUnitOfWorkJSON.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoAndUnitOfWorkJSON.Entites;

namespace RepoAndUnitOfWorkJSON.Concrete
{
    class Repository : IRepository
    {
        protected JsonData jsData;
        public Repository()
        {
            jsData = new JsonData();
        }

        public List<Programme> ListOfJsonProgram(string date, string channel)
        {
            JsonProgram jp = new JsonProgram();
            jp = jsData.GetJsonChannel(date, channel);
            List<Programme> programList = new List<Programme>();
            programList = jp.jsontv.programme.ToList();

            return programList;
        }
    }
}
