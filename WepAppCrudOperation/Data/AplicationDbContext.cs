using Microsoft.EntityFrameworkCore;
using WepAppCrudOperation.Models;

namespace WepAppCrudOperation.Data
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext>options):base(options)
        {

        }
        //second way to add schema to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employee>().ToTable("Employees", "HR");
        }

        public DbSet<Department> Deoartments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
