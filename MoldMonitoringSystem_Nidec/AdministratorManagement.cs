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
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MoldMonitoringSystem_Nidec.Class;
using MoldMonitoringSystem_Nidec.Forms;
using MoldMonitoringSystem_Nidec.EndUserForms;

namespace MoldMonitoringSystem_Nidec
{
    public partial class AdministratorManagement : Form
    {
        private Button currentButton;
        private Random random = new Random();
        private int tempIndex;
        private Form activeForm = null;
        private string _section;
        private string _employeename;
        private string _role;

        public AdministratorManagement(string section, string username, string role)
        {
            InitializeComponent();
            this.Text = string.Empty;
            _section = section;
            _employeename = username;
            _role = role;
            GetEmployee();  // Now uses the _employeename
            lbl_section.Text = _section;  // Directly setting the section
            Timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateRealTime();
        }
    
        private void UpdateRealTime()
        {
            lbl_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
        private void GetEmployee()
        {
            lbl_employeename.Text = GetDataFromDB("SELECT employeename FROM Users WHERE username = @username",
                                                  new Dictionary<string, object> { { "@username", _employeename } });
        }

        // Reusable method to get data from database
        private string GetDataFromDB(string query, Dictionary<string, object> parameters)
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
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                        result = cmd.ExecuteScalar()?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving data.", ex);
            }

            return result;
        }

        // Set button access based on section
        

        // Select theme color
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            return ColorTranslator.FromHtml(ThemeColor.ColorList[index]);
        }

        // Activate button with theme color
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null && currentButton != (Button)btnSender)
            {
                DisableButton();
                Color color = SelectThemeColor();
                currentButton = (Button)btnSender;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new Font("Microsoft Sans Serif", 12.5F);
                panel_title.BackColor = color;
                Panel_logo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                ThemeColor.PrimaryColor = color;
                ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
            }
        }

        // Disable buttons' themes
        private void DisableButton()
        {
            foreach (Control previousBtn in panel_menu.Controls)
            {
                if (previousBtn is Button btn)
                {
                    btn.BackColor = Color.FromArgb(51, 51, 76);
                    btn.ForeColor = Color.Gainsboro;
                    btn.Font = new Font("Microsoft Sans Serif", 10F);
                }
            }
        }

        // Open child form in panel
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_desktopform.Controls.Add(childForm);
            panel_desktopform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            Lbl_title.Text = childForm.Text;
        }

        private void btn__Click(object sender, EventArgs e)
        {
           OpenChildForm(new EndUserForms.AddUser(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EndUserForms.EditUserinformation(), sender);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EndUserForms.DeleteUserAccount(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }
        
        private void btn_pincode_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EndUserForms.QRCodePinManagement(), sender);
        }
        private void ShowLoginForm()
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EndUserForms.MoldmasterList(), sender);
        }

        private void AdministratorManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new EndUserForms.ChangePassword(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.transactionhistory(_role), sender);
        }

        private void Print_Logs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EndUserForms.Print_Logs(), sender);
        }
    }
}
