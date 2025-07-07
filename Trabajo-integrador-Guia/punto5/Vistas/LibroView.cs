using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_integrador_Guia.punto5.Controlador;
using Trabajo_integrador_Guia.punto5.Modelos;

namespace Trabajo_integrador_Guia.punto5.Vistas
{
    internal class LibroView
    {
        private LibroController libroController;

        public LibroView(LibroController controller)
        {
            libroController = controller;
        }

        public void RegistrarLibro()
        {
            Console.Clear();
            Console.WriteLine("Registrar nuevo libro");
            Console.Write("Título: ");
            var titulo = Console.ReadLine();
            Console.Write("Autor: ");
            var autor = Console.ReadLine();
            Console.Write("ISBN: ");
            var isbn = Console.ReadLine();

            var libro = new Libro { Titulo = titulo, Autor = autor, ISBN = isbn, Disponible = true };
            libroController.AgregarLibro(libro);

            Console.WriteLine("Libro registrado. Presione Enter para continuar...");
            Console.ReadLine();
        }

        public void MostrarLibrosDisponibles()
        {
            Console.Clear();
            Console.WriteLine("Libros disponibles:");
            List<Libro> libros = libroController.ListarLibrosDisponibles();

            if (libros.Count == 0)
                Console.WriteLine("No hay libros disponibles.");
            else
                libros.ForEach(l => Console.WriteLine(l));

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}

