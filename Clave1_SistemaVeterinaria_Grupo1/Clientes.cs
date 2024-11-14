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
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de filas completas
            this.Load += new EventHandler(Clientes_Load);
        }
        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarClientes(); // Carga los clientes automáticamente en el dgv
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

            consulta.Parameters.AddWithValue("@nombre", c.Nombre);
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
       
       
        private void btnConexion_Click(object sender, EventArgs e)
        {
            try
            {
                conexionDB.AbrirConexion();
                MessageBox.Show("Conexión satisfactoria");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de texto
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

        }

        //Método para modificar un producto
        private void CargarClientes()
        {
            {
                string query = "SELECT idCliente AS Id, nombre, telefono, direccion FROM cliente";
                MySqlConnection conexion = conexionDB.AbrirConexion();
                DataTable table = new DataTable();


                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                    adapter.Fill(table);
                    dgvClientes.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron clientes en la base de datos.");
                    }
                    else
                    {
                        dgvClientes.Columns["Id"].HeaderText = "ID";
                        dgvClientes.Columns["nombre"].HeaderText = "Nombre";
                        dgvClientes.Columns["telefono"].HeaderText = "Telefono";
                        dgvClientes.Columns["direccion"].HeaderText = "Direccion";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los clientes: " + ex.Message);
                }


                finally
                {
                    conexionDB.CerrarConexion();
                }
            }
        }
       
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells[0].Value);
            string newNombre = txtNombre.Text;
            string newTelefono = txtTelefono.Text;
            string newDireccion = txtDireccion.Text;

            if (string.IsNullOrEmpty(newNombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre a modificar.");
                return;
            }
            else if (string.IsNullOrEmpty(newTelefono))
            {
                MessageBox.Show("Por favor, ingrese el número de telefono a modificar");
                return;

            }
            else if (string.IsNullOrEmpty(newDireccion))
            {
                MessageBox.Show("Por favor, ingrese la dirección a modificar");
                return;
            }


            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Comando SQL para eliminar un producto por ID
                    string query = "UPDATE cliente SET nombre = @nombre, telefono = @telefono, direccion = @direccion WHERE idCliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", newNombre);
                    cmd.Parameters.AddWithValue("@telefono", newTelefono);
                    cmd.Parameters.AddWithValue("@direccion", newDireccion);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)

                    {
                        MessageBox.Show("Cliente actualizado exitosamente.");
                        CargarClientes();
                        // Refresca la tabla de clientes después de modificar
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron clientes con ese Id.");
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Obtiene el id del producto desde el TextBox
            string Cliente = textId.Text;

            if (string.IsNullOrEmpty(Cliente))
            {
                MessageBox.Show("Por favor, ingrese el id del producto a buscar.");
                return;
            }


            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                // Consulta para buscar productos por id
                string query = "SELECT idCliente, nombre, telefono, direccion FROM cliente WHERE idCliente LIKE @id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", "%" + Cliente + "%");
                DataTable table = new DataTable();

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                    dgvClientes.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron clientes con ese id.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar los clientes: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                return;
            }
            int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ID"].Value);

            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Comando SQL para eliminar un cliente por ID
                    string query = "DELETE FROM cliente WHERE idCliente = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id); // Asigna el ID al parámetro

                    // Ejecuta el comando
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente eliminado exitosamente.");

                    //Recarga la lista de clientes
                    CargarClientes();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}











       