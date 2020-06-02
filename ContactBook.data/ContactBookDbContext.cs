using ContactBook.core;
using ContactBook.data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactBook.data
{
    public class ContactBookDbContext : DbContext
    {
        public ContactBookDbContext() : base("contact-book")
        {
            Database.SetInitializer<ContactBookDbContext>(null);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContactBookDbContext, Configuration>());
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactAdress> Adresses { get; set; }
        public DbSet<ContactEmail> Emails { get; set; }
        public DbSet<ContactPhone> Phones { get; set; }
        
    }
}
