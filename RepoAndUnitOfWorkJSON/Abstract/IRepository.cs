using RepoAndUnitOfWorkJSON.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWorkJSON.Abstract
{
    public interface IRepository 
    {
        //method to get all rows in a table
        List<Programme> ListOfJsonProgram(string date, string channel);

    }
}
