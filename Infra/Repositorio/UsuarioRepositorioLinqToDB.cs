using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;
using CrudWindowsForms.Dominio.Servicos;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class UsuarioRepositorioLinqToDB : IUsuarioRepositorio
    {
        public void Adicionar(Usuario entidade)
        {
            entidade.senha = EncriptografarSenha.Cifrar(entidade.senha);
            using (var db = new LinqToDBConexao())
            {
                db.Insert(entidade);
            }
        }

        public void Atualizar(Usuario entidade)
        {
            entidade.senha = EncriptografarSenha.Cifrar(entidade.senha);
            using (var db = new LinqToDBConexao())
            {
                db.Update(entidade);
            }
        }

        public void Deletar(int id)
        {
            using (var db = new LinqToDBConexao())
            {
                db.Usuario.Where(usuario => usuario.Id == id).Delete();
            }
        }

        public Usuario ObterPorId(int id)
        {
            using (var db = new LinqToDBConexao())
            {
                var q = from usuario in db.Usuario
                        where usuario.Id == id
                        select DescriptografarUsuario(usuario);

                return q.Single();
            }
        }

        private Usuario DescriptografarUsuario(Usuario entidade)
        {
            entidade.senha = EncriptografarSenha.Decifrar(entidade.senha);
            return entidade;
        }

        public List<Usuario> ObterTodos()
        {
            using (var db = new LinqToDBConexao())
            {
                var query = from usuario in db.Usuario
                            select usuario;

                return query.ToList();
            }
        }
    }
}
