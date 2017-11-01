using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    public class ProgramDbContext : DbContext
    {
        public DbSet<Program> Program { get; set; }
        public ProgramDbContext() : base ("name=ProgramDbContext")
        {

        }
    }
}
