using System.Collections.Generic;

namespace WinFormsApp1.Repositorio
{
    interface IRepositorio<T> where T : class
    {
        public void Adicionar(T entidade);
        public void Atualizar(T entidade);
        public void Deletar(int id);
        public List<T> ObterTodos();
    }
}
