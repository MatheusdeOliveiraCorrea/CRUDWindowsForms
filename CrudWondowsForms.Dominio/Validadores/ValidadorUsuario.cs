using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CrudWindowsForms.Dominio.Validadores
{
    public class ValidadorUsuario : AbstractValidator<Usuario>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public ValidadorUsuario(IUsuarioRepositorio usuarioRepositorioLinqToDB)
        {
            _usuarioRepositorio = usuarioRepositorioLinqToDB;

            RuleFor(usuario => usuario.Nome)
                .NotEmpty().WithMessage("{PropertyName} do usuário NÃO pode ser vazio")
                .MinimumLength(2).WithMessage("{PropertyName} do usuário deve ter NO MÍNIMO {MinLength} caracteres");

            RuleFor(usuario => usuario.Email)
                .NotEmpty().WithMessage("{PropertyName} do usuário NÃO pode ser vazio")
                .MinimumLength(8).WithMessage("{PropertyName} do usuário deve ter NO MÍNIMO {MinLength} caracteres")
                .Must(ValidarFormatoDoEmailInserido).WithMessage("{PropertyName} do usuário {PropertyValue} com formato inválido")
                .Must((usuario, email) => EmailJaExiste(usuario)).WithMessage("{PropertyName}: '{PropertyValue}' já foi cadastrado");

            RuleFor(usuario => usuario.DataNascimento)
                .LessThan(DateTime.Now).WithMessage($"Data de nascimento do usuário não pode ser maior que a data atual: {DateTime.Now.ToString("d")}");

            RuleFor(usuario => usuario.Senha)
                .NotEmpty().WithMessage("{PropertyName} do usuário NÃO pode ser vazia")
                .MinimumLength(5).WithMessage("{PropertyName} do usuário é obrigatória e precisa NO MÍNIMO {MinLength} caracteres");
        }

        private bool ValidarFormatoDoEmailInserido(string email)
        {
            if (string.IsNullOrWhiteSpace(email) == false)
            {
                Match regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email);
                return regex.Success;
            }

            return true;
        }

        private bool EmailJaExiste(Usuario usuarioValidador)
        {
            if (_usuarioRepositorio.ObterTodos().Any(usuario => usuario.Email == usuarioValidador.Email
            && usuarioValidador.Id != usuario.Id))
            {
                return false;
            }
            return true;
        }

        public bool EmailJaExiste(int idDoUsuario, string email)
            {
            if (_usuarioRepositorio.ObterTodos().Any(usuario => usuario.Email == email
             && idDoUsuario != usuario.Id))
            {
                return false;
            }
            return true;
        }
    }
}
