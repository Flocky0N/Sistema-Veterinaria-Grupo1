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
            Inventary inventario = new Inventary (txtNombre.Text, txtCantidad.Text, txtPrecio.Text);
            ingresaProducto(inventario);

        }

        public void ingresaProducto (Inventary i)
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
    }
}
