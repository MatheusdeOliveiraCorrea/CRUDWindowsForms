using System;
using System.Text;
using WinFormsApp1.Modelo;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

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
            {
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
            string sql =
                "Delete from Usuario where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
        }

        public void Atualizar(Usuario entidade)
        {
            string sql =
"Update Usuario set nome = @nome, email = @email, senha = @senha, dataNascimento = @dataNascimento, dataCriacao = @dataCriacao Where id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nome", entidade.nome);
            cmd.Parameters.AddWithValue("@email", entidade.email);
            cmd.Parameters.AddWithValue("@senha", entidade.senha);
            cmd.Parameters.AddWithValue("@dataNascimento", entidade.dataNascimento);
            cmd.Parameters.AddWithValue("@dataCriacao", entidade.dataCriacao);
            cmd.Parameters.AddWithValue("@id", entidade.Id);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Edição SQL concluida");

        }

        public Usuario ObterPorId(int id)
        {
            Usuario usuario = new Usuario();
            string sql = "SELECT * FROM Usuario WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                usuario.Id = id;
                usuario.nome = reader.GetString("nome");
                usuario.email = reader.GetString("email");
                usuario.senha = reader.GetString("senha");
                usuario.dataNascimento = reader.GetDateTime("dataNascimento");
                usuario.dataCriacao = reader.GetDateTime("dataCriacao");

            }
            con.Close();
            return usuario;
        }

        public List<Usuario> ObterTodos()
        {
            string strSql = "SELECT * FROM Usuario";
            SqlConnection con = new SqlConnection(BDUsuario.strCon);

            SqlCommand cmd = new SqlCommand(strSql, con);

            List<Usuario> lista = new List<Usuario>();

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Id = reader.GetInt32("id");
                usuario.nome = reader.GetString("nome");
                usuario.email = reader.GetString("email");
                usuario.senha = reader.GetString("senha");
                usuario.dataNascimento = reader.GetDateTime("dataNascimento");
                usuario.dataCriacao = reader.GetDateTime("dataCriacao");

                lista.Add(usuario);
            }
            con.Close();
            return lista;
        }
    }
}
