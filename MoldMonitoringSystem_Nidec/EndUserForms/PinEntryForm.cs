using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class PinEntryForm : Form
    {
        public Action<bool> OnPinValidated;
        private string _correctPin;

        public PinEntryForm(string correctPin)
        {
            InitializeComponent();
            _correctPin = correctPin;
            textBox1.UseSystemPasswordChar = true; // Mask the PIN input
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidatePin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OnPinValidated?.Invoke(false);
            this.Close();
        }
        private void ValidatePin()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return;
            }

            if (textBox1.Text == _correctPin)
            {
                MessageBox.Show("Access granted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnPinValidated?.Invoke(true);
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect PIN. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
            }
        }
    }
}
