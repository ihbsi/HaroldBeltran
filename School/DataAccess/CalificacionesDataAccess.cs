using School.Models;
using System;
using System.Data;

namespace School.DataAccess
{
    public class CalificacionesDataAccess : IDataAccess<CalificacionesView>
    {
        private readonly SchoolDbTasks _schoolDbTasks = new();

        public void Delete(CalificacionesView calificacion)
        {
            var query = $"DELETE FROM Calificacion "
                        + $"WHERE IdMateria = {calificacion.MateriaInfo.IdMateria} "
                        + $"AND IdEstudiante = {calificacion.EstudianteInfo.IdEstudiante} "
                        + $"AND AcademicYear = {calificacion.AcademicYear} "
                        + $"AND AcademicSemestre = {calificacion.AcademicSemestre}";
            _schoolDbTasks.ExecuteQuery(query);
        }

        public DataTable GetAll()
        {
            try
            {
                var query = "SELECT E.IdEstudiante, E.Identificacion, E.Nombre AS NombreEstudiante, M.IdMateria, M.Descripcion AS Materia, "
                            + "C.AcademicYear, C.AcademicSemestre, C.Nota FROM Estudiante E INNER JOIN Calificacion C "
                            + "ON C.IdEstudiante = E.IdEstudiante INNER JOIN Materia M ON M.IdMateria = C.IdMateria "
                            + "ORDER BY E.IdEstudiante, C.AcademicYear DESC, C.AcademicSemestre DESC";
                var dsCalificaciones = _schoolDbTasks.Read(query);
                return dsCalificaciones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetById(CalificacionesView filters)
        {
            var query = "SELECT E.IdEstudiante, E.Identificacion, E.Nombre AS NombreEstudiante, M.IdMateria, M.Descripcion AS Materia, "
                        + "C.AcademicYear, C.AcademicSemestre, C.Nota FROM Estudiante E INNER JOIN Calificacion C "
                        + "ON C.IdEstudiante = E.IdEstudiante INNER JOIN Materia M ON M.IdMateria = C.IdMateria "
                        + $"WHERE C.IdMateria = {filters.MateriaInfo.IdMateria} AND C.IdEstudiante = {filters.EstudianteInfo.IdEstudiante} "
                        + $"AND C.AcademicYear = {filters.AcademicYear} AND C.AcademicSemestre = {filters.AcademicSemestre}";
            var dsCalificaciones = _schoolDbTasks.Read(query);
            return dsCalificaciones;
        }

        public void InsertData(CalificacionesView calificacion)
        {
            try
            {
                var query = "INSERT INTO Calificacion VALUES("
                            + $"{calificacion.MateriaInfo.IdMateria}, {calificacion.EstudianteInfo.IdEstudiante}, "
                            + $"{calificacion.AcademicYear}, {calificacion.AcademicSemestre}, {calificacion.Nota})";
                _schoolDbTasks.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateData(CalificacionesView calificacion)
        {
            var query = $"UPDATE Calificacion SET Nota = {calificacion.Nota} "
                        + $"WHERE IdMateria = {calificacion.MateriaInfo.IdMateria} "
                        + $"AND IdEstudiante = {calificacion.EstudianteInfo.IdEstudiante} "
                        + $"AND AcademicYear = {calificacion.AcademicYear} "
                        + $"AND AcademicSemestre = {calificacion.AcademicSemestre}";
            _schoolDbTasks.ExecuteQuery(query);
        }
    }
}