namespace MoldMonitoringSystem_Nidec.Forms
{
    partial class MachineQR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineQR));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmb_line = new System.Windows.Forms.ComboBox();
            this.equipmentMasterlistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moldTrackingSystemDataSet2 = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_machineno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.equipmentMasterlistTableAdapter = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet2TableAdapters.EquipmentMasterlistTableAdapter();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentMasterlistBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.cmb_line);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_machineno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 450);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Mold QR Code";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(79, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 34);
            this.button2.TabIndex = 29;
            this.button2.Text = "Print QR Code";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmb_line
            // 
            this.cmb_line.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_line.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmb_line.DataSource = this.equipmentMasterlistBindingSource;
            this.cmb_line.DisplayMember = "Equipment";
            this.cmb_line.FormattingEnabled = true;
            this.cmb_line.Location = new System.Drawing.Point(134, 36);
            this.cmb_line.Name = "cmb_line";
            this.cmb_line.Size = new System.Drawing.Size(148, 24);
            this.cmb_line.TabIndex = 31;
            this.cmb_line.TextChanged += new System.EventHandler(this.cmb_line_TextChanged);
            // 
            // equipmentMasterlistBindingSource
            // 
            this.equipmentMasterlistBindingSource.DataMember = "EquipmentMasterlist";
            this.equipmentMasterlistBindingSource.DataSource = this.moldTrackingSystemDataSet2;
            // 
            // moldTrackingSystemDataSet2
            // 
            this.moldTrackingSystemDataSet2.DataSetName = "MoldTrackingSystemDataSet2";
            this.moldTrackingSystemDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(79, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 141);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Equiment Name:";
            // 
            // txt_machineno
            // 
            this.txt_machineno.Location = new System.Drawing.Point(134, 90);
            this.txt_machineno.Name = "txt_machineno";
            this.txt_machineno.ReadOnly = true;
            this.txt_machineno.Size = new System.Drawing.Size(148, 22);
            this.txt_machineno.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(42, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Machine no:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // equipmentMasterlistTableAdapter
            // 
            this.equipmentMasterlistTableAdapter.ClearBeforeFill = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(330, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 426);
            this.panel1.TabIndex = 28;
            // 
            // MachineQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MachineQR";
            this.Text = "Machine QR";
            this.Load += new System.EventHandler(this.MachineQR_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentMasterlistBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmb_line;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_machineno;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private MoldTrackingSystemDataSet2 moldTrackingSystemDataSet2;
        private System.Windows.Forms.BindingSource equipmentMasterlistBindingSource;
        private MoldTrackingSystemDataSet2TableAdapters.EquipmentMasterlistTableAdapter equipmentMasterlistTableAdapter;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Panel panel1;
    }
}