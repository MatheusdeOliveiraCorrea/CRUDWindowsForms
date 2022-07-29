using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Repositorio.Interfaces_Repositorio;
namespace WinFormsApp1.Repositorio.UnitOfWork
{
    internal interface IUnitOfWork
    {
        IUsuario_Repositorio InterfaceUsuario { get; }
        public void Save();
    }
}
