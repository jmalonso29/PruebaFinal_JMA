using PruebaFinal_JMA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinal_JMA.GestorDB
{
    public class ProductoVendidoDB
    {
        private string stringConnection;

        public ProductoVendidoDB()
        {
            this.stringConnection = @"Server=JQS\\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        }

        public ProductoVendido ObtenerProductoVendidoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "select * from ProductoVendido where id = @id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int _id = Convert.ToInt32(reader["id"]);
                    int _stock = Convert.ToInt32(reader["Stock"]);
                    int idProducto = Convert.ToInt32(reader["IdProducto"]);
                    double idVenta = Convert.ToInt32(reader["IdVenta"]);
                    
                    ProductoVendido productoVendido = new ProductoVendido(_id, _stock, idProducto, idVenta);

                    return productoVendido;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool ActualizarProductoPorId(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "update Producto set Descripciones= @descripcion, Costo= @costo, PrecioDeVenta= @precioDeVenta, Stock= @stock, IdUsuario=@idUsuario where id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("descripcion", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioDeVenta", producto.PrecioDeVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
