using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace School.Models
{
    public class Materia
    {
        [DisplayName("Materia")]
        public string Descripcion { get; set; }

        public int IdMateria { get; set; }
    }
}