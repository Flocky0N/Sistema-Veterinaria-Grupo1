using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
    public class Mascotas: Animal
    {
        //Atributos de la clase llamada Mascota
        
        private string raza;
        private int edad;
        private int idCliente;


        //Metodos accesores para poder acceder a la clase Mascota
        public string Raza
        {
            get => raza;
            set => raza = value;
        }
        public int Edad
        {
            get => edad;
            set => edad = value;
        }
        public int IdCliente
        {
            get => idCliente;
            set => idCliente = value;
        }

        //Constructores clase Mascotas
        public Mascotas(string NOMBRE, string TIPO, string RAZA, int EDAD, int IDCLIENTE)
        {
            this.Nombre = NOMBRE;
            this.Tipo = TIPO;
            this.raza = RAZA;
            this.edad = EDAD;
            this.idCliente = IDCLIENTE;
        }

    }
}

