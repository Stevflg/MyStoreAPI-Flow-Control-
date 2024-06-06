using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class UserRolConfig : IEntityTypeConfiguration<Userrol>
    {
        void IEntityTypeConfiguration<Userrol>.Configure(EntityTypeBuilder<Userrol> entity)
        {
            entity.HasKey(e => new { e.UserId, e.RolId }).HasName("PRIMARY");

            entity.ToTable("userrol");

            entity.HasIndex(e => e.RolId, "RolID");

            entity.Property(e => e.UserId)
                .HasMaxLength(40)
                .HasColumnName("UserID");
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

            entity.HasOne(d => d.Rol).WithMany(p => p.Userrols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userrol_ibfk_2");

            entity.HasOne(d => d.User).WithMany(p => p.Userrols)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userrol_ibfk_1");
        }
    }
}