using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC_ASSIGNMENT_1.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("connectstr") { }

        public DbSet<Contact> Contacts { get; set; }

    }
}