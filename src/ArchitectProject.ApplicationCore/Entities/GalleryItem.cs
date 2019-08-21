using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.ApplicationCore.Entities
{
    public class GalleryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public bool? IsActive { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
