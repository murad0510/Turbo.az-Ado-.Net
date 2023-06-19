using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az__Ado.Net.Entities.Mapping
{
    public class FuelTypeMap : EntityTypeConfiguration<FuelType>
    {
        public FuelTypeMap()
        {
            this.HasKey(i => i.Id);

            this.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true);

            this.HasMany(c => c.Cars)
                .WithOptional()
                .HasForeignKey(i => i.FuelTypeId);
        }
    }
}
