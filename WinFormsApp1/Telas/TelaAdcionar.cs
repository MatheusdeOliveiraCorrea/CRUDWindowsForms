using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Modelo;
using WinFormsApp1.Servicos;
using WinFormsApp1.Repositorio.Classes_Repositorio;

namespace WinFormsApp1
{
    public partial class TelaAdcionar : Form
    {
        public Usuario usuario { set; get; } = new Usuario();
        public TelaPrincipal telaPrincipal;
        public int sinalizadorDeExcessao { get; set; } = 0;
        //public Validador validador = new Validador();

        UsuarioRepositorio usuariorepositorio = new UsuarioRepositorio();

        public TelaAdcionar()
        {
            InitializeComponent();
            dataDeNascimento.ShowCheckBox = true;
        }

        static int id = 0;
        private void AoClicarEmSalvar(object enviar, EventArgs evento)
        {
            try
            {
                if (string.IsNullOrEmpty(campoId.Text))
                {
                    ValidarCampos();
                    //validador.ValidarCampos(nome.Text, email.Text, senha.Text);
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
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    ValidarCampos();
                    //validador.ValidarCampos(nome.Text, email.Text, senha.Text);
                    usuario.nome = nome.Text;
                    usuario.email = email.Text;
                    usuario.senha = senha.Text;
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
            var dateTime = DateTime.Now;
            dataDeCriacao.Text = dateTime.ToString();
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

        private void ValidarCampos()
        {
            if (nome.Text == string.Empty)
            {
                throw new Exception("Nome não pode ser vazio");
            }

            bool validarCampoDeEmail = ValidarEmailUsuario(this.email.Text, campoId.Text);
            if (!validarCampoDeEmail)
            {
                throw new Exception("Insira o email valido");
            }

            if (EmailJaExiste(this.email.Text) && TelaCadastroOuTelaEditar())
            {
                throw new Exception("Email já existe");
            }

            bool validarCampoDeSenha = string.IsNullOrEmpty(senha.Text);
            if (senha.Text == string.Empty)
            {
                throw new Exception("Senha não pode ser vazia");
            }
        }

        public bool TelaCadastroOuTelaEditar()
        {

            var usuarioCadastrando = false;
            var usuarioEditando = false;
            if (TelaPrincipal.usuarioSelecionado == null)
            {
                usuarioCadastrando = true;
            }
            else if (this.email.Text != TelaPrincipal.usuarioSelecionado.email)
            {
                usuarioEditando = true;
            }

            return usuarioCadastrando || usuarioEditando;
        }

        private bool ValidarEmailUsuario(string email, string idUsuario)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(email);

            return match.Success;
        }

        private bool EmailJaExiste(string email)
        {
            return usuariorepositorio.getListaDeUsuarios().Any(usuario => usuario.email == email);
        }
    }
}