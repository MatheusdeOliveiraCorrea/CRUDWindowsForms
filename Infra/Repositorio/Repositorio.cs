using System.Collections.Generic;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Servicos;

namespace CrudWindowsForms.Infra.Repositorio
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected List<T> _lista = ListaSingleton<T>.ListaDeUsuarios;

        public virtual void Adicionar(T entidade)
        {
            _lista.Add(entidade);
        }

        public abstract void Atualizar(T entidade);

        public abstract void Deletar(int id);

        public abstract List<T> ObterTodos();

    }
}
