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
    public partial class MoldRegistration : Form
    {
        private readonly string _employeename;
        public MoldRegistration(string employee)
        {
            InitializeComponent();
            _employeename = employee;
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            LoadData();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void MoldRegistration_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
        private bool DuplicateRegistration(string molnumber, string partnumber)
        {
            try
            {
                string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
                string duplicatequery = "select count(*) from MoldMaster where Mold_no = @moldnumber and Material = @partnumber";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using(SqlCommand cmd = new SqlCommand(duplicatequery, connection))
                    {
                        cmd.Parameters.AddWithValue("@moldnumber",molnumber);
                        cmd.Parameters.AddWithValue("@partnumber", partnumber);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch(Exception ex) 
            {
                throw new ApplicationException(ex.Message, ex);
            }
        }

        // Method for inserting Data
        private void InsertData()
        {
           
            string moldnumber = textBox1.Text;
            string mnewnumber = textBox2.Text;

            if (DuplicateRegistration(moldnumber,mnewnumber))
            {
                MessageBox.Show("The mold number already exists in the database. Please enter a unique mold number.", "Duplicate Mold Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus(); // Set focus back to the mold number textbox
                return;
            }

            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    DateTime date = DateTime.Now;
                    DateTime time = DateTime.Now;
                    string CurrentTime = time.ToString("HH:mm:ss");
                    string CurrentDate = date.Date.ToString("MM/dd/yyyy");

                    string employee = GetDataFromDB("SELECT employeename FROM Users WHERE username = @username", _employeename);
                    
                    string insertData = "insert into MoldMaster (Mold_no, Material, Material_Name, Customer, Die_no, Date_created, Time_created, Username, Status) values " +
                        "(@mold_no, @material, @material_name, @customer, @die_no, @date_created, @time_created, @creator, @status)";

                    if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                        string.IsNullOrWhiteSpace(textBox2.Text) ||
                        string.IsNullOrWhiteSpace(textBox3.Text) ||
                        string.IsNullOrWhiteSpace(comboBox1.Text)||
                        string.IsNullOrWhiteSpace(comboBox2.Text)||
                        string.IsNullOrWhiteSpace(comboBox3.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand(insertData, connection))
                    {
                        cmd.Parameters.AddWithValue("@mold_no", textBox1.Text);
                        cmd.Parameters.AddWithValue("@material", textBox2.Text);
                        cmd.Parameters.AddWithValue("@material_name", textBox3.Text);
                        cmd.Parameters.AddWithValue("@customer", comboBox2.SelectedItem);
                        cmd.Parameters.AddWithValue("@die_no", comboBox1.SelectedItem);
                        cmd.Parameters.AddWithValue("@date_created", CurrentDate);
                        cmd.Parameters.AddWithValue("@time_created", CurrentTime);
                        cmd.Parameters.AddWithValue("@creator", employee);
                        cmd.Parameters.AddWithValue("@status", comboBox3.Text);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");

                            textBox1.Text = string.Empty;
                            textBox2.Text = string.Empty;
                            textBox3.Text = string.Empty;
                            comboBox1.SelectedIndex = -1;
                            comboBox2.SelectedIndex = -1;
                            comboBox3.SelectedIndex = -1;
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
                throw new ApplicationException(ex.Message, ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertData();
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateMoldData updateMoldData = new UpdateMoldData(_employeename);
            updateMoldData.Show();
        }

        private void LoadData()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
            string LoadData = "SELECT Mold_no, Material, Customer, Die_no, Date_created, Username, Status " +
                              "FROM MoldMaster " +
                              "WHERE CONVERT(date, Date_created) = CONVERT(date, GETDATE())";  // Filtering by today's date

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    DataTable dt = new DataTable();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(LoadData, connection))
                    {
                        adapter.Fill(dt);
                    }

                    advancedDataGridView1.DataSource = dt;
                    advancedDataGridView1.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error: " + connectionString, ex);
            }
        }
    }
}
