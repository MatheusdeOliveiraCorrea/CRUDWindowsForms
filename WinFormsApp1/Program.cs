using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Servicos;
namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var senha = "Ola, meu nome é Matheus";
            var conversor = new UnicodeEncoding();


            //var textoPlano = new byte[2048];
            //var textoCifrado = new byte[2048];
            var textoDecifrado = new byte[2048];

            /* textoPlano = conversor.GetBytes(senha);
             textoCifrado = EncriptografarSenha.RSACifra(textoPlano, rsa.ExportParameters(false), false);*/

            string aposSerCifradoMetodo = EncriptografarSenha.CifrarString(senha);
            byte[] cifrado = conversor.GetBytes(aposSerCifradoMetodo);

            textoDecifrado = EncriptografarSenha.RSADecifra(cifrado, EncriptografarSenha.rsa.ExportParameters(true), false);

            string aposSerDecifrado = conversor.GetString(textoDecifrado);

            /*Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TelaPrincipal());*/

        }
    }
}
