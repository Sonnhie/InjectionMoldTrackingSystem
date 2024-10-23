using MoldMonitoringSystem_Nidec.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Forms
{
    public partial class QRCodeOption : Form
    {
        public Action<Form> OnFormSelected;
        private string _employeename;
        private string _section;
        public QRCodeOption(string employeename, string section)
        {
            InitializeComponent();
            _employeename = employeename;
            _section = section;
           LoadThemeUtility.LoadTheme(this);
            GetbuttonAccess();
        }
        private void GetbuttonAccess()
        {
            var buttonAccess = new Dictionary<string, Action>
            {
                { "Injection", () =>
                                {
                                   MoldQR_button.Hide();
                                } },
                { "Mold", () =>
                                {
                                   MachineQR_button.Hide();
                                } },
     
            };

            if (buttonAccess.ContainsKey(_section))
            {
                buttonAccess[_section].Invoke();
            }
        }
        private void QRCodeOption_Load(object sender, EventArgs e)
        {
            LoadThemeUtility.LoadTheme(this);
        }
        private void QRCodeOption_Shown(object sender, EventArgs e)
        {
            //LoadTheme();
        }

        private void MoldQR_button_Click(object sender, EventArgs e)
        {

                OnFormSelected?.Invoke(new Forms.MoldQrGenerator(_employeename));
                this.Close();

        }

        private void MachineQR_button_Click(object sender, EventArgs e)
        {
            OnFormSelected?.Invoke(new Forms.MachineQR(_employeename));
            this.Close();
        }

       
    }
}
