using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class vigenere
    {
        /// <summary>
        /// Зашифровывает в шифр Виженера
        /// </summary>
        /// <param name="input">Исходный текст</param>
        /// <param name="key">Ключ</param>
        /// <param name="alphabet">Алфавит</param>
        /// <returns></returns>
        public static string Encrypt(string input, string key, string alphabet)
        {
            int j = 0; // Индекс для ключа

            StringBuilder ret = new StringBuilder(input.Length);

            // Проходим по всей строке
            for (int i = 0; i < input.Length; i++)
            {
                // Если алфавит содержит символ, на которм мы сейчас
                if (alphabet.Contains(input[i]))
                {
                    // Добавляем новый символ алфавита, вычисляем его по формуле ниже
                    ret.Append(alphabet[(alphabet.IndexOf(input[i]) + alphabet.IndexOf(key[j])) % alphabet.Length]);
                }
                else
                {
                    // Если не содержит, то просто добавляем
                    ret.Append(input[i]);
                }

                // Вычисляем новый индекс
                j = (j + 1) % key.Length;
            }

            // Возвращаем результат
            return ret.ToString();
        }

        /// <summary>
        /// Расшифровывает в шифр Виженера
        /// </summary>
        /// <param name="input">Исходный текст</param>
        /// <param name="key">Ключ</param>
        /// <param name="alphabet">Алфавит</param>
        /// <returns></returns>
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
