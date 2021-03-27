using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class caesarCipher
    {
        /// <summary>
        /// Алгоритм шифра Цезаря
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Зашифровывает в Цезаря
        /// </summary>
        /// <param name="plainMessage"></param>
        /// <param name="key"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        public static string Encrypt(string plainMessage, int key, string alphabet)
        {
            return Encode(plainMessage, key, alphabet);
        }

        /// <summary>
        /// Расшифровывает из Цезаря
        /// </summary>
        /// <param name="encryptedMessage"></param>
        /// <param name="key"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedMessage, int key, string alphabet)
        {
            return Encode(encryptedMessage, key, alphabet);
        }
    }
}
