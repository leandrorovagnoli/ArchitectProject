using ArchitectProject.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.Infrastructure.EntityConfig
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FileName)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(x => x.IsGalleryThumb)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(x => x.GalleryItem)
                .WithMany(x => x.Photos)
                .HasForeignKey(x => x.GalleryItemId);
        }
    }
}
