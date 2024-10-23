using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoldMonitoringSystem_Nidec.Class
{
    public class LoadThemeUtility
    {
        public static void LoadTheme(Control container)
        {
            if (container == null)
            
                throw new ArgumentException(nameof(container));

            foreach(Control c in container.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

                }

                if (c.HasChildren)
                {
                    LoadTheme(c);
                }
            }
            
        }
    }
}
