namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    partial class RegisterNewPincode
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
            this.pincode_txt = new System.Windows.Forms.TextBox();
            this.confirmpin_txt = new System.Windows.Forms.TextBox();
            this.section_combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.warning_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.username_combo = new System.Windows.Forms.ComboBox();
            this.moldTrackingSystemDataSet5 = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet5();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usersTableAdapter = new MoldMonitoringSystem_Nidec.MoldTrackingSystemDataSet5TableAdapters.UsersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pincode_txt
            // 
            this.pincode_txt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pincode_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pincode_txt.Location = new System.Drawing.Point(165, 132);
            this.pincode_txt.Name = "pincode_txt";
            this.pincode_txt.Size = new System.Drawing.Size(245, 24);
            this.pincode_txt.TabIndex = 0;
            this.pincode_txt.UseSystemPasswordChar = true;
            // 
            // confirmpin_txt
            // 
            this.confirmpin_txt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmpin_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpin_txt.Location = new System.Drawing.Point(165, 178);
            this.confirmpin_txt.Name = "confirmpin_txt";
            this.confirmpin_txt.Size = new System.Drawing.Size(245, 24);
            this.confirmpin_txt.TabIndex = 1;
            this.confirmpin_txt.UseSystemPasswordChar = true;
            this.confirmpin_txt.TextChanged += new System.EventHandler(this.confirmpin_txt_TextChanged);
            // 
            // section_combo
            // 
            this.section_combo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.section_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.section_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.section_combo.FormattingEnabled = true;
            this.section_combo.Items.AddRange(new object[] {
            "Injection",
            "Mold",
            "I.T"});
            this.section_combo.Location = new System.Drawing.Point(165, 87);
            this.section_combo.Name = "section_combo";
            this.section_combo.Size = new System.Drawing.Size(121, 26);
            this.section_combo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Enter Pin Code:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirm Pin Code:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Section:";
            // 
            // warning_label
            // 
            this.warning_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.warning_label.AutoSize = true;
            this.warning_label.ForeColor = System.Drawing.Color.Red;
            this.warning_label.Location = new System.Drawing.Point(162, 215);
            this.warning_label.Name = "warning_label";
            this.warning_label.Size = new System.Drawing.Size(128, 13);
            this.warning_label.TabIndex = 6;
            this.warning_label.Text = "Pincode did not matched!";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(283, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(406, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(416, 139);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Show Pincode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Username:";
            // 
            // username_combo
            // 
            this.username_combo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.username_combo.DataSource = this.usersBindingSource;
            this.username_combo.DisplayMember = "username";
            this.username_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.username_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_combo.FormattingEnabled = true;
            this.username_combo.Location = new System.Drawing.Point(165, 42);
            this.username_combo.Name = "username_combo";
            this.username_combo.Size = new System.Drawing.Size(121, 26);
            this.username_combo.TabIndex = 12;
            this.username_combo.ValueMember = "username";
            // 
            // moldTrackingSystemDataSet5
            // 
            this.moldTrackingSystemDataSet5.DataSetName = "MoldTrackingSystemDataSet5";
            this.moldTrackingSystemDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.moldTrackingSystemDataSet5;
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // RegisterNewPincode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(546, 335);
            this.Controls.Add(this.username_combo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.warning_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.section_combo);
            this.Controls.Add(this.confirmpin_txt);
            this.Controls.Add(this.pincode_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegisterNewPincode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Register New Pincode";
            this.Load += new System.EventHandler(this.RegisterNewPincode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.moldTrackingSystemDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pincode_txt;
        private System.Windows.Forms.TextBox confirmpin_txt;
        private System.Windows.Forms.ComboBox section_combo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label warning_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox username_combo;
        private MoldTrackingSystemDataSet5 moldTrackingSystemDataSet5;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private MoldTrackingSystemDataSet5TableAdapters.UsersTableAdapter usersTableAdapter;
    }
}