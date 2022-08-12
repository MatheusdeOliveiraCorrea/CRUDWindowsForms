using System;
using System.Linq;
using System.Windows.Forms;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Infra.Repositorio;
using FluentValidation;

namespace CrudWindowsForms.InterfaceDoUsuario
{
    public partial class TelaPrincipal : Form
    {
        TelaAdcionar telaCadastro;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IValidator<Usuario> _usuarioValidador;

        public TelaPrincipal(IUsuarioRepositorio usuarioRepositorio, IValidator<Usuario> usuarioValidador)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioValidador = usuarioValidador;
            InitializeComponent();
            AtualizarGrid();
        }

        private void AoClicarEmAdicionarUsuario(object enviar, EventArgs e)
        {
            try
            {
                telaCadastro = new TelaAdcionar(_usuarioRepositorio, _usuarioValidador);
                telaCadastro.ShowDialog();
                if (telaCadastro.DialogResult == DialogResult.OK)
                {
                    _usuarioRepositorio.Adicionar(telaCadastro.usuario);
                    AtualizarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Infelizmente algo deu errado na INSERÇÃO do usuário na memória\nDescrição do erro para os desenvolvedores:\n {ex.Message}", "ALERTA");
            }
        }

        private void AoClicarEmDeletar(object enviar, EventArgs e)
        {
            try
            {
                var usuarioSelecionado = PegarUsuarioSelecionado();
                if (usuarioSelecionado == null) throw new Exception("Selecionar Usuário da Lista");

                var messageBoxExcluirUsuario = MessageBox.Show($"EXCLUIR permanentemente {usuarioSelecionado.Nome.ToUpper()} " +
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
                MessageBox.Show($"Infelizmente algo deu errado na REMOÇÃO do usuário na memória\nDescrição do erro para os desenvolvedores:\n {ex.Message}", "ALERTA");
            }
        }

        private void AoClicarEmSair(object enviar, EventArgs e)
        {
            this.Close();
        }

        public void AtualizarGrid()
        {
            try
            {
                gridUsuarios.DataSource = _usuarioRepositorio.ObterTodos();
                gridUsuarios.Columns["senha"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Infelizmente algo deu errado na ATUALIZAÇÃO DA GRID de usuários\nDescrição do erro para os desenvolvedores:\n {ex.Message}", "ALERTA");
            }
        }

        private Usuario? PegarUsuarioSelecionado()
        {
            try
            {
                if (gridUsuarios.SelectedCells.Count > decimal.Zero)
                {
                    var id = gridUsuarios.CurrentRow.Cells["id"].Value.ToString();
                    Usuario? usuarioSelecionado = _usuarioRepositorio.ObterPorId(Convert.ToInt32(id));

                    return usuarioSelecionado;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Infelizmente algo deu errado ao pegar usuário selecionado");
            }
            return null;
        }

        private void AoClicarEmEditar(object enviar, EventArgs e)
        {
            try
            {
                var usuarioSelecionado = PegarUsuarioSelecionado();
                if (usuarioSelecionado == null) throw new Exception("Nenhum usuário selecionado");

                telaCadastro = new TelaAdcionar(_usuarioRepositorio, _usuarioValidador);
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
                MessageBox.Show($"Infelizmente algo deu errado na EDIÇÃO do usuário na memória\nDescrição do erro para os desenvolvedores:\n {ex.Message}", "ALERTA");
            }
        }

        public void PopularCamposUsuario(TelaAdcionar telaCadastro, Usuario usuario)
        {
            telaCadastro.campoId.Text = usuario.Id.ToString();
            telaCadastro.nome.Text = usuario.Nome;
            telaCadastro.email.Text = usuario.Email;
            telaCadastro.senha.Text = usuario.Senha;
            telaCadastro.dataDeNascimento.Text = usuario.DataNascimento.ToString();
            telaCadastro.dataDeCriacao.Text = usuario.DataCriacao.ToString();
        }
    }
}

