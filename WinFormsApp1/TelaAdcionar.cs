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
    public partial class TelaAdcionar : Form
    {
        public Usuario usuario { set; get; } = new Usuario();
        

        public TelaAdcionar()
        {
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }


        static int id = 0;
        private void aoClicarEmSalvar(object sender, EventArgs e)
        {
            
            //inicializando atributos com o texto da tela
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            
            string senha = txtSenha.Text;
            string dataNascimento = boxdataNascimento.Text;

            try
            {
                
                this.Close();
                usuario.nome = nome;
                usuario.email = email;
                usuario.senha = senha;
                usuario.Id = id;
                usuario.dataNascimento = DateTime.Parse(dataNascimento);
                usuario.dataCriacao = DateTime.Now;
                id++;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Dados inválidos ou incompletos", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                this.Close();
               
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

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCriacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void aoClicarEmSair(object sender, EventArgs e)
        {
            Close();
        }
    }
}
