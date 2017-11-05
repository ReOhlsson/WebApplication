using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetUserCredentials(string username, string password);
    }
}
