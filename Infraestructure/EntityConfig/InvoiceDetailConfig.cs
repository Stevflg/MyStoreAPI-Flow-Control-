using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class InvoiceDetailConfig : IEntityTypeConfiguration<Invoicedetail>
    {
        void IEntityTypeConfiguration<Invoicedetail>.Configure(EntityTypeBuilder<Invoicedetail> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoicedetail");

            entity.HasIndex(e => e.InvoiceId, "InvoiceId");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.CreatedBy).HasMaxLength(40);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceId).HasMaxLength(40);
            entity.Property(e => e.Iva)
                .HasPrecision(10)
                .HasColumnName("IVA");
            entity.Property(e => e.Price).HasPrecision(10);
            entity.Property(e => e.ProductId).HasMaxLength(40);
            entity.Property(e => e.State).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasMaxLength(40);

            entity.HasOne(d => d.Invoice).WithMany(p => p.Invoicedetails)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("invoicedetail_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Invoicedetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("invoicedetail_ibfk_2");
        }
    }
}