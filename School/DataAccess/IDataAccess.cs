using System.Collections.Generic;
using System.Data;

namespace School.DataAccess
{
    public interface IDataAccess<T> where T : class
    {
        void Delete(T obj);

        DataTable GetAll();

        DataTable GetById(T filters);

        void InsertData(T obj);

        void UpdateData(T obj);
    }
}