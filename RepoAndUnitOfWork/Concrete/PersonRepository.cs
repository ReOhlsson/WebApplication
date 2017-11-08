using RepoAndUnitOfWork.Abstract;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RepoAndUnitOfWork.Security;

namespace RepoAndUnitOfWork.Concrete
{
    class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ProgramDbContext pb) : base(pb)
        {

        }

        public Person GetUserCredentials(string username, string password)
        {
            
            var person =  dbContext.Person.Where(x => x.Username == username).Include(x => x.Role).FirstOrDefault();
            if(CreateHash(password, person.Password))
            {
                return person;
            }
            return null;
        }

        public bool IsInRole(string username, string roleName)
        {
            var role = dbContext.Person.Where(x => x.Username == username).Include(x => x.Role).Where(x => x.Role.Roles == roleName);

            return role.Any();
        }
        private bool CreateHash(string password, string storedPass)
        {
            string storedPassword = storedPass;

            byte[] hashByte = Convert.FromBase64String(storedPassword);

            HashingPassword hash = new HashingPassword(hashByte);
            if (hash.VerifyPassword(password))
            {
                return true;
            }
            return false;
        }

    }
}

