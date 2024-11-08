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
    public partial class Clientes : Form
    {
        private conexionGrupo1 conexionDB;
        public Clientes()
        {
            InitializeComponent();
            conexionDB = new conexionGrupo1();
        }

        

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!validarCampos())
            {
                MessageBox.Show("Ingrese datos en los campos correspondientes: " + Camposvacios());
                return;
            }
            Cliente cliente = new Cliente(txtNombre.Text, txtTelefono.Text, txtDireccion.Text);
            ingresarCliente(cliente);
        }

        //Metodo para ingresar un cliente a la base de datos
        public void ingresarCliente(Cliente c)
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand();

            consulta.Connection = conexion;
            consulta.CommandText = "INSERT INTO cliente(nombre,telefono, direccion) " +
                "VALUES(@nombre, @telefono, @direccion)";

            consulta.Parameters.AddWithValue("@nombre", c.NombreCliente);
            consulta.Parameters.AddWithValue("@telefono", c.Telefono);
            consulta.Parameters.AddWithValue("@direccion", c.Direccion);

            try
            {
                int rowsAffected = consulta.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("El cliente se ha agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el cliente");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Eror al procesar la instrucción" + ex);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }
        public bool validarCampos()
        {
            foreach(Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    if (item.Name != "textId")
                    {
                        if (TextoVacio(item.Text))
                            return false;
                    }
                }
            }
            return true;
        }
        public string Camposvacios()
        {
            string campos = "";
            foreach (Control item in this.Controls)
            {
                if (item is TextBox && item.Name != "textId")
                {
                    if (TextoVacio(item.Text))
                        campos += "\n" + item.Name;
                }
            }
            return campos;
        }

        public bool TextoVacio(string texto)
        {
            return string.IsNullOrWhiteSpace(texto);
        }
        // Método para eliminar un cliente
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Comando SQL para eliminar un cliente por ID
                    string query = "DELETE FROM cliente WHERE idCliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                   

                    // Ejecuta el comando
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente eliminado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
                finally
                {
                    // Cierra la conexión
                    conexionDB.CerrarConexion();
                }
            }
        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            try
            {
                conexionDB.AbrirConexion();
                MessageBox.Show("Conexión satisfactoria");

            }catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }
    }
}
       