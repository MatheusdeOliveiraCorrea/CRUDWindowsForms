using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Pessoa
    {
        public int pessoaId { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public DateTime data { get; set; }

        public Pessoa(int id, string nome, string email, string senha, DateTime data)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha; 
            this.data = data;
            this.pessoaId = id;

        }
        
        public static int getId(ref int id)
        {
            id++;
            return id;
        }


        public static List<Pessoa> lista()
        {

            List<Pessoa> pessoaList = new List<Pessoa>();
            int id = 0;
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004,06,02) ) );
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));
            pessoaList.Add(new Pessoa(getId(ref id), "Matheus", "matheus@mail.com", "123", new DateTime(2004, 06, 02)));


            return pessoaList;
        }

    }
}
