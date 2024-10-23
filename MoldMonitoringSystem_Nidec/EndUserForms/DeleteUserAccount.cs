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
    public partial class DeleteUserAccount : Form
    {
        private readonly string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
        private readonly UserDatabaseServiceUtility _UserDatabaseServiceUtility = new UserDatabaseServiceUtility();
       
        public DeleteUserAccount()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {          
            try
            {
                string DeleteUserData = "select username, section, type, employeename from Users";

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(DeleteUserData, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        advancedDataGridView1.DataSource = dt;
                        advancedDataGridView1.ReadOnly = true;                        

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
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void advancedDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == advancedDataGridView1.Columns["btnDelete"].Index && e.RowIndex >= 0 )
            {               
                string userid = advancedDataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
                var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    UserDatabaseServiceUtility.UserData ExistingUser = new UserDatabaseServiceUtility.UserData
                    {
                        userid = userid
                    };
                    bool Deleteuser = _UserDatabaseServiceUtility.DeleteUser(ExistingUser);
                    if (Deleteuser)
                    {                       
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.");
                    }
                }
            }
        }
    }
}
