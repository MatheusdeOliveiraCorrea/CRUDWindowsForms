<<<<<<< HEAD
﻿namespace WinFormsApp1.Repositorio
=======
﻿using System.Collections.Generic;

namespace WinFormsApp1.Repositorio
>>>>>>> AdcionandoBancoDeDados
{
    interface IRepositorio<T> where T : class
    {
        public void Adicionar(T entidade);
        public void Atualizar(T entidade);
        public void Deletar(int id);
<<<<<<< HEAD
=======
        public List<T> ObterTodos();
>>>>>>> AdcionandoBancoDeDados
    }
}
