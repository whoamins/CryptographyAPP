using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace WpfApp1
{
    public class RIPEMD160Hash
    {
        public static string GetHash(string input)
        {
            // Создаем экземпляр
            RIPEMD160 r160 = RIPEMD160Managed.Create();

            // Получаем байты
            byte[] myByte = Encoding.ASCII.GetBytes(input);

            // Вычисляем хеш
            byte[] encrypted = r160.ComputeHash(myByte);

            // Создаем StringBuilder
            StringBuilder sb = new StringBuilder();

            // Заполняем sb
            for (int i = 0; i < encrypted.Length; i++)
            {
                sb.Append(encrypted[i].ToString("X2"));
            }

            // Возращаем хеш в нижнем регистре и текстовом формате
            return sb.ToString().ToLower();
        }
    }
}
