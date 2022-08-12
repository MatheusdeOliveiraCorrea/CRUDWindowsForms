using LinqToDB;
using CrudWindowsForms.Dominio.Modelo;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class LinqToDBConexao : LinqToDB.Data.DataConnection
    {
        public LinqToDBConexao() : base("System.Data.SqlClient", "Server=INVENT087\\SQLSERVER;Database=BancoDeDadosCRUDWindowsForms;Trusted_Connection=True;") { }

        public ITable<Usuario> Usuario => this.GetTable<Usuario>();
    }
}