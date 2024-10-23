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
    public partial class QRCodePinManagement : Form
    {
        private readonly string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
        
        public QRCodePinManagement()
        {
            InitializeComponent();
            LoadData();
        }
        private void QRCodePinManagement_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
        private void LoadData()
        {
            try
            {
                string DeleteUserData = "select username,section, pincode, date_updated from PinCode";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(DeleteUserData, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        advancedDataGridView1.DataSource = dt;
                        advancedDataGridView1.ReadOnly = true;

                        
                        if (advancedDataGridView1.Columns["btnupdate"] == null)
                        {
                            // Add a delete button column
                            DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
                            updateButton.HeaderText = "Action";
                            updateButton.Name = "btnupdate";
                            updateButton.Text = "Change Pin";
                            updateButton.UseColumnTextForButtonValue = true; // Show "Delete" as button text
                            updateButton.ReadOnly = false;
                            advancedDataGridView1.Columns.Add(updateButton);
                        }
                        if (advancedDataGridView1.Columns["btnDelete"] == null)
                        {
                            // Add a delete button column
                            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                            deleteButton.HeaderText = "Action";
                            deleteButton.Name = "btnDelete";
                            deleteButton.Text = "Delete";
                            deleteButton.UseColumnTextForButtonValue = true; // Show "Delete" as button text
                            deleteButton.ReadOnly = false;
                            advancedDataGridView1.Columns.Add(deleteButton);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void DeleteUser(string section)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string DeleteUsers = "delete from PinCode where section = @section";


                    using (SqlCommand cmd = new SqlCommand(DeleteUsers, conn))
                    {
                        cmd.Parameters.AddWithValue("@section", section);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == advancedDataGridView1.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                string section = advancedDataGridView1.Rows[e.RowIndex].Cells["section"].Value.ToString();

                var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DeleteUser(section); // Call the method to delete the data from the database
                    LoadData(); // Reload data after deletion
                }
            }
            if (e.ColumnIndex == advancedDataGridView1.Columns["btnupdate"].Index && e.RowIndex >= 0)
            {
                string section = advancedDataGridView1.Rows[e.RowIndex].Cells["section"].Value.ToString();
                string pincode = advancedDataGridView1.Rows[e.RowIndex].Cells["pincode"].Value.ToString();
                

               OpenUpdateForm(section, pincode);
            }

        }
        private void OpenUpdateForm(string section, string pincode)
        {
            updatepincode updatepincode = new updatepincode(section, pincode);

            if (updatepincode.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void OpenRegistrationForm()
        {
            RegisterNewPincode registerNewPincode = new RegisterNewPincode();

            if (registerNewPincode.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenRegistrationForm();
        }
    }
}
