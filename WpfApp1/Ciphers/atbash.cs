using WpfApp1.Interfaces.Ciphers;

namespace WpfApp1
{
    public class Atbash : ICipher
    {
        //метод для переворачивания строки
        private static string Reverse(string inputText)
        {
            //переменная для хранения результата
            var reversedText = string.Empty;
            foreach (var s in inputText)
            {
                //добавляем символ в начало строки
                reversedText = s + reversedText;
            }

            return reversedText;
        }

        //метод шифрования/дешифрования
        private static string EncryptDecrypt(string text, string symbols, string cipher)
        {
            //переводим текст в нижний регистр
            text = text.ToLower();

            var outputText = string.Empty;
            for (var i = 0; i < text.Length; i++)
            {
                //поиск позиции символа в строке алфавита
                var index = symbols.IndexOf(text[i]);
                if (index >= 0)
                {
                    //замена символа на шифр
                    outputText += cipher[index].ToString();
                }
            }

            return outputText;
        }

        //шифрование текста
        public string Encrypt(string plainText, string alphabet)
        {
            return EncryptDecrypt(plainText, alphabet, Reverse(alphabet));
        }

        //расшифровка текста
        public string Decrypt(string encryptedText, string alphabet)
        {
            return EncryptDecrypt(encryptedText, Reverse(alphabet), alphabet);
        }
    }
}

