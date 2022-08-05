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
        public static Usuario usuarioSelecionado;

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
                telaCadastro.senha.PasswordChar = '*';
                telaCadastro.ShowDialog();
                if (telaCadastro.usuario.Id != decimal.Zero && telaCadastro.DialogResult == DialogResult.OK)
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
            var atributosUsuario = _usuarioRepositorio.ObterPorId(usuarioSelecionado.Id);

            try
            {
                if (atributosUsuario != null)
                {
                    if (MessageBox.Show($"EXCLUIR permanentemente {atributosUsuario.nome.ToUpper()} de sua lista de usuários?\nEssa ação não pode ser desfeita",
                         "ALERTA", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        _usuarioRepositorio.Deletar(atributosUsuario.Id);
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
            if (_usuarioRepositorio.ObterTodos().Count != decimal.Zero)
            {
                gridUsuarios.DataSource = _usuarioRepositorio.ObterTodos().ToList();

                try
                {
                    gridUsuarios.DataSource = _usuarioRepositorio.ObterTodos();

                    gridUsuarios.Columns["senha"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void AoClicarEmAlgumaCelulaDaGridView(object enviar, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridUsuarios.SelectedCells.Count > decimal.Zero)
                {
                    var linhaSelecionada = gridUsuarios.CurrentCell.RowIndex;
                    var id = gridUsuarios.CurrentRow.Cells["id"].Value.ToString();
                    var usuarioSelecionado = _usuarioRepositorio.ObterPorId(Convert.ToInt32(id));
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

                    var id = gridUsuarios.CurrentRow.Cells["id"].Value.ToString();
                    var atributosUsuario = _usuarioRepositorio.ObterPorId(Convert.ToInt32(id));


                    telaCadastro = new TelaAdcionar();
                    telaCadastro.Text = "Editar";
                    PopularCamposUsuario(telaCadastro, atributosUsuario);
                    string datacriao = telaCadastro.dataDeCriacao.Text;
                    telaCadastro.ShowDialog();
                }

                if (telaCadastro.DialogResult == DialogResult.OK)
                {
                    _usuarioRepositorio.Atualizar(telaCadastro.usuario);

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

        public void PopularCamposUsuario(TelaAdcionar telaCadastro, Usuario usuario)
        {
            telaCadastro.campoId.Text = usuario.Id.ToString();
            telaCadastro.nome.Text = usuario.nome;
            telaCadastro.email.Text = usuario.email;
            telaCadastro.senha.Text = EncriptografarSenha.Decifrar(usuario.senha);
            telaCadastro.dataDeNascimento.Text = usuario.dataNascimento.ToString();
            telaCadastro.dataDeCriacao.Text = usuario.dataCriacao.ToString();
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

