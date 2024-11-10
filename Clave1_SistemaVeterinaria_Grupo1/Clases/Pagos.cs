using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
    class Pagos
    {

        //Atributos de la clase llamada Mascota
        private string monto;
        private string tipoPago;
        private string fecha;
        private string idCita;
     
        public string Monto
        {
            get => monto;
            set => monto = value;
        }
        public string TipoPago
        {
            get => tipoPago;
            set => tipoPago = value;
        }
        public string Fecha
        {
            get => fecha;
            set => fecha = value;
        }
        
        public string IdCita
        {
            get => idCita;
            set => idCita = value;
        }

        //Constructores clase Mascotas
        public Pagos(string MONTO, string TIPOPAGO, string FECHANACIMIENTO, string IDCITA)
        {
            this.monto = MONTO;
            this.tipoPago = TIPOPAGO;
            this.fecha = FECHANACIMIENTO;
            this.idCita = IDCITA;
        }
    }
}
