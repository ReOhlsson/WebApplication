
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
        public virtual DbSet<PersonProgram> PersonProgram { get; set; }

        public ProgramDbContext() : base ("name=ProgramDbContext")
        {

        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>().HasMany(p => p.Program).WithMany(p => p.Person).Map(m => 
        //    {
        //        m.ToTable("PersonProgram");
        //        m.MapLeftKey("Person_id");
        //        m.MapRightKey("Program_id");
        //    });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
