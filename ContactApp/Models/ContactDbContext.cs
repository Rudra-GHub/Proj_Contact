using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactApp.Models
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext() : base("name=SqlConn")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}