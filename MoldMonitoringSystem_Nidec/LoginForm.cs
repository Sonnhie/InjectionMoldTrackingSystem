using MoldMonitoringSystem_Nidec.Class;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;


namespace MoldMonitoringSystem_Nidec
{
    public partial class LoginForm : Form
    {
        private const int MaxFailedAttempts = 5;
        private int failedAttempts = 0;
        private DateTime lockoutEndTime;
        private bool isLockedOut = false;
        private Timer lockoutTimer;
        private const int lockoutDurationInSeconds = 20;
        private readonly UserDatabaseServiceUtility _UserDatabaseServiceUtility = new UserDatabaseServiceUtility();

        public LoginForm()
        {
            InitializeComponent();
            lockoutTimer = new Timer();
            lockoutTimer.Interval = 1000; // Set timer to tick every second
            lockoutTimer.Tick += LockoutTimer_Tick;
            textBox1.Focus();

            WebClient client = new WebClient();
            try
            {
                if (client.DownloadString("").Contains("1.1.0"))
                {
                    if (MessageBox.Show("There is an update! Do you want to download it?", "IMTS app", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
                    {
                        Process.Start("Updater.exe");
                        this.Close();
                    }
                }
            }
            catch
            {

            }
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            // Handle lockout
            if (IsLockedOut())
                return;

            var loggedInUser = _UserDatabaseServiceUtility.Validateuser(textBox1.Text, textBox2.Text);

            if (loggedInUser != null)
            {
                if (loggedInUser.Type == "Administrator")
                {
                    var adminform = new AdministratorManagement(loggedInUser.Section, loggedInUser.userid, loggedInUser.Type);
                    adminform.Show();
                    this.Hide();
                }
                else
                {
                    // Success: open the dashboard and hide the login form
                    var mainForm = new MainDashboard(loggedInUser.Section, loggedInUser.userid, loggedInUser.Type);
                    mainForm.Show();
                    this.Hide();
                }
               
            }
            else
            {
                HandleFailedLogin();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HandleFailedLogin()
        {
            failedAttempts++;

            if (failedAttempts >= MaxFailedAttempts)
            {
                isLockedOut = true;
                lockoutEndTime = DateTime.Now.AddSeconds(lockoutDurationInSeconds);
                MessageBox.Show("Too many failed attempts. You are locked out for 20 seconds.");
                lockoutTimer.Start();
            }
            else
            {
                MessageBox.Show($"Login failed. You have {MaxFailedAttempts - failedAttempts} attempts left.");
            }
        }

        private bool IsLockedOut()
        {
            if (isLockedOut)
            {
                if (DateTime.Now < lockoutEndTime)
                {
                    // Calculate remaining seconds
                    double remainingSeconds = (lockoutEndTime - DateTime.Now).TotalSeconds;
                    MessageBox.Show($"Too many failed attempts. Please wait {Math.Ceiling(remainingSeconds)} seconds before trying again.");
                    return true;
                }
                if (DateTime.Now >= lockoutEndTime)
                {
                    isLockedOut = false;
                    failedAttempts = 0;
                    lockoutTimer.Stop();
                }
            }
            return false;
        }
        private void LockoutTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= lockoutEndTime)
            {
                lockoutTimer.Stop();
                isLockedOut = false;
                failedAttempts = 0;
                MessageBox.Show("Lockout ended. You can try logging in again.");
                lock_lbl.Visible = false;
            }
            else
            {
                // Calculate remaining time and update a label (you can add a label to your form)
                double remainingSeconds = (lockoutEndTime - DateTime.Now).TotalSeconds;
                lock_lbl.Text = $"Locked out for {Math.Ceiling(remainingSeconds)} seconds"; // Update label with remaining time
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void showpass_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !showpass_chckbox.Checked;
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
