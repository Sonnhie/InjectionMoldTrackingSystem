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
    public partial class updatepincode : Form
    {
        private string _section;
        private string _pincode;
        private readonly string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

        public updatepincode(string section, string pincode)
        {
            InitializeComponent();
            _section = section;
            _pincode = pincode;
            warning_lbl.Visible = false;
            
        }
        private void Updatepincode()
        {
            try
            {
                string update = "update PinCode set pincode = @pincode, date_updated = @updateddate where section = @section";
                string currentdate = DateTime.Now.ToString("dd/MM/yyyy");
                string newpincode = txt_new_pincode.Text;
                string confirmedpincode = confirm_pincode.Text;

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (newpincode != confirmedpincode)
                    {
                        MessageBox.Show("Pincode did not match!");
                        return;
                    }

                    using (SqlCommand command = new SqlCommand(update, connection))
                    {
                       

                        command.Parameters.AddWithValue("@pincode",newpincode);
                        command.Parameters.AddWithValue("@updateddate", currentdate);
                        command.Parameters.AddWithValue("@section", _section);

                        int RowsAffected = command.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            MessageBox.Show("Pincode updated successfully.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified user id.");
                        }
                    }
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Updatepincode();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txt_new_pincode.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void warning_lbl_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void confirm_pincode_TextChanged(object sender, EventArgs e)
        {
            if (txt_new_pincode.Text != confirm_pincode.Text)
            {
                warning_lbl.Visible = true;
            }
            else
            {
                warning_lbl.Visible = false;
            }
        }
    }
}
