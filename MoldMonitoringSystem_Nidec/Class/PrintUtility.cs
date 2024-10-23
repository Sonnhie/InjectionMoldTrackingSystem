using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Class
{

    public class PrintUtility
    {
        private readonly string _connectionString;

        public PrintUtility()
        {
            _connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
        }
        public ListView GetPrintLogs(DateTime StartDate, DateTime EndDate, ListView listView)
        {
            if (listView.Columns.Count == 0)
            {
                listView.View = View.Details;
                listView.Columns.Add("Date", 100);
                listView.Columns.Add("Time", 100);
                listView.Columns.Add("Details", 500);
                listView.Columns.Add("User", 100);

            }

            string query = "SELECT Date, Time, [Content], [User] FROM PrintLogs WHERE Date BETWEEN @StartDate AND @EndDate";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StartDate", StartDate.ToString());
                        command.Parameters.AddWithValue("@EndDate", EndDate.ToString());

                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            listView.Items.Clear();

                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["Date"].ToString());
                                item.SubItems.Add(reader["Time"].ToString());
                                item.SubItems.Add(reader["[Content]"].ToString());
                                item.SubItems.Add(reader["[User]"].ToString());

                                // Add the item to the ListView
                                listView.Items.Add(item);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error loading data: {ex.Message}");
                    return null;
                }
            }
            return listView;
        }

        public static PrintDocument PrintImage(Image image, string labelText, Panel previewPanel)
        {
            if (image == null)
            {
                throw new ArgumentException(nameof(image), "Image cannot be null");
            }

            PrintDocument printDocument = new PrintDocument();
            PaperSize customPaperSize = new PaperSize("Custom", (int)(90 * 100 / 25.4), (int)(40 * 100 / 25.4)); // Convert mm to hundredths of an inch
            printDocument.DefaultPageSettings.PaperSize = customPaperSize;

            printDocument.PrintPage += (sender, e) => PrintPageHandler(sender, e, image, labelText, customPaperSize);

            try
            {
                // Create a PrintPreviewControl and embed it into the panel
                PrintPreviewControl printPreviewControl = new PrintPreviewControl
                {
                    Document = printDocument,
                    Dock = DockStyle.Fill,
                    Zoom = 1 // Adjust zoom level if needed
                };

                // Clear existing controls in the panel
                previewPanel.Controls.Clear();

                // Add the PrintPreviewControl to the panel
                previewPanel.Controls.Add(printPreviewControl);

            }
            catch (Exception ex)
            {
                // Handle exceptions related to printing
                Console.WriteLine("Error printing image: " + ex.Message);
            }
            return printDocument;
        }

        // The PrintPage event handler, which defines how the image and label will be printed
        private static void PrintPageHandler(object sender, PrintPageEventArgs e, Image image, string labelText, PaperSize paperSize)
        {
            int dpi = 300; // Set resolution for printing (300 DPI)

            // Detect the size of the paper in inches (width and height)
            float paperWidthInInches = paperSize.Width / 100.0f; // Convert from hundredths of an inch
            float paperHeightInInches = paperSize.Height / 100.0f;

            // Dynamically scale the QR code to fit the paper size (e.g., make it 50% of the paper's width)
            float qrCodeSizeInInches = paperWidthInInches * 0.08f; // 50% of the paper width

            // Convert QR code size to pixels based on DPI
            int qrCodeSizeInPixels = (int)(qrCodeSizeInInches * dpi);

            // Font and brush settings for label and title
            Font labelFont = new Font("Aptos Narrow", 7, FontStyle.Regular);
            Brush labelBrush = Brushes.Black;

            // Split the label by '/' or any other delimiter
            string[] labelLines = labelText.Split('/');

            // Fixed X position for QR code aligned to the left with some margin
            float qrCodeMargin = 15; // Margin from the left side
            float startX = qrCodeMargin;

            // Set Y position for QR code and label block near the bottom of the page
            float blockY = e.PageBounds.Height - qrCodeSizeInPixels - 40; // Keep it 120px from the bottom

            // Draw the title "NIPC" above the QR code and label
            Font titleFont = new Font("Arial", 8, FontStyle.Bold);
            Brush titleBrush = Brushes.Black;
            string title = "Nidec Instruments Philippine Corporation";

            // Measure the size of the title text to center it
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            float titleXPosition = (e.PageBounds.Width - titleSize.Width) / 2;
            float titleYPosition = blockY - 20; // Position above the block

            // Draw the title
            e.Graphics.DrawString(title, titleFont, titleBrush, new PointF(titleXPosition, titleYPosition));

            // Define the area to draw the QR code (aligned left with fixed margin)
            Rectangle qrCodeArea = new Rectangle((int)startX, (int)blockY, qrCodeSizeInPixels, qrCodeSizeInPixels);

            // Draw the QR code image
            e.Graphics.DrawImage(image, qrCodeArea);

            // Position the label to the right of the QR code
            float labelXPosition = startX + qrCodeSizeInPixels + 5; // Position next to QR code, 20px gap
            float labelYPosition = blockY; // Align with top of QR code

            // Draw each line of the label text
            foreach (string line in labelLines)
            {
                // Measure the size of the current line
                SizeF labelSize = e.Graphics.MeasureString(line, labelFont);

                // Draw the line of text next to the QR code
                e.Graphics.DrawString(line, labelFont, labelBrush, new PointF(labelXPosition, labelYPosition));

                // Move the Y position for the next line
                labelYPosition += labelSize.Height;
            }

            // Indicate that no more pages are needed
            e.HasMorePages = false;
        }
        
    }
}
