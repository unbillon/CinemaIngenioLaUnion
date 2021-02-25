using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test2.Models
{
    public class AlumnoCE
    {
        public int ID { get; set; }

        [Required]
        [Display (Name="Ingrese Nombres")]
        public string Nombres { get; set; }

        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Edad del alumno")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Sexo del alumno")]
        public string Sexo { get; set; }

        public System.DateTime FechaRegistro { get; set; }  

        [Required]
        [Display(Name = "Ingrese Ciudad")]
        public int CodCiudad { get; set; }

        public string nombreCiudad { get; set; }

        public String NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
    [MetadataType(typeof(AlumnoCE))]
    public partial class Alumno
    {
        public String NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
}