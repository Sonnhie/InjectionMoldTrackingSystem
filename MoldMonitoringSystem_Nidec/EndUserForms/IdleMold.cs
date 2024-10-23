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

namespace MoldMonitoringSystem_Nidec.EndUserForms
{
    public partial class IdleMold : Form
    {
        private readonly MoldDataBaseServiceUtility _moldDataBaseServiceUtility = new MoldDataBaseServiceUtility();
        public IdleMold()
        {
            InitializeComponent();
        }
        

        private void IdleMold_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
