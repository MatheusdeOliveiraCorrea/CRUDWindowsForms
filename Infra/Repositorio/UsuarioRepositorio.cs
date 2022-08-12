using System;
using System.Text;
using CrudWindowsForms.Dominio.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private static SqlConnection conexaoSql = new SqlConnection(ConstantesDoSql.CONEXAO_STRING);

        public void Adicionar(Usuario entidade)
        {
            using (SqlConnection conexaoSql = new SqlConnection(ConstantesDoSql.CONEXAO_STRING))
            {
                using (var cmd = new SqlCommand(ConstantesDoSql.USUARIO_INSERIR, conexaoSql))
                {
                    conexaoSql.Open();
                    InserirParametrosSQL(cmd, entidade);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conexaoSql = new SqlConnection(ConstantesDoSql.CONEXAO_STRING))
            {
                using (var cmd = new SqlCommand(ConstantesDoSql.USUARIO_DELETAR, conexaoSql))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conexaoSql.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Atualizar(Usuario entidade)
        {
            using (SqlConnection conexaoSql = new SqlConnection(ConstantesDoSql.CONEXAO_STRING))
            {
                using (var cmd = new SqlCommand(ConstantesDoSql.USUARIO_ATUALIZAR, conexaoSql))
                {
                    InserirParametrosSQL(cmd, entidade);
                    conexaoSql.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Usuario ObterPorId(int id)
        {
            using (SqlConnection conexaoSql = new SqlConnection(ConstantesDoSql.CONEXAO_STRING))
            {
                using (var cmd = new SqlCommand(ConstantesDoSql.USUARIO_PORID, conexaoSql))
                {
                    var usuario = new Usuario();
                    cmd.Parameters.AddWithValue("@id", id);
                    conexaoSql.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new Exception($"Não encontrado o usuário com o ID {id}");
                    }
                    while (reader.Read())
                    {
                        usuario.Id = id;
                        usuario.Nome = reader.GetString("nome");
                        usuario.Email = reader.GetString("email");
                        usuario.Senha = reader.GetString("senha");
                        usuario.DataNascimento = reader.IsDBNull("dataNascimento") ? null : reader.GetDateTime("dataNascimento");
                        usuario.DataCriacao = reader.GetDateTime("dataCriacao");
                    }

                    return usuario;
                }

            }
        }

        public List<Usuario> ObterTodos()
        {
            using (var con = new SqlConnection(ConstantesDoSql.CONEXAO_STRING))
            {
                using (var cmd = new SqlCommand(ConstantesDoSql.USUARIO_SELECIONAR_TODOS, con))
                {
                    con.Open();
                    SqlDataReader lerDoBancoDeDados = cmd.ExecuteReader();

                    var lista = new List<Usuario>();

                    while (lerDoBancoDeDados.Read())
                    {
                        lista.Add(CriarUsuarioDoBancoDeDados(lerDoBancoDeDados));
                    }

                    return lista;
                }
            }
        }

        private Usuario CriarUsuarioDoBancoDeDados(SqlDataReader lerDoBancoDeDados)
        {
            var usuario = new Usuario();
            usuario.Id = lerDoBancoDeDados.GetInt32("id");
            usuario.Nome = lerDoBancoDeDados.GetString("nome");
            usuario.Email = lerDoBancoDeDados.GetString("email");
            var senha = CriptografarSenha.Descriptografar(lerDoBancoDeDados.GetString("senha"));
            usuario.Senha = senha;
            usuario.DataNascimento = lerDoBancoDeDados.IsDBNull("dataNascimento") ? null : lerDoBancoDeDados.GetDateTime("dataNascimento");
            usuario.DataCriacao = lerDoBancoDeDados.GetDateTime("dataCriacao");

            return usuario;
        }

        private void InserirParametrosSQL(SqlCommand comando, Usuario entidade)
        {
            if (entidade?.Id != null)
            {
                comando.Parameters.AddWithValue("@id", entidade.Id);
            }
            comando.Parameters.AddWithValue("@nome", entidade.Nome);
            comando.Parameters.AddWithValue("@email", entidade.Email);
            comando.Parameters.AddWithValue("@senha", CriptografarSenha.Criptografar(entidade.Senha));
            comando.Parameters.AddWithValue("@dataNascimento", entidade.DataNascimento == null ? DBNull.Value : entidade.DataNascimento);
            comando.Parameters.AddWithValue("@dataCriacao", entidade.DataCriacao);
        }
    }
}

