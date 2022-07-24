﻿using System;
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
        
        

        public static List<Usuario> listaDeUsuarios { get; set; } = new List<Usuario>();
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
            if (!listaDeUsuarios.Contains(telaCadastro.usuario) && telaCadastro.usuario.nome != null)
            {
                listaDeUsuarios.Add(telaCadastro.usuario);
                AtualizarGrid();
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
            telaCadastro.boxdataNascimento.ReadOnly = true;//data indisponível para editar
            telaCadastro.txtCriacao.ReadOnly = true; //data indisponível para editar
            telaCadastro.btnCancelar.Text = "DELETAR";

            //preenche dados nos campos de texto
            if (dadosLinhaSelecionada != null)
            {
                telaCadastro.txtId.Text = dadosLinhaSelecionada.Id.ToString();
                telaCadastro.txtNome.Text = dadosLinhaSelecionada.nome;
                telaCadastro.txtEmail.Text = dadosLinhaSelecionada.email;
                telaCadastro.txtSenha.Text = dadosLinhaSelecionada.senha;
                telaCadastro.boxdataNascimento.Text = dadosLinhaSelecionada.dataNascimento.ToString();
                telaCadastro.txtCriacao.Text = dadosLinhaSelecionada.dataCriacao.ToString();

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

        Usuario dadosLinhaSelecionada;
        private void gridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gridUsuarios.CurrentRow.Selected = true;
            string id = gridUsuarios.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            string nome = gridUsuarios.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            string email = gridUsuarios.Rows[e.RowIndex].Cells["email"].Value.ToString();
            string senha = gridUsuarios.Rows[e.RowIndex].Cells["senha"].Value.ToString();
            string dataNascimento =  gridUsuarios.Rows[e.RowIndex].Cells["dataNascimento"].Value.ToString();
            string dataCriacao = gridUsuarios.Rows[e.RowIndex].Cells["dataCriacao"].Value.ToString();

            dadosLinhaSelecionada = new Usuario();
            dadosLinhaSelecionada.Id = int.Parse(id);
            dadosLinhaSelecionada.nome = nome;
            dadosLinhaSelecionada.email = email;
            dadosLinhaSelecionada.senha = senha;
            dadosLinhaSelecionada.dataNascimento = DateTime.Parse(dataNascimento);
            dadosLinhaSelecionada.dataCriacao = DateTime.Parse(dataCriacao);


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
                    }


                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
