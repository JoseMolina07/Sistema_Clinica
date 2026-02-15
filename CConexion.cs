using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Sistema_Clinica
{
    internal class CConexion
    {
        string cadenaConexion = "server=localhost; port=3306; database=db_laboratorio_pio; User=root; password=;";
        public MySqlConnection conexion = new MySqlConnection();

        public MySqlConnection establecerconexion()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + e.ToString());

                throw;
            }
            return conexion;
        }
        public void cerrarconexion()
        {  
                conexion.Close();
        }
    }
}
