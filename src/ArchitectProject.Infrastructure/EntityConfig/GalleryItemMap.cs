using ArchitectProject.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.Infrastructure.EntityConfig
{
    public class GalleryItemMap : IEntityTypeConfiguration<GalleryItem>
    {
        public void Configure(EntityTypeBuilder<GalleryItem> builder)
        {
            builder.ToTable("GalleryItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasColumnType("varchar(3000)")
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasMany(x => x.Photos)
                .WithOne(x => x.GalleryItem)
                .HasForeignKey(x => x.GalleryItemId)
                .HasPrincipalKey(x=>x.Id)
                .IsRequired();

            builder.HasOne(x => x.Menu)
                .WithMany(x => x.GalleryItems)
                .HasForeignKey(x=>x.MenuId);

            builder.Property(x => x.PublishDate)
               .HasColumnType("datetime")
               .IsRequired();

            builder.Property(x => x.Title)
               .HasColumnType("varchar(200)")
               .IsRequired();
        }
    }
}
