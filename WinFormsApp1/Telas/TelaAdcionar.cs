using System;
using System.Windows.Forms;
using WinFormsApp1.Modelo;
using WinFormsApp1.Servicos;
using WinFormsApp1.Repositorio;

namespace WinFormsApp1
{
    public partial class TelaAdcionar : Form
    {
        public Usuario usuario { set; get; } = new Usuario();

        public TelaPrincipal telaPrincipal;

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

                    Validador.ValidarCampos(usuario);
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

                    Validador.ValidarCampos(usuario);
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
    }
}