using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Modelo;
using WinFormsApp1.Repositorio.Interfaces_Repositorio;
using WinFormsApp1.Servicos;

namespace WinFormsApp1.Repositorio.Classes_Repositorio
{
    public abstract class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected List<T> _lista = ListaSingleton<T>.ListaDeUsuarios;

        public virtual void Adicionar(T entidade)
        {
            _lista.Add(entidade);
        }

        public abstract void Editar(T entidade);

        public abstract void Deletar(int id);
    }
}
