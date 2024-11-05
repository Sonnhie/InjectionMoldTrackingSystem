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

        private static readonly string _connectionString = "Data Source=(localdb)\\Local;Initial Catalog=MoldTrackingSystem;Integrated Security=True";

        public static SqlConnection GetSqlConnection()
        {
            var _conn = new SqlConnection(_connectionString);
            return _conn;
        }

        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = GetSqlConnection();
            connection.Open();
            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
