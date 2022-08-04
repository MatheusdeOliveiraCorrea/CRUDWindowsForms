using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinFormsApp1.Modelo;
using WinFormsApp1.Repositorio;
namespace WinFormsApp1.Servicos

{
    public class Validador
    {
        private Validador()
        {

        }

        public static void ValidarCampos(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.nome))
            {
                throw new Exception("Nome não pode ser vazio");
            }

            if (!ValidarFormatoDoEmailInserido(usuario.email) || string.IsNullOrWhiteSpace(usuario.email))
            {
                throw new Exception("Insira um email válido");
            }

            if (EmailJaExiste(usuario.email) && EmailFoiEditado(usuario))
            {
                throw new Exception("Email já existe");
            }

            if (string.IsNullOrWhiteSpace(usuario.senha))
            {
                throw new Exception("Senha não pode ser vazia ou ser composta somente de espaços");
            }
        }

        private static bool EmailFoiEditado(Usuario usuario)
        {
            var usuarioCadastrando = false;
            var usuarioEditandoEmail = false;
            if (TelaPrincipal.usuarioSelecionado == null)
            {
                usuarioCadastrando = true;
            }
            else if (usuario.email != TelaPrincipal.usuarioSelecionado.email)
            {
                usuarioEditandoEmail = true;
            }
            return usuarioCadastrando || usuarioEditandoEmail;
        }

        private static bool ValidarFormatoDoEmailInserido(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);

            return match.Success;
        }

        private static bool EmailJaExiste(string email)
        {
            var usuariorepositorio = new UsuarioRepositorio();
            return usuariorepositorio.ObterTodos().Any(usuario => usuario.email == email);
        }
    }
}
