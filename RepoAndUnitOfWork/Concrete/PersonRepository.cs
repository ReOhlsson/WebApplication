using RepoAndUnitOfWork.Abstract;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ProgramDbContext pb) : base(pb)
        {

        }

        public IEnumerable<Person> GetUserCredentials(string username, string password)
        {
            return dbContext.Person.Where(x => x.Username == username && x.Password == password);
        }
    }
}

