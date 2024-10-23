using MoldMonitoringSystem_Nidec.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    public partial class ChangePassword : Form
    {
        private readonly UserDatabaseServiceUtility _databaseServiceUtility = new UserDatabaseServiceUtility();
        public ChangePassword()
        {
            InitializeComponent();
            txt_userid.CharacterCasing = CharacterCasing.Upper;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            LoadThemeUtility.LoadTheme(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure that the userid textbox is not empty before proceeding
            if (string.IsNullOrWhiteSpace(txt_userid.Text))
            {
                MessageBox.Show("Please enter a UserID.");
                return;
            }

            // Initialize UserData object with the entered userid
            UserDatabaseServiceUtility.UserData userData = new UserDatabaseServiceUtility.UserData
            {
                userid = txt_userid.Text // Ensure this matches your property in UserData class
            };

            // Check if the user exists in the database
            bool CheckUser = _databaseServiceUtility.ValidateUserExistence(userData);

            if (CheckUser)
            {
                // Check if the new password and confirm password fields match
                if (txt_newpass.Text == txt_confirmpass.Text)
                {
                    // Update the password if they match
                    _databaseServiceUtility.UpdatePassword(txt_newpass.Text, txt_userid.Text);
                    MessageBox.Show("Password updated successfully!");
                }
                else
                {
                    MessageBox.Show("Passwords do not match!");
                }
            }
            else
            {
                MessageBox.Show("UserID does not exist!");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt_newpass.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txt_confirmpass.UseSystemPasswordChar = !checkBox2.Checked;
        }
    }
}
