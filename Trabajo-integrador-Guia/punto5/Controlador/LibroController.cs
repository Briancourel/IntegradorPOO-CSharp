using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_integrador_Guia.punto5.Data;
using Trabajo_integrador_Guia.punto5.Modelos;

namespace Trabajo_integrador_Guia.punto5.Controlador
{
    internal class LibroController
    {
        private List<Libro> libros;

        public LibroController()
        {
            libros = Repository.CargarLibros();
        }

        public List<Libro> ListarLibros() => libros;

        public List<Libro> ListarLibrosDisponibles() => libros.Where(l => l.Disponible).ToList();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            Repository.GuardarLibros(libros);
        }

        public Libro BuscarPorISBN(string isbn)
        {
            return libros.FirstOrDefault(l => l.ISBN == isbn);
        }

        public void ActualizarLibro(Libro libro)
        {
            Repository.GuardarLibros(libros);
        }
    }
}


