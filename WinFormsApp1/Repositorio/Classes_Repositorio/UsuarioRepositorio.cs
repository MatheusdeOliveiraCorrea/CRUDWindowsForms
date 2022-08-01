using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Modelo;
using WinFormsApp1.Repositorio.Interfaces_Repositorio;
using WinFormsApp1.Servicos;
using System.Windows.Forms;
namespace WinFormsApp1.Repositorio.Classes_Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuario_Repositorio
    {
        public override void Adicionar(Usuario usuario)
        {
            _lista.Add(usuario);
        }

        public override void Editar(Usuario usuario)
        {
            var usuarioDaLista = _lista.Find(x => x.Id == usuario.Id);

            if (usuarioDaLista == null)
            {
                throw new Exception("Usuario não existe");
            }

            usuarioDaLista.nome = usuario.nome;
            usuarioDaLista.email = usuario.email;
            usuarioDaLista.senha = usuario.senha;
            usuarioDaLista.dataNascimento = usuario.dataNascimento;
        }

        public override void Deletar(int id)
        {
            var usuarioDaLista = _lista.Find(x => x.Id == id);
            if (usuarioDaLista == null)
            {
                throw new Exception("Usuario não existe");
            }

            _lista.RemoveAll(usuario => usuario.Id == id);
        }

        public Usuario getUsuario(int id)
        {
            if (_lista.Find(x => x.Id == id) == null)
            {
                throw new Exception("Usuário não existe");
            }
            return _lista.Find(x => x.Id == id);
        }

        public List<Usuario> getListaDeUsuarios()
        {
            return _lista;
        }
    }
}
