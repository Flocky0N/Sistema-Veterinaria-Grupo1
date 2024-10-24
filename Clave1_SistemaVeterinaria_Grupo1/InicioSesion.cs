using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave1_SistemaVeterinaria_Grupo1
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            //Obtener los datos
            string usuario = txtUsuario.Text;
            string Password = txtpass.Text;


            if (usuario == "admin" && Password == "admin2024")
            {
                // Mostrar mensaje de bienvenida 
                MessageBox.Show("Bienvenido Administrador");
                // Ocultar el formulario de Inicio de Sesión
                this.Hide();
                // Invocar el formulario principal
                FormPrincipal frmPrincipal = new FormPrincipal();
                // Mostrar el formulario principal
                frmPrincipal.Show(); 

            }
            else if (usuario == "veterinario" && Password == "ve2024")
            {
                // Mostrar mesaje de bienvenida
                MessageBox.Show("Bienvenido Veterinario");
                // Ocultar el formulario de Inicio de Sesión
                this.Hide();
                // Invocar el formulario principal
                FormPrincipal frmPrincipal = new FormPrincipal();
                // Mostrar el formulario principal
                frmPrincipal.Show();

            }
            else if (usuario == "cliente" && Password == "client123")
            {
                // Nostrar mensaje de bienvenida
                MessageBox.Show("Bienvenido Cliente");
                // Ocultar el formulario de Inicio de Sesión
                this.Hide();
                // Invocar el formulario principal
                FormPrincipal frmPrincipal = new FormPrincipal();
                // Mostrar el formulario principal
                frmPrincipal.Show();

            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.Intentelo nuevamente");
            }

        }
    }
}
