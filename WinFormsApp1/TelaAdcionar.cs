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
        public int sinalizadorDeExcessao { get; set; }
        public TelaAdcionar()
        {
            InitializeComponent();
        }

        static int id = 0;
        private void aoClicarEmSalvar(object sender, EventArgs e)
        {// ou salvando novo usuário ou editando um existente
            
            try
            {

                    //atribuindo valores ao usuário
                    usuario.nome = txtNome.Text;
                    usuario.email = txtEmail.Text;
                    usuario.senha = txtSenha.Text;


                if (usuario.Id != 0)
                {
                    usuario.Id = id;
                }
                else
                {
                    usuario.Id = ++id;
                }
                usuario.dataNascimento = DateTime.Parse(boxdataNascimento.Text);
                    usuario.dataCriacao = DateTime.Now;
                try
                {
                    ValidarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                //
                //DialogResult = DialogResult.OK;        
                sinalizadorDeExcessao = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("Dados inválidos ou incompletos", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinalizadorDeExcessao++;
                this.Close();
               
            }
            
            this.Close();
        }
        
        private void TelaAdcionar_Load(object sender, EventArgs e)
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string v = dateTime.ToString();
            txtCriacao.Text = v;
            
        }


        private void aoClicarEmSair(object sender, EventArgs e)// clickar em cancelar ou deletar
        {

            if (btnCancelar.Text == "Cancelar")
            {//código cancelar
                Close();
            }
            else
            {//código deletar

                usuario = new Usuario();
                usuario.Id = int.Parse(txtId.Text);
                usuario.nome = txtNome.Text;
                usuario.email = txtEmail.Text;
                usuario.senha = txtSenha.Text;
                usuario.dataNascimento = DateTime.Parse(boxdataNascimento.Text);
                usuario.dataCriacao = DateTime.Parse(txtCriacao.Text);

                telaPrincipal = new TelaPrincipal();
                telaPrincipal.removerListaUsuarios(usuario.email, usuario.senha);

                Close();
            }

        }

        public void ValidarCampos()
        {
            if(txtNome.Text == string.Empty)
            {
                throw new Exception("Este campo não pode ser vazio");
            }
            if(txtSenha.Text == string.Empty)
            {
                throw new Exception("Este campo não pode ser vazio");
            }

            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                throw new Exception("Insira um email válido");
            }
        }

    }
}
