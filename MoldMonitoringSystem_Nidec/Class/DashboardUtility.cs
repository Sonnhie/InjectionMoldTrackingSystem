using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MoldMonitoringSystem_Nidec.Class
{
    public class DashboardUtility
    {
        private string _connectionString;
        
        public DashboardUtility(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public int GetTotalMolds()
        {
            return ExecuteCountQuery("select count(Mold_no) from MoldMaster");
        }
        public int GetActiveMolds()
        {
            return ExecuteCountQuery("select count(Mold_no) from MoldMaster where Status = 'Active'");
        }
        public int GetEndofLifeMolds()
        {
            return ExecuteCountQuery("select count(Mold_no) from MoldMaster where Status = 'End of Life'");
        }
        public int GetTotalMoldpreperation()
        {
            return ExecuteCountQuery("SELECT COUNT(*) AS TotalMolds " +
                                      "FROM ( " +
                                      "SELECT h.moldnumber, MAX(CONCAT(h.date, ' ', h.time)) AS latestTimestamp " +
                                      "FROM History h " +
                                      "GROUP BY h.moldnumber " +
                                      ") AS LatestStatus " +
                                      "JOIN History h2 " +
                                      "ON h2.moldnumber = LatestStatus.moldnumber " +
                                      "AND CONCAT(h2.date, ' ', h2.time) = LatestStatus.latestTimestamp " +
                                      "WHERE h2.status IN ('Mold Preparation')");
        }
        public int GetTotalMoldSetup()
        {
            return ExecuteCountQuery("SELECT COUNT(*) AS TotalMolds " +
                                      "FROM ( " +
                                      "SELECT h.moldnumber, MAX(CONCAT(h.date, ' ', h.time)) AS latestTimestamp " +
                                      "FROM History h " +
                                      "GROUP BY h.moldnumber " +
                                      ") AS LatestStatus " +
                                      "JOIN History h2 " +
                                      "ON h2.moldnumber = LatestStatus.moldnumber " +
                                      "AND CONCAT(h2.date, ' ', h2.time) = LatestStatus.latestTimestamp " +
                                      "WHERE h2.status IN ('Mold Set-up(Start Set-up)', 'Mold Set-up(End Set-up)')");
        }
        public int GetTotalMoldRepair()
        {
            return ExecuteCountQuery("SELECT COUNT(*) AS TotalMolds " +
                                      "FROM ( " +
                                      "SELECT h.moldnumber, MAX(CONCAT(h.date, ' ', h.time)) AS latestTimestamp " +
                                      "FROM History h " +
                                      "GROUP BY h.moldnumber " +
                                      ") AS LatestStatus " +
                                      "JOIN History h2 " +
                                      "ON h2.moldnumber = LatestStatus.moldnumber " +
                                      "AND CONCAT(h2.date, ' ', h2.time) = LatestStatus.latestTimestamp " +
                                      "WHERE h2.status IN ('Mold Maintenance')");
        }
        public int GetTotalEndOfSchedule()
        {
            return ExecuteCountQuery( "SELECT COUNT(*) AS TotalMolds " +
                                      "FROM ( " +
                                      "SELECT h.moldnumber, MAX(CONCAT(h.date, ' ', h.time)) AS latestTimestamp " +
                                      "FROM History h " +
                                      "GROUP BY h.moldnumber " +
                                      ") AS LatestStatus " +
                                      "JOIN History h2 " +
                                      "ON h2.moldnumber = LatestStatus.moldnumber " +
                                      "AND CONCAT(h2.date, ' ', h2.time) = LatestStatus.latestTimestamp " +
                                      "WHERE h2.status IN ('End-of-schedule(Downmold)', 'End-of-schedule(Standby at machine)')"
                                    );


        }
        private int ExecuteCountQuery(string query, Dictionary<string,object> parameters = null)
        {
            int count = 0;

            try
            {
                using(SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            foreach(var param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        count = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing count query: " + ex.Message);
            }

            return count;
        }
    }
}
