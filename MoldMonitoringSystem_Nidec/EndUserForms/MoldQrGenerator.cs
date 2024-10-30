using MoldMonitoringSystem_Nidec.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class MoldQrGenerator : Form
    {
        private string _employeename;
        private readonly MoldDataBaseServiceUtility _dataBaseServiceUtility = new MoldDataBaseServiceUtility();
        private readonly string _connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

        public MoldQrGenerator(string employeename)
        {
            InitializeComponent();
            _employeename = employeename;   
        }
        
        private void MoldQrGenerator_Load(object sender, EventArgs e)
        {
            LoadThemeUtility.LoadTheme(this);
            // TODO: This line of code loads data into the 'moldTrackingSystemDataSet3.MoldMaster' table. You can move, or remove it, as needed.
            this.moldMasterTableAdapter.Fill(this.moldTrackingSystemDataSet3.MoldMaster);
            pictureBox1.Hide();

            SetupPartNumberAutoSuggest();
        }
        private void GenerateQrCode()
        {   
            string qrCodeData = $"{partnumber_txt.Text}/{moldnumber_txt.Text}/{die_txt.Text}/{customer_txt.Text}";
            Image qrCodeImage = QRCodeUtility.GenerateQrCode(qrCodeData, 100);
            pictureBox1.Image = QRCodeUtility.Resize(qrCodeImage, pictureBox1.Width, pictureBox1.Height);
        }     
        private void die_txt_TextChanged(object sender, EventArgs e)
        {
            UpdateMoldAndCustomerInfo();
        }
        private void partnumber_txt_TextChanged_1(object sender, EventArgs e)
        {
           UpdateMoldAndCustomerInfo();
        }
        private void UpdateMoldAndCustomerInfo()
        {
            string partNumber = partnumber_txt.Text.Trim();
            string dieNumber = die_txt.Text.Trim();

            if (!string.IsNullOrWhiteSpace(partNumber) && !string.IsNullOrWhiteSpace(dieNumber))
            {
                var moldData = _dataBaseServiceUtility.ProvideData(partNumber, dieNumber);
                if (moldData != null)
                {
                    moldnumber_txt.Text = moldData.MoldNumber;
                    customer_txt.Text = moldData.Customer;
                    GenerateQrCode();  // Function to generate the QR code
                    PrintPreviewPanel();
                }
                else
                {
                    // Clear fields if no data is found
                    moldnumber_txt.Text = "";
                    customer_txt.Text = "";
                }
            }
            else
            {
                // Clear fields if either input is missing
                moldnumber_txt.Text = "";
                customer_txt.Text = "";
            }
        }
        private PrintDocument _printDocument;
        public bool _showPrintDocument = false;
        public void PrintPreviewPanel()
        {
            var partNumbers = _dataBaseServiceUtility.GetPartNumbersForMold(moldnumber_txt.Text);

            if (partNumbers != null && partNumbers.Count > 0)
            {
                // Limit the number of part numbers to 5 (or use as many as exist, if fewer than 5)
                int maxPartNumbers = Math.Min(partNumbers.Count, 5);
                string partNumbersLabel = string.Join("/", partNumbers.Take(maxPartNumbers));

                // Construct the label by appending the mold number, die number, and customer details
                string label = $"Mold Number: {moldnumber_txt.Text}/Customer: {customer_txt.Text}";

                if (pictureBox1.Image != null)
                {
                    // Replace "/" with newlines for the printed label
                    string labelText = label.Replace("/", "\n");
                    
                    _printDocument = PrintUtility.PrintImage(pictureBox1.Image, labelText, panel1);

                    _showPrintDocument = true;


                }
                else
                {
                    MessageBox.Show("There is no image to print.");
                }
            }
            else
            {
                MessageBox.Show("Could not find any part numbers associated with the mold.");
            }
        }
        private void PrintLogs()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "insert into PrintLogs (Date, Time, [Content], [User]) values (@Date, @Time, @Content, @User)";

                    string label = $"Mold Number: {moldnumber_txt.Text}/Customer: {customer_txt.Text}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Time", DateTime.Now.ToString("HH:mm:ss"));
                        command.Parameters.AddWithValue("@Content", label);
                        command.Parameters.AddWithValue("@User", _employeename);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Print log recorded successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Failed to record print log.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging to database: {ex.Message}");
                }
            }
        }
        private void print_button_Click(object sender, EventArgs e)
        {
            if (_printDocument != null)
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = _printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    _printDocument.Print();

                    if (_showPrintDocument)
                    {
                        PrintLogs();
                    }
                    _showPrintDocument = false;
                } 
            }
            else
            {
                MessageBox.Show("No document is prepared for printing. Please preview first.");
            }
        }
        private void SetupPartNumberAutoSuggest()
        {
            // Get part numbers from the database
            var partNumbers = _dataBaseServiceUtility.GetAllPartNumbers(); // Assuming this method returns a list of part numbers

            if (partNumbers != null && partNumbers.Count > 0)
            {
                // Create an AutoCompleteStringCollection and add part numbers to it
                AutoCompleteStringCollection autoSuggestCollection = new AutoCompleteStringCollection();
                autoSuggestCollection.AddRange(partNumbers.ToArray());

                // Configure the ComboBox for auto-suggest
                partnumber_txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                partnumber_txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                partnumber_txt.AutoCompleteCustomSource = autoSuggestCollection;
            }
        }

     
    }
}
