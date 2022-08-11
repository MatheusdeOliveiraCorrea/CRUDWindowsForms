using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Dominio.Servicos;
using CrudWindowsForms.Infra.Repositorio;
using FluentValidation;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    public partial class TelaAdcionar : Form
    {
        public Usuario usuario { set; get; } = new Usuario();

        public TelaPrincipal telaPrincipal;

        public TelaAdcionar()
        {
            InitializeComponent();
            dataDeNascimento.ShowCheckBox = true;
        }

        private void AoClicarEmSalvar(object enviar, EventArgs evento)
        {
            try
            {
                usuario.Id = string.IsNullOrEmpty(campoId.Text) ? (int)decimal.Zero : int.Parse(campoId.Text);
                usuario.nome = nome.Text;
                usuario.email = email.Text;
                usuario.senha = senha.Text;
                usuario.dataCriacao = string.IsNullOrEmpty(campoId.Text) ? DateTime.Now : DateTime.Parse(dataDeCriacao.Text);

                if (dataDeNascimento.Checked == true) usuario.dataNascimento = DateTime.Parse(dataDeNascimento.Text);
                else usuario.dataNascimento = null;

                var validador = new ValidadorUsuario();
                validador.ValidateAndThrow(usuario);

                //ValidadorUsuario.ValidarAtributosUsuario(usuario);

                if (string.IsNullOrEmpty(campoId.Text))
                {
                    ValidadorUsuario.ValidarAtributosUsuario(usuario);
                    ValidadorUsuario.EmailJaExiste(usuario.email);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
                return;
            }

            this.Close();
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