using FluentMigrator;

namespace CrudWindowsForms.Infra.Migracao
{
    [Migration(20220430121801)]
    public class AdicionarTabelaDeUsuario : Migration
    {
        public override void Up()
        {
            Create.Table("Usuario")
                .WithColumn("id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("nome").AsString(40).NotNullable()
                .WithColumn("email").AsString(40).NotNullable()
                .WithColumn("senha").AsString(1000).NotNullable()
                .WithColumn("dataNascimento").AsDateTime().Nullable()
                .WithColumn("dataCriacao").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            //  Delete.Table("Usuario");
        }
    }
}