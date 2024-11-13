using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
   public class persona
    {
        private string nombre;
        private int id;
   
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public int Id
        {
            get => id;
            set => id = value;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {id}, Nombre: {nombre}");
        }
    }
}
