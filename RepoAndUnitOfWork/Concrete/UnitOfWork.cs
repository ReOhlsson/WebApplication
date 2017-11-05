using RepoAndUnitOfWork.Abstract;
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    public class UnitOfWork : IDisposable
    {
        //Our database context
        private ProgramDbContext dbContext = new ProgramDbContext();

        //Public members corresponding to each concrete repository
        public IProgramRepository ProgramRepository { get; private set; }
        public IPersonRepository PersonRepository { get; private set; }

        public UnitOfWork()
        {
            ProgramRepository = new ProgramRepository(dbContext);
            PersonRepository = new PersonRepository(dbContext);
        }
        //method to save all changes to repositories 
        public void Commit()
        {
            dbContext.SaveChanges();
            
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void InsertOrUpdateClicks(Program p)
        {
            var test = ProgramRepository.Find(x => x.Title == p.Title && x.Start_time == p.Start_time);
            if (!test.Any())
            {
                ProgramRepository.Create(p);
                Commit();
            }
            else
            {
                p = (Program)test.FirstOrDefault();
                p.Click += 1;
                ProgramRepository.Update(p);
                Commit();
            }
        }
    }
}
