using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class Planning : Form
    {
        public Planning()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            progressBar1.Visible = false;

        }
        private void Planning_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   string customer = cmb_customer.Text;
                   string loadData;

                    if (customer == "All Customers")
                    {
                        loadData = "WITH LatestTransaction AS (SELECT moldnumber, MAX(CONCAT(date, ' ', time)) AS LatestTimestamp FROM History " +
                                   "GROUP BY moldnumber) " +
                                   "SELECT h.date, h.partnumber, h.moldnumber, h.dienumber, h.status, h.location, h.remarks, h.in_charge, h.time " +
                                   "FROM history h JOIN LatestTransaction lt ON h.moldnumber = lt.moldnumber AND CONCAT(h.date, ' ', h.time) = lt.LatestTimestamp " +
                                   "ORDER BY h.date ASC, h.time ASC";

                    }
                    else
                    {
                        loadData = "with LatestTransaction AS (SELECT moldnumber, MAX(CONCAT(date, ' ', time)) AS LatestTimestamp FROM History " +
                                    "where customer = @customer group by moldnumber) " +
                                    "select h.date, h.partnumber,h.moldnumber, h.dienumber, h.status, h.location, h.remarks, h.in_charge, h.time " +
                                    "from history h join LatestTransaction lt On h.moldnumber = lt.moldnumber and CONCAT(h.date, ' ', h.time) = lt.LatestTimestamp " +
                                    "where h.customer = @customer " +
                                    "order by h.date ASC, h.time ASC";
                    }
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(loadData, connection))
                    {
                        if (customer != "All Customers")
                        {
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@customer", customer);
                        }
                        dataAdapter.Fill(dt);
                    }

                    advancedDataGridView1.DataSource = dt;
                    advancedDataGridView1.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CustomerFilename = cmb_customer.Text;
            string filePath = $"TransactionReport_{CustomerFilename}.xlsx";

            if (advancedDataGridView1.Rows.Count > 0)
            {
                // Use SaveFileDialog to let the user choose the save location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = filePath; // Default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Reset and show progress bar and label
                        progressBar1.Visible = true;
                        progressBar1.Value = 0; // Reset progress bar
                        progresslbl.Visible = true;
                        progresslbl.Text = "Starting export...";

                        // Start background worker for exporting the data
                        backgroundWorker1.RunWorkerAsync(saveFileDialog.FileName);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export.");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string CustomerFilename = cmb_customer.Text;

            string filePath = $"TransactionReport_{CustomerFilename}.xlsx";
            bool success = false;

            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Create a new Excel package using EPPlus
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Add a new worksheet to the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(filePath);

                    // Get the number of rows and columns from the DataGridView
                    int rowCount = advancedDataGridView1.Rows.Count;
                    int colCount = advancedDataGridView1.Columns.Count;

                    // Write column headers
                    for (int col = 0; col < colCount; col++)
                    {
                        var cell = worksheet.Cells[1, col + 1];
                        cell.Value = advancedDataGridView1.Columns[col].HeaderText;
                        cell.Style.Font.Name = "ＭＳ ゴシック"; // Set the font
                        cell.Style.Font.Size = 11; // Set the font size
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    // Write data rows
                    for (int row = 0; row < rowCount; row++)
                    {
                        for (int col = 0; col < colCount; col++)
                        {
                            var cell = worksheet.Cells[row + 2, col + 1];
                            var cellValue = advancedDataGridView1.Rows[row].Cells[col].Value;
                            cell.Value = cellValue?.ToString() ?? "";

                            // Apply font to the cell
                            cell.Style.Font.Name = "ＭＳ ゴシック";
                            cell.Style.Font.Size = 11;

                            // Apply alignment
                            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            // Apply date format to the first column (index 0)
                            if (col == 0 && cellValue != null)
                            {
                                DateTime dateValue;
                                if (DateTime.TryParse(cellValue.ToString(), out dateValue))
                                {
                                    cell.Value = dateValue;
                                    cell.Style.Numberformat.Format = "dd/mm/yy"; // Set custom date format
                                }
                            }
                        }

                        // Calculate and report progress
                        int progress = (int)((float)(row + 1) / rowCount * 100);
                        backgroundWorker1.ReportProgress(progress, $"Exporting row {row + 1} of {rowCount} ({progress}% completed)");
                    }

                    
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Cells[worksheet.Dimension.Address].Style.Numberformat.Format = "@";
                    
                    FileInfo file = new FileInfo(filePath);
                    package.SaveAs(file);
                    success = true;
                }
            }
            catch (IOException ex)
            {
                e.Result = $"Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                e.Result = $"Unexpected error: {ex.Message}";
            }

            if (!success && e.Result == null)
            {
                e.Result = "The export failed.";
            }
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progresslbl.Text = e.UserState.ToString();
        }
        private async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Ensure progress bar visibility and reset
            progressBar1.Visible = false;
            progresslbl.Visible = false;

            if (e.Error != null)
            {
                MessageBox.Show($"An error occurred: {e.Error.Message}");
            }
            else if (e.Result is string resultMessage && resultMessage.StartsWith("Error"))
            {
                MessageBox.Show(resultMessage); // Show error message
            }
            else
            {
                MessageBox.Show("Excel file exported successfully.");
            }
            await Task.Delay(6000);
        }

        private void cmb_customer_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
