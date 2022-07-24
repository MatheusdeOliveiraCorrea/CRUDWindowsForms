using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            //inicializando atributos com o texto da tela
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            string dataNascimento = boxdataNascimento.Text;
            
            try
            {

                    //atribuindo valores ao usuário
                    usuario.nome = nome;
                    usuario.email = email;
                    usuario.senha = senha;
                    usuario.Id = id;
                    usuario.dataNascimento = DateTime.Parse(dataNascimento);
                    usuario.dataCriacao = DateTime.Now;
                    id++;


                if(this.Text == "Editar")
                {
                    foreach (Usuario u in TelaPrincipal.listaDeUsuarios)
                    {
                        if (u.email == TelaPrincipal.dadosLinhaSelecionada.email && u.senha == TelaPrincipal.dadosLinhaSelecionada.senha)
                        {
                            u.nome = txtNome.Text;
                            u.email = txtEmail.Text;
                            u.senha = txtSenha.Text;
                            u.dataNascimento = DateTime.Parse(boxdataNascimento.Text);
                        }
                    }
                }


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

    }
}
