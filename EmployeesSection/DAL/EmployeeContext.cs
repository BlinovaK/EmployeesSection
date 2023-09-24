using EmployeesSection.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesSection.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) 
        {
        }

        public DbSet<Employee> Employee { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
