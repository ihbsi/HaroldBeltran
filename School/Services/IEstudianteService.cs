using School.Models;
using System.Collections.Generic;

namespace School.Services
{
    public interface IEstudianteService
    {
        IEnumerable<Estudiante> GetAll();
    }
}