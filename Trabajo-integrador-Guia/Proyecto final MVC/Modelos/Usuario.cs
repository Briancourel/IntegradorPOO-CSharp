﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_integrador_Guia.punto5.Modelos
{
    internal class Usuario
    {
        public string Nombre { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({Email})";
        }
    }
}
