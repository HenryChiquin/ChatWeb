using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCcrud.Models.ViewModel
{
    public class ListPersonaViewModel
    {
        public int Id_Persona { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
    }
}