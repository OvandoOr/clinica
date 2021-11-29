using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace clinica
{
    public partial class cita : Form
    {
        public cita()
        {
            InitializeComponent();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capturarfecha();
        }
        private void capturarfecha()
        {
            lfecha.Text = DateTime.Now.ToShortDateString();
            lhora.Text = DateTime.Now.ToShortTimeString();
        }

        private void cita_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CapturaFormulario();
            textBox1.Text = "guardado";
        }


        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
                                         int nWidth, int nHeight, IntPtr hdcSrc,
                                         int nXSrc, int nYSrc, int dwRop);

        private void CapturaFormulario()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size sz = this.ClientRectangle.Size;
            Bitmap bmp = new Bitmap(sz.Width, sz.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
                   this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);

            bmp.Save("prueba.bmp", ImageFormat.Bmp,);
        }
    }
}
