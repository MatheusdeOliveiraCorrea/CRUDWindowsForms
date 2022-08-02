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
                var sql = "Insert into Usuario values(@nome, @email, @senha, @dataNascimento, @dataCriacao)";
                var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", entidade.nome);
                cmd.Parameters.AddWithValue("@email", entidade.email);
                cmd.Parameters.AddWithValue("@senha", entidade.senha);
                cmd.Parameters.AddWithValue("@dataNascimento", entidade.dataNascimento);
                cmd.Parameters.AddWithValue("@dataCriacao", entidade.dataCriacao);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Adcionado com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro no cadastro do usuário: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Deletar(int id)
        {
            try
            {
                string sql = "Delete from Usuario where id = @id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na deleção do usuário: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Atualizar(Usuario entidade)
        {
            try
            {
                var sql =
"Update Usuario set nome = @nome, email = @email, senha = @senha, dataNascimento = @dataNascimento, dataCriacao = @dataCriacao Where id = @id";
                var cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", entidade.nome);
                cmd.Parameters.AddWithValue("@email", entidade.email);
                cmd.Parameters.AddWithValue("@senha", entidade.senha);
                cmd.Parameters.AddWithValue("@dataNascimento", entidade.dataNascimento);
                cmd.Parameters.AddWithValue("@dataCriacao", entidade.dataCriacao);
                cmd.Parameters.AddWithValue("@id", entidade.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na atualização do usuário: " + e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                var usuario = new Usuario();
                var sql = "SELECT * FROM Usuario WHERE id = @id";
                var cmd = new SqlCommand(sql, con);
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
                
                return usuario;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu algum erro: " + e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Usuario> ObterTodos()
        {
            try
            {
                var lista = new List<Usuario>();

                var strSql = "SELECT * FROM Usuario";
                var con = new SqlConnection(BDUsuario.strCon);
                var cmd = new SqlCommand(strSql, con);
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
               
                return lista;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu algum erro: " + e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
