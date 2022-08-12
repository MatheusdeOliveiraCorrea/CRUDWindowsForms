using System;
using LinqToDB.Mapping;

namespace CrudWindowsForms.Dominio.Modelo
{
    [Table(Name = "Usuario")]
    public class Usuario
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column(Name = "nome"), NotNull]
        public string Nome { get; set; }

        [Column(Name = "senha"), NotNull]
        public string Senha { get; set; }

        [Column(Name = "email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "dataNascimento"), NotNull]
        public DateTime? DataNascimento { get; set; }

        [Column(Name = "dataCriacao"), NotNull]
        public DateTime DataCriacao { get; set; }

    }
}


