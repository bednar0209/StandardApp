using StandardApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardApp.Model
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
