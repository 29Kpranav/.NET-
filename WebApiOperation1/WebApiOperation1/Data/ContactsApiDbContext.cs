using Microsoft.EntityFrameworkCore;
using WebApiOperation1.Models;

namespace WebApiOperation1.Data
{
    public class ContactsApiDbContext: DbContext
    {

        public ContactsApiDbContext(DbContextOptions options) : base(options) { 

        }

        public  DbSet<Contact> Contacts { get; set; }

    }
}
