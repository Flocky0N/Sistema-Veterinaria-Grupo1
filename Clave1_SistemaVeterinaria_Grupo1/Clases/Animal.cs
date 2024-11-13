using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
    public class Animal
    {
        //Atributos de la clase llamada Animal
        private int id;
        private string nombre;
        private string tipo;


        //Metodos accesores para poder acceder a la clase Animal
        public int Id
        {
            get => id;
            set => id = value;
        }


        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public string Tipo
        {
            get => tipo;
            set => tipo = value;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {id}, Nombre: {nombre}");
        }
    }
}
