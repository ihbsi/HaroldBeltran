using School.Models;
using System;
using System.Data;

namespace School.DataAccess
{
    public class EstudianteDataAccess : IDataAccess<Estudiante>
    {
        private readonly SchoolDbTasks _schoolDbTasks = new();

        public void Delete(Estudiante obj)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            try
            {
                var query = "SELECT IdEstudiante, Identificacion, Nombre AS NombreEstudiante " +
                            "FROM Estudiante ORDER BY NombreEstudiante";
                var dsCalificaciones = _schoolDbTasks.Read(query);
                return dsCalificaciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetById(Estudiante filters)
        {
            throw new NotImplementedException();
        }

        public void InsertData(Estudiante obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Estudiante obj)
        {
            throw new NotImplementedException();
        }
    }
}