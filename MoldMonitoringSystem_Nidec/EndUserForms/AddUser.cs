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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    public partial class AddUser : Form
    {
        private readonly UserDatabaseServiceUtility _UserDatabaseServiceUtility = new UserDatabaseServiceUtility();
        public AddUser()
        {
            InitializeComponent();
            userid_textbox.CharacterCasing = CharacterCasing.Upper;
        }
        private void AddUser_Load(object sender, EventArgs e)
        {
            LoadThemeUtility.LoadTheme(this);
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            registeruser();
        }
        private void registeruser()
        {
            // Validate input fields first
            if (string.IsNullOrWhiteSpace(userid_textbox.Text) ||
                string.IsNullOrWhiteSpace(password_text.Text) ||
                string.IsNullOrWhiteSpace(combo_role.Text) ||
                string.IsNullOrWhiteSpace(combo_section.Text) ||
                string.IsNullOrWhiteSpace(employeename_txtbox.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create new user object
            UserDatabaseServiceUtility.UserData NewUser = new UserDatabaseServiceUtility.UserData
            {
                userid = userid_textbox.Text,
                password = password_text.Text,
                Section = combo_section.Text,
                Type = combo_role.Text,
                employeename = employeename_txtbox.Text
            };

            // Check if the user already exists before adding
            bool Existing_user = _UserDatabaseServiceUtility.duplicateuser(NewUser);

            if (Existing_user)
            {
                MessageBox.Show("The userid already exists in the database. Please enter a unique userid.", "Duplicate userid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userid_textbox.Focus(); // Set focus back to the userid textbox
                return;
            }
            bool UserAdded = _UserDatabaseServiceUtility.AddUserData(NewUser);

            if (UserAdded)
            {
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showpass_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            password_text.UseSystemPasswordChar = !showpass_chckbox.Checked;
        }
    }
}
