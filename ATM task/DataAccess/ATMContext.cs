using ATM_task.Entities;
using ATM_task.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ATM_task
{
    public class ATMContext:DbContext
    {
        public ATMContext()
        :base("ATMDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CardMap());
            modelBuilder.Configurations.Add(new CurtomerMap());
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
