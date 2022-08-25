using CrudWindowsForms.Dominio;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class UsuarioRepositorioLinqToDB : IUsuarioRepositorio
    {
        private readonly LinqToDBConexao _linqToDBConexao;

        public UsuarioRepositorioLinqToDB(LinqToDBConexao linqToDBConexao)
        {
            _linqToDBConexao = linqToDBConexao;
        }

        public void Adicionar(Usuario entidade)
        {
            try
            {
                entidade.Senha = CriptografarSenha.Criptografar(entidade.Senha);
                _linqToDBConexao.Insert(entidade);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                _linqToDBConexao.Close();
            }
        }

        public void Atualizar(Usuario entidade)
        {
            try
            {
                entidade.Senha = CriptografarSenha.Criptografar(entidade.Senha);
                _linqToDBConexao.Update(entidade);
            }
            catch (Exception erro)
            {

                throw new Exception(erro.Message);
            }
            finally
            {
                _linqToDBConexao.Close();
            }

        }

        public void Deletar(int id)
        {
            try
            {
                _linqToDBConexao.Usuario.Where(usuario => usuario.Id == id).Delete();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                _linqToDBConexao.Close();
            }
        }

        public Usuario ObterPorId(int id)
        {
            try
            {
                var q = from usuario in _linqToDBConexao.Usuario
                        where usuario.Id == id
                        select DescriptografarUsuario(usuario);

                return q.Single();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                _linqToDBConexao.Close();
            }
        }

        private Usuario DescriptografarUsuario(Usuario entidade)
        {
            entidade.Senha = CriptografarSenha.Descriptografar(entidade.Senha);
            return entidade;
        }

        public List<Usuario> ObterTodos()
        {
            try
            {
                var query = from usuario in _linqToDBConexao.Usuario
                            orderby usuario.Id descending
                            select usuario;
                return query.ToList();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                _linqToDBConexao.Close();
            }
        }
    }
}
