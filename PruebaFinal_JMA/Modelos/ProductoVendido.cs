using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinal_JMA.Modelos
{
    internal class ProductoVendido
    {
        private int _id;        
        private int _stock;
        private int idProducto;
        private double idVenta;

        public ProductoVendido() { }
        public ProductoVendido(int id, int stock, int idProducto, double idVenta)
        {
            _id = id;
            _stock = stock;
            this.idProducto = idProducto;            
            this.idVenta = idVenta;
        }

        public int Id { get => _id; set => _id = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }        
        public double IdVenta { get => idVenta; set => idVenta = value; }
    }
}
