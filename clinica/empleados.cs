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
    public partial class empleados : Form
    {
        string sangre, puesto, horario, estado, sexo, area, turno;

        public empleados()
        {
            InitializeComponent();
            cargar_tabla();
            estado_civil();
            tipo_sexo();
            tipo_sangre();
            tipo_area();
            tipo_horario();
            tipo_puesto();
            tipo_turno();
        }

        private void cargar_tabla()
        {
            string Query = "SELECT * FROM condesa.empleados; ";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView2.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            string Query = "INSERT INTO `condesa`.`empleados` (`Nombre`, `A_paterno`, `A_materno`, `Edad`, `Telefono`, `Correo`, `Direccion`, `Fecha_nac`, `RFC`, `CURP`, `Escuela_pro`, `Sueldo`, `Estado_civil_idEstado_civil`, `Tipo_sangre_idTipo_sangre`, `Sexo_idSexo`, `Turno_idTurno`, `Horario_idHorario`, `Puesto_idPuesto`, `Area_idArea`) VALUES('" + tbnombre.Text+"', '"+tba_Paterno.Text+"', '"+tba_Materno+"', '"+tbedad+"', '"+tbTelefono.Text+"', '"+tbCorreo.Text+"', '"+tbdireccion.Text+"', '"+dtpfechanac.Text+"', '"+tbrfc.Text+"', '"+tbcurp.Text+"','"+tbescuela.Text+"','"+cbsueldo.Text+"','"+estado+"','"+sangre+"','"+sexo+"', '"+turno+"', '"+horario+"', '"+puesto+"', '"+area+"');";



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
        }
        private void estado_civil()
        {
            string Query = "select * from condesa.estado_civil;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbestado_civil.DisplayMember = "Descripcion";
                cbestado_civil.ValueMember = "id";
                cbestado_civil.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbtipo_sangre_SelectedIndexChanged(object sender, EventArgs e)
        {
            sangre = cbtipo_sangre.SelectedValue.ToString();
        }

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            sexo = cbSexo.SelectedValue.ToString();
        }

        private void cbestado_civil_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = cbestado_civil.SelectedValue.ToString();
        }

        private void cbturno_SelectedIndexChanged(object sender, EventArgs e)
        {
            turno = cbturno.SelectedValue.ToString();
        }

        private void cbarea_SelectedIndexChanged(object sender, EventArgs e)
        {
            area = cbarea.SelectedValue.ToString();
        }

        private void cbhorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            horario = cbhorario.SelectedValue.ToString();
        }

        private void cbpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            puesto = cbpuesto.SelectedValue.ToString();
        }

        private void tipo_sexo()
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
        private void tipo_sangre()
        {
            string Query = "select * from condesa.tipo_sangre;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbtipo_sangre.DisplayMember = "Descripcion";
                cbtipo_sangre.ValueMember = "id";
                cbtipo_sangre.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void tipo_area()
        {
            string Query = "select * from condesa.area;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbarea.DisplayMember = "Descripcion";
                cbarea.ValueMember = "id";
                cbarea.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tipo_horario()
        {
            string Query = "select * from condesa.horario;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbhorario.DisplayMember = "Descripcion";
                cbhorario.ValueMember = "id";
                cbhorario.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tipo_puesto()
        {
            string Query = "select * from condesa.puesto;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbpuesto.DisplayMember = "Descripcion";
                cbpuesto.ValueMember = "id";
                cbpuesto.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tipo_turno()
        {
            string Query = "select * from condesa.turno;";

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(Query, BaseDeDatos.ObtenerConexion());
                DataTable ds = new DataTable();
                sda.Fill(ds);

                cbturno.DisplayMember = "Descripcion";
                cbturno.ValueMember = "id";
                cbturno.DataSource = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }

}
