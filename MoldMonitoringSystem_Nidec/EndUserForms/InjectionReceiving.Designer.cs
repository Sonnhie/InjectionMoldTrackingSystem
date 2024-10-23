using Zuby.ADGV;

namespace MoldMonitoringSystem_Nidec.Forms
{
    partial class InjectionReceiving
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
            this.label7 = new System.Windows.Forms.Label();
            this.txt_shotcount = new System.Windows.Forms.TextBox();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_customer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_moldno = new System.Windows.Forms.TextBox();
            this.txt_partnumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cmb_die = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.equipmentMasterlistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moldTrackingSystemDataSet2 = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet2();
            this.equipmentMasterlistTableAdapter = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet2TableAdapters.EquipmentMasterlistTableAdapter();
            this.txt_location = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentMasterlistBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 36;
            this.label7.Text = "Shot count:";
            // 
            // txt_shotcount
            // 
            this.txt_shotcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_shotcount.Location = new System.Drawing.Point(104, 287);
            this.txt_shotcount.Name = "txt_shotcount";
            this.txt_shotcount.Size = new System.Drawing.Size(228, 24);
            this.txt_shotcount.TabIndex = 35;
            // 
            // cmb_status
            // 
            this.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Items.AddRange(new object[] {
            "Mold Set-up(Start Set-up)",
            "Mold Set-up(End Set-up)",
            "End-of-schedule(Standby at machine)",
            "End-of-schedule(Downmold)"});
            this.cmb_status.Location = new System.Drawing.Point(104, 200);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(228, 26);
            this.cmb_status.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(37, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Remarks:";
            // 
            // txt_remarks
            // 
            this.txt_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.Location = new System.Drawing.Point(104, 325);
            this.txt_remarks.Multiline = true;
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(228, 80);
            this.txt_remarks.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Customer";
            // 
            // txt_customer
            // 
            this.txt_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_customer.Location = new System.Drawing.Point(104, 158);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.ReadOnly = true;
            this.txt_customer.Size = new System.Drawing.Size(228, 24);
            this.txt_customer.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(28, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mold No:";
            // 
            // txt_moldno
            // 
            this.txt_moldno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_moldno.Location = new System.Drawing.Point(104, 116);
            this.txt_moldno.Name = "txt_moldno";
            this.txt_moldno.Size = new System.Drawing.Size(228, 24);
            this.txt_moldno.TabIndex = 24;
            this.txt_moldno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_moldno_KeyDown);
            // 
            // txt_partnumber
            // 
            this.txt_partnumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_partnumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_partnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_partnumber.Location = new System.Drawing.Point(104, 35);
            this.txt_partnumber.Name = "txt_partnumber";
            this.txt_partnumber.ReadOnly = true;
            this.txt_partnumber.Size = new System.Drawing.Size(228, 24);
            this.txt_partnumber.TabIndex = 23;
            this.txt_partnumber.TextChanged += new System.EventHandler(this.txt_partnumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Part Number:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(463, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 34);
            this.button1.TabIndex = 20;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.GridColor = System.Drawing.Color.Blue;
            this.advancedDataGridView1.Location = new System.Drawing.Point(353, 39);
            this.advancedDataGridView1.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(422, 331);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(28, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 16);
            this.label8.TabIndex = 39;
            this.label8.Text = "Die No:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(631, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 34);
            this.button2.TabIndex = 21;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmb_die
            // 
            this.cmb_die.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_die.Location = new System.Drawing.Point(104, 80);
            this.cmb_die.Name = "cmb_die";
            this.cmb_die.ReadOnly = true;
            this.cmb_die.Size = new System.Drawing.Size(228, 24);
            this.cmb_die.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(350, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 16);
            this.label9.TabIndex = 41;
            this.label9.Text = "Transaction Logs";
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
            // equipmentMasterlistTableAdapter
            // 
            this.equipmentMasterlistTableAdapter.ClearBeforeFill = true;
            // 
            // txt_location
            // 
            this.txt_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_location.Location = new System.Drawing.Point(104, 241);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(228, 24);
            this.txt_location.TabIndex = 42;
            this.txt_location.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_location_KeyDown);
            // 
            // InjectionReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmb_die);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_shotcount);
            this.Controls.Add(this.cmb_status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_remarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_customer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_moldno);
            this.Controls.Add(this.txt_partnumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "InjectionReceiving";
            this.Text = "Injection Receiving";
            this.Load += new System.EventHandler(this.InjectionReceiving_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentMasterlistBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_shotcount;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_customer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_moldno;
        private System.Windows.Forms.TextBox txt_partnumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox cmb_die;
        private System.Windows.Forms.Label label9;
        private MoldTrackingSystemDataSet2 moldTrackingSystemDataSet2;
        private System.Windows.Forms.BindingSource equipmentMasterlistBindingSource;
        private MoldTrackingSystemDataSet2TableAdapters.EquipmentMasterlistTableAdapter equipmentMasterlistTableAdapter;
        private System.Windows.Forms.TextBox txt_location;
    }
}