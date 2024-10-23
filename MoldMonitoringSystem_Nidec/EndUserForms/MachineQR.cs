using MoldMonitoringSystem_Nidec.Class;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class MachineQR : Form
    {
        private string _employeename;
        private readonly MoldDataBaseServiceUtility _dataBaseServiceUtility = new MoldDataBaseServiceUtility();
        private readonly string _connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

        public MachineQR(string employeename)
        {
            InitializeComponent();
            _employeename = employeename;
        }

        private void MachineQR_Load(object sender, EventArgs e)
        {
            // Load data into EquipmentMasterlist table
            this.equipmentMasterlistTableAdapter.Fill(this.moldTrackingSystemDataSet2.EquipmentMasterlist);
            LoadThemeUtility.LoadTheme(this);
            pictureBox1.Hide();
            SetupPartNumberAutoSuggest();
        }
        private PrintDocument _printDocument;
        public bool _showPrintDocument = false;
        private void PrintPreviewPanel()
        {
            string label = $"Machine Line no:  {cmb_line.Text}/Machine Name: {txt_machineno.Text}";
            if (pictureBox1.Image != null)
            {
                string labelText = label.Replace("/", "\n");
                _printDocument = PrintUtility.PrintImage(pictureBox1.Image, labelText, panel1);

                _showPrintDocument = true;
            }
            else
            {
                MessageBox.Show("There is no image to print.");
            }
        }
        private void GenerateQrCode()
        {
            string qrCodeData = $"{cmb_line.Text}/{txt_machineno.Text}";
            Image qrCodeImage = QRCodeUtility.GenerateQrCode(qrCodeData, 80);
            pictureBox1.Image = QRCodeUtility.Resize(qrCodeImage, pictureBox1.Width, pictureBox1.Height);
        }
        private void PrintLogs()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "insert into PrintLogs (Date, Time, [Content], [User]) values (@Date, @Time, @Content, @User)";

                    string label = $"Machine Number: {txt_machineno.Text}/Equipment Name: {cmb_line.Text}";

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
        
        private void button2_Click(object sender, EventArgs e)
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

        private void cmb_line_TextChanged(object sender, EventArgs e)
        {
            string equipment = cmb_line.Text;

            if (!string.IsNullOrWhiteSpace(equipment))
            {
                var machineData = _dataBaseServiceUtility.ProvideDataMachine(equipment);

                if (machineData != null)
                {
                    txt_machineno.Text = machineData.Equipment_name;
                    GenerateQrCode();
                    PrintPreviewPanel();
                }
                else
                {
                    MessageBox.Show("No machine data found for the selected line.");
                    txt_machineno.Text = string.Empty;
                }
            }
            else
            {
                cmb_line.SelectedIndex = -1;
                txt_machineno.Text = string.Empty;
            }
        }
        private void SetupPartNumberAutoSuggest()
        {
            // Get part numbers from the database
            var partNumbers = _dataBaseServiceUtility.GetAllMachine(); // Assuming this method returns a list of part numbers

            if (partNumbers != null && partNumbers.Count > 0)
            {
                // Create an AutoCompleteStringCollection and add part numbers to it
                AutoCompleteStringCollection autoSuggestCollection = new AutoCompleteStringCollection();
                autoSuggestCollection.AddRange(partNumbers.ToArray());

                // Configure the ComboBox for auto-suggest
                txt_machineno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_machineno.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_machineno.AutoCompleteCustomSource = autoSuggestCollection;
            }
        }

    }
}
