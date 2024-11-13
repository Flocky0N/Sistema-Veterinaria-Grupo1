using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave1_SistemaVeterinaria_Grupo1.Clases
{
    class usuario: persona
    {

        //Atributos de la clase llamada usuario
        private string nombreUsuario;
        private string contrasena;
        private string rol;

        //Metodos accesores para poder acceder a la clase usuario
        public string NombreUsuario
        {
            get => nombreUsuario;
            set => nombreUsuario = value;
        }
        public string Contrasena
        {
            get => contrasena;
            set => contrasena = value;
        }
        public string Rol
        {
            get => rol;
            set => rol = value;
        }


        //Constructores clase cliente
        public usuario(string NOMBRE, string NOMBREUSUARIO, string CONTRASENA, string ROL)
        {
            this.Nombre = NOMBRE;
            this.nombreUsuario = NOMBREUSUARIO;
            this.contrasena = CONTRASENA;
            this.rol = ROL;

        }
    }
}
