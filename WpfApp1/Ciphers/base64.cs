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
        public static string Base64Encrypt(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(plainTextBytes);
        }

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
