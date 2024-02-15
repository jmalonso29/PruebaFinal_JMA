using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinal_JMA.Modelos
{
    public class Usuarios
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _email;

        public Usuarios() { }
        public Usuarios(string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._contraseña = contraseña;
            this._email = mail;
        }

        public Usuarios (int id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail) : this(nombre, apellido, nombreUsuario, contraseña, mail) 
        {
            this.Id = Id;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Mail { get => _email; set => _email = value; }
    }
}
