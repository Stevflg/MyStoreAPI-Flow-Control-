using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class PriceConfig : IEntityTypeConfiguration<Price>
    {
        void IEntityTypeConfiguration<Price>.Configure(EntityTypeBuilder<Price> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("prices");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.CreatedBy).HasMaxLength(40);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.DiscountPrice).HasPrecision(10);
            entity.Property(e => e.Price1)
                .HasPrecision(10)
                .HasColumnName("Price");
            entity.Property(e => e.PromotionPrice).HasPrecision(10);
            entity.Property(e => e.State).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasMaxLength(40);
        }
    }
}