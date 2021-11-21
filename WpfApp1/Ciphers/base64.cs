using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Base64
    {
        /// <summary>
        /// Зашифровывает в base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string plainText)
        {
            // Получаем байты исходного текста
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Конвертируем его в Base64. Используя встроенные методы языка C#
            return Convert.ToBase64String(plainTextBytes);
        }
        
        /// <summary>
        /// Расшифровывает из base64
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string base64EncodedData)
        {
            // Отлавливаеем исключения
            try
            {
                // Получаем байты base64
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

                // Конвертируем в обычный UTF-8 тектс
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch // Если возникает исключение, то просто выкидываем message box с ошибкой
            {
                MessageBox.Show("Неизвестные символы, укажите Base64!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return base64EncodedData;
            }
        }
    }
}
