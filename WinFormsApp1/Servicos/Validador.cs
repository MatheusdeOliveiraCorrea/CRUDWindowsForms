using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinFormsApp1.Modelo;
using WinFormsApp1.Repositorio.Classes_Repositorio;
namespace WinFormsApp1.Servicos
{
    public class Validador
    {
        UsuarioRepositorio _repositorio = new UsuarioRepositorio();
        Usuario usuario = new Usuario();

        public void ValidarCampos(Usuario usuario)
        {
            if (usuario.nome == String.Empty)
            {
                throw new Exception("Nome não pode ser vazio");
            }

            if (!ValidarEmailUsuario(usuario.email))
            {
                throw new Exception("Insira o email valido");
            }

            if (EmailJaExiste(usuario.email))
            {
                throw new Exception("Email já existe");
            }

            bool validarCampoDeSenha = string.IsNullOrEmpty(usuario.senha);
            if (validarCampoDeSenha)
            {
                throw new Exception("Senha não pode ser vazia");
            }
        }

        private bool ValidarEmailUsuario(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);

            return match.Success;
        }

        private bool EmailJaExiste(string email)
        {
            var emailExiste = false;
            if (usuario.Id == decimal.Zero)
            {
                emailExiste = _repositorio.getListaDeUsuarios().Any(usuario => usuario.email == email);
            }
            else
            {
                //O usuario mudou o email? verifique se o email já existe no banco

            }

            return emailExiste;
        }
    }
}
