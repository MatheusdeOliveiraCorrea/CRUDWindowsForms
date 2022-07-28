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

namespace WinFormsApp1
{
    public partial class TelaAdcionar : Form
    {
        public Usuario usuario { set; get; } = new Usuario();
        public TelaPrincipal telaPrincipal;
        public int sinalizadorDeExcessao { get; set; } = 0;
        public TelaAdcionar()
        {
            InitializeComponent();
            dataDeNascimento.ShowCheckBox = true;
        }

        static int id = 0;
        private void aoClicarEmSalvar(object enviar, EventArgs evento)
        {
            try
            {
                if (string.IsNullOrEmpty(campoId.Text))
                {
                    ValidarCampos();
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
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string v = dateTime.ToString();
            dataDeCriacao.Text = v;
        }

        private void aoClicarEmCancelar(object enviar, EventArgs e)// clickar em cancelar ou deletar
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ValidarCampos()
        {
            bool usuarioCadastrando = false;
            bool usuarioEditando = false;
            if (TelaPrincipal.usuarioSelecionado == null)
            {
                usuarioCadastrando = true;
            }
            else if (this.email.Text != TelaPrincipal.usuarioSelecionado.email)
            {
                usuarioEditando = true;
            }

            telaPrincipal = new TelaPrincipal();
            if (EmailJaExiste(this.email.Text, campoId.Text) && (usuarioCadastrando || usuarioEditando))
            {
                throw new Exception("email já existe");
            }
            {

            }
            if (string.IsNullOrWhiteSpace(nome.Text))
            {
                throw new Exception("Nome não pode ser vazio");
            }
            if (string.IsNullOrEmpty(senha.Text))
            {
                throw new Exception("Senha não pode ser vazia");
            }

            string email = this.email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (!match.Success)
            {
                throw new Exception("Insira um email válido");
            }
        }

        private bool EmailJaExiste(string email, string id)
        {
            var encontrado = ListaSingleton.ListaDeUsuarios.FirstOrDefault(usuario => usuario.email == email && usuario.Id.ToString() != id);
            return encontrado != null;
        }
    }
}