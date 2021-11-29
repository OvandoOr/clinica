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
    public partial class historial : Form
    {
        int posicion = 0;
        public historial()
        {
            InitializeComponent();
            cargar_tabla();
            this.toolTip1.SetToolTip(txtbnombre, "Ingrese el nombre");
            this.toolTip1.SetToolTip(txtapellido, "Ingrese el Apellido Paterno");
            this.toolTip1.SetToolTip(edad, "Ingrese la edad");
            this.toolTip1.SetToolTip(cmbdoctor, "Ingrese el nombre del medico");
            this.toolTip1.SetToolTip(altura, "Ingrese la altura del paciente");
            this.toolTip1.SetToolTip(peso, "Ingrese el peso del paciente");
            this.toolTip1.SetToolTip(sexo, "Ingrese el sexo del paciente");

        }

        private void cargar_tabla()
        {
            string Query = "SELECT * FROM Clinica.Paciente;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void radiobuton1()
        {
            string Query = "SELECT * FROM Clinica.Paciente where Nombre like'" + textBox1.Text + "%';";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void radiobuton2()
        {

            string Query = "SELECT * FROM Clinica.Paciente where Edad like'" + textBox1.Text + "%';";
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void radiobuton3()
        {

            string Query = "SELECT * FROM Cliente.Paciente where idPaciente like'" + textBox1.Text + "%';";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            posicion = dataGridView1.CurrentCell.RowIndex;
            // esto es para que te diga en que posición esta la columna seleccionada 
            txtbnombre.Text = Convert.ToString(dataGridView1[1, posicion].Value);
            txtapellido.Text = Convert.ToString(dataGridView1[2, posicion].Value);
            cmbdoctor.Text = Convert.ToString(dataGridView1[3, posicion].Value);
            edad.Text = Convert.ToString(dataGridView1[4, posicion].Value);
            altura.Text = Convert.ToString(dataGridView1[5, posicion].Value);
            peso.Text = Convert.ToString(dataGridView1[6, posicion].Value);
            sexo.Text = Convert.ToString(dataGridView1[7, posicion].Value);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Query = " UPDATE `Clinica`.`Paciente` SET `Nombre`='" + txtbnombre.Text + "', `Apellido P.`='" + txtapellido + "', `Apellido M.`='" + cmbdoctor + "', `sexo`='" + edad.Text + "', `Edad`='" + altura.Text + "', `telefono`='" + peso.Text + "', `correo`='" + cmbdoctor.Text + "'  WHERE `idCliente`='" + (posicion + 1) + "';";
            try
            {
                MySqlCommand cmdDataBase = new MySqlCommand(Query, BaseDeDatos.ObtenerConexion());
                MySqlDataReader myReader;
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Se registraron los datos con exito");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cargar_tabla();

            limpiar();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string Query = "DELETE FROM Clinica.Paciente where idPaciente='" + (posicion + 1) + "';";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cargar_tabla();

            limpiar();
        }

        public void limpiar()
        {
           


        }
        private void button4_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void btngua_Click(object sender, EventArgs e)
        {

            string Query = "insert into Clinica.Paciente(Nombre, Apellido P., Apellido M., sexo, Edad, telefono, correo, Tipo_De_Cliente, Cantidad_compras, Adeudo) values;"; //+ tbnombre.Text + "', '" + tba_Paterno.Text + "', '" + tba_Materno.Text + "', '" + cbSexo.Text + "', '" + tbedad.Text + "', '" + tbTelefono.Text + "', '" + tbCorreo.Text + "', '" + cbusuario.Text + "', '0', ' 0 ');";
            try
            {
                MySqlCommand cmdDataBase = new MySqlCommand(Query, BaseDeDatos.ObtenerConexion());
                MySqlDataReader myReader;
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Se registraron los datos con exito");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            limpiar();

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radiobuton1();
            }

            if (radioButton2.Checked == true)
            {
                radiobuton2();
            }

            if (radioButton3.Checked == true)
            {
                radiobuton3();
            }

        }


    }
}
