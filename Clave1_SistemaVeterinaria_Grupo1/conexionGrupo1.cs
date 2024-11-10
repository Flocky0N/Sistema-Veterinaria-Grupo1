using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Clave1_SistemaVeterinaria_Grupo1
{
     public class conexionGrupo1
    {
        // Cadena de conexión
        private static string servidor = "localhost";
        private static string dataBase = "VeterinariaGrupo01";
        private static string usuario = "root";
        private static string pass = "root";
        private static string cadenaConexion = $"Server={servidor};Database={dataBase};User ID={usuario};Password={pass};";

        // Objeto de conexión
        private MySqlConnection conexion;

        // Constructor
        public conexionGrupo1()
        {
            conexion = new MySqlConnection(cadenaConexion);
        }

        // Método para abrir la conexión
        public MySqlConnection AbrirConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión: " + ex.Message);
            }
            return conexion;
        }

        // Método para cerrar la conexión
        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cerrar la conexión: " + ex.Message);
            }
        }

        internal void Fill(DataTable table)
        {
            throw new NotImplementedException();
        }

        public void Fill(DataTable table, string query)
        { 
            try
            { MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion); adapter.Fill(table);
            
            } 
            catch (Exception ex)
            { 
                Console.WriteLine("Error al llenar el DataTable: " + ex.Message);
            }
        }
    }
}
   
