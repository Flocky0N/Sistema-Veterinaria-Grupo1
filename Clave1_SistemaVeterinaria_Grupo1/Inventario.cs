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
    public partial class Inventario : Form
    {
        private conexionGrupo1 conexionDB;


        public Inventario()
        {
            InitializeComponent();
            conexionDB = new conexionGrupo1();
            CargarInventario();
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                MessageBox.Show("Ingrese datos en los campos correspondientes: " + Camposvacios());
                return;
            }
            Inventary inventario = new Inventary(txtNombre.Text, txtCantidad.Text, txtPrecio.Text);
            Producto(inventario);

        }


        //Agregar productos en la base de datos
        internal void Producto(Inventary i)
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand();

            consulta.Connection = conexion;
            consulta.CommandText = "INSERT INTO producto(nombre,cantidad, precio) " +
                "VALUES(@nombre, @cantidad, @precio)";

            consulta.Parameters.AddWithValue("@nombre", i.Nombre);
            consulta.Parameters.AddWithValue("@cantidad", i.Cantidad);
            consulta.Parameters.AddWithValue("@precio", i.Precio);

            try
            {
                int rowsAffected = consulta.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("El producto se ha agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el producto");
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
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
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

        //Método para eliminar un producto
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Comando SQL para eliminar un producto por ID
                    string query = "DELETE FROM producto WHERE idProducto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);


                    // Ejecuta el comando
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto eliminado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                }
                finally
                {
                    // Cierra la conexión
                    conexionDB.CerrarConexion();
                }
            }
        }

        //Método para modificar un producto
        private void CargarInventario()
        {
            {
                string query = "SELECT Id, Nombre, Cantidad, Precio FROM producto";
                MySqlConnection conexion = conexionDB.AbrirConexion();
                DataTable table = new DataTable();
                conexionDB.Fill(table);
                dgvInventario.DataSource = table;
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells["Id"].Value);
            string newNombre = txtNombre.Text;
            string newCantidad = txtCantidad.Text;
            string newPrecio = txtPrecio.Text;

            if (string.IsNullOrEmpty(newNombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre a modificar.");
                return;
            }
            else if (string.IsNullOrEmpty(newCantidad))
            {
                MessageBox.Show("Por favor, ingrese la cantidad a modificar");
                return;

            }
            else if (string.IsNullOrEmpty(newPrecio))
            {
                MessageBox.Show("Por favor, ingrese el precio a modificar");
            }


                MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Comando SQL para eliminar un producto por ID
                    string query = "UPDATE FROM producto nombre = @nombre, cantidad = @cantidad, precio = @precio WHERE idProducto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", newNombre);
                    cmd.Parameters.AddWithValue("@cantidad", newCantidad);
                    cmd.Parameters.AddWithValue("@precio", newPrecio);
                    cmd.Parameters.AddWithValue("@Id", id);


                    // Ejecuta el comando
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto actualizado exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el producto: " + ex.Message);
                }
                finally
                {
                    // Cierra la conexión
                    conexionDB.CerrarConexion();
                }
            }
        }

        //Método para consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Obtiene el id del producto desde el TextBox
            string Producto = textId.Text;

            if (string.IsNullOrEmpty(Producto))
            {
                MessageBox.Show("Por favor, ingrese el id del producto a buscar.");
                return;
            }


            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            { 
                // Consulta para buscar productos por id
                string query = "SELECT Id, Nombre, Cantidad, Precio FROM producto WHERE idProducto LIKE @id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", "%" + Producto + "%");
                DataTable table = new DataTable();

                try
                {   
                   conexionDB.Fill(table);
                        dgvInventario.DataSource = table;

                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show("No se encontraron productos con ese id.");
                        }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar el inventario: " + ex.Message);
                }
            }
        }





    }
}