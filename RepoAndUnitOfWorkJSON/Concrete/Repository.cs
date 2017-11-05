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
            return programList;
        }

    }
}
