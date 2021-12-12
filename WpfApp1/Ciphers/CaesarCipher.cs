using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class CaesarCipher
    {
        /// <summary>
        /// Алгоритм шифра Цезаря
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        public static string Encode(string text, int key, string alphabet)
        {
            var minimizedText = text.ToLower();
            var letterQuntity = alphabet.Length;
            var result = "";

            try
            {
                for (int i = 0; i < minimizedText.Length; i++)
                {
                    var c = minimizedText[i]; 
                    var index = alphabet.IndexOf(c); 

                    if (index < 0)
                    {
                        result += c.ToString();
                    }
                    else 
                    {
                        var codeIndex = (letterQuntity + index + key) % letterQuntity;

                        if (codeIndex >= alphabet.Length)
                        {
                            codeIndex = 0;
                        }

                        result += alphabet[codeIndex];
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxes.CaesarErrorMessageBox(alphabet);
            }

            return result;
        }

        /// <summary>
        /// Зашифровывает в Цезаря
        /// </summary>
        /// <param name="plainMessage"></param>
        /// <param name="key"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        public static string Encrypt(string plainMessage, int key, string alphabet)
        {
            try
            {
                if (key > alphabet.Length)
                {
                    throw new Exception();
                }

                return Encode(plainMessage, key, alphabet);
            }
            catch (Exception)
            {
                MessageBoxes.CaesarErrorMessageBox(alphabet);
                return "";
            }
        }

        /// <summary>
        /// Расшифровывает из Цезаря
        /// </summary>
        /// <param name="encryptedMessage"></param>
        /// <param name="key"></param>
        /// <param name="alphabet"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedMessage, int key, string alphabet)
        {
            try 
            {
                return Encode(encryptedMessage, key, alphabet);
            }
            catch (Exception)
            {
                MessageBoxes.CaesarErrorMessageBox(alphabet);
                return "";
            }
       }
    }
}

