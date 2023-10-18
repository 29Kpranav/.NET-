using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApproch.Data
{
    internal class DemoContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }  

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductOrders> ProductOrders { get; set; } 

        protected override void OnConfiguring(DbContectOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-F4QI0N65;database=MvcDemoDb;Trusted_connection=True;TrustServerCertificate=Yes\")
        }
    }
}
