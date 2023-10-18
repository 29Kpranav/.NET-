using crudMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace crudMVC.Data
{
    public class Mvc_demo_DbContext : DbContext
    {
        public Mvc_demo_DbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
