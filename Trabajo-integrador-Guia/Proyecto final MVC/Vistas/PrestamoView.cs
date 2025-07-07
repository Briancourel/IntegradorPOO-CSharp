using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_integrador_Guia.punto5.Controlador;

namespace Trabajo_integrador_Guia.punto5.Vistas
{
    internal class PrestamoView
    {
        private PrestamoController prestamoController;

        public PrestamoView(PrestamoController controller)
        {
            prestamoController = controller;
        }

        public void PrestarLibro()
        {
            Console.Clear();
            Console.WriteLine("Prestar libro");
            Console.Write("ISBN del libro: ");
            var isbn = Console.ReadLine();
            Console.Write("Email del usuario: ");
            var email = Console.ReadLine();

            bool exito = prestamoController.PrestarLibro(isbn, email);

            Console.WriteLine(exito ? "Préstamo realizado con éxito." : "Error: libro no disponible o usuario no registrado.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        public void DevolverLibro()
        {
            Console.Clear();
            Console.WriteLine("Devolver libro");
            Console.Write("ISBN del libro: ");
            var isbn = Console.ReadLine();

            bool exito = prestamoController.DevolverLibro(isbn);

            Console.WriteLine(exito ? "Libro devuelto con éxito." : "Error: préstamo no encontrado.");
            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
