using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Conexion
    {
        private string connectionString = "Server=DESKTOP-VSK4022\\SQLEXPRESS01;Database=ProyectoHerrera; Trusted_Connection=True;Encrypt=False;";  //agregar la cadena de conexion

        // Método para obtener la conexió
        public SqlConnection ObtenerConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la conexión: " + ex.Message);
            }
        }

        // Método para cerrar la conexión
        public void CerrarConexion(SqlConnection conexion)
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión: " + ex.Message);
            }
        }
    }
}