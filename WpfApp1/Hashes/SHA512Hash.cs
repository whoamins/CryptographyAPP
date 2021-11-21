using System;
using System.Text;
using System.Security.Cryptography;
using WpfApp1.Interface.Hashes;


namespace WpfApp1
{
    public class SHA512Hash : IHash
    {
        /// <summary>
        /// Получаем SHA512 хеш
        /// </summary>
        /// <param name="input">Сообщения, которые нужны для хешировани</param>
        /// <returns></returns>
        public string GetHash(string input)
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
