using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArchitectProject.ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        [StringLength(maximumLength: 120, ErrorMessage = "O campo {0} precisa ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Sobrenome")]
        [StringLength(maximumLength: 120, ErrorMessage = "O campo {0} precisa ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        public string Surname { get; set; }
        [Display(Name = "Telefone/Celular")]
        [Phone(ErrorMessage = "O campo {0} deve conter um número de telefone.")]
        [MinLength(15, ErrorMessage = "O campo {0} precisa ter no mínimo {1} caracteres.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "E-mail")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo {0} precisa ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 5)]
        [EmailAddress(ErrorMessage = "É necessário utilizar um email válido.")]
        public string Email { get; set; }
    }
}
