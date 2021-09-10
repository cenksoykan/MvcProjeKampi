using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HashManager
    {
        private static readonly SHA1 sha1 = new SHA1CryptoServiceProvider();
        private static readonly MD5 md5 = new MD5CryptoServiceProvider();

        public static string MD5(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            byte[] hash = md5.ComputeHash(data);
            return Convert.ToBase64String(hash);
            //return BitConverter.ToString(hash).Replace("-", String.Empty);
        }


        public static string SHA1(string secret)
        {
            byte[] data = Encoding.UTF8.GetBytes(secret);
            byte[] hash = sha1.ComputeHash(data);
            return Convert.ToBase64String(hash);
            //return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
    }
}
