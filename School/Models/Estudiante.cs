using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Estudiante
    {
        public string Identificacion { get; set; }
        public int IdEstudiante { get; set; }

        [DisplayName("Nombre estudiante")]
        public string Nombre { get; set; }
    }
}