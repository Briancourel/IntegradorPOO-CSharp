using System;

namespace Trabajo_integrador_Guia
{
    internal class Ciudadano
    {
        // Campos privados
        private string nombreCompleto;
        private string dni;
        private int edad;

        // Constructor
        public Ciudadano(string nombreCompleto, string dni, int edad)
        {
            this.NombreCompleto = nombreCompleto;
            this.DNI = dni;
            this.Edad = edad; // se valida en la propiedad
        }

        // Propiedades con encapsulamiento
        public string NombreCompleto
        {
            get { return nombreCompleto; }
            set { nombreCompleto = value; }
        }

        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value >= 0)
                    edad = value;
                else
                    throw new ArgumentException("La edad no puede ser negativa.");
            }
        }

        // Método Saludar
        public string Saludar()
        {
            return $"Hola, soy {NombreCompleto} y tengo {Edad} años.";
        }

        // Método para saber si es mayor de edad
        public bool EsMayorDeEdad()
        {
            return Edad >= 18;
        }
    }
}

