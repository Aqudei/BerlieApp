using BerlieApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlieApp.Persistence
{
    class BerlieContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }

        public BerlieContext()
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
