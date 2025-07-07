using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_integrador_Guia.punto5.Controlador;
using Trabajo_integrador_Guia.punto5.Modelos;

namespace Trabajo_integrador_Guia.punto5.Vistas
{
    internal class UsuarioView
    {
        private UsuarioController usuarioController;

        public UsuarioView(UsuarioController controller)
        {
            usuarioController = controller;
        }

        public void RegistrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Registrar nuevo usuario");
            Console.Write("Nombre: ");
            var nombre = Console.ReadLine();
            Console.Write("Email: ");
            var email = Console.ReadLine();

            var usuario = new Usuario { Nombre = nombre, Email = email };
            usuarioController.AgregarUsuario(usuario);

            Console.WriteLine("Usuario registrado. Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}

