using ArchitectProject.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectProject.UI.Web.Areas.Admin.Models
{
    public class AdminViewModel
    {
        public ICollection<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Menu> MenuList { get; set; }
        public ICollection<Menu> MenuDropDownList { get; set; }
        public Menu Menu { get; set; }
        public bool IsEditMode { get; set; }
        public GalleryItem GalleryItem { get; set; }
        public ICollection<GalleryItem> GalleryList { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
