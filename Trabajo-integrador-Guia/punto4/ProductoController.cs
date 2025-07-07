using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_integrador_Guia.punto4
{
    internal class ProductoController
    {
        private ProductoRepository repo;

        public ProductoController(ProductoRepository repo)
        {
            this.repo = repo;
        }

        public void Alta()
        {
            var p = new Producto();

            Console.Write("ID: ");
            p.Id = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            p.Nombre = Console.ReadLine();
            Console.Write("Precio: ");
            p.Precio = decimal.Parse(Console.ReadLine());
            Console.Write("Stock: ");
            p.Stock = int.Parse(Console.ReadLine());

            repo.Agregar(p);
            Console.WriteLine("Producto agregado.");
        }

        public void Baja()
        {
            Console.Write("ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());
            repo.Eliminar(id);
            Console.WriteLine("Producto eliminado.");
        }

        public void Modificar()
        {
            Console.Write("ID del producto a modificar: ");
            int id = int.Parse(Console.ReadLine());
            var producto = repo.BuscarPorId(id);
            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }

            Console.Write($"Nombre ({producto.Nombre}): ");
            string nombre = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nombre)) producto.Nombre = nombre;

            Console.Write($"Precio ({producto.Precio}): ");
            string precioStr = Console.ReadLine();
            if (decimal.TryParse(precioStr, out var precio)) producto.Precio = precio;

            Console.Write($"Stock ({producto.Stock}): ");
            string stockStr = Console.ReadLine();
            if (int.TryParse(stockStr, out var stock)) producto.Stock = stock;

            Console.WriteLine("Producto modificado.");
        }

        public void VerTodos()
        {
            var lista = repo.ObtenerTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay productos.");
                return;
            }

            foreach (var p in lista)
            {
                Console.WriteLine(p);
            }
        }

        public void GuardarCambios()
        {
            repo.Guardar();
        }
    }
}
