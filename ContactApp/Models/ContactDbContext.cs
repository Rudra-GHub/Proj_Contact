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
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<ContactDbContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Contact> Contacts { get; set; }
    }
}