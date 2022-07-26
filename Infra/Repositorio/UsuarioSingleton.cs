﻿using System;
using System.Collections.Generic;
using CrudWindowsForms.Dominio.Interfaces;
using CrudWindowsForms.Dominio.Modelo;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class UsuarioSingleton : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public override void Adicionar(Usuario usuario)
        {
            _lista.Add(usuario);
        }

        public override void Atualizar(Usuario usuario)
        {
            var usuarioDaLista = ObterPorId(usuario.Id);

            usuarioDaLista.Nome = usuario.Nome;
            usuarioDaLista.Email = usuario.Email;
            usuarioDaLista.Senha = usuario.Senha;
            usuarioDaLista.DataNascimento = usuario.DataNascimento;
        }

        public override void Deletar(int id)
        {
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

        public override List<Usuario> ObterTodos()
        {
            return _lista;
        }
    }
}
