using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class caesarCipher
    {
        public string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public static string Encode(string text, int key, string alphabet)
        {
            var minimizedText = text.ToLower();
            var letterQuntity = alphabet.Length;
            var result = "";

            for (int i = 0; i < minimizedText.Length; i++)
            {
                var c = minimizedText[i];
                var index = alphabet.IndexOf(c);
                if (index < 0)
                {
                    result += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQuntity + index + key) % letterQuntity;
                    result += alphabet[codeIndex];
                }
            }

            return result;
        }

        public static string Encrypt(string plainMessage, int key, string alphabet) => Encode(plainMessage, key, alphabet);
        public static string Decrypt(string encryptedMessage, int key, string alphabet) => Encode(encryptedMessage, key, alphabet);
    }
}
