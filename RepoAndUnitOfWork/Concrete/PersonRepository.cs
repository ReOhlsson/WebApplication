using RepoAndUnitOfWork.Abstract;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public bool IsUserRole(string username, string roleName)
        {
            var role = dbContext.Person.Where(x => x.Username == username).Include(x => x.Role).Where(x => x.Role.Roles == roleName);

            return role.Any();
        }
    }
}

