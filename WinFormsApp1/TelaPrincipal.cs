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

    public partial class TelaPrincipal : Form
    {

        public static List<Usuario> listaDeUsuarios { get; private set; } = new List<Usuario>();
        TelaAdcionar telaCadastro = new TelaAdcionar();

        public TelaPrincipal()
        {
            InitializeComponent();
            gridUsuarios.DataSource = listaDeUsuarios.ToList();
            gridUsuarios.Columns["senha"].Visible = false;
        }

        //METODOS PARA MANIPULAR LISTA EM OUTRAS CLASSES
        public void adcionarListaUsuarios(Usuario usuario)
        {
            listaDeUsuarios.Add(usuario);
        }
        public void removerListaUsuarios(string email, string senha)
        {

            try
            {

                foreach (Usuario u in listaDeUsuarios)
                {

                    if (u.email == email && u.senha == senha)
                    {
                        listaDeUsuarios.Remove(u);
                        MessageBox.Show("Usuario Excluido", "ALERTA");
                    }


                }
            }
            catch (Exception ex)
            {
        
            }
        }
        public void editarListaUsuarios()
        {

        }


        public void frameLista_Load(object sender, EventArgs e)
        {


        }

        private void aoClicarAdcionarUsuario(object sender, EventArgs e)
        {

            //Mostrar Tela Cadastro
            telaCadastro = null;
            telaCadastro = new TelaAdcionar();
            telaCadastro.txtId.ReadOnly = true;
            telaCadastro.txtCriacao.ReadOnly = true;
            telaCadastro.ShowDialog();

            //verificar se foi adcionado algum dado na janela cadastro ou não 
            //se o usuário da tela de cadastro não existe em lista

            if (telaCadastro.sinalizadorDeExcessao == 0)
            {
                //retornar true se nenhum campo for nulo
                bool camposNaoNulos = (!string.IsNullOrWhiteSpace(telaCadastro.usuario.nome)) &&
                    (!string.IsNullOrWhiteSpace(telaCadastro.usuario.email)) &&
                    (!string.IsNullOrWhiteSpace(telaCadastro.usuario.senha));
            

                if (!listaDeUsuarios.Contains(telaCadastro.usuario) && camposNaoNulos )
                {
                    listaDeUsuarios.Add(telaCadastro.usuario);  
                    AtualizarGrid();
                }
                else
                {
                    MessageBox.Show("Dados inválidos ou incompletos", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            //seta tela limpa
            telaCadastro = null;
            telaCadastro = new TelaAdcionar();

            telaCadastro.txtId.ReadOnly = true; //id indisponível para editar.
            telaCadastro.txtNome.ReadOnly = true;//nome indisponível para editar
            telaCadastro.txtEmail.ReadOnly = true;//email indisponível para editar
            telaCadastro.txtSenha.ReadOnly = true;//senha indisponível para editar
            telaCadastro.btnConcluir.Enabled = false; //botao salvar indisponível
            telaCadastro.boxdataNascimento.Enabled = false;//data indisponível para editar
            telaCadastro.txtCriacao.ReadOnly = true; //data indisponível para editar
            telaCadastro.btnCancelar.Text = "DELETAR";

            //preenche dados nos campos de texto
            if (usuarioSelecionado != null)
            {
                telaCadastro.txtId.Text = usuarioSelecionado.Id.ToString();
                telaCadastro.txtNome.Text = usuarioSelecionado.nome;
                telaCadastro.txtEmail.Text = usuarioSelecionado.email;
                telaCadastro.txtSenha.Text = usuarioSelecionado.senha;
                telaCadastro.boxdataNascimento.Text = usuarioSelecionado.dataNascimento.ToString();
                telaCadastro.txtCriacao.Text = usuarioSelecionado.dataCriacao.ToString();

                telaCadastro.ShowDialog();//mostra tela configurada

            }
            else
            {
                MessageBox.Show("Selecionar Usuário da Lista", "Alerta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            AtualizarGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aoClickarAtualizar(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {
            
            gridUsuarios.DataSource = null;
            if (listaDeUsuarios.Count > 0)
                gridUsuarios.DataSource = listaDeUsuarios.ToList();

            gridUsuarios.Columns["senha"].Visible = false;
        }

        Usuario usuarioSelecionado;
        private void gridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                var linhaSelecionada = gridUsuarios.CurrentCell.RowIndex;
                var usuarioSelecionado = gridUsuarios.Rows[linhaSelecionada].DataBoundItem as Usuario;
                this.usuarioSelecionado = usuarioSelecionado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void aoClickarEditar(object sender, EventArgs e)
        {

            //pegar dados do usuario selecionado
            if ( usuarioSelecionado != null)
            {
                var linhaSelecionada = gridUsuarios.CurrentCell.RowIndex;
                var usuarioSelecionado = gridUsuarios.Rows[linhaSelecionada].DataBoundItem as Usuario;

                telaCadastro.txtId.Text = usuarioSelecionado.Id.ToString();
                telaCadastro.txtNome.Text = usuarioSelecionado.nome;
                telaCadastro.txtEmail.Text = usuarioSelecionado.email;
                telaCadastro.txtSenha.Text = usuarioSelecionado.senha;
                telaCadastro.boxdataNascimento.Text = usuarioSelecionado.dataNascimento.ToString();
                telaCadastro.txtCriacao.Text = usuarioSelecionado.dataCriacao.ToString();
                telaCadastro.Text = "Editar";
                telaCadastro.txtId.ReadOnly = true;
                telaCadastro.txtCriacao.ReadOnly = true;
                telaCadastro.ShowDialog();//mostra tela configurada

                bool limitar = true;
                int cont = 0;
                foreach (Usuario usuarioParaPercorrerLista in listaDeUsuarios)
                {

                    if ((usuarioParaPercorrerLista.Id == usuarioSelecionado.Id) && limitar)
                    {

                        //usuario antes da edicao recebendo novos valores dos campos de texto...
                        listaDeUsuarios[cont].nome = telaCadastro.txtNome.Text;
                        listaDeUsuarios[cont].email = telaCadastro.txtEmail.Text;
                        listaDeUsuarios[cont].senha = telaCadastro.txtSenha.Text;
                        listaDeUsuarios[cont].dataNascimento = DateTime.Parse(telaCadastro.boxdataNascimento.Text);
                        limitar = false;

                    }
                    cont++;

                }

                AtualizarGrid();
            }
            else
            {
                MessageBox.Show("Selecionar Usuário da Lista", "ALERTA",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        private void gridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
