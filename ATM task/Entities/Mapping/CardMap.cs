using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_task.Entities.Mapping
{
    public class CardMap : EntityTypeConfiguration<Card>
    {
        public CardMap()
        {
            this.HasKey(x => x.Id);

            this.Property(c => c.CardNumber)
                   .IsRequired()
                   .HasMaxLength(16)
                   .IsUnicode(true);

            this.Property(c => c.CustomerId)
                   .IsRequired();

            this.Property(c => c.Balance)
                .IsRequired();
        }
    }
}
