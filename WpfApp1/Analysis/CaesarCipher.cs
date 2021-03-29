using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class CaesarCipher
    {
        public static string Crack(string input, string alphabet)
        {
            StringBuilder sb = new StringBuilder();

            for(int key = 0; key <= alphabet.Length; key++)
            {
                sb.AppendLine(string.Format($"Ключ - {key} - {caesarCipher.Decrypt(input, -key, alphabet)}"));
            }

            return sb.ToString();
        }
    }
}
