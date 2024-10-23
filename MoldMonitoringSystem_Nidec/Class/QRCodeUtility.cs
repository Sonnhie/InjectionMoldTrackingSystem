using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace MoldMonitoringSystem_Nidec.Class
{
    public class QRCodeUtility
    {
        public static Image GenerateQrCode(string data, int size)
        {
            var qrCode = BarcodeDrawFactory.CodeQr;
            return qrCode.Draw(data, size);
        }
        public static Image Resize(Image QrImage , int width, int height)
        {
            Bitmap FinaQRimage = new Bitmap(width, height);
            using(Graphics g = Graphics.FromImage(FinaQRimage))
            {
                g.DrawImage(QrImage, 0, 0, width, height);
            }
            return FinaQRimage;
        }
      
    }

}
