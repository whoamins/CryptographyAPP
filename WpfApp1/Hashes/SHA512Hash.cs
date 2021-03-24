using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace WpfApp1
{
    public class SHA512Hash
    {
        public static string GetHash(string input)
        {
            SHA512 sha512Hash = new SHA512Managed();
            byte[] sourceBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            return hash.ToLower();
        }
    }
}
