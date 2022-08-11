using System;
using System.Linq;
using System.Text.RegularExpressions;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using FluentValidation;
using CrudWindowsForms.Infra.Repositorio;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    public class ValidadorUsuario : AbstractValidator<Usuario>
    {   
        public ValidadorUsuario()
        {
            RuleFor(u => u.nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Insira um nome válido");

            RuleFor(u => u.email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Insira um email válido");

            RuleFor(u => u.senha)
                .NotEmpty()
                .NotNull()
                .WithMessage("Insira uma senha válida");
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
