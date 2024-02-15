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
    public class VentaDB
    {
        private string stringConnection;

        public VentaDB()
        {
            this.stringConnection = @"Server=JQS\\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        }
        public Venta ObtenerVentaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "select * from Venta where id = @id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string comentarios = reader.GetString(1);
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]); ;

                    Venta venta = new Venta(id, comentarios, idUsuario);

                    return venta;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool AgregarVenta(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "insert into Venta (Id, Comentarios, IdUsuario) values (@ïd, @comentarios, @idUsuario); select @@IDENTITY as Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", venta.Id);
                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool BorrarUnaVentaPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "delete from Venta where id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
