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
            boxdataNascimento.ShowCheckBox = true;
            
        }

        static int id = 0;
        private void aoClicarEmSalvar(object sender, EventArgs e)
        {// ou salvando novo usuário ou editando um existente

            try
            {
                if (this.Text == "Cadastro")
                {
                    //atribuindo valores ao usuário
                    usuario.nome = txtNome.Text;
                    usuario.email = txtEmail.Text;
                    usuario.senha = txtSenha.Text;
                    try
                    {
                        ValidarCampos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    if (usuario.Id != 0)
                    {
                        usuario.Id = id;
                    }
                    else
                    {
                        usuario.Id = ++id;
                    }

                    if (boxdataNascimento.Checked == true)
                    {

                        usuario.dataNascimento = DateTime.Parse(boxdataNascimento.Text);

                    }
                    else
                    {
                        boxdataNascimento.Enabled = false;
                        usuario.dataNascimento = null;
                    }


                    usuario.dataCriacao = DateTime.Now;
                    DialogResult = DialogResult.OK;
                    /*FIM ATRIBUIÇÕES*/
                    // código volta pra tela principal para salvar o usuario
      

                }
                //Atualizar
                else
                {
                    
                    try
                    {
                        ValidarCampos();
                        DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        DialogResult = DialogResult.OK;
                        if(ex.Message != "email já existe")
                        {
                            DialogResult = DialogResult.Cancel;
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro " + ex.Message);
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
            try
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                throw new Exception("Nome não pode ser vazio");
            }
            if(string.IsNullOrEmpty(txtSenha.Text))
            {
                throw new Exception("Senha não pode ser vazia");
            }

            string email = txtEmail.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
           
            if (!match.Success)
            {
                throw new Exception("Insira um email válido");
            }
            if (EmailJaExiste(txtEmail.Text))
            {   
                throw new Exception("email já existe");
            }
        }

        public bool EmailJaExiste(string email)
        {
            foreach (Usuario todosUsuarios in TelaPrincipal.listaDeUsuarios)
            {

                if (todosUsuarios.email == email)
                {                  
                    return true;
                }
            }
            return false;
        }
    }
}
