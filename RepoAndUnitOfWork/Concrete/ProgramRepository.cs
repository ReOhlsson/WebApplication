using RepoAndUnitOfWork.Abstract;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    class ProgramRepository : Repository<Program>, IProgramRepository
    {
        public ProgramRepository(ProgramDbContext pb) : base(pb)
        {
        }

        public IEnumerable<Program> GetMostPopular(int number)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return dbContext.Program.OrderBy(t => t.Click >= 1).OrderByDescending(t => t.Click).Take(number).Where(x => x.End_time > unixTimestamp);
        }

        public IEnumerable<Program> GetProgramNews(int number)
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return dbContext.Program.Where(t => t.Editor_recommendation == true).Take(number).Where(x => x.End_time > unixTimestamp);
        }
    }
}
