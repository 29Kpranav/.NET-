using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CustomerWebApi
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databseCreator != null )
                {
                    if (!databseCreator.CanConnect()) databseCreator.Create();      //create database
                    if (!databseCreator.HasTables()) databseCreator.CreateTables(); //create tables
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<CustomerDbContext> Customers { set; get; }
        
    }
}
