using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az__Ado.Net.Entities.Mapping
{
    public class ColorMap : EntityTypeConfiguration<Color>
    {
        public ColorMap()
        {
            this.HasKey(i => i.Id);

            this.Property(n => n.ColorName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true);

            this.HasMany(m => m.Cars)
                .WithOptional()
                .HasForeignKey(c => c.ColorId);
        }
    }
}
