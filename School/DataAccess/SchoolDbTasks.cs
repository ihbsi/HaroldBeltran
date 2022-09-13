using Microsoft.Extensions.Configuration;
using School.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace School.DataAccess
{
    public class SchoolDbTasks
    {
        private readonly SqlConnection _sqlConnectionDb;

        public SchoolDbTasks()
        {
            var connectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetSection("ConnectionStrings")["SchoolConnection"];

            _sqlConnectionDb = new SqlConnection(connectionString);
        }

        public void ExecuteQuery(string query)
        {
            _sqlConnectionDb.Open();
            var cmd = new SqlCommand(query, _sqlConnectionDb);
            try
            {
                var ds = new DataSet();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error en DB: {ex.Message}");
            }
            finally
            {
                _sqlConnectionDb.Close();
            }
        }

        public DataTable Read(string query)
        {
            _sqlConnectionDb.Open();
            var cmd = new SqlCommand(query, _sqlConnectionDb);
            try
            {
                var ds = new DataSet();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocurrió un error en DB: {ex.Message}");
            }
            finally
            {
                _sqlConnectionDb.Close();
            }
        }
    }
}