using System;
using System.Collections.Generic;
using System.Text;

namespace ArchitectProject.ApplicationCore.Entities
{
    public class Menu
    {
        public Menu()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MenuId { get; set; }
        public ICollection<Menu> SubMenu  { get; set; }
        public ICollection<GalleryItem> GalleryItems { get; set; }
    }
}
