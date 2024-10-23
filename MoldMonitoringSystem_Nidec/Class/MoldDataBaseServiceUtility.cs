
using MoldMonitoringSystem_Nidec.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Class
{
    public class MoldDataBaseServiceUtility
    {
        private readonly string _connectionString;

        public MoldDataBaseServiceUtility()
        {
            _connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
        }
        public class MoldData
        {
            public string MoldNumber { get; set; }
            public string Material { get; set; }
            public string Material_name { get; set; }
            public string DieNumber { get; set; }
            public string Customer { get; set; }
            public DateTime LastUsedDate { get; set; }
            public string Location { get; set; }
            public string DateCreated { get; set; }
            public string TimeCreated { get; set; }
            public string UserName { get; set; }
            public string Status { get; set; }
        }   
        public class MachineData
        {
            public string Equipment { get; set; }
            public string Equipment_name { get; set; }
        }
        public List<MoldData> GetIdleMold()
        {
            List<MoldData> IdleMold = new List<MoldData>();

            string query = "WITH LatestTransaction AS (SELECT moldnumber, MAX(CONCAT(date, ' ', time)) AS LatestTimestamp FROM History " +
                                   "GROUP BY moldnumber) " +
                                   "SELECT h.moldnumber, h.date, h.status, h.location " +
                                   "FROM history h JOIN LatestTransaction lt ON h.moldnumber = lt.moldnumber AND CONCAT(h.date, ' ', h.time) = lt.LatestTimestamp " +
                                   "WHERE DATEDIFF(DAY, lt.LatestTimestamp, GETDATE()) > 90 " +
                                   "ORDER BY h.date ASC, h.time ASC";
            

            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MoldData moldData = new MoldData
                        {
                            MoldNumber = reader["moldnumber"].ToString(),
                            DateCreated = GetTenure(reader["date"].ToString(), out DateTime lastUsedDate),
                            LastUsedDate = lastUsedDate,
                            Status = reader["status"].ToString(),
                            Location = reader["location"].ToString()
                        };
                        
                        IdleMold.Add(moldData);
                    }
                }
            }
            return (IdleMold);
        }
        private string GetTenure(string dateCreated, out DateTime lastUsedDate)
        {
            if (DateTime.TryParse(dateCreated, out lastUsedDate))
            {
                DateTime currentDate = DateTime.Now;
           
                TimeSpan timeDifference = currentDate - lastUsedDate;

                int months = (currentDate.Year - lastUsedDate.Year) * 12 + currentDate.Month - lastUsedDate.Month;
                int days = timeDifference.Days - (months * 30);             
                return $"{months} months {days} days";
            }
            else
            {
                lastUsedDate = DateTime.MinValue; 
                return "Invalid Date";
            }
        }

        public List<MoldData> GetMoldMasterList()
        {
            List<MoldData> moldMasterList = new List<MoldData>();

            string query = "SELECT Mold_no, Material, Material_Name, Customer," +
                           "Die_no, Date_created, Time_created, Username, Status FROM MoldMaster";  // Replace with your actual table name

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MoldData moldMaster = new MoldData
                        {
                            MoldNumber = reader["Mold_no"].ToString(),
                            Material = reader["Material"].ToString(),
                            Material_name = reader["Material_Name"].ToString(),
                            Customer = reader["Customer"].ToString(),
                            DieNumber = reader["Die_no"].ToString(),
                            DateCreated = reader["Date_created"].ToString(),
                            TimeCreated = reader["Time_created"].ToString(),
                            UserName = reader["Username"].ToString(),
                            Status = reader["Status"].ToString()                          
                        };

                        moldMasterList.Add(moldMaster);
                    }
                }
            }

            return moldMasterList;
        }
        public bool DeleteMoldData(string MoldNumber)
        {
            string query = "DELETE FROM MoldMaster WHERE Mold_no = @MoldNumber";
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MoldNumber", MoldNumber);

                int RowsAffected = command.ExecuteNonQuery();
                return RowsAffected > 0;    
            }
        }
        public List<string> GetAllPartNumbers()
        {
            List<string> partNumbers = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Material FROM MoldMaster"; // Adjust table/column as needed
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            partNumbers.Add(reader["Material"].ToString());
                        }
                    }
                }
            }
            return partNumbers;
        }

        public List<string> GetAllMachine()
        {
            List<string> Machine = new List<string>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT DISTINCT Equipment FROM EquipmentMasterlist"; // Adjust table/column as needed
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Machine.Add(reader["Equipment"].ToString());
                        }
                    }
                }
            }
            return Machine;
        }

        public List<string> GetPartNumbersForMold(string moldNumber)
        {
            List<string> partNumbers = new List<string>();

            string query = "SELECT TOP 5 Material, Mold_no, Die_no, Material_Name, Customer FROM MoldMaster WHERE Mold_no = @MoldNumber";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MoldNumber", moldNumber);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string partnumber = $"Part number: {reader["Material"].ToString()} \nPart name: {reader["Material_Name"].ToString()}";
                                partNumbers.Add(partnumber);
                               
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle exceptions as needed
                    MessageBox.Show($"An error occurred while fetching part numbers: {ex.Message}");
                }
            }

            return partNumbers;
        }

        public MoldData ProvideData(string partnumber, string die_no)
        {
            string query = "SELECT Customer, Mold_no FROM MoldMaster WHERE Material = @partNumber and Die_no = @die_no";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@partNumber", partnumber);
                        command.Parameters.AddWithValue("@die_no", die_no);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            
                            if (reader.Read())
                            {
                                return new MoldData
                                {
                                    MoldNumber = reader["Mold_no"].ToString(),
                                    //DieNumber = reader["Die_no"].ToString(),
                                    Customer = reader["Customer"].ToString()
                                };
                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception as needed and handle it gracefully
                Console.WriteLine("Error retrieving mold data: " + ex.Message);
            }
            return null;
        }
        public MachineData ProvideDataMachine(string machinenumber)
        {
            string query = "SELECT Equipment_name FROM EquipmentMasterlist WHERE Equipment = @machinenumber";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@machinenumber", machinenumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new MachineData
                                {
                                    Equipment_name = reader["Equipment_name"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception as needed and handle it gracefully
                Console.WriteLine("Error retrieving equipment data: " + ex.Message);
            }
            return null;
        }
      
       public DataTable GetMoldReceivingLogs(DateTime currentDate, string section)
        {
            DataTable table = new DataTable();
            string loadData = "SELECT date, moldnumber, dienumber, status, location, remarks, in_charge, time " +
                        "FROM History WHERE CAST(date AS DATE) = @currentDate AND section = @section ORDER BY date ASC, time ASC";

            try
            {
                using(SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    using(SqlDataAdapter adapter = new SqlDataAdapter(loadData,connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@currentdate",currentDate);
                        adapter.SelectCommand.Parameters.AddWithValue("@section",section);
                        adapter.Fill(table);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data from database: " + ex.Message);
            }
            return table;
        }
    }
}
