using School.Models;
using System.Collections.Generic;

namespace School.Services
{
    public interface IMateriaService
    {
        IEnumerable<Materia> GetAll();
    }
}