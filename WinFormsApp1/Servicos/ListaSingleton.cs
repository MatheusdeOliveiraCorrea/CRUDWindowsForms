using System.Collections.Generic;
using WinFormsApp1.Modelo;

namespace WinFormsApp1.Servicos
{
    public sealed class ListaSingleton
    {
        private int _id;
        public int Id { get { return _id; } set { _id = value; } }

        private static List<Usuario>? _listaDeUsuarios;
        private static object _bloqueador = new object();
        private ListaSingleton()
        {

        }

        public static List<Usuario> ListaDeUsuarios
        {
            get
            {
                if (_listaDeUsuarios == null)
                {
                    lock (_bloqueador)
                    {
                        if (_listaDeUsuarios == null)
                        {
                            _listaDeUsuarios = new List<Usuario>();
                        }
                    }
                }
                return _listaDeUsuarios;
            }
        }
    }
}
