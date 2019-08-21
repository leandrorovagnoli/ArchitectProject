using ArchitectProject.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.Infrastructure.EntityConfig
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnType("varchar(15)");

            builder.Property(x => x.Email)
               .HasColumnType("varchar(100)")
               .IsRequired();
        }
    }
}
