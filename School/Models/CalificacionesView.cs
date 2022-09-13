using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class CalificacionesView
    {
        [Required(ErrorMessage = "El semestre es requerido")]
        [RegularExpression("(^[1-9])", ErrorMessage = "Solo se permite un dígito")]
        [DisplayName("Semestre")]
        public int AcademicSemestre { get; set; }

        [Required(ErrorMessage = "El año es requerido")]
        [Range(1900, 2999, ErrorMessage = "Ingrese un año válido")]
        [DisplayName("Año")]
        public int AcademicYear { get; set; }

        public Estudiante EstudianteInfo { get; set; }

        public Materia MateriaInfo { get; set; }

        [Required(ErrorMessage = "La nota es requerida")]
        [RegularExpression("(^[0-9]+(.[0-9]+)*$)", ErrorMessage = "Solo se permiten números")]
        public string Nota { get; set; }
    }
}