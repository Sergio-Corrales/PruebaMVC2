using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PruebaMVC2.Models.ViewModels
{
    public class SubjectViewModel
    {
        [Required]
        [Display(Name ="Nombre")]
        [StringLength(40,ErrorMessage ="Maximo 40 caracteres")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Capacidad")]
        public int Capacity { get; set; }

        [Required]
        [Display(Name = "Horarios")]
        public string TimeTable { get; set; }

    }
}