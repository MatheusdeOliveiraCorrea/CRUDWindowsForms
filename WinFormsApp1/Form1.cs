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
    public partial class frameLista : Form
    {
        public frameLista()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frameLista_Load(object sender, EventArgs e)
        {

            tabela.DataSource = Pessoa.lista();

           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TelaAdcionar tela= new TelaAdcionar();
            tela.ShowDialog();

            
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            TelaAdcionar tela = new TelaAdcionar();
            tela.txtId.ReadOnly = false; 
            tela.ShowDialog();
        }
    }
}
