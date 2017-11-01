using RepoAndUnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected ProgramDbContext dbContext;

        protected DbSet<T> dbSet;
        public Repository(ProgramDbContext pb)
        {
            dbContext = pb;
            dbSet = pb.Set<T>();
        }
        public IEnumerable<T> DataSet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T GetById(int? id)
        {
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }
    }
}
