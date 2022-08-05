using System;
using System.Collections.Generic;
using WinFormsApp1.Modelo;

namespace WinFormsApp1.Repositorio
{
<<<<<<< HEAD
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuario_Repositorio
=======
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
>>>>>>> AdcionandoBancoDeDados
    {
        public override void Adicionar(Usuario usuario)
        {
            _lista.Add(usuario);
        }

        public override void Atualizar(Usuario usuario)
        {
            var usuarioDaLista = ObterPorId(usuario.Id);

            usuarioDaLista.nome = usuario.nome;
            usuarioDaLista.email = usuario.email;
            usuarioDaLista.senha = usuario.senha;
            usuarioDaLista.dataNascimento = usuario.dataNascimento;
        }

        public override void Deletar(int id)
        {
            var usuarioDaLista = ObterPorId(id);
<<<<<<< HEAD
=======

>>>>>>> AdcionandoBancoDeDados
            _lista.RemoveAll(usuario => usuario.Id == id);
        }

        public Usuario ObterPorId(int id)
        {
            var usuario = _lista.Find(x => x.Id == id);
            if (usuario == null)
            {
                throw new Exception("Usuário não existe");
            }
            return usuario;
        }

<<<<<<< HEAD
        public List<Usuario> ObterTodos()
=======
        public override List<Usuario> ObterTodos()
>>>>>>> AdcionandoBancoDeDados
        {
            return _lista;
        }
    }
}
