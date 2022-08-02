using System.Collections.Generic;
using WinFormsApp1.Servicos;

namespace WinFormsApp1.Repositorio
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected List<T> _lista = ListaSingleton<T>.ListaDeUsuarios;

        public abstract void Adicionar(T entidade);

        public abstract void Atualizar(T entidade);

        public abstract void Deletar(int id);

        public abstract List<T> ObterTodos();

    }
}
