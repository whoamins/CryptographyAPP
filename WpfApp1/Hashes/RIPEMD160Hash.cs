using System.Text;
using System.Security.Cryptography;
using WpfApp1.Interface.Hashes;

namespace WpfApp1
{
    public class RIPEMD160Hash : IHash
    {
        public string GetHash(string input)
        {
            RIPEMD160 r160 = RIPEMD160.Create();

            byte[] myByte = Encoding.ASCII.GetBytes(input);
            byte[] encrypted = r160.ComputeHash(myByte);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < encrypted.Length; i++)
            {
                sb.Append(encrypted[i].ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }
}
