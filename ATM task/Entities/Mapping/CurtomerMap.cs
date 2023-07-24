using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATM_task.Entities.Mapping
{
    public class CurtomerMap : EntityTypeConfiguration<Customer>
    {
        public CurtomerMap()
        {
            this.HasKey(x => x.Id);

            this.Property(c => c.FullName)
                   .IsRequired()
                   .HasMaxLength(30)
                   .IsUnicode();
        }
    }
}
