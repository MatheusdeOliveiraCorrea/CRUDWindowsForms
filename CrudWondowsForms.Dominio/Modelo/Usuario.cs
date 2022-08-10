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
        public string nome { get; set; }

        [Column(Name = "senha"), NotNull]
        public string senha { get; set; }

        [Column(Name = "email"), NotNull]
        public string email { get; set; }

        [Column(Name = "dataNascimento"), NotNull]
        public DateTime? dataNascimento { get; set; }

        [Column(Name = "dataCriacao"), NotNull]
        public DateTime dataCriacao { get; set; }

    }
}


