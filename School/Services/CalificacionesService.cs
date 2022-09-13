using School.DataAccess;
using School.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace School.Services
{
    public class CalificacionesService : ICalificacionesService
    {
        private readonly IDataAccess<CalificacionesView> _calificacionesDataAccess;

        public CalificacionesService(IDataAccess<CalificacionesView> calificacionesDataAccess)
        {
            _calificacionesDataAccess = calificacionesDataAccess;
        }

        public void Delete(CalificacionesView calificacionesView)
        {
            _calificacionesDataAccess.Delete(calificacionesView);
        }

        public IEnumerable<CalificacionesView> GetAll()
        {
            var dtCalificaciones = _calificacionesDataAccess.GetAll();
            return BuildCalificacionesData(dtCalificaciones);
        }

        public CalificacionesView GetById(CalificacionesView filters)
        {
            var dtCalificaciones = _calificacionesDataAccess.GetById(filters);
            var calificacionesData = BuildCalificacionesData(dtCalificaciones);
            return calificacionesData.FirstOrDefault();
        }

        public void SaveData(CalificacionesView calificacionesView)
        {
            var calificacionView = GetById(calificacionesView);
            if (calificacionView == null)
            {
                _calificacionesDataAccess.InsertData(calificacionesView);
                return;
            }
            UpdateData(calificacionesView);
        }

        public void UpdateData(CalificacionesView calificacionesView)
        {
            _calificacionesDataAccess.UpdateData(calificacionesView);
        }

        private static List<CalificacionesView> BuildCalificacionesData(DataTable dtCalificaciones)
        {
            var list = new List<CalificacionesView>();
            foreach (DataRow dr in dtCalificaciones.Rows)
            {
                var estudianteInfo = new Estudiante()
                {
                    IdEstudiante = dr.Field<int>("IdEstudiante"),
                    Identificacion = dr.Field<string>("Identificacion"),
                    Nombre = dr.Field<string>("NombreEstudiante"),
                };
                var materiaInfo = new Materia()
                {
                    IdMateria = dr.Field<int>("IdMateria"),
                    Descripcion = dr.Field<string>("Materia")
                };
                var calificacionesView = new CalificacionesView()
                {
                    EstudianteInfo = estudianteInfo,
                    MateriaInfo = materiaInfo,
                    AcademicSemestre = dr.Field<int>("AcademicSemestre"),
                    AcademicYear = dr.Field<int>("AcademicYear"),
                    Nota = dr.Field<double>("Nota").ToString()
                };
                list.Add(calificacionesView);
            }
            return list;
        }
    }
}