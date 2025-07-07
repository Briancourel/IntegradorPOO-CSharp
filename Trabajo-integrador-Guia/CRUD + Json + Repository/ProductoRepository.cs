using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Trabajo_integrador_Guia.punto4
{
    internal class ProductoRepository
    {
        private const string Archivo = "productos.json";
        private List<Producto> productos = new List<Producto>();

        public ProductoRepository()
        {
            Cargar();
        }

        public List<Producto> ObtenerTodos() => productos;

        public void Agregar(Producto p)
        {
            productos.Add(p);
        }

        public void Eliminar(int id)
        {
            productos.RemoveAll(p => p.Id == id);
        }

        public Producto BuscarPorId(int id)
        {
            return productos.FirstOrDefault(p => p.Id == id);
        }

        public void Guardar()
        {
            var json = JsonSerializer.Serialize(productos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Archivo, json);
        }

        private void Cargar()
        {
            if (File.Exists(Archivo))
            {
                string json = File.ReadAllText(Archivo);
                var datos = JsonSerializer.Deserialize<List<Producto>>(json);
                if (datos != null)
                    productos = datos;
            }
        }
    }
}
