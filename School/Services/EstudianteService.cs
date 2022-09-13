using School.DataAccess;
using School.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace School.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IDataAccess<Estudiante> _estudianteDataAccess;

        public EstudianteService(IDataAccess<Estudiante> estudianteDataAccess)
        {
            _estudianteDataAccess = estudianteDataAccess;
        }

        public IEnumerable<Estudiante> GetAll()
        {
            var dtEstudiantes = _estudianteDataAccess.GetAll();
            return BuildEstudianteData(dtEstudiantes);
        }

        private static IEnumerable<Estudiante> BuildEstudianteData(DataTable dtEstudiantes)
        {
            var list = new List<Estudiante>();
            foreach (DataRow dr in dtEstudiantes.Rows)
            {
                var estudianteInfo = new Estudiante()
                {
                    IdEstudiante = dr.Field<int>("IdEstudiante"),
                    Identificacion = dr.Field<string>("Identificacion"),
                    Nombre = dr.Field<string>("NombreEstudiante"),
                };
                list.Add(estudianteInfo);
            }
            return list;
        }
    }
}