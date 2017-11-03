using RepoAndUnitOfWorkJSON.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWorkJSON.Abstract
{
    public interface IRepository 
    {
        //method to get all rows in a table
        List<Programme> ListOfJsonProgram(string date, string channel);
        //Method to find a specific program
        Programme Find(Expression<Func<Programme, bool>> predicate);
    }
}
