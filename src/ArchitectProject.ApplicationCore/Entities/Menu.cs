using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArchitectProject.ApplicationCore.Entities
{
    public class Menu
    {
        public Menu()
        {

        }
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Menu")]
        [StringLength(maximumLength: 60, ErrorMessage = "O campo {0} precisa ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; }
        public int? MenuId { get; set; }
        public ICollection<Menu> SubMenu  { get; set; }
        public ICollection<GalleryItem> GalleryItems { get; set; }
    }
}
