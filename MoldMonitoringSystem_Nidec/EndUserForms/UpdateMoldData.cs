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
    public partial class UpdateMoldData : Form
    {
        private readonly string _employeename;

        public UpdateMoldData(string employeename)
        {
            InitializeComponent();
            _employeename = employeename;
            part_code.CharacterCasing = CharacterCasing.Upper;
            part_name.CharacterCasing = CharacterCasing.Upper;
            mold_number.CharacterCasing = CharacterCasing.Upper;
        }
        private void UpdateMoldData_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn)  // Check if the control is a Button
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;  // Set FlatAppearance for buttons only
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            insertData();


            
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

        private void insertData()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
            string updateMoldData = "UPDATE MoldMaster SET Mold_no = @MoldNumber, Material_Name = @partname, Die_no = @Die, " +
                                    "Customer = @customer, Date_created = @created, Time_created =@timecreated, " +
                                    "Username = @userid , Status = @Status WHERE Material = @partnumber";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    DateTime date = DateTime.Now;
                    DateTime time = DateTime.Now;
                    string CurrentTime = time.ToString("HH:mm:ss");
                    string CurrentDate = date.Date.ToString("MM/dd/yyyy");
                    string employee = GetDataFromDB("SELECT employeename FROM Users WHERE username = @username", _employeename);


                    using (SqlCommand cmd = new SqlCommand(updateMoldData, conn))
                    {
                        cmd.Parameters.AddWithValue("@partnumber", part_code.Text);
                        cmd.Parameters.AddWithValue("@MoldNumber", mold_number.Text);
                        cmd.Parameters.AddWithValue("@partname", part_name.Text);
                        cmd.Parameters.AddWithValue("@Die", die_number.SelectedItem);
                        cmd.Parameters.AddWithValue("@Customer", customer.SelectedItem);
                        cmd.Parameters.AddWithValue("@Status", status.SelectedItem);
                        cmd.Parameters.AddWithValue("@created", CurrentDate);
                        cmd.Parameters.AddWithValue("@timecreated", CurrentTime);
                        cmd.Parameters.AddWithValue("@userid", employee);

                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully!");


                            part_code.Text = string.Empty;
                            mold_number.Text = string.Empty;
                            part_name.Text = string.Empty;
                            die_number.SelectedIndex = -1;
                            customer.SelectedIndex = -1;
                            status.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified partnumber.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void ProvideData(string partnumber)
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
            string query = "SELECT Die_no, Customer, Mold_no, Material_Name, Status FROM MoldMaster WHERE Material = @partNumber";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@partNumber", partnumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                mold_number.Text = reader["Mold_no"].ToString();
                                die_number.Text = reader["Die_no"].ToString();
                                customer.Text = reader["Customer"].ToString();
                                part_name.Text = reader["Material_Name"].ToString();
                                status.Text = reader["status"].ToString();
                            }
                            else
                            {
                                mold_number.Text = string.Empty;
                                die_number.Text  = string.Empty;
                                customer.Text = string.Empty;
                                part_name.Text = string.Empty;
                                status.Text = string.Empty;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void part_code_TextChanged(object sender, EventArgs e)
        {
            string partNumber = part_code.Text.ToUpper();

            if (!string.IsNullOrWhiteSpace(partNumber))
            {
                ProvideData(partNumber);
            }
            else
            {
                mold_number.Text = string.Empty ;
                die_number.Text = string.Empty ;
                customer.Text = string.Empty ;
                part_name.Text = string.Empty ;
                status.Text = string.Empty ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
