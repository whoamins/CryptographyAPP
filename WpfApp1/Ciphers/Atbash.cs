using WpfApp1.Interfaces.Ciphers;

namespace WpfApp1
{
    public class Atbash : ICipher
    {
        /// <summary>
        /// Реверс строки
        /// </summary>
        /// <param name="inputText">Входной текст</param>
        /// <returns>Перевернутый входной текст</returns>
        private static string Reverse(string inputText)
        {
            var reversedText = string.Empty;

            foreach (var s in inputText)
            {
                reversedText = s + reversedText;
            }

            return reversedText;
        }

        private static string EncryptDecrypt(string text, string symbols, string cipher)
        {
            text = text.ToLower();
            var outputText = string.Empty;

            for (var i = 0; i < text.Length; i++)
            {
                var index = symbols.IndexOf(text[i]);

                if (index >= 0)
                {
                    outputText += cipher[index].ToString();
                }
            }

            return outputText;
        }

        public string Encrypt(string plainText, string alphabet)
        {
            return EncryptDecrypt(plainText, alphabet, Reverse(alphabet));
        }

        public string Decrypt(string encryptedText, string alphabet)
        {
            return EncryptDecrypt(encryptedText, Reverse(alphabet), alphabet);
        }
    }
}

