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
    public partial class RegisterNewPincode : Form
    {
        private readonly string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
        public RegisterNewPincode()
        {
            InitializeComponent();
            warning_label.Visible = false;
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
        private bool duplicateuser(string username)
        {
            try
            {
                string duplicateuser = "select count(*) from PinCode where username = @username";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(duplicateuser, conn))
                    {
                      
                        cmd.Parameters.AddWithValue("@username", username);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return false;
        }
        private void RegisterPinCode()
        {
            try
            {
                if (duplicateuser(username_combo.Text))
                {
                    MessageBox.Show("The username already exists in the database.", "Duplicate userid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string RegisterPinCode = "insert into PinCode (username, section, pincode, date_updated) values (@username, @section, @pincode, @date_updated)";
                    string currentdate = DateTime.Now.ToString("dd/MM/yyyy");

                    if (string.IsNullOrWhiteSpace(section_combo.Text) ||
                        string.IsNullOrWhiteSpace(pincode_txt.Text) ||
                        string.IsNullOrWhiteSpace(confirmpin_txt.Text))
                    {
                        MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand(RegisterPinCode, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username_combo.Text);
                        cmd.Parameters.AddWithValue("@section", section_combo.Text);
                        cmd.Parameters.AddWithValue("@pincode", pincode_txt.Text);
                        cmd.Parameters.AddWithValue("@date_updated", currentdate);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Data inserted successfully!");
                            username_combo.SelectedIndex = -1;
                            section_combo.SelectedIndex = -1;
                            pincode_txt.Text = string.Empty;
                            confirmpin_txt.Text = string.Empty;
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
                MessageBox.Show("Error: "+ ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           RegisterPinCode();
        }

        private void RegisterNewPincode_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'moldTrackingSystemDataSet5.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.moldTrackingSystemDataSet5.Users);
            LoadTheme();
        }

        private void confirmpin_txt_TextChanged(object sender, EventArgs e)
        {
            if (pincode_txt.Text != confirmpin_txt.Text)
            {
                warning_label.Visible = true;
            }
            else
            {
                warning_label.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pincode_txt.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
