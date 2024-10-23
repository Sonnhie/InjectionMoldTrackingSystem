using MoldMonitoringSystem_Nidec.Class;
using MoldMonitoringSystem_Nidec.EndUserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class Dashboard : Form
    {
        private readonly MoldDataBaseServiceUtility _moldDataBaseServiceUtility = new MoldDataBaseServiceUtility();
        private string _section;
        public Dashboard(string section)
        {
            InitializeComponent();
            _section = section;
        }

        private void InventoryDashboard_Load(object sender, EventArgs e)
        {
            LoadThemeUtility.LoadTheme(this);
            DisplayIdleMoldToListView();
            GetCounts(); 
            populateChart1();
           
        }
        private void GetCounts()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";

            DashboardUtility inventory = new DashboardUtility(connectionString);
            var InactiveMolds = _moldDataBaseServiceUtility.GetIdleMold();

            int TotalMold = inventory.GetTotalMolds();
            int EolMolds = inventory.GetEndofLifeMolds();
            int ActiveMold = inventory.GetActiveMolds();
            int IdleMold = InactiveMolds.Count;

            int ActiveMoldFinal = TotalMold - EolMolds - IdleMold;

            lbl_total_molds.Text = inventory.GetTotalMolds().ToString();
            lbl_active_molds.Text = ActiveMoldFinal.ToString();
            lbl_eol_molds.Text = inventory.GetEndofLifeMolds().ToString();
            inactive_lbl.Text = InactiveMolds.Count.ToString();
        }
        private void AlertIdleMolds()
        {
            var idleMolds = _moldDataBaseServiceUtility.GetIdleMold();

           DialogResult result = MessageBox.Show($"Total Inactive Molds: {idleMolds.Count} " , "Inactive Molds", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ConfigureChartArea()
        {
            chart2.Series.Clear();
            chart2.ChartAreas.Clear();
            chart2.Titles.Clear();
            ChartArea chartArea = new ChartArea();
            chart2.ChartAreas.Add(chartArea);
            chart2.Titles.Add("Mold Inventory Status");
            chart2.Titles[0].Font = new System.Drawing.Font("Arial", 14F); // Title font size
            chartArea.AxisX.MajorGrid.Enabled = false; // Hide X-axis major gridlines
            chartArea.AxisY.MajorGrid.Enabled = false; // Hide Y-axis major gridlines
            chartArea.BackColor = Color.Transparent;
        }
        private void populateChart1()
        {
            string connectionString = "Data Source=192.168.101.41;Initial Catalog=MoldTrackingSystem;User ID=Administrator;Encrypt=False";
            DashboardUtility inventory = new DashboardUtility(connectionString);

            int TotalMoldRepair = inventory.GetTotalMoldRepair();
            int TotalMoldPreparation = inventory.GetTotalMoldpreperation();
            int TotalMoldSetup = inventory.GetTotalMoldSetup();
            int TotalEndofSchedule = inventory.GetTotalEndOfSchedule();

            ConfigureChartArea();

            Series series = new Series("Molds")
            {
                ChartType = SeriesChartType.Column
                
            };
            chart2.Series.Add(series);

            chart2.Series["Molds"].Points.AddXY("Mold Preparation", TotalMoldPreparation);
            chart2.Series["Molds"].Points.AddXY("Mold Repair", TotalMoldRepair);
            chart2.Series["Molds"].Points.AddXY("Mold Setup", TotalMoldSetup);
            chart2.Series["Molds"].Points.AddXY("End of Schedule", TotalEndofSchedule);

            series.IsValueShownAsLabel = true;
            series.IsVisibleInLegend = true;
            series.Color = Color.Green;
            series.BorderWidth = 0; // Removes border lines
            series.BorderColor = System.Drawing.Color.Transparent; // Ensure border color is transparent
            series["PointWidth"] = "0.5";
            
            // Set data label properties
            series.IsValueShownAsLabel = true;
           
            foreach (DataPoint point in series.Points)
            {
                point.Label = point.YValues[0].ToString(); // Set label to value
                point.LabelForeColor = Color.Black;    
                point.LabelAngle = 0; // Ensure labels are not rotated
                
            }

        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            var idleMolds = _moldDataBaseServiceUtility.GetIdleMold();

            if (_section == "Mold" || _section == "PCD")
            {
                if (idleMolds.Count > 0)
                {
                    AlertIdleMolds();
                }
            } 
        }
        private void DisplayIdleMoldToListView()
        {
            listView1.Items.Clear();

            var idleMolds = _moldDataBaseServiceUtility.GetIdleMold();

            foreach (var idleMold in idleMolds)
            {
                ListViewItem MoldNumber = new ListViewItem(idleMold.MoldNumber);

                MoldNumber.ForeColor = Color.Red;

               

                MoldNumber.SubItems.Add(idleMold.Location);
                MoldNumber.SubItems.Add(idleMold.Status);
                MoldNumber.SubItems.Add(idleMold.DateCreated);
                MoldNumber.SubItems.Add(idleMold.LastUsedDate.ToString("yyyy-MM-dd HH:mm:ss"));
                listView1.Items.Add(MoldNumber);

            }
            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2;
            }
        }

    }
}
