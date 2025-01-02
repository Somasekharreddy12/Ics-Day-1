using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeChallenge8_2.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("connectstr") { }

        public DbSet<Movie> Movies { get; set; }

    }
}