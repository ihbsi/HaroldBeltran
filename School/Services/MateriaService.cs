using School.DataAccess;
using School.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace School.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IDataAccess<Materia> _materiaDataAccess;

        public MateriaService(IDataAccess<Materia> materiaDataAccess)
        {
            _materiaDataAccess = materiaDataAccess;
        }

        public IEnumerable<Materia> GetAll()
        {
            var dtMaterias = _materiaDataAccess.GetAll();
            return BuildMateriaData(dtMaterias);
        }

        private static IEnumerable<Materia> BuildMateriaData(DataTable dtCalificaciones)
        {
            var list = new List<Materia>();
            foreach (DataRow dr in dtCalificaciones.Rows)
            {
                var materiaInfo = new Materia()
                {
                    IdMateria = dr.Field<int>("IdMateria"),
                    Descripcion = dr.Field<string>("Descripcion")
                };
                list.Add(materiaInfo);
            }
            return list;
        }
    }
}