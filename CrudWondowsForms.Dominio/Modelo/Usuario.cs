using System;

namespace CrudWindowsForms.Dominio.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public DateTime? dataNascimento { get; set; }
        public DateTime dataCriacao { get; set; }

    }
}


