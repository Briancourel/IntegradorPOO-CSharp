using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_integrador_Guia.punto3
{
    internal class Facturasaver
    {
        public void GuardarEnArchivo(Factura factura)
        {
            Console.WriteLine($"Guardando factura #{factura.Id} en archivo...");
        }
    }
}
