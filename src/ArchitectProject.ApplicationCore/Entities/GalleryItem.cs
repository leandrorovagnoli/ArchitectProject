using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArchitectProject.ApplicationCore.Entities
{
    public class GalleryItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Título")]
        [StringLength(maximumLength: 250, ErrorMessage = "O campo {0} precisa ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        public string Title { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data da publicação")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy - hh.mm tt}")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
