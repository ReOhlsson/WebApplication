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
            return dbContext.Program.OrderBy(t => t.Click >= 1).OrderByDescending(t => t.Click).Take(number);
        }
    }
}
