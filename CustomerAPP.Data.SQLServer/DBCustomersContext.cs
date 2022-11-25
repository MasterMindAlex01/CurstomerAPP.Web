using System;
using System.Collections.Generic;
using CustomerAPP.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerAPP.Data.SQLServer
{
    public class DBCustomersContext : DbContext
    {
        public DBCustomersContext()
        {
        }

        public DBCustomersContext(DbContextOptions<DBCustomersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomersPhone> CustomersPhones { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.CLastName1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cLastName1");

                entity.Property(e => e.CLastName2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cLastName2");

                entity.Property(e => e.CName1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cName1");

                entity.Property(e => e.CName2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cName2");
            });

            modelBuilder.Entity<CustomersPhone>(entity =>
            {
                entity.HasKey(e => e.CpId);

                entity.Property(e => e.CpId).HasColumnName("cpId");

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.CpPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cpPhone");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.CustomersPhones)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomersPhones_Customers");
            });

        }

    }
}
