using School.Models;
using System.Collections.Generic;

namespace School.Services
{
    public interface ICalificacionesService
    {
        void Delete(CalificacionesView obj);

        IEnumerable<CalificacionesView> GetAll();

        CalificacionesView GetById(CalificacionesView filters);

        void SaveData(CalificacionesView obj);

        void UpdateData(CalificacionesView obj);
    }
}