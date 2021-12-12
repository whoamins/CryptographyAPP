using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class CaesarCipherAnalysis
    {
        /// <summary>
        /// Перебирает ключ для шифра Цезаря
        /// </summary>
        /// <param name="input">Исходный текст</param>
        /// <param name="alphabet">Алфавит</param>
        /// <returns></returns>
        public static string Crack(string input, string alphabet)
        {
            StringBuilder sb = new StringBuilder();

            for(int key = 0; key <= alphabet.Length; key++)
            {
                sb.AppendLine(string.Format($"Ключ - {key} - {CaesarCipher.Decrypt(input, -key, alphabet)}"));
            }

            return sb.ToString();
        }
    }
}
