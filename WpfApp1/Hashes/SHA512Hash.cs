using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace WpfApp1
{
    public class SHA512Hash
    {
        /// <summary>
        /// Получаем SHA512 хеш
        /// </summary>
        /// <param name="input">Сообщения, которые нужны для хешировани</param>
        /// <returns></returns>
        public static string GetHash(string input)
        {
            // Создаем экземпляр
            SHA512 sha512Hash = new SHA512Managed();

            // Получаем байты из введеного сообщения
            byte[] sourceBytes = Encoding.UTF8.GetBytes(input);

            // Хешируем байты
            byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);

            // Получаем сам хеш
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            // Возращаем хеш в нижнем регистре
            return hash.ToLower();
        }
    }
}
