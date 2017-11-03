
using RepoAndUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Concrete
{
    public class ProgramDbContext : DbContext
    {
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Role> Role { get; set; }

        public ProgramDbContext() : base ("name=ProgramDbContext")
        {

        }
    }
}
