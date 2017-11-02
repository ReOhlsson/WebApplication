using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        //method to get all rows in a table
        IEnumerable<T> DataSet { get; }

        //method to add row to the table
        void Create(T entity);

        //Method so fetch row from the table
        T GetById(int? id);

        //Method to update a row in a table
        void Update(T entity);

        //Method to delete a row from the table
        void Delete(T entity);

        IEnumerable<T> GetByStartTimeAndTitle(Expression<Func<T, bool>> predicate);
    }
}
