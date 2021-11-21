using System.Text;
using System.Security.Cryptography;
using WpfApp1.Interface.Hashes;

namespace WpfApp1
{
    public class MD5Hash : IHash
    {
        public string GetHash(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            
            byte[] bytes = Encoding.ASCII.GetBytes(input);            
            byte[] hashenc = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();

            foreach (var b in hashenc)
            {
                sb.Append(b.ToString("x2"));
            }
            
            // Возвращаем результат
            return sb.ToString();
        }
    }
}
