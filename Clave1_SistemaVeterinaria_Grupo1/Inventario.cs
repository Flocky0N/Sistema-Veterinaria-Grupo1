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
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de filas completas
            this.Load += new EventHandler(Inventario_Load); 
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            CargarInventario(); // Carga el inventario automáticamente
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

            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
                return;
            }
            int id = Convert.ToInt32(dgvInventario.SelectedRows[0].Cells["Id"].Value);

            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Verifica si el producto existe
                    string checkQuery = "SELECT COUNT(*) FROM producto WHERE idProducto = @idProducto";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conexion);
                    checkCmd.Parameters.AddWithValue("@idProducto", id);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());


                    if (count == 0)
                    {
                        MessageBox.Show("El producto no existe en la base de datos.");
                        return;
                    }
                    // Elimina el producto
                    string deleteQuery = "DELETE FROM producto WHERE idProducto = @idProducto";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conexion);
                    deleteCmd.Parameters.AddWithValue("@idProducto", id);
                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Producto eliminado exitosamente.");
                        CargarInventario(); // Refresca el inventario
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el producto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                }
                finally
                {
                    conexionDB.CerrarConexion();
                }
                
            }
        }

        //Método para modificar un producto
        private void CargarInventario()
        {
            {
                string query = "SELECT idProducto AS Id, nombre, cantidad, precio FROM producto";
                MySqlConnection conexion = conexionDB.AbrirConexion();
                DataTable table = new DataTable();


                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                    adapter.Fill(table);
                    dgvInventario.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron productos en la base de datos.");
                    }
                    else
                    {
                        dgvInventario.Columns["Id"].HeaderText = "ID";
                        dgvInventario.Columns["nombre"].HeaderText = "Nombre";
                        dgvInventario.Columns["cantidad"].HeaderText = "Cantidad";
                        dgvInventario.Columns["precio"].HeaderText = "Precio";
                    }
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show("Error al cargar el inventario: " + ex.Message); 
                }
                finally
                {
                    conexionDB.CerrarConexion();
                }
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
                    string query = "UPDATE producto SET nombre = @nombre, cantidad = @cantidad, precio = @precio WHERE idProducto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", newNombre);
                    cmd.Parameters.AddWithValue("@cantidad", newCantidad);
                    cmd.Parameters.AddWithValue("@precio", newPrecio);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    
                        {
                            MessageBox.Show("Producto actualizado exitosamente.");
                            CargarInventario();
                            // Refresca el inventario después de modificar
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron productos con ese Id.");
                        }
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
                string query = "SELECT idProducto, nombre, cantidad, precio FROM producto WHERE idProducto LIKE @id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", "%" + Producto + "%");
                DataTable table = new DataTable();

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
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

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de texto
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
           
        }
    }
}