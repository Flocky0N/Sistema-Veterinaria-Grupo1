using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
    class Inventary
    {
        //Atributos de la clase llamada Inventario
        private string nombre;
        private string cantidad;
        private string precio;

        //Metodos accesores para poder acceder a la clase inventario


        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public string Cantidad
        {
            get => cantidad;
            set => cantidad = value;
        }
        public string Precio
        {
            get => precio;
            set => precio = value;
        }

        //Constructores clase inventario
        public Inventary(string NOMBRE, string CANTIDAD, string PRECIO)
        {
            this.nombre = NOMBRE;
            this.cantidad = CANTIDAD;
            this.precio = PRECIO;
        }


    }
}

