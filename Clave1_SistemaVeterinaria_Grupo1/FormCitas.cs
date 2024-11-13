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
    public partial class FormCitas : Form
    {
        private conexionGrupo1 conexionDB;


        public FormCitas()
        {
            InitializeComponent();
            conexionDB = new conexionGrupo1();
            txtIDCliente.Leave += txtIDCliente_Leave; 
            dgvCita.CellClick += dgvCitas_CellClick; 
            CargarCitas(); // Cargar todas las citas al iniciar el formulario

        }
        private void txtIDCliente_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtIDCliente.Text, out int idCliente))
            {
                ValidarClienteYCargarMascotas(idCliente);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de cliente válido.");
                txtIDCliente.Focus();
            }
        }


        // Método para validar la existencia del cliente y cargar mascotas en el DataGridView
        private void ValidarClienteYCargarMascotas(int idCliente)
        {

            {
                MySqlConnection conexion = conexionDB.AbrirConexion(); if (conexion != null)
                {
                    try
                    {
                        MySqlCommand consulta = new MySqlCommand();
                        consulta.Connection = conexion; // Verificar que el idCliente existe
                        consulta.CommandText = "SELECT COUNT(*) FROM cliente WHERE idCliente = @idCliente";
                        consulta.Parameters.AddWithValue("@idCliente", idCliente); int countCliente = Convert.ToInt32(consulta.ExecuteScalar());
                        if (countCliente == 0)
                        {
                            MessageBox.Show("El ID del cliente no existe en la base de datos. Por favor, verifique el ID.");
                            txtIDCliente.Focus();
                            return;
                        } // Filtrar y cargar solo las mascotas del cliente especificado en el DataGridView
                        consulta.CommandText = "SELECT idMascota, nombre FROM mascota WHERE idCliente = @idCliente";
                        consulta.Parameters.Clear();
                        // Limpiar los parámetros anteriores
                        consulta.Parameters.AddWithValue("@idCliente", idCliente);
                        // Agregar el parámetro idCliente nuevamente
                        DataTable dtMascotas = new DataTable();
                        MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta);
                        adaptador.Fill(dtMascotas);
                        // Llenar el DataTable con los resultados de la consulta
                        dgvCita.DataSource = dtMascotas;
                        // Asignar el DataTable como fuente de datos para el DataGridView
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al llenar el DataTable: " + ex.Message);
                    }
                    finally
                    {
                        conexionDB.CerrarConexion();
                    }
                }
            }


        }
        // Evento para seleccionar el ID de la mascota desde el DataGridView
        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada sea válida
            { 
                txtIDCita.Text = dgvCita.Rows[e.RowIndex].Cells["idCita"].Value.ToString();
            }
        }
                public void ingresarCita(Citas cita)
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                MySqlCommand consulta = new MySqlCommand();
                consulta.Connection = conexion;
                consulta.CommandText = "INSERT INTO cita(fechaHora, estadoMascota, idCliente, idMascota) VALUES(@fechaHora, @estadoMascota, @idCliente, @idMascota)";
                consulta.Parameters.AddWithValue("@fechaHora", cita.FechaCita);
                consulta.Parameters.AddWithValue("@estadoMascota", cita.EstadoMascota);
                consulta.Parameters.AddWithValue("@idCliente", cita.IDCliente);
                consulta.Parameters.AddWithValue("@idMascota", cita.IDMascota);

                try
                {
                    int rowsAffected = consulta.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("La cita se ha agregado exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la cita.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al procesar la instrucción: " + ex.Message);
                }
                finally
                {
                    conexionDB.CerrarConexion();
                }
            }
        }
        public bool validarCampos()
        {
            return !(string.IsNullOrEmpty(txtestadoMascota.Text) ||
                     string.IsNullOrEmpty(txtIDCliente.Text) ||
                     string.IsNullOrEmpty(txtIDMascota.Text) ||
                     dtpfechahora.Value == null); // Asegura que la fecha esté seleccionada
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
            {
                MessageBox.Show("Por favor, llene todos los campos.");
                return;
            }
            try
            { // Crear una nueva instancia de Cita con los valores de los campos Cita
                Citas nuevaCita = new Citas(
                 dtpfechahora.Value,
                 txtestadoMascota.Text,
                 int.Parse(txtIDCliente.Text),
                 int.Parse(txtIDMascota.Text));
                // Llamar al método para ingresar la cita en la base de datos
                ingresarCita(nuevaCita);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para el ID del cliente y el ID de la mascota.");
            }
        }

        private void CargarCitas()
        {
            MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null)
            {
                try
                {
                    string query = "SELECT idCita, fechaHora, estadoMascota, idCliente, idMascota FROM cita";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable dtCitas = new DataTable(); adaptador.Fill(dtCitas);
                    dgvCitasRegistros.DataSource = dtCitas;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al cargar las citas: " + ex.Message);
                }
                finally
                {
                    conexionDB.CerrarConexion();
                }
            }
        }

        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIDCita.Text, out int idCita))
            {
                MySqlConnection conexion = conexionDB.AbrirConexion(); if (conexion != null)
                {
                    try
                    {
                        string query = "DELETE FROM cita WHERE idCita = @idCita"; MySqlCommand cmd = new MySqlCommand(query, conexion); cmd.Parameters.AddWithValue("@idCita", idCita); int rowsAffected = cmd.ExecuteNonQuery(); if (rowsAffected > 0)
                        {
                            MessageBox.Show("La cita ha sido cancelada exitosamente."); CargarCitas();
                            // Actualizar el DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No se pudo cancelar la cita.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al cancelar la cita: " + ex.Message);
                    }
                    finally
                    {
                        conexionDB.CerrarConexion();

                    }
                }
            }
            else { MessageBox.Show("Por favor, seleccione una cita válida para cancelar."); }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de texto
            txtIDCita.Text = "";
            txtestadoMascota.Text = "";
            txtIDCliente.Text = "";
            txtIDMascota.Text = "";

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIDCita.Text, out int idCita) &&
                DateTime.TryParse(dtpfechahora.Value.ToString(), out DateTime fechaHora) && 
                int.TryParse(txtIDCliente.Text, out int idCliente) && 
                int.TryParse(txtIDMascota.Text, out int idMascota))
            {
                MySqlConnection conexion = conexionDB.AbrirConexion();
                if (conexion != null)
                {
                    try
                    {
                        string query = "UPDATE cita SET fechaHora = @fechaHora, estadoMascota = @estadoMascota, idCliente = @idCliente, idMascota = @idMascota WHERE idCita = @idCita";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@fechaHora", dtpfechahora.Value);
                        cmd.Parameters.AddWithValue("@estadoMascota", txtestadoMascota.Text);
                        cmd.Parameters.AddWithValue("@idCliente", int.Parse(txtIDCliente.Text));
                        cmd.Parameters.AddWithValue("@idMascota", int.Parse(txtIDMascota.Text));
                        cmd.Parameters.AddWithValue("@idCita", idCita);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("La cita ha sido modificada exitosamente.");
                            CargarCitas();
                            // Actualizar el DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar la cita.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al modificar la cita: " + ex.Message);
                    }
                    finally
                    {
                        conexionDB.CerrarConexion();

                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una cita válida para modificar.");

            }
        }
    }
}

                      
