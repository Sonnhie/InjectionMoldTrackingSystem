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

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class InjectionReceiving : Form
    {
        private string _employeename;
        private Timer debounceTimer;
        private int debounceInterval = 500; // Delay interval in milliseconds
        private readonly MoldDataBaseServiceUtility _dataBaseServiceUtility = new MoldDataBaseServiceUtility();

        public InjectionReceiving(string employeename)
        {
            InitializeComponent();
            _employeename = employeename;
            LoadData();
            txt_moldno.Focus();
            txt_partnumber.ReadOnly = true;
            txt_customer.ReadOnly = true; 

        }
        private void InjectionReceiving_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moldTrackingSystemDataSet2.EquipmentMasterlist' table. You can move, or remove it, as needed.
            this.equipmentMasterlistTableAdapter.Fill(this.moldTrackingSystemDataSet2.EquipmentMasterlist);
            SetupPartNumberAutoSuggest();
            LoadThemeUtility.LoadTheme(this);
            txt_moldno.Focus();
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
                                    "AND section = @section " +
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
       
        private bool MoldNumberExist(string moldNumber, string partnumber)
        {
            string query = "select count(*) from MoldMaster where Mold_no = @moldnumber and Material = @partnumber";
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@moldnumber", moldNumber);
                    command.Parameters.AddWithValue("@partnumber", partnumber);
                    //command.Parameters.AddWithValue("@partnumber", partnumber);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void InsertData()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    DateTime date = DateTime.Now.Date;
                    DateTime time = DateTime.Now;
                    string employee = GetDataFromDB("SELECT employeename FROM Users WHERE username = @username", _employeename);
                    string section = GetDataFromDB("SELECT section FROM Users WHERE username = @username", _employeename);
                    string CurrentTime = time.ToString("HH:mm:ss");

                    string InsertData = "Insert into History (partnumber, moldnumber, dienumber, customer," +
                        "status, remarks, shot_count, date, in_charge, time, location, section) values (@partnumber, @moldnumber, @dienumber, @customer," +
                        "@status, @remarks, @shot_count, @date, @in_charge, @datetime, @location, @section)";
                    
                    if (!MoldNumberExist(txt_moldno.Text, txt_partnumber.Text))
                    {
                        MessageBox.Show("Mold number or Part number does not match in the database.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(cmb_die.Text)||
                        string.IsNullOrWhiteSpace(cmb_status.Text)||
                        string.IsNullOrWhiteSpace(txt_remarks.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand(InsertData, connection))
                    {
                        
                        cmd.Parameters.AddWithValue("@partnumber", txt_partnumber.Text);
                        cmd.Parameters.AddWithValue("@moldnumber", txt_moldno.Text);
                        cmd.Parameters.AddWithValue("@dienumber", cmb_die.Text);
                        cmd.Parameters.AddWithValue("@customer", txt_customer.Text);
                        cmd.Parameters.AddWithValue("@status", cmb_status.Text);
                        cmd.Parameters.AddWithValue("@remarks", txt_remarks.Text);
                        cmd.Parameters.AddWithValue("@shot_count", txt_shotcount.Text);
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@datetime", CurrentTime);
                        cmd.Parameters.AddWithValue("@in_charge", employee);
                        cmd.Parameters.AddWithValue("@location", txt_location.Text);
                        cmd.Parameters.AddWithValue("@section", section);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {                            
                            MessageBox.Show("Data inserted successfully!");

                            //clear inputs
                            txt_partnumber.Text = string.Empty;
                            txt_moldno.Text = string.Empty;
                            txt_customer.Text = string.Empty;
                            txt_remarks.Text = string.Empty;
                            txt_shotcount.Text = string.Empty;
                            txt_location.Text = string.Empty;
                            
                            cmb_die.Text = string.Empty; // Sets no selection
                            cmb_status.SelectedIndex = -1; // Sets no selection
                            txt_moldno.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //clear inputs
            txt_partnumber.Text = string.Empty;
            txt_moldno.Text = string.Empty;
            txt_customer.Text = string.Empty;
            txt_remarks.Text = string.Empty;
            txt_shotcount.Text = string.Empty;
            txt_location.Text = string.Empty;

            cmb_die.Text = string.Empty; // Sets no selection
            cmb_status.SelectedIndex = -1; // Sets no selection

            txt_moldno.Focus();
        }
        private void RetrieveDataFromDB(string moldNumber, string partNumber)
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
            string query = "SELECT Die_no, Customer, Material FROM MoldMaster WHERE Mold_no = @mold_no";

            using (SqlConnection connection = new SqlConnection(connectionString))
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
                            bool recordFound = false;

                            while (reader.Read())
                            {
                                recordFound = true;
                                partNumbers.Add(reader["Material"].ToString());
                                cmb_die.Text = reader["Die_no"].ToString();
                                txt_customer.Text = reader["Customer"].ToString();
                            }
                            if (recordFound)
                            {
                                if (partNumbers.Distinct().Count() > 1)
                                {
                                    MessageBox.Show("Duplicate mold number found with different part numbers.");
                                    txt_partnumber.ReadOnly = false;
                                    txt_partnumber.Text = "";
                                    txt_partnumber.SelectionStart = txt_partnumber.TextLength;
                                   
                                }
                                else if (partNumbers.Count == 1)
                                {
                                    txt_partnumber.Text = partNumbers[0];        
                                }
                                else
                                {   
                                    txt_partnumber.Text = "";
                                }
                            }
                            else
                            {
                                MessageBox.Show("No data found for the provided Mold Number.");
                                txt_moldno.Focus();
                                ClearFields();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            txt_partnumber.Clear();
            txt_moldno.Clear();
            cmb_die.Clear();
            txt_customer.Clear();
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

        private void txt_partnumber_TextChanged(object sender, EventArgs e)
        {
           txt_partnumber.Text = txt_partnumber.Text.ToUpper();
        }
        private void txt_location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                ExtractMachineNumber(txt_location.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void txt_moldno_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                ExtractPartnumber(txt_moldno.Text);

                e.Handled = true;
                e.SuppressKeyPress = true;
                txt_location.Focus();
            }
        }

        private void ExtractMachineNumber(string scannedData)
        {
            string[] extract = scannedData.Split('/');

            if (extract.Length >= 2)
            {
               txt_location.Text = extract[0];
            }
            else
            {
                MessageBox.Show("Scanned data format is incorrect. Please scan again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
                txt_moldno.Focus();
            }
        }
        private void ExtractPartnumber(string scannedData)
        {
            // Assuming the format is partnumber/moldnumber/dienumber/customer
            string[] extract = scannedData.Split('/');

            // Ensure that the scanned data contains the expected number of parts
            if (extract.Length >= 2)
            {
                txt_partnumber.Text = extract[0];  // Part number
                txt_moldno.Text = extract[1];      // Mold number

                if (extract.Length >= 3)
                    cmb_die.Text = extract[2];     // Die number (optional)

                if (extract.Length >= 4)
                    txt_customer.Text = extract[3]; // Customer (optional)

                // Autofill the remaining data
                RetrieveDataFromDB(txt_moldno.Text, txt_partnumber.Text);
            }
            else
            {
                MessageBox.Show("Scanned data format is incorrect. Please scan again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearFields();
                txt_moldno.Focus();
            }
        }
    }
}
