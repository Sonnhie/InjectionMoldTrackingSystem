namespace MoldMonitoringSystem_Nidec.Forms
{
    partial class UpdateMoldData
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
            this.label1 = new System.Windows.Forms.Label();
            this.part_code = new System.Windows.Forms.TextBox();
            this.mold_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.part_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.die_number = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(58, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part Number:";
            // 
            // part_code
            // 
            this.part_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.part_code.Location = new System.Drawing.Point(160, 51);
            this.part_code.Name = "part_code";
            this.part_code.Size = new System.Drawing.Size(310, 24);
            this.part_code.TabIndex = 1;
            this.part_code.TextChanged += new System.EventHandler(this.part_code_TextChanged);
            // 
            // mold_number
            // 
            this.mold_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mold_number.Location = new System.Drawing.Point(160, 102);
            this.mold_number.Name = "mold_number";
            this.mold_number.Size = new System.Drawing.Size(310, 24);
            this.mold_number.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mold Number:";
            // 
            // part_name
            // 
            this.part_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.part_name.Location = new System.Drawing.Point(160, 153);
            this.part_name.Name = "part_name";
            this.part_name.Size = new System.Drawing.Size(310, 24);
            this.part_name.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Die number:";
            // 
            // customer
            // 
            this.customer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customer.FormattingEnabled = true;
            this.customer.Items.AddRange(new object[] {
            "BIPH",
            "CBMP",
            "EPPI",
            "EXCELITAS",
            "IMI",
            "IVOCLAR",
            "JCM",
            "NIDEC",
            "Yazaki",
            "ZAMA"});
            this.customer.Location = new System.Drawing.Point(160, 255);
            this.customer.Name = "customer";
            this.customer.Size = new System.Drawing.Size(310, 26);
            this.customer.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Part Name:";
            // 
            // die_number
            // 
            this.die_number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.die_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.die_number.FormattingEnabled = true;
            this.die_number.Items.AddRange(new object[] {
            "D1",
            "D2",
            "D3"});
            this.die_number.Location = new System.Drawing.Point(160, 203);
            this.die_number.Name = "die_number";
            this.die_number.Size = new System.Drawing.Size(310, 26);
            this.die_number.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Customer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(97, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Status:";
            // 
            // status
            // 
            this.status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.FormattingEnabled = true;
            this.status.Items.AddRange(new object[] {
            "Active",
            "End of life"});
            this.status.Location = new System.Drawing.Point(160, 305);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(310, 26);
            this.status.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 46);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(381, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 46);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateMoldData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(535, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.die_number);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customer);
            this.Controls.Add(this.part_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mold_number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.part_code);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateMoldData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Mold Data";
            this.Load += new System.EventHandler(this.UpdateMoldData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox part_code;
        private System.Windows.Forms.TextBox mold_number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox part_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox customer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox die_number;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}