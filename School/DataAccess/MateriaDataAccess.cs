using School.Models;
using System;
using System.Data;

namespace School.DataAccess
{
    public class MateriaDataAccess : IDataAccess<Materia>
    {
        private readonly SchoolDbTasks _schoolDbTasks = new();

        public void Delete(Materia obj)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetAll()
        {
            try
            {
                var query = "SELECT IdMateria, Descripcion FROM Materia ORDER BY Descripcion";
                var dsCalificaciones = _schoolDbTasks.Read(query);
                return dsCalificaciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetById(Materia filters)
        {
            throw new NotImplementedException();
        }

        public void InsertData(Materia obj)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(Materia obj)
        {
            throw new NotImplementedException();
        }
    }
}