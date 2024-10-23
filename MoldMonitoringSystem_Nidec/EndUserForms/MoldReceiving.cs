using Zuby.ADGV;
using MoldMonitoringSystem_Nidec.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class MoldReceiving : Form
    {
        private readonly string _employeename;
        private readonly string _section;
        private readonly MoldDataBaseServiceUtility _dataBaseServiceUtility = new MoldDataBaseServiceUtility();
       

        public MoldReceiving(string employeename, string section)
        {
            InitializeComponent();
            _employeename = employeename;
            LoadData();
            _section = section; 
        }

        private void MoldReceiving_Load(object sender, EventArgs e)
        {
            SetupPartNumberAutoSuggest();
            LoadThemeUtility.LoadTheme(this);
            txt_moldnumber.Focus();
        }

        private string ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            string result = string.Empty;
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                        result = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
        private string GetDataFromDB(string query, string username)
        {
            string result = string.Empty;
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader[0].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving data.", ex);
            }
            return result;
        }
        private void LoadData()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the user's section from the Users table based on their username
                    string section = GetDataFromDB("SELECT section FROM Users WHERE username = @username", _employeename);

                    DateTime currentDate = DateTime.Now.Date;

                    // Modify the query to filter transactions by the section
                    string loadData = "SELECT date, partnumber, moldnumber, dienumber, status, location, remarks, in_charge, time " +
                        "FROM History " +
                        "WHERE CAST(date AS DATE) = @currentDate " +
                        "AND section = @section " +  // Add this condition to filter by section
                        "ORDER BY date ASC, time ASC";

                    DataTable dt = new DataTable();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(loadData, connection))
                    {
                        // Add parameters for the query
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@currentDate", currentDate);
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@section", section);  // Pass the section as a parameter
                        dataAdapter.Fill(dt);
                    }

                    // Bind the result to the DataGridView
                    advancedDataGridView1.DataSource = dt;
                    advancedDataGridView1.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool MoldNumberExists(string moldNumber)
        {
            string query = "SELECT COUNT(*) FROM MoldMaster WHERE mold_no = @moldnumber";
            return int.Parse(ExecuteScalar(query, new Dictionary<string, object> { { "@moldnumber", moldNumber } })) > 0;
        }

        private void InsertData()
        {
            if (!MoldNumberExists(txt_moldnumber.Text))
            {
                MessageBox.Show("Mold number does not exist in the database.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmb_dienumber.Text) || string.IsNullOrWhiteSpace(cmb_status.Text) || string.IsNullOrWhiteSpace(txt_remarks.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "INSERT INTO History (partnumber, moldnumber, dienumber, customer, status, remarks, date, in_charge, time, location, section) " +
                           "VALUES (@partnumber, @moldnumber, @dienumber, @customer, @status, @remarks, @date, @in_charge, @time, @location, @section)";

            var parameters = new Dictionary<string, object>
            {
                { "@partnumber", txt_partnumber.Text },
                { "@moldnumber", txt_moldnumber.Text },
                { "@dienumber", cmb_dienumber.Text },
                { "@customer", txt_customer.Text },
                { "@status", cmb_status.Text },
                { "@remarks", txt_remarks.Text },
                { "@date", DateTime.Now.Date },
                { "@time", DateTime.Now.ToString("HH:mm:ss") },
                { "@in_charge", ExecuteScalar("SELECT employeename FROM Users WHERE username = @username", new Dictionary<string, object> { { "@username", _employeename } }) },
                { "@location", txt_location.Text },
                { "@section", ExecuteScalar("SELECT section FROM Users WHERE username = @username", new Dictionary<string, object> { { "@username", _employeename } }) }
            };

            try
            {
                ExecuteNonQuery(query, parameters);
                MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error executing database command.", ex);
            }
        }

        private void ClearInputs()
        {
            txt_partnumber.Clear();
            txt_moldnumber.Clear();
            txt_customer.Clear();
            txt_remarks.Clear();
            txt_location.SelectedIndex = -1;
            cmb_dienumber.Clear();
            cmb_status.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            txt_moldnumber.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txt_moldnumber.Focus();
        }

        private void RetrieveDataFromDB(string moldNumber)
        {
            string query = "SELECT Die_no, Customer, Material FROM MoldMaster WHERE Mold_no = @mold_no";

            using (SqlConnection connection = new SqlConnection("Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False"))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@mold_no", moldNumber);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> partNumbers = new List<string>();
                            while (reader.Read())
                            {
                                partNumbers.Add(reader["Material"].ToString());
                                cmb_dienumber.Text = reader["Die_no"].ToString();
                                txt_customer.Text = reader["Customer"].ToString();
                            }

                            if (partNumbers.Count > 1)
                            {
                                MessageBox.Show("Duplicate mold number found with different part numbers.");
                                txt_partnumber.Clear();
                                txt_remarks.Focus();
                            }
                            else if (partNumbers.Count == 1)
                            {
                                txt_partnumber.Text = partNumbers[0];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Retrieve Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExtractPartNumber(string scannedData)
        {
            // Assuming the format is partnumber/moldnumber/dienumber/customer
            string[] extract = scannedData.Split('/');

            // Ensure that the scanned data contains the expected number of parts
            if (extract.Length >= 2)
            {
                txt_partnumber.Text = extract[0];  // Part number
                txt_moldnumber.Text = extract[1];      // Mold number

                if (extract.Length >= 3)
                    cmb_dienumber.Text = extract[2];     // Die number (optional)

                if (extract.Length >= 4)
                    txt_customer.Text = extract[3]; // Customer (optional)

                // Autofill the remaining data
                RetrieveDataFromDB(txt_moldnumber.Text);
            }
            else
            {
                MessageBox.Show("Scanned data format is incorrect. Please scan again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
                txt_moldnumber.Focus();
            }
        }
        private void SetupPartNumberAutoSuggest()
        {
            // Get part numbers from the database
            var partNumbers = _dataBaseServiceUtility.GetAllPartNumbers(); // Assuming this method returns a list of part numbers

            if (partNumbers != null && partNumbers.Count > 0)
            {
                // Create an AutoCompleteStringCollection and add part numbers to it
                AutoCompleteStringCollection autoSuggestCollection = new AutoCompleteStringCollection();
                autoSuggestCollection.AddRange(partNumbers.ToArray());

                // Configure the ComboBox for auto-suggest
                txt_partnumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_partnumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_partnumber.AutoCompleteCustomSource = autoSuggestCollection;
            }
        }
        private void ClearFields()
        {
            txt_partnumber.Clear();
            txt_moldnumber.Clear();
            cmb_dienumber.Clear();
            txt_customer.Clear();
        }
        private void txt_moldnumber_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_moldnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                ExtractPartNumber(txt_moldnumber.Text);

                e.Handled = true;
                e.SuppressKeyPress = true;
                txt_remarks.Focus();
            }
        }
    }
}
