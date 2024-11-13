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
using Clave1_SistemaVeterinaria_Grupo1.Clases;

namespace Clave1_SistemaVeterinaria_Grupo1
{
    /// <summary>
    /// Autores: Yasmin Guadalupe
    /// Daniel Alexander Torres Barrera
    /// Diego Rafael Ortiz 
    /// Naidelyn Lisbeth Pichinte Flores
    /// Aplicacion diseñada para automatizar los procesos sistematicos en una 
    /// veterinaria, ya que este sistema permite desde agregar mascotas, clientes hasta la modificación, eliminación
    /// y consultas de los regitros del sistema.
    /// </summary>
    public partial class InicioSesion : Form
    {
        private conexionGrupo1 conexionDB = new conexionGrupo1();
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtNombreUsuario.Text;
            string contrasena = txtContrasena.Text;

            var (nombre, rol) = ObtenerDatosUsuario(usuario, contrasena);

            if (!string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show($"Bienvenido, {nombre}. Tu rol es: {rol}");
                this.Hide(); // Oculta el formulario de inicio de sesión
                // Aquí abre el formulario principal
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
        //Obtener datos del usuario como su nombre y rol y mostrar mensaje
        private (string, string) ObtenerDatosUsuario(string usuario, string contrasena)
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion == null) return (null, null);

            string query = "SELECT nombre, rol FROM usuarios WHERE nombreUsuario = @usuario AND contrasena = @contrasena";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contrasena", contrasena);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string nombre = reader["nombre"].ToString();
                string rol = reader["rol"].ToString();
                conexionDB.CerrarConexion();
                return (nombre, rol);
            }
            else
            {
                conexionDB.CerrarConexion();
                return (null, null);
            }
        }
    }
}
         
              


  
   

