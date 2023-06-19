using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az__Ado.Net.Entities.Mapping
{
    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Year)
                .IsRequired();

            this.Property(v => v.Price)
                .IsRequired();

            this.Property(b => b.Km)
                .IsRequired();

            this.Property(h => h.CarImage);

            this.Property(p => p.IsNew).IsRequired();

            this.Property(p => p.Engine).IsRequired();

        }

    }
}
