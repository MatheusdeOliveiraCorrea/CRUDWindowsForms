using System;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conversor = new UnicodeEncoding();

            string senha = "Ola, meu nome é Matheus";

            byte[] textoCifrado = new byte[2048];

            textoCifrado = EncriptografarSenha.CifrarString(senha);
            string aposSerCifrado = conversor.GetString(textoCifrado);

            byte[] byteDecifrado = new byte[2048];

            //byteDecifrado = EncriptografarSenha.DecifrarString(aposSerCifrado);
            byteDecifrado = EncriptografarSenha.RSADecifra(textoCifrado, EncriptografarSenha.rsa.ExportParameters(true), false);

            string aposSerDecifrado = conversor.GetString(byteDecifrado);
        }
    }
}
