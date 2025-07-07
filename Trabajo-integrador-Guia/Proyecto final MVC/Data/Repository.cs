using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Trabajo_integrador_Guia.punto5.Modelos;

namespace Trabajo_integrador_Guia.punto5.Data
{
    internal class Repository
    {
        private static readonly string librosFile = "libros.json";
        private static readonly string usuariosFile = "usuarios.json";
        private static readonly string prestamosFile = "prestamos.json";

        public static List<Libro> CargarLibros()
        {
            if (!File.Exists(librosFile)) return new List<Libro>();
            var json = File.ReadAllText(librosFile);
            return JsonSerializer.Deserialize<List<Libro>>(json);
        }

        public static void GuardarLibros(List<Libro> libros)
        {
            var json = JsonSerializer.Serialize(libros, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(librosFile, json);
        }

        public static List<Usuario> CargarUsuarios()
        {
            if (!File.Exists(usuariosFile)) return new List<Usuario>();
            var json = File.ReadAllText(usuariosFile);
            return JsonSerializer.Deserialize<List<Usuario>>(json);
        }

        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(usuariosFile, json);
        }

        public static List<Prestamo> CargarPrestamos()
        {
            if (!File.Exists(prestamosFile)) return new List<Prestamo>();
            var json = File.ReadAllText(prestamosFile);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            return JsonSerializer.Deserialize<List<Prestamo>>(json, options);
        }

        public static void GuardarPrestamos(List<Prestamo> prestamos)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };
            var json = JsonSerializer.Serialize(prestamos, options);
            File.WriteAllText(prestamosFile, json);
        }
    }
}

