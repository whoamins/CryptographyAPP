using System.Text;
using System.Security.Cryptography;
using WpfApp1.Interface.Hashes;

namespace WpfApp1
{
    public class SHA1Hash : IHash
    {
        public string GetHash(string input)
        {
            SHA1Managed sha1 = new SHA1Managed();

            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder(hash.Length * 2);

            foreach(byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString().ToLower();
        }
    }
}
