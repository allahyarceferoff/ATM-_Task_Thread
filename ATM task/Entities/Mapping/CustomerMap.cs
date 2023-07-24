using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_task.Entities.Mapping
{
    public class CustomerMap:EntityTypeConfiguration<Customer>  
    {
        public CustomerMap()
        {
            this.HasKey(x => x.Id);

            this.Property(c => c.FullName)
                   .IsRequired()
                   .HasMaxLength(16)
                   .IsUnicode(true);
        }
    }
}
