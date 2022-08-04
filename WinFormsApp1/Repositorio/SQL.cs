using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Repositorio
{
    public static class SQL
    {
        public const string USUARIO_INSERIR = "Insert into Usuario values(@nome, @email, @senha, @dataNascimento, @dataCriacao)";

        public const string USUARIO_DELETAR = "Delete from Usuario where id = @id";

        public const string USUARIO_ATUALIZAR = "Update Usuario set nome = @nome, email = @email, senha = @senha, dataNascimento = @dataNascimento, dataCriacao = @dataCriacao Where id = @id";

        public const string USUARIO_PORID = "SELECT * FROM Usuario WHERE id = @id";

        public const string USUARIO_SELECIONAR_TODOS = "SELECT * FROM Usuario";

        public static string Inserir(string nomeTabela, params string[] campos)
        {
            string camposTabela = "";

            for (int i = 0; i < campos.Length; i++)
                camposTabela += (i + 1) != campos.Length ? $"@{campos[i]}, " : $"@{campos[i]}";

            return $"Insert into {nomeTabela} values({camposTabela})";
        }

        public static string Atualizar(string nomeTabela, string campoIdentificadorUnico, params string[] campos)
        {
            string camposTabela = "";

            for (int i = 0; i < campos.Length; i++)
                camposTabela += (i + 1) != campos.Length ? $"{campos[i]} = @{campos[i]}, " : $"{campos[i]} = @{campos[i]}";

            return $"UPDATE {nomeTabela} SET {camposTabela} WHERE {campoIdentificadorUnico} = @{campoIdentificadorUnico}";
        }
    }
}
