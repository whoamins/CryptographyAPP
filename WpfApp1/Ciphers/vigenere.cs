using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class vigenere
    {
        public static string Encrypt(string input, string key, string alphabet)
        {
            int j = 0;

            StringBuilder ret = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (alphabet.Contains(input[i]))
                {
                    ret.Append(alphabet[(alphabet.IndexOf(input[i]) + alphabet.IndexOf(key[j])) % alphabet.Length]);
                }
                else
                {
                    ret.Append(input[i]);
                }

                j = (j + 1) % key.Length;
            }

            return ret.ToString();
        }

        public static string Decrypt(string input, string key, string alphabet)
        {
            int j = 0;
            StringBuilder ret = new StringBuilder(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (alphabet.Contains(input[i]))
                    ret.Append(alphabet[(alphabet.IndexOf(input[i]) - alphabet.IndexOf(key[j]) + alphabet.Length) % alphabet.Length]);
                else
                    ret.Append(input[i]);
                j = (j + 1) % key.Length;
            }

            return ret.ToString().ToLower();
        }
    }
}
