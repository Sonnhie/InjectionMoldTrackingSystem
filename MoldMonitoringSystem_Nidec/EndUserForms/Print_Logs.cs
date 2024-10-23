using MoldMonitoringSystem_Nidec.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    public partial class Print_Logs : Form
    {
        private PrintUtility _printLogUtility;
        private readonly string _connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
        public Print_Logs()
        {
            InitializeComponent();
            
        }
       
        private void GetLogs()
        {
            DateTime StartDate = dateTimePicker1.Value.Date;
            DateTime EndDate = dateTimePicker2.Value.Date;
           


            if (PrintLogs_ListView.Columns.Count == 0)
            {
                PrintLogs_ListView.View = View.Details;
                PrintLogs_ListView.Columns.Add("Date", 100);
                PrintLogs_ListView.Columns.Add("Time", 100);
                PrintLogs_ListView.Columns.Add("Print Details", 400);
                PrintLogs_ListView.Columns.Add("User", 100);
            }
          

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    string query = "SELECT Date, Time, [Content], [User] FROM PrintLogs WHERE Date BETWEEN @StartDate AND @EndDate";

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            PrintLogs_ListView.Items.Clear();

                            while (reader.Read())
                            {
                                // Convert "Date" to DateTime
                                DateTime DateValue = Convert.ToDateTime(reader["Date"]);

                             
                                DateTime TimeValue;
                                if (DateTime.TryParse(reader["Time"].ToString(), out TimeValue))
                                {
                                    // Format the date and time
                                    string formattedDate = DateValue.ToString("yyyy-MM-dd");
                                    string formattedTime = TimeValue.ToString("HH:mm:ss");

                                    // Create ListViewItem and add subitems
                                    ListViewItem item = new ListViewItem(formattedDate);
                                    item.SubItems.Add(formattedTime);
                                    item.SubItems.Add(reader["Content"].ToString());
                                    item.SubItems.Add(reader["User"].ToString());

                                    // Add the item to the ListView
                                    PrintLogs_ListView.Items.Add(item);
                                }
                                else
                                {
                                    // Handle the case where the time cannot be parsed (optional)
                                    Console.WriteLine("Invalid time format: " + reader["Time"]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                }
            }
        }

        private void Print_Logs_Load(object sender, EventArgs e)
        {
            GetLogs();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetLogs();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            GetLogs();
        }
    }
}
