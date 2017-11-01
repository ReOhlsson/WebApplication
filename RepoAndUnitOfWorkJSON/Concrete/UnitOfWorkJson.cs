using RepoAndUnitOfWorkJSON.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWorkJSON.Concrete
{
    public class UnitOfWorkJson
    {
        //Our database context
        //private ProgramDbContext dbContext = new ProgramDbContext();

        //Private members corresponding to each concrete repository
        private Repository programRepository;

        public IRepository ProgramRepository
        {
            get
            {
                if (programRepository == null)
                {
                    programRepository = new Repository();
                }
                return programRepository;
            }
        }
    }
}
