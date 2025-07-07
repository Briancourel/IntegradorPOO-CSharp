using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_integrador_Guia.punto4
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio:C}, Stock: {Stock}";
        }
    }
}
