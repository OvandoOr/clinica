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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Medicos medicos = new clinica.Medicos();
            medicos.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            menu_medicos menumed = new menu_medicos();
            menumed.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cita cita = new cita();
            cita.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            paciente paciente = new paciente();
            paciente.ShowDialog();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            historial historial = new historial();
            historial.ShowDialog();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            proveedores provedor = new proveedores();
            provedor.ShowDialog();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            empleados empleados = new clinica.empleados();
            empleados.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            capturafechayhora();
        }
        private void capturafechayhora()
        {
            lfecha.Text = DateTime.Now.ToShortDateString();
            lhora.Text = DateTime.Now.ToShortTimeString();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            usuarios usuarios = new usuarios();
            usuarios.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            area area = new clinica.area();
            area.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
