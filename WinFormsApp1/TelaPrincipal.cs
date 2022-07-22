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
        TelaAdcionar telaadcionar = new TelaAdcionar();

        public TelaPrincipal()
        {

            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void frameLista_Load(object sender, EventArgs e)
        {
            tabela.DataSource = listaDeUsuarios;
        }

        private void aoClicarAdcionarUsuario(object sender, EventArgs e)
        {

            listaDeUsuarios.Add(telaadcionar.usuario);
            tabela.DataSource = null;
            tabela.DataSource = listaDeUsuarios;

            telaadcionar = null;
            telaadcionar = new TelaAdcionar();
            telaadcionar.ShowDialog();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
           
            telaadcionar.txtId.ReadOnly = false; //id disponível para editar.
            telaadcionar.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();    
        }

        private void aoClickarAtualizar(object sender, EventArgs e)
        {
            listaDeUsuarios.Add(telaadcionar.usuario);
            tabela.DataSource = null;
            tabela.DataSource = listaDeUsuarios;
        }
    }
}
