using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace WpfApp1
{
    public class RIPEMD160Hash
    {
        public static string GetHash(string input)
        {
            RIPEMD160 r160 = RIPEMD160Managed.Create();

            byte[] myByte = Encoding.ASCII.GetBytes(input);

            byte[] encrypted = r160.ComputeHash(myByte);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < encrypted.Length; i++)
            {
                sb.Append(encrypted[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }
}
