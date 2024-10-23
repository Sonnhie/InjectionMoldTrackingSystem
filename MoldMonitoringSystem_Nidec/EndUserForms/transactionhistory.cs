
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
using OfficeOpenXml;
using System.IO;



namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class transactionhistory : Form
    {
        private string _role;
        private readonly string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

        public transactionhistory(string role)
        {
            InitializeComponent();
            _role = role;
            backgroundWorker1.WorkerReportsProgress = true;
            progressBar1.Visible = false;
            LoadData();
            
        }

        private void Settings_Load(object sender, EventArgs e)
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
        private BindingSource bindingSource = new BindingSource();
        private void LoadData()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    DateTime currentDate = dateTimePicker2.Value.Date;
                    DateTime previousDate = dateTimePicker1.Value.Date;

                    string partnumber = txt_partnumber.Text;

                    string loadData;

                    if (string.IsNullOrWhiteSpace(partnumber))
                    {
                        loadData = "select id, date, partnumber, moldnumber, dienumber, status, location, remarks, in_charge, time from History " +
                         "where date BETWEEN @startDate AND @endDate " +
                         "order by date ASC, time ASC";
                    }
                    else
                    {
                        loadData = "select id, date, partnumber, dienumber, status, location, remarks, in_charge, time from History " +
                        "where date BETWEEN @startDate AND @endDate AND partnumber LIKE @partnumber " +
                        "order by date ASC, time ASC";
                    }

                    DataTable dt = new DataTable();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(loadData, connection))
                    {
                     
                        if (!string.IsNullOrWhiteSpace(partnumber))
                        {
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@startDate", previousDate);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@partnumber", partnumber);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@endDate", currentDate);
                        }
                        else
                        {
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@startDate", previousDate);
                            dataAdapter.SelectCommand.Parameters.AddWithValue("@endDate", currentDate);
                        }

         
                        dataAdapter.Fill(dt);
                    }

                    bindingSource.DataSource = dt;
                    advancedDataGridView1.DataSource = bindingSource;
                    advancedDataGridView1.ReadOnly = true;

                    if (_role == "Administrator")
                    {
                        if (advancedDataGridView1.Columns["btnDelete"] == null)
                        {
                            // Add a delete button column
                            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                            deleteButton.HeaderText = "Action";
                            deleteButton.Name = "btnDelete";
                            deleteButton.Text = "Delete";
                            deleteButton.UseColumnTextForButtonValue = true; // Show "Delete" as button text
                            deleteButton.ReadOnly = false;
                            advancedDataGridView1.Columns.Add(deleteButton);
                        }
                        //advancedDataGridView1.ReadOnly = false;
                    }


                    CustomHeaders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DeleteUser(string RowID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string DeleteUsers = "delete from History where id = @RowID";


                    using (SqlCommand cmd = new SqlCommand(DeleteUsers, conn))
                    {
                        cmd.Parameters.AddWithValue("@RowID", RowID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == advancedDataGridView1.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                string RowID = advancedDataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                var confirmResult = MessageBox.Show("Are you sure to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    DeleteUser(RowID); // Call the method to delete the data from the database
                    LoadData(); // Reload data after deletion
                }
            }
        }
        private void CustomHeaders()
        {
            if (advancedDataGridView1.Columns.Count > 0)
            {
                advancedDataGridView1.Columns["id"].HeaderText = "Row Id";
                advancedDataGridView1.Columns["date"].HeaderText = "Date";
                advancedDataGridView1.Columns["partnumber"].HeaderText = "Part Number";
                advancedDataGridView1.Columns["moldnumber"].HeaderText = "Mold Number";
                advancedDataGridView1.Columns["dienumber"].HeaderText = "Die Number";
                advancedDataGridView1.Columns["status"].HeaderText = "Status";
                advancedDataGridView1.Columns["location"].HeaderText = "Location";
                advancedDataGridView1.Columns["remarks"].HeaderText = "Remarks";
                advancedDataGridView1.Columns["in_charge"].HeaderText = "In Charge";
                advancedDataGridView1.Columns["time"].HeaderText = "Time";

                // Example: Set the font and color for the headers
                foreach (DataGridViewColumn column in advancedDataGridView1.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Aptos Narrow", 9);
                    column.HeaderCell.Style.BackColor = Color.LightGray;
                    column.HeaderCell.Style.ForeColor = Color.Black;
                   
                } 
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = e.Argument.ToString();
            bool success = false;

            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                // Create a new Excel package using EPPlus
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Add a new worksheet to the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                    // Get the number of rows and columns from the DataGridView
                    int rowCount = advancedDataGridView1.Rows.Count;
                    int colCount = advancedDataGridView1.Columns.Count;

                    // Write column headers
                    for (int col = 1; col < colCount; col++)
                    {
                        var cell = worksheet.Cells[1, col];
                        cell.Value = advancedDataGridView1.Columns[col].HeaderText;
                        cell.Style.Font.Name = "ＭＳ ゴシック"; // Set the font
                        cell.Style.Font.Size = 11; // Set the font size
                        cell.Style.Font.Bold = true;
                        cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    }

                    // Write data rows
                    for (int row = 0; row < rowCount; row++)
                    {
                        for (int col = 1; col < colCount; col++)
                        {
                            var cell = worksheet.Cells[row + 2, col];
                            var cellValue = advancedDataGridView1.Rows[row].Cells[col].Value;
                            cell.Value = cellValue?.ToString() ?? "";

                            // Apply font to the cell
                            cell.Style.Font.Name = "ＭＳ ゴシック";
                            cell.Style.Font.Size = 11;

                            // Apply alignment
                            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            // Apply date format to the first column (index 0)
                            if (col == 1 && cellValue != null)
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

                    // Auto-fit columns (optimize this call to be once)
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Save the Excel file to the user-specified location
                    FileInfo file = new FileInfo(filePath);
                    package.SaveAs(file);
                    success = true;
                }
            }
            catch (IOException ex)
            {
                // Handle IOException and return the message for failure
                e.Result = $"Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                // General exception handler
                e.Result = $"Unexpected error: {ex.Message}";
            }

            if (!success && e.Result == null)
            {
                e.Result = "The export failed.";
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update progress bar and label
            progressBar1.Value = e.ProgressPercentage;
            lbl_process.Text = e.UserState.ToString();
        }

        private async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Ensure progress bar visibility and reset
            progressBar1.Visible = false;
            lbl_process.Visible = false;

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

        private void btn_export_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            string fileName = $"TransactionReport_{startDate:yyyy-MM-dd}_to_{endDate:yyyy-MM-dd}.xlsx";

            if (advancedDataGridView1.Rows.Count > 0)
            {
                // Use SaveFileDialog to let the user choose the save location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = fileName; // Default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Reset and show progress bar and label
                        progressBar1.Visible = true;
                        progressBar1.Value = 0; // Reset progress bar
                        lbl_process.Visible = true;
                        lbl_process.Text = "Starting export...";

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }


    }
}
