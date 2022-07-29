using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositorio.Interfaces_Repositorio
{
    internal interface IRepositorio<T> where T : class
    {
        public void Adcionar();
        public void Remover();
        public void Editar();
        public void Deletar();

    }
}
