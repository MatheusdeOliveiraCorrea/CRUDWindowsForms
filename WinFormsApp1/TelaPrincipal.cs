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

    public partial class TelaPrincipal : Form
    {
        
        

        public List<Usuario> listaDeUsuarios { get; set; } = new List<Usuario>();
        TelaAdcionar telaCadastro = new TelaAdcionar();

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void frameLista_Load(object sender, EventArgs e)
        {

            gridUsuarios.DataSource = listaDeUsuarios.ToList();
            gridUsuarios.Columns["senha"].Visible = false;
            /*tabela.DataSource = listaDeUsuarios;
            tabela.Columns["senha"].Visible = false;*/
        }

        private void aoClicarAdcionarUsuario(object sender, EventArgs e)
        {

            //Mostrar Tela Cadastro
            telaCadastro = null;
            telaCadastro = new TelaAdcionar();
            telaCadastro.txtId.ReadOnly = true;
            telaCadastro.txtCriacao.ReadOnly = true;
            telaCadastro.ShowDialog();

            listaDeUsuarios.Add(telaCadastro.usuario);
            AtualizarGrid();

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            telaCadastro.txtCriacao.ReadOnly = true; //indisponível para editar
            telaCadastro.txtId.ReadOnly = false; //id disponível para editar.
            telaCadastro.ShowDialog();

            AtualizarGrid();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();    
        }

        private void aoClickarAtualizar(object sender, EventArgs e)
        {
            if(telaCadastro.usuario.nome != "")
            listaDeUsuarios.Add(telaCadastro.usuario);
            AtualizarGrid();
        }

        public void AtualizarGrid()
        {
            gridUsuarios.DataSource = null;
            if(listaDeUsuarios.Count>0)
            gridUsuarios.DataSource = listaDeUsuarios.ToList(); 
        }

        private void GridUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
