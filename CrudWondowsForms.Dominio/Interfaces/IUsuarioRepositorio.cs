using CrudWindowsForms.Dominio.Modelo;

namespace CrudWindowsForms.Dominio.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        public Usuario ObterPorId(int id);
    }
}
