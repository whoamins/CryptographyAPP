using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class CaesarCipher
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

            // Проходимся по всему алфавиту
            for(int key = 0; key <= alphabet.Length; key++)
            {
                // Добавляем в результат строку "Ключ - {ключ} - {расшифрованный текст с данным ключом}"
                sb.AppendLine(string.Format($"Ключ - {key} - {caesarCipher.Decrypt(input, -key, alphabet)}"));
            }

            // Возвращаем строку
            return sb.ToString();
        }
    }
}
