using System;
using System.Linq;
using System.Text.RegularExpressions;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Infra.Repositorio;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    public class Validador
    {
        private Validador()
        {

        }

        public static void ValidarAtributosUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.nome))
            {
                throw new Exception("Nome não pode ser vazio");
            }

            if (!ValidarFormatoDoEmailInserido(usuario.email) || string.IsNullOrWhiteSpace(usuario.email))
            {
                throw new Exception("Insira um email válido");
            }

            if (string.IsNullOrWhiteSpace(usuario.senha))
            {
                throw new Exception("Senha não pode ser vazia ou ser composta somente de espaços");
            }
        }

        private static bool ValidarFormatoDoEmailInserido(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);

            return match.Success;
        }

        public static bool EmailJaExiste(string email)
        {
            /*esta usando lista...*/
            IUsuarioRepositorio usuarioRepositorio = new BDUsuarioLinqToDB();

            if (usuarioRepositorio.ObterTodos().Any(usuario => usuario.email == email))
            {
                throw new Exception("Email já existe");
            }

            return false;

        }
    }
}
