using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class FrequencyAnalysisDecrypt
    {
        private static string Decipher(string text, int shift)
        {
            char[] characters = text.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                char c = characters[i];
                char letter = Char.ToLower(characters[i]);
                if (char.IsLetter(letter))
                {
                    letter = (char)(letter - shift);
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }

                    if (char.IsLower(c))
                        characters[i] = letter;
                    else
                        characters[i] = Char.ToUpper(letter);
                }
            }
            return new string(characters);
        }

        public static string Decrypt(string text)
        {
            var characterCount = new Dictionary<char, int>();

            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                if (characterCount.ContainsKey(c))
                    characterCount[c]++;
                else
                    characterCount[c] = 1;
            }


            var items = from pair in characterCount
                        orderby pair.Value ascending
                        select pair;

            sb.AppendLine(" > Наиболее вероятные ключи");

            foreach (KeyValuePair<char, int> pair in characterCount.OrderByDescending(i => i.Value))
            {
                int shift = 0;
                char c = pair.Key;

                if (char.IsLetter(c))
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);


                    while (c != 'e')
                    {
                        c--;
                        shift++;
                        if (c > 'z')
                        {
                            c = (char)(c - 26);
                        }
                        else if (c < 'a')
                        {
                            c = (char)(c + 26);
                        }
                    }
                    if (c == 'e')
                    {
                        sb.AppendLine(string.Format("KEY {0}, {1}", shift, Decipher(text, shift)));                        
                    }
                }
            }

            return sb.ToString();
        }
    }
}
