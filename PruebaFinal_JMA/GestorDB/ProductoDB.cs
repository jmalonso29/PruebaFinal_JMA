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
    public class ProductoDB
    {
        private string stringConnection;

        public ProductoDB()
        {
            this.stringConnection = @"Server=JQS\\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        }

        public Producto ObtenerProductoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "select * from Producto where id = @id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string descripcion = reader.GetString(1);
                    decimal costo = Convert.ToDecimal(reader["Costo"]);
                    decimal precioDeVenta = Convert.ToDecimal(reader["PrecioDeVenta"]);
                    int stock = Convert.ToInt32(reader["Stock"]); ;
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]); ;

                    Producto producto = new Producto(id, descripcion, costo, precioDeVenta, stock, idUsuario);

                    return producto;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool AgregarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "insert into Producto (Descripciones, Costo, PrecioDeVenta, Stock, IdUsuario) values (@descripciones, @costo, @precioDeVenta, @stock, @idUsuario); select @@IDENTITY as Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioDeVenta", producto.PrecioDeVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idUsuario", producto.IdUsuario);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool BorrarUnProductoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "delete from Producto where id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
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
