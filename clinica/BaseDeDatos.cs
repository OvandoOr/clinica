using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace clinica
{
    class BaseDeDatos
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=127.0.0.1;database=condesa;Uid=root;pwd=;");
            conectar.Open();
            return conectar;
        }
    }
}
