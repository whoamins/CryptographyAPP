using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class base64
    {
        /// <summary>
        /// Зашифровывает в base64
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encrypt(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(plainTextBytes);
        }
        
        /// <summary>
        /// Расшифровывает из base64
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string base64EncodedData)
        {
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch
            {
                MessageBox.Show("Неизвестные символы, укажите Base64!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return base64EncodedData;
            }
        }
    }
}
