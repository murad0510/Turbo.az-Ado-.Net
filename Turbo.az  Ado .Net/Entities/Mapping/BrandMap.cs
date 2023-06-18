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


        //        this.Property(c => c.CompanyName)
        //    .IsRequired()
        //    .HasMaxLength(30)
        //    .IsUnicode(true);

        //this.Property(c => c.ContactName)
        //    .HasMaxLength(40);

        //this.ToTable("Customers");

        //this.Property(t => t.Id).HasColumnName("Id");
        //this.Property(t => t.Country).HasColumnName("Country");
        //this.Property(t => t.CompanyName).HasColumnName("CompanyName");

        //this.Property(t => t.ContactName)
        //    .HasColumnAnnotation(IndexAnnotation.AnnotationName,
        //    new IndexAnnotation(new IndexAttribute("IX_ContactName", 2) { IsUnique = true }));

        //this.HasMany(c => c.Orders)
        //    .WithOptional()
        //    .HasForeignKey(o => o.CustomerId)
        //    .WillCascadeOnDelete(true);

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
