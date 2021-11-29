using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace clinica
{
    public partial class consulta : Form
    {
        public consulta()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capturarfechayhora();
        }
        private void capturarfechayhora()
        {
            fecha.Text = DateTime.Now.ToShortDateString();
            hora.Text = DateTime.Now.ToShortTimeString();
        }

        private void consulta_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
