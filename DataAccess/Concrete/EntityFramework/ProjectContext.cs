using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AnimalShelter;Trusted_Connection=true");
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeArchive> EmployeeArchives { get; set; }
        public DbSet<Genus> Genera { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Species> Species { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Animal>().ToTable(tb => tb.HasTrigger("TriggerName"));
            builder.Entity<Employee>().ToTable(tb => tb.HasTrigger("TriggerName"));
            builder.Entity<Shelter>().ToTable(tb => tb.HasTrigger("TriggerName"));
        }

    }
}
