using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.ApplicationCore.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public bool? IsGalleryThumb { get; set; }
        public int GalleryItemId { get; set; }
        public GalleryItem GalleryItem { get; set; }
    }
}
