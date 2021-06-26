using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCcrud.Models.ViewModel
{
    public class PersonaViewModel
    {
        public int Id_Persona { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime Fecha_Nacimiento { get; set; }

    }
}