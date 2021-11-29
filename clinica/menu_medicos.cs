using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinica
{
    public partial class menu_medicos : Form
    {
        public menu_medicos()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            consulta_car cardiologo = new consulta_car();
            cardiologo.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            consulta general = new consulta();
            general.ShowDialog();
        }
    }
}
