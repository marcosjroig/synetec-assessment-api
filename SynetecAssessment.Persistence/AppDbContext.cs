using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
