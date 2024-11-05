using MoldMonitoringSystem_Nidec.Class;
using MoldMonitoringSystem_Nidec.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration; // For using app.config

namespace MoldMonitoringSystem_Nidec
{
    public partial class MainDashboard : Form
    {
        // Fields
        private Button currentButton;
        private Random random = new Random();
        private int tempIndex;
        private Form activeForm = null;
        private string _section;
        private string _employeename;
        private string _role;

        // Constructor
        public MainDashboard(string section, string username, string role)
        {
            InitializeComponent();
            this.Text = string.Empty;
            _section = section;
            _employeename = username;
            _role = role;
            SetButtonAccess();
            GetEmployee();  // Now uses the _employeename
            lbl_section.Text = _section;  // Directly setting the section
            Timer1.Start();
            LoadDashboard();
            _role = role;
        }

        // Timer to update real time
        private void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateRealTime();
        }

        private void UpdateRealTime()
        {
            lbl_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        // Get Employee Name
        private void GetEmployee()
        {
            lbl_employeename.Text = GetDataFromDB("SELECT employeename FROM imts_users WHERE username = @username",
                                                  new Dictionary<string, object> { { "@username", _employeename } });
        }

        // Reusable method to get data from database
        private string GetDataFromDB(string query, Dictionary<string, object> parameters)
        {
            string result = string.Empty;

            try
            {
                using (SqlConnection connection = DatabaseConnection.GetSqlConnection())
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
        private void SetButtonAccess()
        {
            var buttonAccess = new Dictionary<string, Action>
            {
                { "Injection", () => 
                                { 
                                   Mold_button.Hide();                        
                                   MoldRegistration_button.Hide();
                                } },
                { "Mold", () => 
                                {
                                   Injection_button.Hide();
                                } },
                { "PCD", () =>
                                {
                                    Mold_button.Hide();
                                    Injection_button.Hide();
                                    MoldRegistration_button.Hide();
                                    QR_button.Hide();
                                }
                }
            };

            if (buttonAccess.ContainsKey(_section))
            {
                buttonAccess[_section].Invoke();
            }
        }

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

        // Button actions
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Dashboard(_section), sender);
        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.MoldReceiving(_employeename, _section), sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.transactionhistory(_role), sender);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
           
            ShowLoginForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.InjectionReceiving(_employeename), sender);
        }

        private void btn_planning_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Planning(), sender);
        }

        // Get Pin Code for a section from the database
        private string GetPinForSection(string section)
        {
            string query = "SELECT pincode FROM PinCode WHERE section = @section";
            var parameters = new Dictionary<string, object> { { "@section", section } };
            return GetDataFromDB(query, parameters);
        }

        // Get section from the selected form
        private string GetSectionFromForm(Form selectedForm)
        {
            if (selectedForm is Forms.MoldQrGenerator || selectedForm is Forms.MachineQR)
            {
                return _employeename;
            }
            else
            {
                return "";
            }
           
        }

        private void ShowLoginForm()
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.MoldRegistration(_employeename), sender);         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QRCodeOption qRCodeOption = new QRCodeOption(_employeename, _section);

            //OpenChildForm(new Forms.QRCodeOption(_employeename),sender);

            qRCodeOption.OnFormSelected = (selectedForm) =>
            {
                string section = GetSectionFromForm(selectedForm);
                string correctPin = GetPinForSection(section);

                PinEntryForm pinEntryForm = new PinEntryForm(correctPin);

                pinEntryForm.OnPinValidated = (IsValid) =>
                {
                    if (IsValid)
                    {
                        OpenChildForm(selectedForm, sender);
                    }
                    else
                    {
                        MessageBox.Show("Access Denied.");
                    }
                };

                pinEntryForm.ShowDialog();
            };

            qRCodeOption.ShowDialog();
            LoadThemeUtility.LoadTheme(qRCodeOption);
        }
        private void LoadDashboard()
        {
            // Create an instance of the Dashboard form
            Forms.Dashboard dashboardForm = new Forms.Dashboard(_section);
            // Open the dashboard form in the panel
            OpenChildForm(dashboardForm, null); // Pass 'null' or any sender if needed
            LoadThemeUtility.LoadTheme(dashboardForm);
        }

        private void MainDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
