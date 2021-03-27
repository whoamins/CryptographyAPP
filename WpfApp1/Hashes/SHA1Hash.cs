using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace WpfApp1
{
    public class SHA1Hash
    {
        public static string GetHash(string input)
        {
            // Создаем экземпляр
            SHA1Managed sha1 = new SHA1Managed();

            // Вычисляем хеш
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Создаем StringBuilder
            StringBuilder sb = new StringBuilder(hash.Length * 2);

            // Заполняем sb хешом
            foreach(byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            // Выводим хеш в нижнем регистре и текстовом формате
            return sb.ToString().ToLower();
        }
    }
}
