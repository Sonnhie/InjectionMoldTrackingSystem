namespace MoldMonitoringSystem_Nidec
{
    partial class AdministratorManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministratorManagement));
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btn_adduser = new System.Windows.Forms.Button();
            this.lbl_section = new System.Windows.Forms.Label();
            this.lbl_employeename = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Panel_logo = new System.Windows.Forms.Panel();
            this.Lbl_logo = new System.Windows.Forms.Label();
            this.panel_title = new System.Windows.Forms.Panel();
            this.lbl_time = new System.Windows.Forms.Label();
            this.Lbl_title = new System.Windows.Forms.Label();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.Print_Logs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_pincode = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_updateuser = new System.Windows.Forms.Button();
            this.panel_desktopform = new System.Windows.Forms.Panel();
            this.Panel_logo.SuspendLayout();
            this.panel_title.SuspendLayout();
            this.panel_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(487, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Employee Name:";
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 594);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(262, 48);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "     Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btn_adduser
            // 
            this.btn_adduser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_adduser.FlatAppearance.BorderSize = 0;
            this.btn_adduser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adduser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adduser.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_adduser.Image = ((System.Drawing.Image)(resources.GetObject("btn_adduser.Image")));
            this.btn_adduser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_adduser.Location = new System.Drawing.Point(0, 80);
            this.btn_adduser.Name = "btn_adduser";
            this.btn_adduser.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_adduser.Size = new System.Drawing.Size(262, 48);
            this.btn_adduser.TabIndex = 1;
            this.btn_adduser.Text = "     Add User";
            this.btn_adduser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_adduser.UseVisualStyleBackColor = true;
            this.btn_adduser.Click += new System.EventHandler(this.btn__Click);
            // 
            // lbl_section
            // 
            this.lbl_section.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_section.AutoSize = true;
            this.lbl_section.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_section.ForeColor = System.Drawing.Color.White;
            this.lbl_section.Location = new System.Drawing.Point(623, 33);
            this.lbl_section.Name = "lbl_section";
            this.lbl_section.Size = new System.Drawing.Size(11, 16);
            this.lbl_section.TabIndex = 7;
            this.lbl_section.Text = " ";
            // 
            // lbl_employeename
            // 
            this.lbl_employeename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_employeename.AutoSize = true;
            this.lbl_employeename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_employeename.ForeColor = System.Drawing.Color.White;
            this.lbl_employeename.Location = new System.Drawing.Point(623, 9);
            this.lbl_employeename.Name = "lbl_employeename";
            this.lbl_employeename.Size = new System.Drawing.Size(11, 16);
            this.lbl_employeename.TabIndex = 6;
            this.lbl_employeename.Text = " ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(570, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(552, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Section:";
            // 
            // Panel_logo
            // 
            this.Panel_logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.Panel_logo.Controls.Add(this.Lbl_logo);
            this.Panel_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel_logo.Location = new System.Drawing.Point(0, 0);
            this.Panel_logo.Name = "Panel_logo";
            this.Panel_logo.Size = new System.Drawing.Size(262, 80);
            this.Panel_logo.TabIndex = 0;
            // 
            // Lbl_logo
            // 
            this.Lbl_logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_logo.AutoSize = true;
            this.Lbl_logo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_logo.ForeColor = System.Drawing.Color.White;
            this.Lbl_logo.Location = new System.Drawing.Point(6, 26);
            this.Lbl_logo.Name = "Lbl_logo";
            this.Lbl_logo.Size = new System.Drawing.Size(255, 16);
            this.Lbl_logo.TabIndex = 3;
            this.Lbl_logo.Text = "Nidec Instruments Philippines Corporation";
            // 
            // panel_title
            // 
            this.panel_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(146)))), ((int)(((byte)(18)))));
            this.panel_title.Controls.Add(this.lbl_time);
            this.panel_title.Controls.Add(this.lbl_section);
            this.panel_title.Controls.Add(this.lbl_employeename);
            this.panel_title.Controls.Add(this.label3);
            this.panel_title.Controls.Add(this.label2);
            this.panel_title.Controls.Add(this.label1);
            this.panel_title.Controls.Add(this.Lbl_title);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(262, 0);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(807, 80);
            this.panel_title.TabIndex = 4;
            // 
            // lbl_time
            // 
            this.lbl_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.White;
            this.lbl_time.Location = new System.Drawing.Point(623, 61);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(11, 16);
            this.lbl_time.TabIndex = 8;
            this.lbl_time.Text = " ";
            // 
            // Lbl_title
            // 
            this.Lbl_title.AutoSize = true;
            this.Lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_title.ForeColor = System.Drawing.Color.White;
            this.Lbl_title.Location = new System.Drawing.Point(36, 24);
            this.Lbl_title.Name = "Lbl_title";
            this.Lbl_title.Size = new System.Drawing.Size(18, 25);
            this.Lbl_title.TabIndex = 2;
            this.Lbl_title.Text = " ";
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel_menu.Controls.Add(this.Print_Logs);
            this.panel_menu.Controls.Add(this.button3);
            this.panel_menu.Controls.Add(this.button1);
            this.panel_menu.Controls.Add(this.button2);
            this.panel_menu.Controls.Add(this.btn_pincode);
            this.panel_menu.Controls.Add(this.btn_delete);
            this.panel_menu.Controls.Add(this.btn_updateuser);
            this.panel_menu.Controls.Add(this.btnLogout);
            this.panel_menu.Controls.Add(this.btn_adduser);
            this.panel_menu.Controls.Add(this.Panel_logo);
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(262, 642);
            this.panel_menu.TabIndex = 3;
            // 
            // Print_Logs
            // 
            this.Print_Logs.Dock = System.Windows.Forms.DockStyle.Top;
            this.Print_Logs.FlatAppearance.BorderSize = 0;
            this.Print_Logs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Print_Logs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_Logs.ForeColor = System.Drawing.Color.Gainsboro;
            this.Print_Logs.Image = ((System.Drawing.Image)(resources.GetObject("Print_Logs.Image")));
            this.Print_Logs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Print_Logs.Location = new System.Drawing.Point(0, 416);
            this.Print_Logs.Name = "Print_Logs";
            this.Print_Logs.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.Print_Logs.Size = new System.Drawing.Size(262, 48);
            this.Print_Logs.TabIndex = 13;
            this.Print_Logs.Text = "     QR Code Print Logs";
            this.Print_Logs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Print_Logs.UseVisualStyleBackColor = true;
            this.Print_Logs.Click += new System.EventHandler(this.Print_Logs_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Gainsboro;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 368);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(262, 48);
            this.button3.TabIndex = 12;
            this.button3.Text = "     Transaction History Management";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 320);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(262, 48);
            this.button1.TabIndex = 11;
            this.button1.Text = "     Change Account Password";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 272);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(262, 48);
            this.button2.TabIndex = 10;
            this.button2.Text = "     Mold Master List";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_pincode
            // 
            this.btn_pincode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_pincode.FlatAppearance.BorderSize = 0;
            this.btn_pincode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pincode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pincode.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_pincode.Image = ((System.Drawing.Image)(resources.GetObject("btn_pincode.Image")));
            this.btn_pincode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_pincode.Location = new System.Drawing.Point(0, 224);
            this.btn_pincode.Name = "btn_pincode";
            this.btn_pincode.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_pincode.Size = new System.Drawing.Size(262, 48);
            this.btn_pincode.TabIndex = 9;
            this.btn_pincode.Text = "     QR Code Pin Management";
            this.btn_pincode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_pincode.UseVisualStyleBackColor = true;
            this.btn_pincode.Click += new System.EventHandler(this.btn_pincode_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete.Image")));
            this.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_delete.Location = new System.Drawing.Point(0, 176);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_delete.Size = new System.Drawing.Size(262, 48);
            this.btn_delete.TabIndex = 8;
            this.btn_delete.Text = "     Delete User";
            this.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_updateuser
            // 
            this.btn_updateuser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_updateuser.FlatAppearance.BorderSize = 0;
            this.btn_updateuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_updateuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateuser.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_updateuser.Image = ((System.Drawing.Image)(resources.GetObject("btn_updateuser.Image")));
            this.btn_updateuser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_updateuser.Location = new System.Drawing.Point(0, 128);
            this.btn_updateuser.Name = "btn_updateuser";
            this.btn_updateuser.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_updateuser.Size = new System.Drawing.Size(262, 48);
            this.btn_updateuser.TabIndex = 7;
            this.btn_updateuser.Text = "     Edit User Information";
            this.btn_updateuser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_updateuser.UseVisualStyleBackColor = true;
            this.btn_updateuser.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_desktopform
            // 
            this.panel_desktopform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_desktopform.Location = new System.Drawing.Point(262, 80);
            this.panel_desktopform.Name = "panel_desktopform";
            this.panel_desktopform.Size = new System.Drawing.Size(807, 562);
            this.panel_desktopform.TabIndex = 5;
            // 
            // AdministratorManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 642);
            this.Controls.Add(this.panel_desktopform);
            this.Controls.Add(this.panel_title);
            this.Controls.Add(this.panel_menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdministratorManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrator Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdministratorManagement_FormClosed);
            this.Panel_logo.ResumeLayout(false);
            this.Panel_logo.PerformLayout();
            this.panel_title.ResumeLayout(false);
            this.panel_title.PerformLayout();
            this.panel_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btn_adduser;
        private System.Windows.Forms.Label lbl_section;
        private System.Windows.Forms.Label lbl_employeename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel Panel_logo;
        private System.Windows.Forms.Label Lbl_logo;
        private System.Windows.Forms.Panel panel_title;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label Lbl_title;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Panel panel_desktopform;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_updateuser;
        private System.Windows.Forms.Button btn_pincode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Print_Logs;
        private System.Windows.Forms.Button button3;
    }
}