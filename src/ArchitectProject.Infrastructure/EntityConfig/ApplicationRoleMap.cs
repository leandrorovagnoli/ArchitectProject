using ArchitectProject.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.Infrastructure.EntityConfig
{
    public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.Property(x => x.Description)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
