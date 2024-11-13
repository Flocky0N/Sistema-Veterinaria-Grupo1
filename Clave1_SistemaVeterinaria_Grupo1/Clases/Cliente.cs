using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
    public class Cliente: persona
    {

        //Atributos de la clase llamada cliente
        private string telefono;
        private string direccion;

        //Metodos accesores para poder acceder a la clase cliente
        public string Telefono
        {
            get => telefono;
            set => telefono = value;
        }
        public string Direccion
        {
            get => direccion;
            set => direccion = value;
        }

        //Constructores clase cliente
        public Cliente (string NOMBRE, string TELEFONO, string DIRECCION)
        {
            this.Nombre = NOMBRE;
            this.telefono = TELEFONO;
            this.direccion = DIRECCION;
        }

        public void MostrarInformacionCliente()
        { Console.WriteLine($"ID Cliente: {Id}, Nombre: {Nombre}, Teléfono: {Telefono}, Dirección: {Direccion}");
        
        }
       


    }
}



