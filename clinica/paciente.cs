using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace clinica
{
    public partial class paciente : Form
    {
        int posicion = 0;
        

        public paciente()
        {      
            InitializeComponent();
            cargar_tabla();
            comboTipoSangre();
            sexo();
            estado();
            this.toolTip1.SetToolTip(tbnombre, "Ingrese el nombre");
            this.toolTip1.SetToolTip(tba_Paterno, "Ingrese el Apellido Paterno");
            this.toolTip1.SetToolTip(tba_Materno, "Ingrese el Apellido Materno");
            this.toolTip1.SetToolTip(tbedad, "Ingrese la edad");
            this.toolTip1.SetToolTip(tbTelefono, "Ingrese el Numero de telefono");
            this.toolTip1.SetToolTip(tbCorreo, "Ingrese el Correo electronico");
            this.toolTip1.SetToolTip(cbSexo, "Seleccione el sexo");

        }

        public void comboTipoSangre()
        {
            string Query = "select * from condesa.tipo_sangre;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                comboBox2.DisplayMember = "Descripcion";
                comboBox2.ValueMember = "id";
                comboBox2.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void sexo()
        {
            string Query = "select * from condesa.sexo;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbSexo.DisplayMember = "Descripcion";
                cbSexo.ValueMember = "id";
                cbSexo.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void estado()
        {
            string Query = "select * from condesa.estado_civil;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbestado.DisplayMember = "Descripcion";
                cbestado.ValueMember = "id";
                cbestado.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void cargar_tabla()
        {
            string Query = "SELECT * FROM condesa.paciente; ";

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
        }

        public void radiobuton2()
        {

            string Query = "SELECT * FROM condesa.paciente where Edad like'" + textBox1.Text + "%';";
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

            string Query = "SELECT * FROM condesa.paciente where idPaciente like'" + textBox1.Text + "%';";

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
            tbnombre.Text = Convert.ToString(dataGridView1[1, posicion].Value);
            tba_Paterno.Text = Convert.ToString(dataGridView1[2, posicion].Value);
            tba_Materno.Text = Convert.ToString(dataGridView1[3, posicion].Value);
            cbSexo.Text = Convert.ToString(dataGridView1[4, posicion].Value);
            tbedad.Text = Convert.ToString(dataGridView1[5, posicion].Value);
            tbTelefono.Text = Convert.ToString(dataGridView1[6, posicion].Value);
            tbCorreo.Text = Convert.ToString(dataGridView1[7, posicion].Value);
            cbestado.Text = Convert.ToString(dataGridView1[8, posicion].Value);


        }

        
        
        public void limpiar()
        {
            tbnombre.Clear();
            tba_Paterno.Clear();
            tba_Materno.Clear();
            tbedad.Clear();
            tbCorreo.Clear();
            tbTelefono.Clear();
            textBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
        string sangre;
        string estado_civil;
        string sex;
        string fechanac;
        string fechain;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sangre = comboBox2.SelectedValue.ToString();
        }

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            sex = cbSexo.SelectedValue.ToString();
        }

        private void cbestado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado_civil = cbestado.SelectedValue.ToString();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            fechanac = dtpFecha.Value.ToString("yyyy-MM-dd");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechain = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void btngua_Click_1(object sender, EventArgs e)
        {
            string Query = "INSERT INTO `condesa`.`paciente` (`Nombre`, `A_paterno`, `A_materno`, `Edad`, `Telefono`, `Correo`, `Direccion`, `Fecha_ingreso`, `Fecha_nac`, `No.seguro`, `Tipo_sangre_idTipo_sangre`, `Estado_civil_idEstado_civil`, `Sexo_idSexo`) VALUES ('" + tbnombre.Text + "', '" + tba_Paterno.Text + "', '" + tba_Materno.Text + "', '" + tbedad.Text + "', '" + tbTelefono.Text + "', '" + tbCorreo.Text + "', '" + textBox2.Text + "', '" + fechain + "', '" + fechanac + "', '" + textBox3.Text + "', '" + sangre + "', '" + estado_civil + "', '" + sex + "');";


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
            cargar_tabla();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string Query = " UPDATE `condesa`.`paciente` SET `Nombre`='" + tbnombre.Text + "', `A_paterno`='" + tba_Paterno.Text + "', `A_materno`='" + tba_Materno.Text + "', `Edad`='" + tbedad.Text + "', `Telefono`='" + tbTelefono.Text + "', `Correo`='" + tbCorreo.Text + "', `Direccion`='" + textBox2.Text + "', `Fecha_ingreso`='" + fechain + "',`Fecha_nac`='" + fechanac + "',`No.seguro`='" + textBox3.Text + "',`Tipo_sangre_idTipo_sangre`='" + sangre + "',`Estado_civil_idEstado_civil'='" +estado_civil  + "', 'Sexo_idSexo`='" + sex+ "', WHERE `idPaciente`='" + (posicion + 1) + "';";
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

        private void button3_Click_1(object sender, EventArgs e)
        {

            string Query = "DELETE FROM condesa.paciente where idPaciente='" + (posicion + 1) + "';";

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            string Query = "SELECT * FROM condesa.paciente where Nombre like'" + textBox1.Text + "';";

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
    }
}

