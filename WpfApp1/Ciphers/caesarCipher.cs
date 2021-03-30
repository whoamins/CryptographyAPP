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
            var minimizedText = text.ToLower(); // Переводим текст в нижний регистр, для удобства вычисления
            var letterQuntity = alphabet.Length; // Длина алфавита
            var result = ""; // Строка результата

            // Проходимся по тексту
            for (int i = 0; i < minimizedText.Length; i++)
            {
                var c = minimizedText[i]; // Получаем символ, на котором сейчас находимся 
                var index = alphabet.IndexOf(c); // Получаем индекс символа

                if (index < 0) // Если индекс меньше нуля, то добавляем его к результату
                {
                    result += c.ToString();
                }
                else // Если индекс больше нуля то вычисляем codeIndex.
                {
                    var codeIndex = (letterQuntity + index + key) % letterQuntity;

                    // И добавляем к результату символ алфавита с индексом, который мы вычислили выше.
                    result += alphabet[codeIndex];
                }
            }

            // Возращаем результат
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
