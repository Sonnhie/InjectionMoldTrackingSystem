using MoldMonitoringSystem_Nidec.Class;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    public partial class MoldmasterList : Form
    {
        private readonly MoldDataBaseServiceUtility _moldDataBaseServiceUtility = new MoldDataBaseServiceUtility();
        public MoldmasterList()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            progressBar1.Visible = false;
        }
        private void MoldmasterList_Load(object sender, EventArgs e)
        {    
           LoadData();   
           LoadTheme();
        }
        private void LoadData()
        {
            try
            {
                var moldMasterList = _moldDataBaseServiceUtility.GetMoldMasterList();

                if (moldMasterList != null && moldMasterList.Count > 0)
                {
                    advancedDataGridView1.DataSource = null; 
                    advancedDataGridView1.AutoGenerateColumns = false;  
                    advancedDataGridView1.Columns.Clear();  

                    
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Mold Number",
                        DataPropertyName = "MoldNumber"  // Corresponds to the property name in MoldData
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Material",
                        DataPropertyName = "Material"
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Material Name",
                        DataPropertyName = "Material_name"
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Customer",
                        DataPropertyName = "Customer"
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Die Number",
                        DataPropertyName = "DieNumber"
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Date Created",
                        DataPropertyName = "DateCreated"
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Time Created",
                        DataPropertyName = "TimeCreated"
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "User Name",
                        DataPropertyName = "UserName"
                    });
                    advancedDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Status",
                        DataPropertyName = "Status"
                    });

                    // Add the delete button column
                    if (advancedDataGridView1.Columns["btnDelete"] == null)
                    {
                        DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
                        {
                            HeaderText = "Action",
                            Name = "btnDelete",
                            Text = "Delete",
                            UseColumnTextForButtonValue = true
                        };
                        advancedDataGridView1.Columns.Add(deleteButton);
                    }

                    // Bind the data
                    advancedDataGridView1.DataSource = moldMasterList;
                }
                else
                {
                    MessageBox.Show("No data found in the mold master list.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenameColumns()
        {
            // Dictionary to map original column names to their new header texts
             var columnHeaders = new Dictionary<string, string>
                {
                    { "MoldNumber", "Mold Number" },
                    { "Customer", "Customer" },
                    { "Material_name", "Material Name" },
                    {"DieNumber", "Die Number" },
                    {"Material", "Material" },
                    {"DateCreated", "Date Updated" },
                    {"TimeCreated", "Time Updated" },
                    {"UserName", "User ID" },
                    {"Status", "Status" }
                };

            // Loop through each column and rename it if it exists in the dictionary
            foreach (DataGridViewColumn column in advancedDataGridView1.Columns)
            {
                if (columnHeaders.ContainsKey(column.Name))
                {
                    column.HeaderText = columnHeaders[column.Name]; // Set new header text
                }
            }
        }
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked cell is not a header or out of bounds
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Check if the delete button column was clicked
                if (advancedDataGridView1.Columns[e.ColumnIndex].Name == "btnDelete")
                {
                    // Get the primary key or identifying value from the selected row
                    string moldNumber = advancedDataGridView1.Rows[e.RowIndex].Cells["MoldNumber"].Value.ToString(); // Adjust column name as necessary

                    // Ask for confirmation before deleting
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete the mold with MoldNumber: {moldNumber}?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Call the delete method to remove the record from the database
                        DeleteMoldRecord(moldNumber);

                        // Reload the data to reflect the changes in the DataGridView
                        LoadData();
                    }
                }
            }
        }
        private void DeleteMoldRecord(string moldNumber)
        {
            try
            {
                // Call your database utility to delete the record by MoldNumber
                bool isDeleted = _moldDataBaseServiceUtility.DeleteMoldData(moldNumber);

                if (isDeleted)
                {
                    MessageBox.Show($"Mold with MoldNumber: {moldNumber} has been successfully deleted.", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete the mold record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the mold record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    int headerColIndex = 1; // Start the index for Excel column headers
                    for (int col = 0; col < colCount; col++)
                    {
                        // Skip the "Action" column
                        if (advancedDataGridView1.Columns[col].Name == "btnDelete")
                        {
                            continue;
                        }

                        var cell = worksheet.Cells[1, headerColIndex];
                        cell.Value = advancedDataGridView1.Columns[col].HeaderText;
                        cell.Style.Font.Name = "ＭＳ ゴシック"; // Set the font
                        cell.Style.Font.Size = 11; // Set the font size
                        cell.Style.Font.Bold = false;
                        cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        headerColIndex++;
                    }

                    // Auto-fit columns (optimize this call to be once)
                   

                    // Write data rows
                    for (int row = 0; row < rowCount; row++)
                    {
                        int dataColIndex = 1; // Start the index for data rows in Excel
                        for (int col = 0; col < colCount; col++)
                        {
                            // Skip the "Action" column
                            if (advancedDataGridView1.Columns[col].Name == "btnDelete")
                            {
                                continue;
                            }

                            var cell = worksheet.Cells[row + 2, dataColIndex];
                            var cellValue = advancedDataGridView1.Rows[row].Cells[col].Value;
                            cell.Value = cellValue?.ToString() ?? "";

                            // Apply font to the cell
                            cell.Style.Font.Name = "ＭＳ ゴシック";
                            cell.Style.Font.Size = 11;

                            // Apply alignment
                            if (advancedDataGridView1.Columns[col].Name == "Customer")
                            {
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            }
                            else
                            {
                                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            }

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
                            dataColIndex++;
                        }

                       

                        // Calculate and report progress
                        int progress = (int)((float)(row + 1) / rowCount * 100);
                        backgroundWorker1.ReportProgress(progress, $"Exporting row {row + 1} of {rowCount} ({progress}% completed)");
                    }

                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                    worksheet.Cells[worksheet.Dimension.Address].Style.Numberformat.Format = "@";
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
            progress_lbl.Text = e.UserState.ToString();
        }
        private async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Ensure progress bar visibility and reset
            progressBar1.Visible = false;
            progress_lbl.Visible = false;

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
            if (advancedDataGridView1.Rows.Count > 0)
            {
                // Use SaveFileDialog to let the user choose the save location
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.FileName = "MoldList.xlsx"; // Default file name

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Reset and show progress bar and label
                        progressBar1.Visible = true;
                        progressBar1.Value = 0; // Reset progress bar
                        progress_lbl.Visible = true;
                        progress_lbl.Text = "Starting export...";

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

        private void advancedDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //advancedDataGridView1.Columns["LastUsedDate"].Visible = false;
            //advancedDataGridView1.Columns["Location"].Visible = false; 
        }
    }
}
