using System;
using System.Text;
using System.Security.Cryptography;

namespace HP_Messaging.Security
{
    public class HashHelper
    {
        public static string GetHash(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public static string DecryptHash(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch 
            {
                decrypted = "";
            }
            return decrypted;
        }
        
    }
}
