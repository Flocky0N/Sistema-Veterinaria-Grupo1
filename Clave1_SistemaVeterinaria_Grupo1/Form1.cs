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
    public partial class FormPrincipal : Form
    {
        
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            FormCitas formCitas = new FormCitas();
            formCitas.ShowDialog();
        }

        private void btnMascotas_Click(object sender, EventArgs e)
        {
            FormMascotas formMascotas = new FormMascotas();
            formMascotas.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            Pago pago = new Pago();
            pago .ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
