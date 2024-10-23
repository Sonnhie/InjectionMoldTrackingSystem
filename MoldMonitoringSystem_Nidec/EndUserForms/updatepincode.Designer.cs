namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    partial class updatepincode
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
            this.txt_new_pincode = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.confirm_pincode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.warning_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_new_pincode
            // 
            this.txt_new_pincode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_new_pincode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_new_pincode.Location = new System.Drawing.Point(181, 75);
            this.txt_new_pincode.Name = "txt_new_pincode";
            this.txt_new_pincode.Size = new System.Drawing.Size(202, 24);
            this.txt_new_pincode.TabIndex = 1;
            this.txt_new_pincode.UseSystemPasswordChar = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(389, 82);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(95, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Show Pincode";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // confirm_pincode
            // 
            this.confirm_pincode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirm_pincode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_pincode.Location = new System.Drawing.Point(181, 117);
            this.confirm_pincode.Name = "confirm_pincode";
            this.confirm_pincode.Size = new System.Drawing.Size(202, 24);
            this.confirm_pincode.TabIndex = 4;
            this.confirm_pincode.UseSystemPasswordChar = true;
            this.confirm_pincode.TextChanged += new System.EventHandler(this.confirm_pincode_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter New Pincode:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Confirm New Pincode:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(222, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(358, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 34);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // warning_lbl
            // 
            this.warning_lbl.AutoSize = true;
            this.warning_lbl.ForeColor = System.Drawing.Color.Red;
            this.warning_lbl.Location = new System.Drawing.Point(178, 153);
            this.warning_lbl.Name = "warning_lbl";
            this.warning_lbl.Size = new System.Drawing.Size(131, 13);
            this.warning_lbl.TabIndex = 10;
            this.warning_lbl.Text = " Pincode did not marched!";
            this.warning_lbl.TextChanged += new System.EventHandler(this.warning_lbl_TextChanged);
            // 
            // updatepincode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(514, 288);
            this.Controls.Add(this.warning_lbl);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.confirm_pincode);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.txt_new_pincode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "updatepincode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Pincode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_new_pincode;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox confirm_pincode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label warning_lbl;
    }
}