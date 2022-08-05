using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Dominio.Servicos;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    public partial class TelaAdcionar : Form
    {
        public Usuario usuario { set; get; } = new Usuario();

        public TelaPrincipal telaPrincipal;

        static int id = 0;

        public TelaAdcionar()
        {
            InitializeComponent();
            dataDeNascimento.ShowCheckBox = true;
        }

        private void AoClicarEmSalvar(object enviar, EventArgs evento)
        {
            try
            {
                if (string.IsNullOrEmpty(campoId.Text))
                {
                    usuario = new Usuario();
                    usuario.nome = nome.Text;
                    usuario.email = email.Text;
                    usuario.senha = senha.Text;
                    usuario.Id = usuario.Id != 0 ? usuario.Id = id : usuario.Id = ++id;
                    if (dataDeNascimento.Checked == true)
                    {
                        usuario.dataNascimento = DateTime.Parse(dataDeNascimento.Text);
                    }
                    else
                    {
                        dataDeNascimento.Enabled = false;
                        usuario.dataNascimento = null;
                    }
                    usuario.dataCriacao = DateTime.Now;

                    ValidarCampos(usuario);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    usuario = new Usuario();
                    usuario.Id = int.Parse(campoId.Text);
                    usuario.nome = nome.Text;
                    usuario.email = email.Text;
                    usuario.senha = senha.Text;
                    if (dataDeNascimento.Checked == true)
                    {
                        usuario.dataNascimento = DateTime.Parse(dataDeNascimento.Text);
                    }
                    else
                    {
                        dataDeNascimento.Enabled = false;
                        usuario.dataNascimento = null;
                    }

                    usuario.dataCriacao = DateTime.Parse(dataDeCriacao.Text);

                    ValidarCampos(usuario);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
                return;
            }

            this.Close();
        }

        private void TelaAdcionar_Load(object enviar, EventArgs evento)
        {
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

        private void dataDeCriacao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}