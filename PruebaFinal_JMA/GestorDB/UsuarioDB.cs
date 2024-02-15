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
    public class UsuarioDB
    {
        private string stringConnection;

        public UsuarioDB() 
        {
            this.stringConnection = @"Server=JQS\\SQLEXPRESS01;DataBase=coderhouse;Trusted_Connection = true";
        }

        public Usuarios ObtenerUsuarioPorId (int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "select * from Usuario where id = @id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int idObtenido = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string password = reader.GetString(4);
                    string email = reader.GetString(5);

                    Usuarios usuario = new Usuarios(id, nombre, apellido, nombreUsuario, password, email);

                    return usuario;
                }
                throw new Exception("Id no encontrado");
            }
        }

        public bool AgregarUsuario (Usuarios usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "insert into Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) values (@nombre, @apellido, @nombreUsuario, @password, @mail); select @@IDENTITY as Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("password", usuario.Contraseña);
                command.Parameters.AddWithValue("mail", usuario.Mail);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool BorrarUnUsuarioPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "delete from Usuario where id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool ActualizarUsuarioPorId (int id, Usuarios usuario)
        {
            using (SqlConnection connection = new SqlConnection(this.stringConnection))
            {
                string query = "update Usuario set Nombre= @nombre, Apellido= @apellido, NombreUsuario= @nombreUsuario, Contraseña= @password, Mail=@email where id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("password", usuario.Contraseña);
                command.Parameters.AddWithValue("mail", usuario.Mail);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        internal Usuarios ObtenerUsuarioPorId()
        {
            throw new NotImplementedException();
        }
    }
}
