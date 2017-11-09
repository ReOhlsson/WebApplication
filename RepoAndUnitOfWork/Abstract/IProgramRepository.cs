using RepoAndUnitOfWork.Concrete;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Abstract
{
    public interface IProgramRepository : IRepository<Program>
    {
        IEnumerable<Program> GetMostPopular(int number);
        IEnumerable<Program> GetProgramNews(int number);
        IEnumerable<Program> GetEditorPrograms();
        //IEnumerable<Program> GetProgramNews(int number);
    }
}
