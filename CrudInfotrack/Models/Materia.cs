using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudInfotrack.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El nombre de la materia es obligatorio")]
        [StringLength(50,ErrorMessage ="El {0} debe ser al menos {2} y máximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Nombre Materia")]
        public string Descripcion { get; set; }
    }
}
