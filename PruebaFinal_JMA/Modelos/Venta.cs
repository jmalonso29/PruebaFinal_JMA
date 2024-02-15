using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinal_JMA.Modelos
{
    internal class Venta
    {
        private int _id;
        private string? comentarios;
        private int idUsuario;

        public Venta() { }
        public Venta(int id, string? comentarios, int idUsuario)
        {
            _id = id;
            this.comentarios = comentarios;
            this.idUsuario = idUsuario;
        }

        public int Id { get => _id; set => _id = value; }
        public string? Comentarios { get => comentarios; set => comentarios = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
    }
}
