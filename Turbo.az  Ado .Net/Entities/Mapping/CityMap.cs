using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az__Ado.Net.Entities.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            this.HasKey(i => i.Id);

            this.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true);

            this.HasMany(m => m.Cars)
                .WithOptional()
                .HasForeignKey(c => c.CityId);
        }
    }
}
