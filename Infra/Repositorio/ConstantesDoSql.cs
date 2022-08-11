using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWindowsForms.Infra.Repositorio
{
    public static class ConstantesDoSql
    {
        public const string USUARIO_INSERIR = "Insert into Usuario values(@nome, @email, @senha, @dataNascimento, @dataCriacao)";

        public const string USUARIO_DELETAR = "Delete from Usuario where id = @id";

        public const string USUARIO_ATUALIZAR = "Update Usuario set nome = @nome, email = @email, senha = @senha, dataNascimento = @dataNascimento, dataCriacao = @dataCriacao Where id = @id";

        public const string USUARIO_PORID = "SELECT * FROM Usuario WHERE id = @id";

        public const string USUARIO_SELECIONAR_TODOS = "SELECT * FROM Usuario";

        public const string CONEXAO_STRING = "Server=INVENT087\\SQLSERVER;Database=BancoDeDadosCRUDWindowsForms;Trusted_Connection=True;Encrypt=False";
    }
}
