using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Modelo;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1.Repositorio
{
    public class BDUsuario : IUsuarioRepositorio
    {
        public static string strCon =
        "Server=INVENT087\\SQLSERVER;Database=BancoDeDadosCRUDWindowsForms;Trusted_Connection=True;";

        private static SqlConnection con = new SqlConnection(strCon);

        public void Adicionar(Usuario entidade)
        {
            try
            { //setar ID auto increment 
                string sql = "Insert into Usuario values(@nome, @email, @senha, @dataNascimento, @dataCriacao)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", entidade.nome);
                cmd.Parameters.AddWithValue("@email", entidade.email);
                cmd.Parameters.AddWithValue("@senha", entidade.senha);
                cmd.Parameters.AddWithValue("@dataNascimento", entidade.dataNascimento);
                cmd.Parameters.AddWithValue("@dataCriacao", entidade.dataCriacao);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Insersao SQL concluida...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        public void Deletar(int id)
        {

        }

        public void Atualizar(Usuario entidade)
        {
            string sql = "Update Usuario set nome=@nome, @email, @senha, @dataNascimento, @dataCriacao Where id=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", entidade.nome);
            cmd.Parameters.AddWithValue("@senha", entidade.senha);
            cmd.Parameters.AddWithValue("@dataNascimento", entidade.dataNascimento);
            cmd.Parameters.AddWithValue("@dataCriacao", entidade.dataCriacao);
            cmd.Parameters.AddWithValue("@id", entidade.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edição SQL concluida");

        }

        public void ObterPorId(int id)
        {

        }

    }
}
