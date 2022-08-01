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
    public partial class TelaPrincipal : Form
    {
        TelaAdcionar telaCadastro;
        public static Usuario usuarioSelecionado;
        UsuarioRepositorio usuariorepositorio = new UsuarioRepositorio();
        public TelaPrincipal()
        {
            InitializeComponent();
            AtualizarGrid();
        }

        private void AoClicarEmAdicionarUsuario(object enviar, EventArgs e)
        {
            try
            {
                telaCadastro = new TelaAdcionar();
                telaCadastro.senha.PasswordChar = '*';
                telaCadastro.ShowDialog();

                if (telaCadastro.usuario.Id != decimal.Zero)
                {
                    usuariorepositorio.Adicionar(telaCadastro.usuario);
                    AtualizarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ALERTA");
            }
        }

        private void AoClicarEmDeletar(object enviar, EventArgs e)
        {
            var atributosUsuario = usuariorepositorio.getUsuario(usuarioSelecionado.Id);
            try
            {
                if (atributosUsuario != null)
                {
                    if (MessageBox.Show($"EXCLUIR permanentemente {atributosUsuario.nome.ToUpper()} de sua lista de usuários?\nEssa ação não pode ser desfeita",
                         "ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        usuariorepositorio.Deletar(atributosUsuario.Id);
                        AtualizarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum usuário foi excluido", "ALERTA");
                    }
                }
                else
                {
                    MessageBox.Show("Selecionar Usuário da Lista", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "erro");
            }
        }

        private void AoClicarEmSair(object enviar, EventArgs e)
        {
            this.Close();
        }

        public void AtualizarGrid()
        {
            gridUsuarios.DataSource = null;
            if (usuariorepositorio.getListaDeUsuarios().Count != decimal.Zero)
            {
                gridUsuarios.DataSource = usuariorepositorio.getListaDeUsuarios().ToList();
                gridUsuarios.Columns["senha"].Visible = false;
            }
        }

        private void AoClicarEmAlgumaCelulaDaGridView(object enviar, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridUsuarios.SelectedCells.Count > decimal.Zero)
                {
                    var linhaSelecionada = gridUsuarios.CurrentCell.RowIndex;
                    var usuarioSelecionado = gridUsuarios.Rows[linhaSelecionada].DataBoundItem as Usuario;
                    TelaPrincipal.usuarioSelecionado = usuarioSelecionado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AoClicarEmEditar(object enviar, EventArgs e)
        {
            try
            {
                var linhaSelecionada = gridUsuarios.CurrentCell;
                if (linhaSelecionada == null)
                {
                    throw new Exception("Nenhum usuário selecionado");
                }

                if (linhaSelecionada != null)
                {
                    var usuarioSelecionado = gridUsuarios.Rows[linhaSelecionada.RowIndex].DataBoundItem as Usuario;
                    var atributosUsuario = usuariorepositorio.getUsuario(usuarioSelecionado.Id);
                    telaCadastro = new TelaAdcionar();
                    telaCadastro.Text = "Editar";
                    PopularCamposUsuario(telaCadastro, atributosUsuario);
                    telaCadastro.ShowDialog();
                }

                if (telaCadastro.DialogResult == DialogResult.OK)
                {
                    telaCadastro.usuario.Id = int.Parse(telaCadastro.campoId.Text);
                    telaCadastro.usuario.nome = telaCadastro.nome.Text;
                    telaCadastro.usuario.email = telaCadastro.email.Text;
                    telaCadastro.usuario.senha = telaCadastro.senha.Text;
                    telaCadastro.usuario.dataNascimento = DateTime.Parse(telaCadastro.dataDeNascimento.Text);
                    telaCadastro.usuario.dataCriacao = DateTime.Parse(telaCadastro.dataDeCriacao.Text);

                    usuariorepositorio.Editar(telaCadastro.usuario);
                    AtualizarGrid();
                }
                else
                {
                    throw new Exception("Nenhum usuário selecionado ou operacao cancelada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
                return;
            }
        }

        public void PopularCamposUsuario(TelaAdcionar telaCadastro, Usuario usuarioSelecionado)
        {
            telaCadastro.campoId.Text = usuarioSelecionado.Id.ToString();
            telaCadastro.nome.Text = usuarioSelecionado.nome;
            telaCadastro.email.Text = usuarioSelecionado.email;
            telaCadastro.senha.Text = usuarioSelecionado.senha;
            telaCadastro.dataDeNascimento.Text = usuarioSelecionado.dataNascimento.ToString();
            telaCadastro.dataDeCriacao.Text = usuarioSelecionado.dataCriacao.ToString();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
