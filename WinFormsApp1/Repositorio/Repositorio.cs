using System.Collections.Generic;
using WinFormsApp1.Servicos;

namespace WinFormsApp1.Repositorio
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected List<T> _lista = ListaSingleton<T>.ListaDeUsuarios;

<<<<<<< HEAD
        public virtual void Adicionar(T entidade)
        {
            _lista.Add(entidade);
        }
=======
        public abstract void Adicionar(T entidade);
>>>>>>> AdcionandoBancoDeDados

        public abstract void Atualizar(T entidade);

        public abstract void Deletar(int id);
<<<<<<< HEAD
=======

        public abstract List<T> ObterTodos();

>>>>>>> AdcionandoBancoDeDados
    }
}
