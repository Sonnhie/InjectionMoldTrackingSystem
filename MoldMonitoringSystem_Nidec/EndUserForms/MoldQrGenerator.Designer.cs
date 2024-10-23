namespace MoldMonitoringSystem_Nidec.Forms
{
    partial class MoldQrGenerator
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.die_txt = new System.Windows.Forms.ComboBox();
            this.partnumber_txt = new System.Windows.Forms.ComboBox();
            this.moldMasterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moldTrackingSystemDataSet3 = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet3();
            this.customer_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moldnumber_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.print_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.moldMasterTableAdapter = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet3TableAdapters.MoldMasterTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moldMasterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.die_txt);
            this.groupBox1.Controls.Add(this.partnumber_txt);
            this.groupBox1.Controls.Add(this.customer_txt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.moldnumber_txt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.print_button);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 487);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Mold QR Code";
            // 
            // die_txt
            // 
            this.die_txt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.die_txt.FormattingEnabled = true;
            this.die_txt.Items.AddRange(new object[] {
            "D1",
            "D2",
            "D3"});
            this.die_txt.Location = new System.Drawing.Point(124, 91);
            this.die_txt.Name = "die_txt";
            this.die_txt.Size = new System.Drawing.Size(148, 24);
            this.die_txt.TabIndex = 37;
            this.die_txt.TextChanged += new System.EventHandler(this.die_txt_TextChanged);
            // 
            // partnumber_txt
            // 
            this.partnumber_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.partnumber_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.partnumber_txt.DataSource = this.moldMasterBindingSource;
            this.partnumber_txt.DisplayMember = "Material";
            this.partnumber_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partnumber_txt.FormattingEnabled = true;
            this.partnumber_txt.IntegralHeight = false;
            this.partnumber_txt.Location = new System.Drawing.Point(124, 41);
            this.partnumber_txt.Name = "partnumber_txt";
            this.partnumber_txt.Size = new System.Drawing.Size(148, 26);
            this.partnumber_txt.TabIndex = 36;
            this.partnumber_txt.ValueMember = "Material";
            this.partnumber_txt.TextChanged += new System.EventHandler(this.partnumber_txt_TextChanged_1);
            // 
            // moldMasterBindingSource
            // 
            this.moldMasterBindingSource.DataMember = "MoldMaster";
            this.moldMasterBindingSource.DataSource = this.moldTrackingSystemDataSet3;
            // 
            // moldTrackingSystemDataSet3
            // 
            this.moldTrackingSystemDataSet3.DataSetName = "MoldTrackingSystemDataSet3";
            this.moldTrackingSystemDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customer_txt
            // 
            this.customer_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer_txt.Location = new System.Drawing.Point(124, 165);
            this.customer_txt.Name = "customer_txt";
            this.customer_txt.Size = new System.Drawing.Size(148, 24);
            this.customer_txt.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(51, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Customer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(39, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 16);
            this.label3.TabIndex = 32;
            this.label3.Text = "Die number:";
            // 
            // moldnumber_txt
            // 
            this.moldnumber_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moldnumber_txt.Location = new System.Drawing.Point(124, 126);
            this.moldnumber_txt.Name = "moldnumber_txt";
            this.moldnumber_txt.Size = new System.Drawing.Size(148, 24);
            this.moldnumber_txt.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Mold Number:";
            // 
            // print_button
            // 
            this.print_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.print_button.Location = new System.Drawing.Point(95, 235);
            this.print_button.Name = "print_button";
            this.print_button.Size = new System.Drawing.Size(177, 34);
            this.print_button.TabIndex = 29;
            this.print_button.Text = "Print QR Code";
            this.print_button.UseVisualStyleBackColor = true;
            this.print_button.Click += new System.EventHandler(this.print_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(95, 275);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 149);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Part Number:";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // moldMasterTableAdapter
            // 
            this.moldMasterTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(393, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 478);
            this.panel1.TabIndex = 29;
            // 
            // MoldQrGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MoldQrGenerator";
            this.Text = "Mold Qr Generator";
            this.Load += new System.EventHandler(this.MoldQrGenerator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moldMasterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button print_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox moldnumber_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox customer_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ComboBox partnumber_txt;
        private MoldTrackingSystemDataSet3 moldTrackingSystemDataSet3;
        private System.Windows.Forms.BindingSource moldMasterBindingSource;
        private MoldTrackingSystemDataSet3TableAdapters.MoldMasterTableAdapter moldMasterTableAdapter;
        private System.Windows.Forms.ComboBox die_txt;
        private System.Windows.Forms.Panel panel1;
    }
}