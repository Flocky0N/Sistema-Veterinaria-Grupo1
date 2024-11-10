using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
    class Mascotas
    {
        //Atributos de la clase llamada Mascota
        private string nombre;
        private string edad;
        private string raza;
        private string fechaNacimiento;
        private string idCliente;


        //Metodos accesores para poder acceder a la clase Mascota


        public string NombreMascota
        {
            get => nombre;
            set => nombre = value;
        }
        public string Edad
        {
            get => edad;
            set => edad = value;
        }
        public string Raza
        {
            get => raza;
            set => raza = value;
        }
        public string FechaNacimiento
        {
            get => fechaNacimiento;
            set => fechaNacimiento = value;
        }
        public string IdCliente
        {
            get => idCliente;
            set => idCliente = value;
        }

        //Constructores clase Mascotas
        public Mascotas(string NOMBRE, string RAZA, string FECHANACIMIENTO, string IDCLIENTE)
        {
            this.nombre = NOMBRE;
            this.raza = RAZA;
            this.fechaNacimiento = FECHANACIMIENTO;
            this.idCliente = IDCLIENTE;
        }

    }
}

