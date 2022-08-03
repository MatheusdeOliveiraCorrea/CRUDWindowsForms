using System;
using System.Security.Cryptography;
using System.Text;

namespace WinFormsApp1.Servicos
{

    public class EncriptografarSenha
    {

        public static RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

        static public string CifrarString(string senha)
        {
            var conversor = new UnicodeEncoding();
            byte[] textoPlano = conversor.GetBytes(senha);
            var re = RSACifra(textoPlano, rsa.ExportParameters(false), false);

            return conversor.GetString(re);
        }

        static public byte[] RSACifra(byte[] byteCifrado, RSAParameters RSAInfo, bool isOAEP)
        {
            try
            {
                byte[] DadosCifrados;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAInfo);
                    DadosCifrados = RSA.Encrypt(byteCifrado, isOAEP);
                }
                return DadosCifrados;
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message);
            }
        }

        static public byte[] RSADecifra(byte[] textoCifrado, RSAParameters RSAInfo, bool isOAEP)
        {
            try
            {
                byte[] DadosDecifrados;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAInfo);
                    DadosDecifrados = RSA.Decrypt(textoCifrado, isOAEP);
                }
                return DadosDecifrados;
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}



/*using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.Servicos
{
    public class EncriptografarSenha
    {

        public EncriptografarSenha(string senha)
        {
            try
            {
                var conv = new UnicodeEncoding();

                //Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] aCriptografar = conv.GetBytes(senha);
                byte[] encriptografado;
                byte[] desencriptografado;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    encriptografado = Cifrar(aCriptografar, PegarChavePublica(), false);
                    desencriptografado = Decifrar(encriptografado, RSA.ExportParameters(true), false);
                }

            }
            catch (Exception)
            {

            }
        }

        public byte[] Cifrar(byte[] aCriptografar, RSAParameters RSAInformacaoChave, bool FazerOAEPPadding)
        {
            try
            {
                byte[] encriptografado;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAInformacaoChave);
                    encriptografado = RSA.Decrypt(aCriptografar, FazerOAEPPadding);
                }
                return encriptografado;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public byte[] Decifrar(byte[] aDesencriptografar, RSAParameters RSAInformacaoChave, bool FazerOAEPPadding)
        {
            try
            {
                byte[] encriptografado;

                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    RSA.ImportParameters(RSAInformacaoChave);

                    encriptografado = RSA.Decrypt(aDesencriptografar, FazerOAEPPadding);
                }
                return encriptografado;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public RSAParameters PegarChavePublica()
        {
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSAParameters RSAParams = RSA.ExportParameters(false);
                return RSAParams;
            }
        }
    }
}*/
