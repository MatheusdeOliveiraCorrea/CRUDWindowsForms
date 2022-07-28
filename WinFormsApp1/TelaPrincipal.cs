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
        TelaAdcionar telaCadastro;

        public TelaPrincipal()
        {
            InitializeComponent();
            AtualizarGrid();
        }

        //METODOS PARA MANIPULAR LISTA EM OUTRAS CLASSES
        public void removerListaUsuarios(int id)
        {

            try
            {
                listaDeUsuarios.RemoveAll(usuario => usuario.Id == id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void frameLista_Load(object sender, EventArgs e)
        {

        }

        private void aoClicarAdcionarUsuario(object sender, EventArgs e)
        {

            //Mostrar Tela Cadastro
            telaCadastro = new TelaAdcionar();
            telaCadastro.txtSenha.PasswordChar = '*';
            telaCadastro.ShowDialog();

            //verificar se foi adcionado algum dado na janela cadastro ou não 
            //se o usuário da tela de cadastro não existe em lista

            if (telaCadastro.usuario.Id != decimal.Zero)
            {
                listaDeUsuarios.Add(telaCadastro.usuario);
            }
            else
            {
                MessageBox.Show("Erro inesperado");
            }
            AtualizarGrid();

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            //seta tela limpa
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
                popularCamposUsuario(telaCadastro, usuarioSelecionado);
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
            if (listaDeUsuarios.Count != decimal.Zero)
            {
                gridUsuarios.DataSource = listaDeUsuarios.ToList();
                gridUsuarios.Columns["senha"].Visible = false;
            }
        }

        Usuario usuarioSelecionado;
        private void gridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (gridUsuarios.SelectedCells.Count > decimal.Zero)
                {
                    var linhaSelecionada = gridUsuarios.CurrentCell.RowIndex;
                    var usuarioSelecionado = gridUsuarios.Rows[linhaSelecionada].DataBoundItem as Usuario;
                    this.usuarioSelecionado = usuarioSelecionado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void aoClickarEditar(object sender, EventArgs e)
        {
            try
            {

               
                
                    var linhaSelecionada = gridUsuarios.CurrentCell.RowIndex;
                    if (linhaSelecionada == -1)
                    {
                        throw new Exception("Nenhum usuário selecionado");
                    }

                    if (gridUsuarios.CurrentCell.RowIndex != null)
                    {
                        var usuarioSelecionado = gridUsuarios.Rows[linhaSelecionada].DataBoundItem as Usuario;

                        telaCadastro = new TelaAdcionar();
                        telaCadastro.Text = "Editar";
                        popularCamposUsuario(telaCadastro, usuarioSelecionado);
                        telaCadastro.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Nenhum usuário selecionado");
                    }               


                if(telaCadastro.DialogResult == DialogResult.OK)
                {
                    telaCadastro.usuario.Id = int.Parse(telaCadastro.txtId.Text);
                    telaCadastro.usuario.nome = telaCadastro.txtNome.Text;
                    telaCadastro.usuario.email = telaCadastro.txtEmail.Text;
                    telaCadastro.usuario.senha = telaCadastro.txtSenha.Text;
                    telaCadastro.usuario.dataNascimento = DateTime.Parse(telaCadastro.boxdataNascimento.Text);
                    telaCadastro.usuario.dataCriacao = DateTime.Parse(telaCadastro.txtCriacao.Text);

                    listaDeUsuarios[telaCadastro.usuario.Id - 1] = telaCadastro.usuario;
                    AtualizarGrid();
                }
                else
                {
                    MessageBox.Show("Operação cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
                return;
            }
        }

        private void gridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void popularCamposUsuario(TelaAdcionar telaCadastro, Usuario usuarioSelecionado)
        {
            telaCadastro.txtId.Text = usuarioSelecionado.Id.ToString();
            telaCadastro.txtNome.Text = usuarioSelecionado.nome;
            telaCadastro.txtEmail.Text = usuarioSelecionado.email;
            telaCadastro.txtSenha.Text = usuarioSelecionado.senha;
            telaCadastro.boxdataNascimento.Text = usuarioSelecionado.dataNascimento.ToString();
            telaCadastro.txtCriacao.Text = usuarioSelecionado.dataCriacao.ToString();
        }

    }
}
