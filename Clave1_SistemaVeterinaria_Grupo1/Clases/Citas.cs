using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
   public class Citas
    {
        //Atributos de la clase llamada cia
        private DateTime fechaCita;
        private string estadoMascota;
        private int idCliente;
        private int idMascota;

        //Metodos accesores para poder acceder a la clase cita


        public DateTime FechaCita
        {
            get => fechaCita;
            set => fechaCita = value;
        }
        public string EstadoMascota
        {
            get => estadoMascota;
            set => estadoMascota = value;
        }
        public int IDCliente
        {
            get => idCliente;
            set => idCliente = value;
        }

        public int IDMascota
        {
            get => idMascota;
            set => idMascota = value;
        }

        //Constructores clase cita
        public Citas (DateTime FECHACITA, string ESTADOMASCOTA, int IDCLIENTE, int IDMASCOTA)
        {
            this.fechaCita = FECHACITA;
            this.estadoMascota = ESTADOMASCOTA;
            this.idCliente = IDCLIENTE;
            this.idMascota = IDMASCOTA;
        }


    }
}

   
