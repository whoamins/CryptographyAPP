using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    public class FrequencyAnalysis
    {
        /// <summary>
        /// Частотный анализ
        /// </summary>
        /// <param name="input">Исходный текст</param>
        /// <param name="output">То, куда выводить текст</param>
        /// <returns></returns>
        public static string Analysis(string input, string output)
        {
            // Создаем массив
            int[] c = new int[(int)char.MaxValue];

            StringBuilder sb = new StringBuilder();

            // Переменной s присваиваем исходный текст
            string s = input;

            
            // Проходимся по списку
            foreach (char t in s)
            {
                c[(int)t]++;
            }

            // Проходимся по английскому алфавиту и спец. символам 33 - A, 126 - z
            for (int i = 33; i <= 126; i++)
            {
                // Добавляем к результату
                sb.AppendLine(string.Format("Символ: {0}  Частота: {1}", (char)i, c[i]));

                // Если прошлись по англ. алфавиту и спец.символам переходим на русский алфавит
                if(i == 126)
                {
                    for(int j = 1040; j <= 1103; j++)
                    {
                        // Добавляем к результату
                        sb.AppendLine(string.Format("Символ: {0}  Частота: {1}", (char)j, c[j]));
                    }
                }
            }

            // Возвращаем результат.
            return sb.ToString();
        }
    }
}
