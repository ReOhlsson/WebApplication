using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Abstract
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetUserCredentials(string username, string password);
        bool IsInRole(string username, string roleName);
    }
}
