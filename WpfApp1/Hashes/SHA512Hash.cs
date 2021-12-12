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
            SHA512 sha512Hash = new SHA512Managed();

            byte[] sourceBytes = Encoding.UTF8.GetBytes(input);

            byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);

            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            return hash.ToLower();
        }
    }
}
