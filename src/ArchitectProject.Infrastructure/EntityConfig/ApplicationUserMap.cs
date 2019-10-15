using ArchitectProject.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.Infrastructure.EntityConfig
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.AvatarImage)
                .HasColumnType("varchar(250)");

            builder.Property(x => x.City)
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Country)
                .HasColumnType("varchar(150)");

            builder.Property(x => x.FirstName)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .HasColumnType("varchar(8)");

            builder.Property(x => x.State)
                .HasColumnType("varchar(70)");

            builder.Property(x => x.Street)
                .HasColumnType("varchar(250)");

            builder.Property(x => x.RegistrationDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
