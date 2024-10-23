namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    partial class AddUser
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showpass_chckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.password_text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_section = new System.Windows.Forms.ComboBox();
            this.combo_role = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.employeename_txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userid_textbox = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.showpass_chckbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.password_text);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.combo_section);
            this.groupBox1.Controls.Add(this.combo_role);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.employeename_txtbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.userid_textbox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(113, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 285);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registration";
            // 
            // showpass_chckbox
            // 
            this.showpass_chckbox.AutoSize = true;
            this.showpass_chckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showpass_chckbox.Location = new System.Drawing.Point(345, 224);
            this.showpass_chckbox.Name = "showpass_chckbox";
            this.showpass_chckbox.Size = new System.Drawing.Size(114, 19);
            this.showpass_chckbox.TabIndex = 10;
            this.showpass_chckbox.Text = "Show Password";
            this.showpass_chckbox.UseVisualStyleBackColor = true;
            this.showpass_chckbox.CheckedChanged += new System.EventHandler(this.showpass_chckbox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password:";
            // 
            // password_text
            // 
            this.password_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_text.Location = new System.Drawing.Point(143, 222);
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(193, 24);
            this.password_text.TabIndex = 8;
            this.password_text.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Section:";
            // 
            // combo_section
            // 
            this.combo_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_section.FormattingEnabled = true;
            this.combo_section.Items.AddRange(new object[] {
            "I.T",
            "Injection",
            "Mold",
            "PCD"});
            this.combo_section.Location = new System.Drawing.Point(143, 179);
            this.combo_section.Name = "combo_section";
            this.combo_section.Size = new System.Drawing.Size(334, 26);
            this.combo_section.TabIndex = 6;
            // 
            // combo_role
            // 
            this.combo_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_role.FormattingEnabled = true;
            this.combo_role.Items.AddRange(new object[] {
            "User",
            "Administrator"});
            this.combo_role.Location = new System.Drawing.Point(143, 137);
            this.combo_role.Name = "combo_role";
            this.combo_role.Size = new System.Drawing.Size(334, 26);
            this.combo_role.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "User Role:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Employee Name:";
            // 
            // employeename_txtbox
            // 
            this.employeename_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeename_txtbox.Location = new System.Drawing.Point(143, 96);
            this.employeename_txtbox.Name = "employeename_txtbox";
            this.employeename_txtbox.Size = new System.Drawing.Size(334, 24);
            this.employeename_txtbox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Id:";
            // 
            // userid_textbox
            // 
            this.userid_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userid_textbox.Location = new System.Drawing.Point(143, 52);
            this.userid_textbox.Name = "userid_textbox";
            this.userid_textbox.Size = new System.Drawing.Size(334, 24);
            this.userid_textbox.TabIndex = 0;
            // 
            // submit_btn
            // 
            this.submit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(458, 375);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(193, 45);
            this.submit_btn.TabIndex = 10;
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(702, 450);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add User account";
            this.Load += new System.EventHandler(this.AddUser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userid_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox employeename_txtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_section;
        private System.Windows.Forms.ComboBox combo_role;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.CheckBox showpass_chckbox;
    }
}