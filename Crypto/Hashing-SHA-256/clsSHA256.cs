using System;
using System.Security.Cryptography;
using System.Text;

namespace Hashing_SHA_256
{
    public class clsSHA256
    {
        public static string ConvertToHash(string Input) 
        {
            string Result;
            using (SHA256 Hash = SHA256.Create()) 
            {
                byte[] HashedBytes = Hash.ComputeHash(Encoding.UTF8.GetBytes(Input));
                Result = BitConverter.ToString(HashedBytes).Replace("-", "");
            }
            return Result;
        }
    }
}
