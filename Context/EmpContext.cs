using Employee_Management_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_App.Context
{
    public class EmpContext : DbContext
    {

        public EmpContext(DbContextOptions<EmpContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<AttendanceSummary> AttendanceSummaries { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}
