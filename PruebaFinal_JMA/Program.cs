using PruebaFinal_JMA.GestorDB;
using PruebaFinal_JMA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinal_JMA
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            
            
            UsuarioDB db = new UsuarioDB();
            try
            {
                Usuarios usuarioObtenido = db.ObtenerUsuarioPorId(1);
                Console.WriteLine(usuarioObtenido.ToString);

                Usuarios usuarioNuevo = new Usuarios("Omar", "Palma", "palmita", "opalma40", "opalma@mail.com");

                if (db.AgregarUsuario(usuarioObtenido))
                {
                    Console.WriteLine("Agregaste un nuevo usuario");
                }

                if (db.BorrarUnUsuarioPorId(2))
                {
                    Console.WriteLine("Eliminaste un usuario");
                }

                Usuarios usuarioAActualizar = new Usuarios();
                if (db.ActualizarUsuarioPorId(2, usuarioAActualizar))
                {
                    Console.WriteLine("Usuario actualizado");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ProductoDB productoDb = new ProductoDB();
            try
            {
                Producto productoObtenido = productoDb.ObtenerProductoPorId(1);
                Console.WriteLine(productoObtenido.ToString);

                Producto productoNuevo = new Producto ();

                if (productoDb.AgregarProducto(productoObtenido))
                {
                    Console.WriteLine("Agregaste un nuevo producto");
                }

                if (productoDb.BorrarUnProductoPorId(2))
                {
                    Console.WriteLine("Eliminaste un producto");
                }

                Producto productoAActualizar = new Producto();
                if (productoDb.ActualizarProductoPorId(2, productoAActualizar))
                {
                    Console.WriteLine("Producto actualizado");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}