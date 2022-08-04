using System;
using System.Text;
using WinFormsApp1.Modelo;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WinFormsApp1.Servicos;
namespace WinFormsApp1.Repositorio
{
    public class BDUsuario : IUsuarioRepositorio
    {
        public static string strCon =
        "Server=INVENT087\\SQLSERVER;Database=BancoDeDadosCRUDWindowsForms;Trusted_Connection=True;";

        private static SqlConnection conexaoSql = new SqlConnection(strCon);

        public void Adicionar(Usuario entidade)
        {
            try
            {
                var cmd = new SqlCommand(SQL.Inserir("Usuario", "nome", "email", "senha", "dataNascimento", "dataCriacao"), conexaoSql);
                InserirParametrosSQL(cmd, entidade);
                conexaoSql.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Adcionado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro no cadastro do usuário: " + erro.Message);
            }
            finally
            {
                conexaoSql.Close();
            }
        }

        public void Deletar(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(SQL.USUARIO_DELETAR, conexaoSql);
                cmd.Parameters.AddWithValue("@id", id);
                conexaoSql.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro na deleção do usuário: " + e.Message);
            }
            finally
            {
                conexaoSql.Close();
            }
        }

        public void Atualizar(Usuario entidade)
        {
            try
            {
                var cmd = new SqlCommand(SQL.Atualizar("Usuario", "id", "nome", "email", "senha", "dataNascimento"), conexaoSql);
                InserirParametrosSQL(cmd, entidade);
                conexaoSql.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Atualizado com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro na atualização do usuário: " + erro.Message);
            }
            finally
            {
                conexaoSql.Close();
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                var usuario = new Usuario();
                var cmd = new SqlCommand(SQL.USUARIO_PORID, conexaoSql);
                cmd.Parameters.AddWithValue("@id", id);
                conexaoSql.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuario.Id = id;
                    usuario.nome = reader.GetString("nome");
                    usuario.email = reader.GetString("email");
                    usuario.senha = reader.GetString("senha");
                    usuario.dataNascimento = reader.IsDBNull("dataNascimento") ? null : reader.GetDateTime("dataNascimento");
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
                conexaoSql.Close();
            }
        }

        public List<Usuario> ObterTodos()
        {
            try
            {
                var lista = new List<Usuario>();
                var con = new SqlConnection(BDUsuario.strCon);
                var cmd = new SqlCommand(SQL.USUARIO_SELECIONAR_TODOS, con);
                con.Open();
                SqlDataReader lerDoBancoDeDados = cmd.ExecuteReader();

                while (lerDoBancoDeDados.Read())
                {
                    lista.Add(CriarUsuarioDoBancoDeDados(lerDoBancoDeDados));
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
                conexaoSql.Close();
            }
        }

        private Usuario CriarUsuarioDoBancoDeDados(SqlDataReader lerDoBancoDeDados)
        {
            Usuario usuario = new Usuario();
            usuario.Id = lerDoBancoDeDados.GetInt32("id");
            usuario.nome = lerDoBancoDeDados.GetString("nome");
            usuario.email = lerDoBancoDeDados.GetString("email");
            string senha = EncriptografarSenha.Decifrar(lerDoBancoDeDados.GetString("senha"));
            usuario.senha = senha;
            usuario.dataNascimento = lerDoBancoDeDados.IsDBNull("dataNascimento") ? null : lerDoBancoDeDados.GetDateTime("dataNascimento");
            usuario.dataCriacao = lerDoBancoDeDados.GetDateTime("dataCriacao");

            return usuario;
        }

        private void InserirParametrosSQL(SqlCommand comando, Usuario entidade)
        {
            if (entidade?.Id != null)
            {
                comando.Parameters.AddWithValue("@id", entidade.Id);
            }
            comando.Parameters.AddWithValue("@nome", entidade.nome);
            comando.Parameters.AddWithValue("@email", entidade.email);
            comando.Parameters.AddWithValue("@senha", EncriptografarSenha.Cifrar(entidade.senha));
            comando.Parameters.AddWithValue("@dataNascimento", entidade.dataNascimento == null ? DBNull.Value : entidade.dataNascimento);
            comando.Parameters.AddWithValue("@dataCriacao", entidade.dataCriacao);
        }
    }
}
