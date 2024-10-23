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
    public partial class EditUserinformation : Form
    {
        private bool isUpdating = false;
        private readonly UserDatabaseServiceUtility _UserDatabaseServiceUtility = new UserDatabaseServiceUtility();

        public EditUserinformation()
        {
            InitializeComponent();
            userid_textbox.CharacterCasing = CharacterCasing.Upper;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            UserDatabaseServiceUtility.UserData userData = new UserDatabaseServiceUtility.UserData
            {
                userid = userid_textbox.Text,
                Type = combo_role.Text,
                Section = combo_section.Text,
                employeename = employeename_txtbox.Text
                
            };

           bool CheckUpdate = _UserDatabaseServiceUtility.UpdateUser(userData);

            if (CheckUpdate)
            {
                MessageBox.Show("Record updated successfully.");
            }
            else
            {
                MessageBox.Show("No record found with the specified user id.");
            }
        }
        private void userid_textbox_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            string userid = userid_textbox.Text;
            var userdata = _UserDatabaseServiceUtility.UserInformation(userid);

            try
            {
                if (!string.IsNullOrEmpty(userid))
                {
                   
                    if (userdata != null)
                    {
                        isUpdating = true;
                        combo_role.Text = userdata.Type;
                        combo_section.Text = userdata.Section;
                        employeename_txtbox.Text = userdata.employeename;
                    }
                }
                else
                {
                    ClearInputs();
                }
            }
            finally
            {
                isUpdating = false;
            }
        }
        private void ClearInputs()
        {
            userid_textbox.Text = string.Empty;
            employeename_txtbox.Text = string.Empty;
            combo_role.SelectedIndex = -1;
            combo_section.SelectedIndex = -1;
        }
    }
}
