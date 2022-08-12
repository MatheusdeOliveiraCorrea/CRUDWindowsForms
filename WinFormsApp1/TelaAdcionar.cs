using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Infra.Repositorio;
using FluentValidation;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    public partial class TelaAdcionar : Form
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IValidator<Usuario> _usuarioValidador;
        public Usuario usuario { set; get; } = new Usuario();

        public TelaPrincipal telaPrincipal;

        public TelaAdcionar(IUsuarioRepositorio usuarioRepositorioLinqToDB, IValidator<Usuario> usuarioValidador)
        {
            _usuarioRepositorio = usuarioRepositorioLinqToDB;
            InitializeComponent();
            dataDeNascimento.ShowCheckBox = true;
            _usuarioValidador = usuarioValidador;
        }

        private void AoClicarEmSalvar(object enviar, EventArgs evento)
        {
            try
            {
                usuario.Id = string.IsNullOrEmpty(campoId.Text) ? (int)decimal.Zero : int.Parse(campoId.Text);
                usuario.Nome = nome.Text;
                usuario.Email = email.Text;
                usuario.Senha = senha.Text;
                usuario.DataCriacao = string.IsNullOrEmpty(campoId.Text) ? DateTime.Now : DateTime.Parse(dataDeCriacao.Text);

                if (dataDeNascimento.Checked == true) usuario.DataNascimento = DateTime.Parse(dataDeNascimento.Text);
                else usuario.DataNascimento = null;

                ValidarFormulario(usuario);

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO");
                return;
            }

            this.Close();
        }

        private void ValidarFormulario(Usuario usuario)
        {
            var messagemDeErro = "";
            var result = _usuarioValidador.Validate(usuario);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    messagemDeErro += "->" + error.ErrorMessage + "\n";
                }

                throw new Exception(messagemDeErro);
            }
        }

        private void AoClicarEmCancelar(object enviar, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}