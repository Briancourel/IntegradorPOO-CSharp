using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_integrador_Guia.punto2
{
    internal class Animal
    {
        public string Nombre { get; set; }

        public Animal(string nombre)
        {
            Nombre = nombre;
        }

        // Método virtual para que pueda ser sobrescrito
        public virtual string EmitirSonido()
        {
            return "Sonido genérico de animal";
        }

        // Método virtual Presentarse, se sobrescribirá en las subclases
        public virtual string Presentarse()
        {
            return $"Soy un animal llamado {Nombre} y hago {EmitirSonido()}";
        }
    }
}
