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

namespace Clave1_SistemaVeterinaria_Grupo1
{
    public partial class InicioSesion : Form
    {
        private conexionGrupo1 conexionDB;
        public InicioSesion()
        {
            InitializeComponent();
            conexionDB = new conexionGrupo1();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtpass.Text;

            using (MySqlConnection conexion = conexionDB.AbrirConexion())
            {
                try
                {
                    //Validar el usuario y la contraseña
                    string consulta = "SELECT rol FROM usuarios WHERE nombreUsuario = @usuario AND contrasena = @password";
                    MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        string rol = resultado.ToString();
                        MessageBox.Show("Bienvenido " + rol);
                        this.Hide();
                        FormPrincipal frmPrincipal = new FormPrincipal();
                        frmPrincipal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos. Inténtelo nuevamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la conexión: " + ex.Message);
                }
                finally
                {
                    conexionDB.CerrarConexion();
                }
            }
        }
    }
}

      