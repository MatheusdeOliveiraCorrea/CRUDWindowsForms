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
            RuleFor(usuario => usuario.nome)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Insira um nome válido");

            RuleFor(usuario => usuario.email)
                .NotEmpty()
                .MinimumLength(8)
                .Must(this.ValidarFormatoDoEmailInserido)
                .WithMessage("Insira um email válido")
                .Must((usuario, email) => this.EmailJaExiste(usuario))
                .WithMessage("Email já cadastrado");

            RuleFor(usuario => usuario.dataNascimento)
                .LessThan(DateTime.Now)
                .WithMessage($"Data não pode ser mair que a data atual: {DateTime.Now.ToString("d")} ");

            RuleFor(usuario => usuario.senha)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Insira uma senha válida");
        }

        private bool ValidarFormatoDoEmailInserido(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email);
            return regex.Success;
        }

        private bool EmailJaExiste(Usuario usuarioValidador)
        {
            IUsuarioRepositorio usuarioRepositorio = new UsuarioRepositorioLinqToDB();

            if (usuarioRepositorio.ObterTodos().Any(usuario => usuario.email == usuarioValidador.email
            && usuarioValidador.Id != usuario.Id))
            {
                return false;
            }

            return true;
        }
    }
}
