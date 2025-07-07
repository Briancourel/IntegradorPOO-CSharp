using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_integrador_Guia.punto5.Data;
using Trabajo_integrador_Guia.punto5.Modelos;

namespace Trabajo_integrador_Guia.punto5.Controlador
{
    internal class PrestamoController
    {
        private List<Prestamo> prestamos;
        private LibroController libroController;
        private UsuarioController usuarioController;

        public PrestamoController(LibroController libroCtrl, UsuarioController usuarioCtrl)
        {
            prestamos = Repository.CargarPrestamos();
            libroController = libroCtrl;
            usuarioController = usuarioCtrl;
        }

        public List<Prestamo> ListarPrestamos() => prestamos;

        public bool PrestarLibro(string isbn, string emailUsuario)
        {
            var libro = libroController.BuscarPorISBN(isbn);
            var usuario = usuarioController.BuscarPorEmail(emailUsuario);

            if (libro == null || usuario == null || !libro.Disponible)
                return false;

            libro.Disponible = false;
            var prestamo = new Prestamo
            {
                Libro = libro,
                Usuario = usuario,
                Fecha = DateTime.Now
            };

            prestamos.Add(prestamo);

            Repository.GuardarPrestamos(prestamos);
            libroController.ActualizarLibro(libro);
            return true;
        }

        public bool DevolverLibro(string isbn)
        {
            var prestamo = prestamos.FirstOrDefault(p => p.Libro.ISBN == isbn);
            if (prestamo == null) return false;

            prestamo.Libro.Disponible = true;
            prestamos.Remove(prestamo);

            Repository.GuardarPrestamos(prestamos);
            libroController.ActualizarLibro(prestamo.Libro);
            return true;
        }
    }
}

