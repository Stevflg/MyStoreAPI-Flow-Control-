using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class ScreensUIConfig : IEntityTypeConfiguration<Screensui>
    {
        void IEntityTypeConfiguration<Screensui>.Configure(EntityTypeBuilder<Screensui> entity)
        {
            
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("screensui");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.Route).HasMaxLength(100);
            entity.Property(e => e.State).HasDefaultValueSql("'1'");
        }
    }
}