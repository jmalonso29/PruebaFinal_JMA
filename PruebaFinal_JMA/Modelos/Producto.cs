using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinal_JMA.Modelos
{
    public class Producto
    {
        private int id;
        private string descripcion;
        private decimal _costo;
        private decimal precioDeVenta;
        private int _stock;
        private int _idUsuario;

        public Producto() { }
        public Producto(int id, string descripcion, decimal costo, decimal precioDeVenta, int stock, int idUsuario)
        {
            this.id = id;
            this.descripcion = descripcion;
            _costo = costo;
            this.precioDeVenta = precioDeVenta;
            _stock = stock;
            _idUsuario = idUsuario;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Costo { get => _costo; set => _costo = value; }
        public decimal PrecioDeVenta { get => precioDeVenta; set => precioDeVenta = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
    }

    
}

