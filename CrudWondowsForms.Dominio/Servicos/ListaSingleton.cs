using System.Collections.Generic;
using CrudWindowsForms.Dominio.Modelo;

namespace CrudWindowsForms.Dominio.Servicos
{
    public sealed class ListaSingleton<T>
    {
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }

        private static List<T>? _listaDeUsuarios;
        private static object _bloqueador = new object();
        private ListaSingleton()
        {

        }

        public static List<T> ListaDeUsuarios
        {
            get
            {
                if (_listaDeUsuarios == null)
                {
                    lock (_bloqueador)
                    {
                        if (_listaDeUsuarios == null)
                        {
                            _listaDeUsuarios = new List<T>();
                        }
                    }
                }
                return _listaDeUsuarios;
            }
        }
    }
}
