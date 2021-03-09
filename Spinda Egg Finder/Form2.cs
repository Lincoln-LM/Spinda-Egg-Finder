using Spinda_Egg_Finder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spinda_Egg_Finder
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string TheValue
        {
            get { return PainterPIDBox.Text; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private string zfill(string pid)
        {
            if (pid.Length < 8)
            {
                do
                {
                    pid = "0" + pid;
                }
                while (pid.Length < 8);
            }
            return pid;
        }

        private Bitmap pidtospinda(string pidstring)
        {
            int spot1x, spot1y, spot2x, spot2y, spot3x, spot3y, spot4x, spot4y;
            string pid, pid1, pid2, pid3, pid4, pid5, pid6, pid7, pid8;


            pid = zfill(pidstring);
            pid1 = pid.Substring(0, 1);
            pid2 = pid.Substring(1, 1);
            pid3 = pid.Substring(2, 1);
            pid4 = pid.Substring(3, 1);
            pid5 = pid.Substring(4, 1);
            pid6 = pid.Substring(5, 1);
            pid7 = pid.Substring(6, 1);
            pid8 = pid.Substring(7, 1);

            spot1x = int.Parse(pid8, System.Globalization.NumberStyles.HexNumber);
            spot1y = int.Parse(pid7, System.Globalization.NumberStyles.HexNumber);
            spot2x = int.Parse(pid6, System.Globalization.NumberStyles.HexNumber);
            spot2y = int.Parse(pid5, System.Globalization.NumberStyles.HexNumber);
            spot3x = int.Parse(pid4, System.Globalization.NumberStyles.HexNumber);
            spot3y = int.Parse(pid3, System.Globalization.NumberStyles.HexNumber);
            spot4x = int.Parse(pid2, System.Globalization.NumberStyles.HexNumber);
            spot4y = int.Parse(pid1, System.Globalization.NumberStyles.HexNumber);

            var bitmap = new Bitmap(260, 295);
            using (var g = Graphics.FromImage(bitmap))
            {
                ResourceManager rm = Resources.ResourceManager;

                var bmp1 = (Bitmap)rm.GetObject("spindapog");
                var bmp2 = (Bitmap)rm.GetObject("spot1");
                var bmp3 = (Bitmap)rm.GetObject("spot2");
                var bmp4 = (Bitmap)rm.GetObject("spot3");
                var bmp5 = (Bitmap)rm.GetObject("spot4");
                g.DrawImage(bmp1, 0, 0);
                g.DrawImage(bmp2, spot1x * 5, spot1y * 5);
                g.DrawImage(bmp3, spot2x * 5, spot2y * 5);
                g.DrawImage(bmp4, spot3x * 5, spot3y * 5);
                g.DrawImage(bmp5, spot4x * 5, spot4y * 5);
                if (OverlayCheck.Checked)
                {
                    var bmp6 = (Bitmap)rm.GetObject("spindaoverlay");
                    g.DrawImage(bmp6, 0, 0);
                }

                Spot1X.Value = spot1x;
                Spot1Y.Value = spot1y;
                Spot2X.Value = spot2x;
                Spot2Y.Value = spot2y;
                Spot3X.Value = spot3x;
                Spot3Y.Value = spot3y;
                Spot4X.Value = spot4x;
                Spot4Y.Value = spot4y;

                return bitmap;
            }

        }
        private Bitmap spotstospinda()
        {
            int spot1x, spot1y, spot2x, spot2y, spot3x, spot3y, spot4x, spot4y;
            string pid, pid1, pid2, pid3, pid4, pid5, pid6, pid7, pid8;

            spot1x = (int)Spot1X.Value;
            spot1y = (int)Spot1Y.Value;
            spot2x = (int)Spot2X.Value;
            spot2y = (int)Spot2Y.Value;
            spot3x = (int)Spot3X.Value;
            spot3y = (int)Spot3Y.Value;
            spot4x = (int)Spot4X.Value;
            spot4y = (int)Spot4Y.Value;

            pid8 = spot1x.ToString("X");
            pid7 = spot1y.ToString("X");
            pid6 = spot2x.ToString("X");
            pid5 = spot2y.ToString("X");
            pid4 = spot3x.ToString("X");
            pid3 = spot3y.ToString("X");
            pid2 = spot4x.ToString("X");
            pid1 = spot4y.ToString("X");

            pid = pid1 + pid2 + pid3 + pid4 + pid5 + pid6 + pid7 + pid8;

            var bitmap = new Bitmap(260, 295);
            using (var g = Graphics.FromImage(bitmap))
            {
                ResourceManager rm = Resources.ResourceManager;

                var bmp1 = (Bitmap)rm.GetObject("spindapog");
                var bmp2 = (Bitmap)rm.GetObject("spot1");
                var bmp3 = (Bitmap)rm.GetObject("spot2");
                var bmp4 = (Bitmap)rm.GetObject("spot3");
                var bmp5 = (Bitmap)rm.GetObject("spot4");
                g.DrawImage(bmp1, 0, 0);
                g.DrawImage(bmp2, spot1x * 5, spot1y * 5);
                g.DrawImage(bmp3, spot2x * 5, spot2y * 5);
                g.DrawImage(bmp4, spot3x * 5, spot3y * 5);
                g.DrawImage(bmp5, spot4x * 5, spot4y * 5);
                if (OverlayCheck.Checked)
                {
                    var bmp6 = (Bitmap)rm.GetObject("spindaoverlay");
                    g.DrawImage(bmp6, 0, 0);
                }

                PainterPIDBox.Text = pid;

                return bitmap;
            }
        }

        private void PIDUpdated(object sender, EventArgs e)
        {
            if (PIDRadio.Checked)
            {
                string pid = PainterPIDBox.Text;
                SpindaPicture.Image = pidtospinda(pid);
            }
        }

        private void SpotUpdated(object sender, EventArgs e)
        {
            if (SpotRadio.Checked)
            {
                SpindaPicture.Image = spotstospinda();
            }
        }
    }
}
