using System.Text;
using System.Security.Cryptography;
using WpfApp1.Interface.Hashes;

namespace WpfApp1
{
    public class SHA256Hash : IHash
    {
        public string GetHash(string input)
        {
            SHA256 sha256Hash = SHA256.Create();
            
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

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
