using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_integrador_Guia.punto5.Data;
using Trabajo_integrador_Guia.punto5.Modelos;

namespace Trabajo_integrador_Guia.punto5.Controlador
{
    internal class UsuarioController
    {
        private List<Usuario> usuarios;

        public UsuarioController()
        {
            usuarios = Repository.CargarUsuarios();
        }

        public List<Usuario> ListarUsuarios() => usuarios;

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            Repository.GuardarUsuarios(usuarios);
        }

        public Usuario BuscarPorEmail(string email)
        {
            return usuarios.FirstOrDefault(u => u.Email == email);
        }
    }
}

