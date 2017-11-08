using RepoAndUnitOfWork.Abstract;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    public class PersonProgramRepository : Repository<PersonProgram>, IPersonProgramRepository
    {
        public PersonProgramRepository(ProgramDbContext pb) : base(pb)
        {
        }
    }
}
