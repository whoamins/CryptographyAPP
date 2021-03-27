using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WpfApp1
{
    public class MD5Hash
    {
        public static string GetHash(string input)
        {
            // Создаем экземпляр
            MD5 md5 = new MD5CryptoServiceProvider();
            
            // Получаем байты
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            
            // Вычисляем хеш
            byte[] hashenc = md5.ComputeHash(bytes);


            StringBuilder sb = new StringBuilder();

            foreach (var b in hashenc)
            {
                sb.Append(b.ToString("x2"));
            }
            
            return sb.ToString();
        }
    }
}
