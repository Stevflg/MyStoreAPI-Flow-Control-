using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class ProductTypeConfig : IEntityTypeConfiguration<Producttype>
    {
        void IEntityTypeConfiguration<Producttype>.Configure(EntityTypeBuilder<Producttype> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producttype");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.CreatedBy).HasMaxLength(40);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.State).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasMaxLength(40);
        }
    }
}