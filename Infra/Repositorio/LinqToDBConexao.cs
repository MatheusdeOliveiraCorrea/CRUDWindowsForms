using LinqToDB;
using CrudWindowsForms.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWindowsForms.Infra.Repositorio
{
    public class LinqToDBConexao : LinqToDB.Data.DataConnection
    {
        public LinqToDBConexao() : base("System.Data.SqlClient", "Server=INVENT087\\SQLSERVER;Database=BancoDeDadosCRUDWindowsForms;Trusted_Connection=True;") { }

        public ITable<Usuario> Usuario => this.GetTable<Usuario>();
    }
}
