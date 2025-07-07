using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_integrador_Guia.punto2
{
    internal class Gato : Animal
    {
        public Gato(string nombre) : base(nombre) { }

        public override string EmitirSonido()
        {
            return "Miau!";
        }

        public override string Presentarse()
        {
            return $"Soy un gato llamado {Nombre} y hago {EmitirSonido()}";
        }
    }
}
