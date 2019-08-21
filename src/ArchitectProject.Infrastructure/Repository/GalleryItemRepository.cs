using ArchitectProject.ApplicationCore.Entities;
using ArchitectProject.ApplicationCore.Interfaces.Repository;
using ArchitectProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ArchitectProject.Infrastructure.Repository
{
    public class GalleryItemRepository : EFRepository<GalleryItem>, IGalleryItemRepository
    {
        public GalleryItemRepository(APContext context) : base(context) 
        {

        }
    }
}
