using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MoldMonitoringSystem_Nidec.Class
{
   

    public static class DatabaseConnection
    {
        private static SqlConnection _connection;

        // Define the connection string (you can also load this from a configuration file)
        private static string _connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

        // Get the SqlConnection instance
        public static SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
            }

            return _connection;
        }

        // Open the database connection
        public static void OpenConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
            }

            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                //_connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
        }

        // Close the database connection
        public static void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        // Dispose the connection when the application closes (optional)
        public static void DisposeConnection()
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

    }
}
