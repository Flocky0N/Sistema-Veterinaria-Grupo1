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
    }
}
