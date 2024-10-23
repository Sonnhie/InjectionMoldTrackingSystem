namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    partial class MoldmasterList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_export = new System.Windows.Forms.Button();
            this.progress_lbl = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.moldMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moldTrackingSystemDataSet4 = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet4();
            this.moldMasterTableAdapter = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet4TableAdapters.MoldMasterTableAdapter();
            this.moldnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materialNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dienoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datecreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timecreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 407);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(642, 32);
            this.progressBar1.TabIndex = 1;
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.Location = new System.Drawing.Point(660, 407);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(128, 32);
            this.btn_export.TabIndex = 2;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // progress_lbl
            // 
            this.progress_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progress_lbl.AutoSize = true;
            this.progress_lbl.BackColor = System.Drawing.Color.Transparent;
            this.progress_lbl.Location = new System.Drawing.Point(351, 442);
            this.progress_lbl.Name = "progress_lbl";
            this.progress_lbl.Size = new System.Drawing.Size(10, 13);
            this.progress_lbl.TabIndex = 3;
            this.progress_lbl.Text = " ";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.moldnoDataGridViewTextBoxColumn,
            this.materialDataGridViewTextBoxColumn,
            this.materialNameDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.dienoDataGridViewTextBoxColumn,
            this.datecreatedDataGridViewTextBoxColumn,
            this.timecreatedDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.advancedDataGridView1.DataSource = this.moldMasterBindingSource;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(12, 12);
            this.advancedDataGridView1.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(776, 389);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 4;
            this.advancedDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellClick);
            this.advancedDataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridView1_DataBindingComplete);
            // 
            // moldMasterBindingSource
            // 
            this.moldMasterBindingSource.DataMember = "MoldMaster";
            this.moldMasterBindingSource.DataSource = this.moldTrackingSystemDataSet4;
            // 
            // moldTrackingSystemDataSet4
            // 
            this.moldTrackingSystemDataSet4.DataSetName = "MoldTrackingSystemDataSet4";
            this.moldTrackingSystemDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // moldMasterTableAdapter
            // 
            this.moldMasterTableAdapter.ClearBeforeFill = true;
            // 
            // moldnoDataGridViewTextBoxColumn
            // 
            this.moldnoDataGridViewTextBoxColumn.DataPropertyName = "Mold_no";
            this.moldnoDataGridViewTextBoxColumn.HeaderText = "Mold_no";
            this.moldnoDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.moldnoDataGridViewTextBoxColumn.Name = "moldnoDataGridViewTextBoxColumn";
            this.moldnoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // materialDataGridViewTextBoxColumn
            // 
            this.materialDataGridViewTextBoxColumn.DataPropertyName = "Material";
            this.materialDataGridViewTextBoxColumn.HeaderText = "Material";
            this.materialDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.materialDataGridViewTextBoxColumn.Name = "materialDataGridViewTextBoxColumn";
            this.materialDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // materialNameDataGridViewTextBoxColumn
            // 
            this.materialNameDataGridViewTextBoxColumn.DataPropertyName = "Material_Name";
            this.materialNameDataGridViewTextBoxColumn.HeaderText = "Material_Name";
            this.materialNameDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.materialNameDataGridViewTextBoxColumn.Name = "materialNameDataGridViewTextBoxColumn";
            this.materialNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // dienoDataGridViewTextBoxColumn
            // 
            this.dienoDataGridViewTextBoxColumn.DataPropertyName = "Die_no";
            this.dienoDataGridViewTextBoxColumn.HeaderText = "Die_no";
            this.dienoDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.dienoDataGridViewTextBoxColumn.Name = "dienoDataGridViewTextBoxColumn";
            this.dienoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // datecreatedDataGridViewTextBoxColumn
            // 
            this.datecreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_created";
            this.datecreatedDataGridViewTextBoxColumn.HeaderText = "Date_created";
            this.datecreatedDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.datecreatedDataGridViewTextBoxColumn.Name = "datecreatedDataGridViewTextBoxColumn";
            this.datecreatedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // timecreatedDataGridViewTextBoxColumn
            // 
            this.timecreatedDataGridViewTextBoxColumn.DataPropertyName = "Time_created";
            this.timecreatedDataGridViewTextBoxColumn.HeaderText = "Time_created";
            this.timecreatedDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.timecreatedDataGridViewTextBoxColumn.Name = "timecreatedDataGridViewTextBoxColumn";
            this.timecreatedDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 24;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // MoldmasterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.progress_lbl);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.progressBar1);
            this.Name = "MoldmasterList";
            this.Text = "Mold Master List";
            this.Load += new System.EventHandler(this.MoldmasterList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Label progress_lbl;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private MoldTrackingSystemDataSet4 moldTrackingSystemDataSet4;
        private System.Windows.Forms.BindingSource moldMasterBindingSource;
        private MoldTrackingSystemDataSet4TableAdapters.MoldMasterTableAdapter moldMasterTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn moldnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn materialNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dienoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datecreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timecreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}