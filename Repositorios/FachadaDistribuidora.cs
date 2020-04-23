using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorios
{
    public static class FachadaDistribuidora
    {
        public static bool AltaUsuario(int cedula, string contrasenia,string rol)
        {
            bool ret = false;
            Usuario usu = new Usuario()
            {
                Cedula= cedula,
                Contrasenia = contrasenia,
                Rol = rol,
                
            };
            RepoUsuario repoUsu= new RepoUsuario();
            ret = repoUsu.Alta(usu);
            return ret;
        }

        public static Usuario BuscarUsuarioPorCi(string ci)
        {
            
            Usuario usuarioEncontrado = new Usuario();
            RepoUsuario repoUsu = new RepoUsuario();
            usuarioEncontrado = repoUsu.BuscarPorId(Convert.ToInt32(ci));
            return usuarioEncontrado;
        }
    }
}
