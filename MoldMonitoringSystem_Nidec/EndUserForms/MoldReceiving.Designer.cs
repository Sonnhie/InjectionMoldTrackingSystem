namespace MoldMonitoringSystem_Nidec.Forms
{
    partial class MoldReceiving
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_partnumber = new System.Windows.Forms.TextBox();
            this.txt_moldnumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_status = new System.Windows.Forms.ComboBox();
            this.txt_customer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.cmb_dienumber = new System.Windows.Forms.TextBox();
            this.txt_location = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(470, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(638, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Part Number:";
            // 
            // txt_partnumber
            // 
            this.txt_partnumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_partnumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_partnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_partnumber.Location = new System.Drawing.Point(111, 40);
            this.txt_partnumber.Name = "txt_partnumber";
            this.txt_partnumber.ReadOnly = true;
            this.txt_partnumber.Size = new System.Drawing.Size(228, 24);
            this.txt_partnumber.TabIndex = 3;
            // 
            // txt_moldnumber
            // 
            this.txt_moldnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_moldnumber.Location = new System.Drawing.Point(111, 122);
            this.txt_moldnumber.Name = "txt_moldnumber";
            this.txt_moldnumber.Size = new System.Drawing.Size(228, 24);
            this.txt_moldnumber.TabIndex = 4;
            this.txt_moldnumber.TextChanged += new System.EventHandler(this.txt_moldnumber_TextChanged);
            this.txt_moldnumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_moldnumber_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(35, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mold No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(30, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(26, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Remarks:";
            // 
            // txt_remarks
            // 
            this.txt_remarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.Location = new System.Drawing.Point(111, 296);
            this.txt_remarks.Multiline = true;
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(228, 115);
            this.txt_remarks.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(44, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Status:";
            // 
            // cmb_status
            // 
            this.cmb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_status.FormattingEnabled = true;
            this.cmb_status.Items.AddRange(new object[] {
            "Mold Preparation",
            "Mold Issuance",
            "Mold Endorsement",
            "Mold Maintenance",
            "Outside (Subcon)"});
            this.cmb_status.Location = new System.Drawing.Point(111, 206);
            this.cmb_status.Name = "cmb_status";
            this.cmb_status.Size = new System.Drawing.Size(228, 26);
            this.cmb_status.TabIndex = 16;
            // 
            // txt_customer
            // 
            this.txt_customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_customer.Location = new System.Drawing.Point(111, 164);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.ReadOnly = true;
            this.txt_customer.Size = new System.Drawing.Size(228, 24);
            this.txt_customer.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(27, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Customer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Die number:";
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
            this.advancedDataGridView1.Location = new System.Drawing.Point(358, 40);
            this.advancedDataGridView1.MaxFilterButtonImageHeight = 23;
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(430, 330);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 20;
            // 
            // cmb_dienumber
            // 
            this.cmb_dienumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_dienumber.Location = new System.Drawing.Point(111, 79);
            this.cmb_dienumber.Name = "cmb_dienumber";
            this.cmb_dienumber.ReadOnly = true;
            this.cmb_dienumber.Size = new System.Drawing.Size(228, 24);
            this.cmb_dienumber.TabIndex = 21;
            // 
            // txt_location
            // 
            this.txt_location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txt_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_location.FormattingEnabled = true;
            this.txt_location.Items.AddRange(new object[] {
            "Mold Storage Area (Rack)",
            "Mold Storage Area (Floor)",
            "Mold Outgoing Area (Rack)",
            "Mold Outgoing Area (Floor)",
            "Mold Receiving Area",
            "Mold Maintenance Area",
            "Outside Area"});
            this.txt_location.Location = new System.Drawing.Point(111, 250);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(228, 26);
            this.txt_location.TabIndex = 22;
            // 
            // MoldReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.cmb_dienumber);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_remarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_customer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_moldnumber);
            this.Controls.Add(this.txt_partnumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MoldReceiving";
            this.Text = "Mold Monitoring";
            this.Load += new System.EventHandler(this.MoldReceiving_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_partnumber;
        private System.Windows.Forms.TextBox txt_moldnumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_status;
        private System.Windows.Forms.TextBox txt_customer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.TextBox cmb_dienumber;
        private System.Windows.Forms.ComboBox txt_location;
    }
}