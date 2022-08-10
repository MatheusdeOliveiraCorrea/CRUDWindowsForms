using System;
using System.Linq;
using System.Windows.Forms;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Dominio.Servicos;
using CrudWindowsForms.Infra.Repositorio;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    public partial class TelaPrincipal : Form
    {
        TelaAdcionar telaCadastro;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public TelaPrincipal(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            InitializeComponent();
            AtualizarGrid();
        }

        private void AoClicarEmAdicionarUsuario(object enviar, EventArgs e)
        {
            try
            {
                telaCadastro = new TelaAdcionar();
                telaCadastro.ShowDialog();
                if (telaCadastro.DialogResult == DialogResult.OK)
                {
                    _usuarioRepositorio.Adicionar(telaCadastro.usuario);
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
            try
            {
                var usuarioSelecionado = PegarUsuarioSelecionado();
                if (usuarioSelecionado == null) throw new Exception("Selecionar Usuário da Lista");

                var messageBoxExcluirUsuario = MessageBox.Show($"EXCLUIR permanentemente {usuarioSelecionado.nome.ToUpper()} " +
                    $"de sua lista de usuários?\nEssa ação não pode ser desfeita",
                        "ALERTA", MessageBoxButtons.OKCancel);

                if (messageBoxExcluirUsuario == DialogResult.OK)
                {
                    _usuarioRepositorio.Deletar(usuarioSelecionado.Id);
                    AtualizarGrid();
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
            gridUsuarios.DataSource = _usuarioRepositorio.ObterTodos();
            gridUsuarios.Columns["senha"].Visible = false;
        }
        private Usuario? PegarUsuarioSelecionado()
        {
            if (gridUsuarios.SelectedCells.Count > decimal.Zero)
            {
                var linhaSelecionada = gridUsuarios.CurrentCell.RowIndex;
                var id = gridUsuarios.CurrentRow.Cells["id"].Value.ToString();
                Usuario? usuarioSelecionado = _usuarioRepositorio.ObterPorId(Convert.ToInt32(id));

                return usuarioSelecionado;
            }
            return null;
        }

        private void AoClicarEmEditar(object enviar, EventArgs e)
        {
            try
            {
                var usuarioSelecionado = PegarUsuarioSelecionado();
                if (usuarioSelecionado == null) throw new Exception("Nenhum usuário selecionado");

                telaCadastro = new TelaAdcionar();
                telaCadastro.Text = "Editar";
                PopularCamposUsuario(telaCadastro, usuarioSelecionado);

                telaCadastro.ShowDialog();

                if (telaCadastro.DialogResult == DialogResult.OK)
                {
                    _usuarioRepositorio.Atualizar(telaCadastro.usuario);
                    AtualizarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        public void PopularCamposUsuario(TelaAdcionar telaCadastro, Usuario usuario)
        {
            telaCadastro.campoId.Text = usuario.Id.ToString();
            telaCadastro.nome.Text = usuario.nome;
            telaCadastro.email.Text = usuario.email;
            telaCadastro.senha.Text = usuario.senha;
            telaCadastro.dataDeNascimento.Text = usuario.dataNascimento.ToString();
            telaCadastro.dataDeCriacao.Text = usuario.dataCriacao.ToString();
        }
    }
}

