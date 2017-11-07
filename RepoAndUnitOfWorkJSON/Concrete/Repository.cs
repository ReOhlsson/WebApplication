using RepoAndUnitOfWorkJSON.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoAndUnitOfWorkJSON.Entites;
using System.Linq.Expressions;

namespace RepoAndUnitOfWorkJSON.Concrete
{
    class Repository : IRepository
    {
        protected JsonData jsData;
        protected IQueryable<Programme> ProgramList;
        public Repository()
        {
            jsData = new JsonData();
        }

        public Programme Find(Expression<Func<Programme, bool>> predicate)
        {
            return ProgramList.Where(predicate).FirstOrDefault();
        }

        public List<Programme> ListOfJsonProgram(string date, string channel)
        {
            JsonProgram jp = new JsonProgram();
            jp = jsData.GetJsonChannel(date, channel);
            List<Programme> programList = new List<Programme>();
            programList = jp.jsontv.programme.ToList();
            
            ProgramList = programList.AsQueryable();

            programList = ConvertListToString(programList);
            programList = SetStartTime(programList);
            return programList;


        }

        private List<Programme> ConvertListToString(List<Programme> jsonList)
        {
            foreach (var item in jsonList)
            {
                foreach (var c in item.category.en)
                {
                    item.CategoryToString += c + "/";
                }
            }

            return jsonList;
        }
        private List<Programme> SetStartTime(List<Programme> jsonList)
        {
            foreach (var p in jsonList)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 1, 0, 0, 0, DateTimeKind.Local);
                dateTime = dateTime.AddSeconds(Convert.ToInt32(p.start));
                p.StartTime = dateTime;

                TimeSpan now = DateTime.Now.TimeOfDay;
                TimeSpan programTime = p.StartTime.TimeOfDay;

                if(now > programTime)
                {
                    p.HasPassed = "Passed";
                }
                else
                {
                    p.HasPassed = "NotPassed";
                }

            }
            return jsonList;

        }

    }
}
