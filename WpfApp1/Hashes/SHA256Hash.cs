using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WpfApp1
{
    public class SHA256Hash
    {
        public static string GetHash(string input)
        {
            // Создаем экземпляр
            SHA256 sha256Hash = SHA256.Create();

            // Вычисляем хеш
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Создаем экземпляр StringBuidler для вывода в программе
            StringBuilder builder = new StringBuilder();

            // Заполняем builder
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            // Возращаем builder в строковом формате
            return builder.ToString();
        }
    }
}
