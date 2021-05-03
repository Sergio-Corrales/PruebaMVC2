using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PruebaMVC2.Models.ViewModels
{
    public class ProfesorViewModel
    {
        [Required]
        [Display(Name = "Dni")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nombres")]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(40, ErrorMessage = "Maximo 40 caracteres")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public int Phone { get; set; }

    }
}