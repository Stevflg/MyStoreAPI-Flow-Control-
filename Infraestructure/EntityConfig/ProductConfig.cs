using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        void IEntityTypeConfiguration<Product>.Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.Price, "Price");

            entity.HasIndex(e => e.Type, "Type");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(40);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ExpirationDate).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasMaxLength(40);
            entity.Property(e => e.State).HasDefaultValueSql("'1'");
            entity.Property(e => e.Type).HasMaxLength(40);
            entity.Property(e => e.Units).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasMaxLength(40);
            entity.Property(e => e.UrlImage).HasMaxLength(200);

            entity.HasOne(d => d.PriceNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Price)
                .HasConstraintName("products_ibfk_1");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("products_ibfk_2");
        }
    }
}