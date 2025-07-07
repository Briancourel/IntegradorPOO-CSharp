using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Trabajo_integrador_Guia.punto3.ISP
{
    internal class FacturaPrinterDigital : IimprimirDigital
    {
       public void ImprimirDigital()
        {
            Console.WriteLine($"Factura  impresa digitalmente.");
        }
    }
}
