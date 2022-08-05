using System;
using System.Text;
using CrudWindowsForms.Dominio.Modelo;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Servicos;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class BDUsuario : IUsuarioRepositorio
    {
        public static string strCon =
        "Server=INVENT087\\SQLSERVER;Database=BancoDeDadosCRUDWindowsForms;Trusted_Connection=True;";

        private static SqlConnection conexaoSql = new SqlConnection(strCon);

        public void Adicionar(Usuario entidade)
        {
            using (SqlConnection conexaoSql = new SqlConnection(strCon))
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
            using (SqlConnection conexaoSql = new SqlConnection(strCon))
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
            using (SqlConnection conexaoSql = new SqlConnection(strCon))
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
            using (SqlConnection conexaoSql = new SqlConnection(strCon))
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
                        usuario.nome = reader.GetString("nome");
                        usuario.email = reader.GetString("email");
                        usuario.senha = reader.GetString("senha");
                        usuario.dataNascimento = reader.IsDBNull("dataNascimento") ? null : reader.GetDateTime("dataNascimento");
                        usuario.dataCriacao = reader.GetDateTime("dataCriacao");
                    }

                    return usuario;
                }

            }


        }

        public List<Usuario> ObterTodos()
        {
            using (var con = new SqlConnection(strCon))
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
            usuario.nome = lerDoBancoDeDados.GetString("nome");
            usuario.email = lerDoBancoDeDados.GetString("email");
            var senha = EncriptografarSenha.Decifrar(lerDoBancoDeDados.GetString("senha"));
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

