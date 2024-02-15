using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaFinal_JMA.Modelos;

namespace PruebaFinal_JMA
{
   
    
    
    public static void CrearProducto(Producto producto)
    {
        string connectionString = @"Server=JQS\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        var query = "insert into Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) values (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.Venta });
                comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario });
            }
            conexion.Close();
        }
    }
    public static void EliminarProducto(Producto producto)
    {
        string connectionString = @"Server=JQS\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        var query = "delete from Producto where Id = @Id";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
            }
            conexion.Close();
        }
    }
    public static List<Producto> Listar Productos()

    {
        List<Producto> lista = new List<Producto>();
        string connectionString = @"Server=JQS\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conecxion.Open();
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                using (SqlDataReader dr = comando.ExecuteReader())

                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();
                            producto.Id = Convert.ToInt32(dr["Id"]);
                            producto.Descripciones = dr["Descripciones"].ToString();
                            producto.Costo = Convert.ToDecimal(dr["Costo"]);
                            producto.PrecioVenta = Convert.ToDecimal(dr['PrecioVenta']);
                            producto.Stock = Convert.ToDecimal(dr["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                            lista.Add(producto);
                        }
                    }
                }
            }
        }
        return lista;
    }

    public static void ModificarProducto(Producto producto)
    {
        string connectionString = @"Server=JQS\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        var query = "update producto" +
                    "set Descripciones = @descripciones" +
                    ", Costo = @Costo" +
                    ", PrecioVenta = @PrecioVenta" +
                    ", Stock = @Stock" +
                    ", IdUsuario =@IdUsuario" +
                    "where Id = @Id";
        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
                comando.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar) { Value = producto.Descripciones });
                comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.Venta });
                comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario });
            }
            conexion.Close();
        }
    }
}
