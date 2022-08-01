using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Modelo;

namespace WinFormsApp1.Repositorio.Interfaces_Repositorio
{
    interface IRepositorio<T> where T : class
    {
        public void Adicionar(T entidade);
        public void Editar(T entidade);
        public void Deletar(int id);
    }
}
