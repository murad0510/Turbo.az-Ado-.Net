using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.az__Ado.Net.Entities.Mapping
{
    public class BrandMap : EntityTypeConfiguration<Brand>
    {
        public BrandMap()
        {
            this.HasKey(i => i.Id);

            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true);

            this.HasMany(c => c.Models)
                  .WithOptional()
                  .HasForeignKey(b => b.BrandId)
                  .WillCascadeOnDelete();
        }
    }
}
