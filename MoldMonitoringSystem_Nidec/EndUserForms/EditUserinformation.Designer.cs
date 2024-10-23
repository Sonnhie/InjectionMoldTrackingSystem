namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    partial class EditUserinformation
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
            this.label4 = new System.Windows.Forms.Label();
            this.combo_section = new System.Windows.Forms.ComboBox();
            this.combo_role = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.employeename_txtbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userid_textbox = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 15;
            this.label4.Text = "Section:";
            // 
            // combo_section
            // 
            this.combo_section.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.combo_section.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_section.FormattingEnabled = true;
            this.combo_section.Items.AddRange(new object[] {
            "I.T",
            "Injection",
            "Mold",
            "PCD"});
            this.combo_section.Location = new System.Drawing.Point(193, 214);
            this.combo_section.Name = "combo_section";
            this.combo_section.Size = new System.Drawing.Size(334, 21);
            this.combo_section.TabIndex = 14;
            // 
            // combo_role
            // 
            this.combo_role.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.combo_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_role.FormattingEnabled = true;
            this.combo_role.Items.AddRange(new object[] {
            "User",
            "Administrator"});
            this.combo_role.Location = new System.Drawing.Point(193, 172);
            this.combo_role.Name = "combo_role";
            this.combo_role.Size = new System.Drawing.Size(334, 21);
            this.combo_role.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "User Role:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Employee Name:";
            // 
            // employeename_txtbox
            // 
            this.employeename_txtbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.employeename_txtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeename_txtbox.Location = new System.Drawing.Point(193, 131);
            this.employeename_txtbox.Name = "employeename_txtbox";
            this.employeename_txtbox.Size = new System.Drawing.Size(334, 24);
            this.employeename_txtbox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "User Id:";
            // 
            // userid_textbox
            // 
            this.userid_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userid_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userid_textbox.Location = new System.Drawing.Point(193, 87);
            this.userid_textbox.Name = "userid_textbox";
            this.userid_textbox.Size = new System.Drawing.Size(334, 24);
            this.userid_textbox.TabIndex = 8;
            this.userid_textbox.TextChanged += new System.EventHandler(this.userid_textbox_TextChanged);
            // 
            // submit_btn
            // 
            this.submit_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submit_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.Location = new System.Drawing.Point(334, 326);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(193, 45);
            this.submit_btn.TabIndex = 16;
            this.submit_btn.Text = "Update Info";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // EditUserinformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(659, 431);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.combo_section);
            this.Controls.Add(this.combo_role);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.employeename_txtbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userid_textbox);
            this.Name = "EditUserinformation";
            this.Text = "Edit User information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_section;
        private System.Windows.Forms.ComboBox combo_role;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox employeename_txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userid_textbox;
        private System.Windows.Forms.Button submit_btn;
    }
}