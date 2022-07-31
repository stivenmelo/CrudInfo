using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudInfotrack.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y Maximo {1} caracteres", MinimumLength = 3)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y Maximo {1} caracteres", MinimumLength = 3)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Este Numero de Documento es obligatorio")]
        [StringLength(11, ErrorMessage = "El {0} debe ser al menos {2} y Maximo {1} caracteres", MinimumLength = 9)]
        [Display(Name = "Numero de Documento")]
        public string Num_Documento { get; set; }


        [Required(ErrorMessage = "la fecha de Nacimiento es obligatoria")]  
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha_nacimiento { get; set; }
    }
}
