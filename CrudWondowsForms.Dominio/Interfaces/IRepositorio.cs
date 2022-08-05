using System.Collections.Generic;

namespace CrudWindowsForms.Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public void Adicionar(T entidade);
        public void Atualizar(T entidade);
        public void Deletar(int id);
        public List<T> ObterTodos();
    }
}
