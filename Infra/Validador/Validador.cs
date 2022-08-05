using System;
using System.Linq;
using System.Text.RegularExpressions;
using CrudWindowsForms.Dominio.Modelo;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class Validador
    {
        private Validador()
        {

        }

        private static bool EmailJaExiste(string email)
        {
            var usuariorepositorio = new UsuarioRepositorio();
            return usuariorepositorio.ObterTodos().Any(usuario => usuario.email == email);
        }
    }
}
