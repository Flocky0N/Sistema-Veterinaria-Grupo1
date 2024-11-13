using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clave1_SistemaVeterinaria_Grupo1.Clases;
using MySql.Data.MySqlClient;

namespace Clave1_SistemaVeterinaria_Grupo1
{
   
    public partial class FormMascotas : Form
    {
        private conexionGrupo1 conexionDB;
        public FormMascotas()
        {
            InitializeComponent();
            conexionDB = new conexionGrupo1();
            dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección de filas completas
            this.Load += new EventHandler(Mascotas_Load);

        }
        private void Mascotas_Load(object sender, EventArgs e)
        {
            CargarMascotas(); // Carga las mascotas automáticamente en el dgv
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de texto
            txtNombreMascota.Text = "";
            txtEdad.Text = "";
            txtTipo.Text = "";
            txtRaza.Text = "";
            txtIdDueño.Text = "";
           

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                MessageBox.Show("Ingrese datos en los campos correspondientes: " + Camposvacios());
                return;
            }
            try
            {
                // Crear una nueva instancia de Mascotas con los valores de los campos de texto
                Mascotas mascotas = new Mascotas(
                    txtNombreMascota.Text,
                    txtTipo.Text, txtRaza.Text,
                    int.Parse(txtEdad.Text),
                    int.Parse(txtIdDueño.Text));

                ingresarMascotas(mascotas);
            }
            catch (FormatException)
            {
                MessageBox.Show("No está ingresando un valor número válido  para la edad y ID cliente");
            }
        }

        //Metodo para ingresar una mascota a la base de datos
        public void ingresarMascotas(Mascotas c)
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand();
            consulta.Connection = conexion;

            // Verificar que el idCliente (idDueño) existe en la tabla cliente
            consulta.CommandText = "SELECT COUNT(*) FROM  cliente WHERE idCliente = @idCliente";
            consulta.Parameters.AddWithValue("@idCliente", c.IdCliente);
            
            int count = Convert.ToInt32(consulta.ExecuteScalar()); if (count == 0) 
            {
                MessageBox.Show("El ID del dueño no existe en la base de datos. Por favor, verifique el ID.");
                conexionDB.CerrarConexion();
                return;
            }
            consulta.Parameters.Clear(); // Limpia los parámetros anteriores

            consulta.CommandText = "INSERT INTO mascota(nombre,tipo,raza,edad, idCliente) " +
            "VALUES(@nombre, @tipo, @raza, @edad,@idCliente)";

            consulta.Parameters.AddWithValue("@nombre", c.Nombre);
            consulta.Parameters.AddWithValue("@tipo", c.Tipo);
            consulta.Parameters.AddWithValue("@raza", c.Raza);
            consulta.Parameters.AddWithValue("@edad", c.Edad);
            consulta.Parameters.AddWithValue("@idCliente", c.IdCliente);


            try
            {
                int rowsAffected = consulta.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("La mascota se ha agregado exitosamente");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la mascota");
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
        //Método para modificar una mascota
        private void CargarMascotas()
        {
            {
                string query = "SELECT idMascota AS Id, nombre,tipo, raza, edad, idCliente FROM mascota";
                MySqlConnection conexion = conexionDB.AbrirConexion();
                DataTable table = new DataTable();


                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
                    adapter.Fill(table);
                    dgvMascotas.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron mascotas en la base de datos.");
                    }
                    else
                    {
                        dgvMascotas.Columns["Id"].HeaderText = "ID";
                        dgvMascotas.Columns["nombre"].HeaderText = "Nombre";
                        dgvMascotas.Columns["tipo"].HeaderText = "Tipo";
                        dgvMascotas.Columns["raza"].HeaderText = "Raza";
                        dgvMascotas.Columns["edad"].HeaderText = "Edad";
                        dgvMascotas.Columns["idCliente"].HeaderText = "IdCliente";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las mascotas: " + ex.Message);
                }


                finally
                {
                    conexionDB.CerrarConexion();
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dgvMascotas.SelectedRows[0].Cells["Id"].Value);
            string newNombre = txtNombreMascota.Text;
            string newTipo = txtTipo.Text;
            string newRaza = txtRaza.Text;
            string newEdad = txtEdad.Text;
            string newIdDueño = txtIdDueño.Text;


            if (string.IsNullOrEmpty(newNombre))
            {
                MessageBox.Show("Por favor, ingrese el nombre a modificar.");
                return;
            }
            else if (string.IsNullOrEmpty(newTipo))
            {
                MessageBox.Show("Por favor, ingrese el tipo de mascota a modificar");
                return;

            }
            else if (string.IsNullOrEmpty(newRaza))
            {
                MessageBox.Show("Por favor, ingrese la raza a a modificar");
            }
            else if (string.IsNullOrEmpty(newEdad))
            {
                MessageBox.Show("Por favor, ingrese la edad a modificar");
                return;

            }
           
            else if (string.IsNullOrEmpty(newIdDueño))
            {
                MessageBox.Show("Por favor, ingrese el ID del dueño a modificar");
                return;
            }


            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Comando SQL para eliminar una mascota por ID
                    string query = "UPDATE mascota SET nombre = @nombre,tipo = @tipo, raza = @raza, edad = @edad, idCliente = @idCliente" +
                        "WHERE idMascota = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", newNombre);
                    cmd.Parameters.AddWithValue("@tipo", newTipo);
                    cmd.Parameters.AddWithValue("@raza", newRaza);
                    cmd.Parameters.AddWithValue("@edad", newEdad);
                    cmd.Parameters.AddWithValue("@idCliente", newIdDueño);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)

                    {
                        MessageBox.Show("Mascota actualizado exitosamente.");
                        CargarMascotas();
                        // Refresca la tabla de clientes después de modificar
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron mascotas con ese Id.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la mascota: " + ex.Message);
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
            // Obtiene el id de desde el TextBox
            string Mascota = textId.Text;

            if (string.IsNullOrEmpty(Mascota))
            {
                MessageBox.Show("Por favor, ingrese el id de la mascota a buscar.");
                return;
            }


            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                // Consulta para buscar productos por id
                string query = "SELECT idMascota, nombre,tipo, raza, edad,idCliente FROM mascota WHERE idMascota LIKE @id";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", "%" + Mascota + "%");
                DataTable table = new DataTable();

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                    dgvMascotas.DataSource = table;

                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron Mascotas con ese id.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar mascotas: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione ua mascota para eliminar.");
                return;
            }
            int id = Convert.ToInt32(dgvMascotas.SelectedRows[0].Cells["ID"].Value);

            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    // Comando SQL para eliminar una mascota por ID
                    string query = "DELETE FROM mascota WHERE idMascota = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id); // Asigna el ID al parámetro

                    // Ejecuta el comando
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mascota eliminado exitosamente.");

                    //Recarga la lista de clientes
                    CargarMascotas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar mascota: " + ex.Message);
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
    

