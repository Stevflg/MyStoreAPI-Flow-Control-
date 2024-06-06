using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.EmployeeId, "EmployeeId");

            entity.Property(e => e.Id).HasMaxLength(40);
            entity.Property(e => e.ChangePassword).HasDefaultValueSql("'0'");
            entity.Property(e => e.CreatedBy).HasMaxLength(40);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasMaxLength(40);
            entity.Property(e => e.Locked).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.Password)
                .HasMaxLength(1000);
            entity.Property(e => e.State).HasDefaultValueSql("'1'");
            entity.Property(e => e.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasMaxLength(40);

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("users_ibfk_1");
            entity.Property(a => a.Email).HasMaxLength(50);
        }
    }
}