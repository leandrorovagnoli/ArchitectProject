using ArchitectProject.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.Infrastructure.EntityConfig
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasMany(x => x.SubMenu)
                .WithOne()
                .HasForeignKey(x => x.MenuId);
                
        }
    }
}
