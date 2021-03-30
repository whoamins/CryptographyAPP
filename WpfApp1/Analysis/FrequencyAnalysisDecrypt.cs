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
            char[] characters = text.ToCharArray(); // Создаем список символов

            // Проходимся по массиву
            for (int i = 0; i < characters.Length; i++)
            {
                // В с записываем символов, на котором мы сейчас находимся
                char c = characters[i];
                
                // Преобразовываем символов с нижнем регистр
                char letter = Char.ToLower(characters[i]);

                // Если символ является буквой
                if (char.IsLetter(letter))
                {
                    // Переменной letter присваиваем letter - shift и преобразовываем в char. 
                    letter = (char)(letter - shift);
                    
                    // Если letter больше z (по алфавиту)
                    if (letter > 'z')
                    {
                        // минусуем 26 позицкй и преобразовываем в char
                        letter = (char)(letter - 26);
                    }
                    // Если letter больше a (по алфавиту)
                    else if (letter < 'a')
                    {
                        // Прибавляем 27 позицкй и преобразовываем в char
                        letter = (char)(letter + 26);
                    }

                    // Если символ в нижнем регистре
                    if (char.IsLower(c))
                        characters[i] = letter;
                    else
                        characters[i] = Char.ToUpper(letter);
                }
            }
            // Возвращаем новую строку
            return new string(characters);
        }

        public static string Decrypt(string text)
        {
            // Создаем словарь
            var characterCount = new Dictionary<char, int>();

            StringBuilder sb = new StringBuilder();

            // Проходимся по исходному тексту
            foreach (char c in text)
            {
                // Если содержится с словаре, то прибавляем кол-во.
                if (characterCount.ContainsKey(c))
                    characterCount[c]++;
                // Если нет, то ставим 1
                else
                    characterCount[c] = 1;
            }

            // Сортируем пары в частотной таблице по значению 
            var items = from pair in characterCount
                        orderby pair.Value ascending
                        select pair;

            
            sb.AppendLine(" > Наиболее вероятные ключи");

            // Выводим наиболее вероятные ключи
            foreach (KeyValuePair<char, int> pair in characterCount.OrderByDescending(i => i.Value))
            {
                int shift = 0;
                char c = pair.Key;

                // Если символ является буквой
                if (char.IsLetter(c))
                {
                    Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

                    // Пока c != 'e'
                    while (c != 'e')
                    {
                        c--; // Уменьшаем c на один
                        shift++; // Прибавляем отступ

                        // Если с больше z (по алфавиту)
                        if (c > 'z') 
                        {
                            // минусуем 26 позицкй и преобразовываем в char
                            c = (char)(c - 26);
                        }

                        // Если с меньше а (по алфавиту)
                        else if (c < 'a')
                        {
                            // минусуем 26 позицкй и преобразовываем в char
                            c = (char)(c + 26);
                        }
                    }
                    // Если c == 'e'
                    if (c == 'e')
                    {
                        // Добавляем к результату
                        sb.AppendLine(string.Format("KEY {0}, {1}", shift, Decipher(text, shift)));                        
                    }
                }
            }

            // Возвращаем результат
            return sb.ToString();
        }
    }
}
