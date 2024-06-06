using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class RolScreenUIConfig : IEntityTypeConfiguration<Rolscreenui>
    {
        void IEntityTypeConfiguration<Rolscreenui>.Configure(EntityTypeBuilder<Rolscreenui>entity)
        {
            entity.HasKey(e => new { e.ScreenUiid, e.RolId }).HasName("PRIMARY");

            entity.ToTable("rolscreenui");

            entity.HasIndex(e => e.RolId, "RolID");

            entity.Property(e => e.ScreenUiid)
                .HasMaxLength(40)
                .HasColumnName("ScreenUIID");
            entity.Property(e => e.RolId)
                .HasMaxLength(40)
                .HasColumnName("RolID");
            entity.Property(e => e.CreatedBy).HasMaxLength(40);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.State).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasMaxLength(40);

            entity.HasOne(d => d.Rol).WithMany(p => p.Rolscreenuis)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rolscreenui_ibfk_2");

            entity.HasOne(d => d.ScreenUi).WithMany(p => p.Rolscreenuis)
                .HasForeignKey(d => d.ScreenUiid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rolscreenui_ibfk_1");
        }
    }
}