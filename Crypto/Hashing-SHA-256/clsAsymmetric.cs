using System;
using System.Security.Cryptography;
using System.Text;

namespace Hashing_SHA_256
{
    public class clsAsymmetric
    {

        string PublicKey { get; set; }
        string PrivateKey { get; set; }
        string Message { get; set; }

        public clsAsymmetric(string Public, string Message)
        {
            this.PublicKey = Public;
            this.Message = Message;
            this.PrivateKey = GeneratePrivateKey();
        }
        string GeneratePrivateKey()
        {
            string Result = "";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                try
                {
                    Result = rsa.ToXmlString(true);
                     
                }
                catch (CryptographicException Exception)
                {
                    Console.WriteLine($"Encryption/Decryption error: {Exception.Message}");

                }
                catch (Exception Error)
                {
                    Console.WriteLine($"Error: {Error.Message}");

                }
            return Result;
        }
        public string GetPublicKey()
        {
            return this.PublicKey;
        }

        public string Encrypt()
        {
            try
            {
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.FromXmlString(this.PublicKey);
                    byte[] encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(this.Message), false);
                    return Convert.ToBase64String(encrypted);
                }
            }
            catch (CryptographicException Exception) 
            {
                Console.WriteLine($"Encryption error: {Exception.Message}");
                throw;
            }
            
        }

    }
}
