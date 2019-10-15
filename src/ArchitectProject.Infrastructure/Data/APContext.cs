using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.Infrastructure.EntityConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.Infrastructure.Data
{
    public class APContext : IdentityDbContext<ApplicationUser, ApplicationRole, string> 
    {
        public APContext(DbContextOptions<APContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new GalleryItemMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            modelBuilder.ApplyConfiguration(new ApplicationRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationUserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
