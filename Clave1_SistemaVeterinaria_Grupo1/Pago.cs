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
    public partial class Pago : Form
    {
        private conexionGrupo1 conexionDB;

        public Pago()
        {
            InitializeComponent();
            conexionDB = new conexionGrupo1();
            CargarCitasParaPago();
            // Cargar todas las citas al iniciar el formulario
            dgvCitasPago.CellClick += dgvCitasPago_CellClick;
            // Agrega el evento para capturar la selección
            CargarPagos();
        }
     

        private void CargarCitasParaPago()
        {
            MySqlConnection conexion = conexionDB.AbrirConexion(); if (conexion != null)
            {
                try
                {
                    string query = "SELECT idCita, fechaHora, estadoMascota, idCliente, idMascota FROM cita";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable dtCitas = new DataTable();
                    adaptador.Fill(dtCitas);
                    dgvCitasPago.DataSource = dtCitas; 
                    // Asegúrate de que tienes un DataGridView llamado dgvCitasParaPago
                    } catch (MySqlException ex)
                {
                    MessageBox.Show("Error al cargar las citas: " + ex.Message);
                } finally { 
                    conexionDB.CerrarConexion();
                } 
            } 
        }
        private void dgvCitasPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada sea válida
            { txtIdCita.Text = dgvCitasPago.Rows[e.RowIndex].Cells["idCita"].Value.ToString();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMonto.Text, out decimal monto) &&
               !string.IsNullOrEmpty(cmbPago.SelectedItem?.ToString()) &&
               int.TryParse(txtIdCita.Text, out int idCita))
            {
                MySqlConnection conexion = conexionDB.AbrirConexion();
                if (conexion != null)
                {
                    try
                    {
                        string query = "INSERT INTO pago (monto, tipoPago, fecha, idCita)" +
                      " VALUES (@monto, @tipoPago, @fecha, @idCita)";
                        MySqlCommand cmd = new MySqlCommand(query, conexion);
                        cmd.Parameters.AddWithValue("@monto", monto);
                        cmd.Parameters.AddWithValue("@tipoPago", cmbPago.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value);
                        cmd.Parameters.AddWithValue("@idCita", idCita);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("El pago ha sido agregado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo agregar el pago.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al agregar el pago: " + ex.Message);
                    }
                    finally
                    {
                        conexionDB.CerrarConexion();
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para todos los campos.");
            }
        }
        private void CargarPagos()
        { MySqlConnection conexion = conexionDB.AbrirConexion();
            if (conexion != null) { try { string query = "SELECT idPago, monto, tipoPago, fecha, idCita FROM pago";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
            DataTable dtPagos = new DataTable(); 
            adaptador.Fill(dtPagos);
            dgvPagos.DataSource = dtPagos;
                } catch (MySqlException ex)
                { 
                    MessageBox.Show("Error al cargar los pagos: " + ex.Message);
                } finally { conexionDB.CerrarConexion();
                } 
            }
        }

        private void dgvPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que la fila seleccionada sea válida
            { txtIdPago.Text = dgvPagos.Rows[e.RowIndex].Cells["idPago"].Value.ToString();
              txtMonto.Text = dgvPagos.Rows[e.RowIndex].Cells["monto"].Value.ToString();
              cmbPago.SelectedItem = dgvPagos.Rows[e.RowIndex].Cells["tipoPago"].Value.ToString(); 
              dtpFecha.Value = Convert.ToDateTime(dgvPagos.Rows[e.RowIndex].Cells["fecha"].Value.ToString());
              txtIdCita.Text = dgvPagos.Rows[e.RowIndex].Cells["idCita"].Value.ToString(); 
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            {
                if (int.TryParse(txtIdPago.Text, out int idPago))
                {
                    MySqlConnection conexion = conexionDB.AbrirConexion(); if (conexion != null)
                    {
                        try
                        {
                            string query = "DELETE FROM pago WHERE idPago = @idPago";
                            MySqlCommand cmd = new MySqlCommand(query, conexion);
                            cmd.Parameters.AddWithValue("@idPago", idPago);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("El pago ha sido eliminado exitosamente.");
                                CargarPagos();
                                // Actualizar el DataGridView
                            }
                            else
                            {
                                MessageBox.Show("No se pudo eliminar el pago.");
                            }
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Error al eliminar el pago: " + ex.Message);
                        }
                        finally
                        {
                            conexionDB.CerrarConexion();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un pago válido para eliminar.");
                }
            }
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            txtIdPago.Clear();
            txtMonto.Clear();
            cmbPago.SelectedIndex = -1;
            // Deselecciona cualquier opción
            dtpFecha.Value = DateTime.Now; 
           // Restablece la fecha a la fecha actual
            txtIdCita.Clear();
        }
    }
}
 

