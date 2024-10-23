namespace MoldMonitoringSystem_Nidec.Forms
{
    partial class QRCodeOption
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
            this.MoldQR_button = new System.Windows.Forms.Button();
            this.MachineQR_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MoldQR_button
            // 
            this.MoldQR_button.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.MoldQR_button.FlatAppearance.BorderSize = 5;
            this.MoldQR_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoldQR_button.Location = new System.Drawing.Point(89, 74);
            this.MoldQR_button.Name = "MoldQR_button";
            this.MoldQR_button.Size = new System.Drawing.Size(161, 47);
            this.MoldQR_button.TabIndex = 0;
            this.MoldQR_button.Text = "Generate Mold QR";
            this.MoldQR_button.UseVisualStyleBackColor = true;
            this.MoldQR_button.Click += new System.EventHandler(this.MoldQR_button_Click);
            // 
            // MachineQR_button
            // 
            this.MachineQR_button.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.MachineQR_button.FlatAppearance.BorderSize = 5;
            this.MachineQR_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MachineQR_button.Location = new System.Drawing.Point(89, 74);
            this.MachineQR_button.Name = "MachineQR_button";
            this.MachineQR_button.Size = new System.Drawing.Size(161, 47);
            this.MachineQR_button.TabIndex = 1;
            this.MachineQR_button.Text = "Generate Machine QR";
            this.MachineQR_button.UseVisualStyleBackColor = true;
            this.MachineQR_button.Click += new System.EventHandler(this.MachineQR_button_Click);
            // 
            // QRCodeOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(346, 198);
            this.Controls.Add(this.MachineQR_button);
            this.Controls.Add(this.MoldQR_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QRCodeOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Qr Code";
            this.Load += new System.EventHandler(this.QRCodeOption_Load);
            this.Shown += new System.EventHandler(this.QRCodeOption_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MoldQR_button;
        private System.Windows.Forms.Button MachineQR_button;
    }
}