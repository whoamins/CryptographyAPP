using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class atbash
    {
        private const string alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string ruAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

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
        public static string EncryptDecrypt(string text, string symbols, string cipher)
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
        public static string Encrypt(string plainText)
        {
            return EncryptDecrypt(plainText, ruAlphabet, Reverse(ruAlphabet));
        }

        //расшифровка текста
        public static string Decrypt(string encryptedText)
        {
            return EncryptDecrypt(encryptedText, Reverse(ruAlphabet), ruAlphabet);
        }
    }
}

