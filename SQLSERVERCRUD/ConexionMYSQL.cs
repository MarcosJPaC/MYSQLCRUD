using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SQLSERVERCRUD
{
    internal class ConexionMYSQL
    {
        public static MySqlConnection conexion = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "cofduty";
        static string ususario = "root";
        static string password = "cisco";
        static string puerto = "3306";

        static String cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id =" + ususario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        private static void conectar()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
                //MessageBox.Show("Se conecto correctamente la base de datos");
            }
            catch (MySqlException e)
            {
                MessageBox.Show("No se puede conectar a la base de datos de MySQL, error:" + e.ToString());
            }




        }

        public static DataTable ejecutaConsultaSelect(string consulta)
        {
            conectar();
            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "tabla");
            conexion.Close();
            return ds.Tables["tabla"];
        }

        public static void ejecutaConsulta(string consulta)
        {
            conectar();
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
