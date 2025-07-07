using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_integrador_Guia.punto2
{
    internal class Perro : Animal
    {
        public Perro(string nombre) : base(nombre) { }

        public override string EmitirSonido()
        {
            return "Guau!";
        }

        public override string Presentarse()
        {
            return $"Soy un perro llamado {Nombre} y hago {EmitirSonido()}";
        }
    }
}
