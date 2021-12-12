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
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"\"{nameof(input)}\" не может быть неопределенным или пустым.", nameof(input));
            }

            if (string.IsNullOrEmpty(output))
            {
                throw new ArgumentException($"\"{nameof(output)}\" не может быть неопределенным или пустым.", nameof(output));
            }

            int[] c = new int[(int)char.MaxValue];

            StringBuilder sb = new StringBuilder();

            string s = input;
            
            foreach (char t in s)
            {
                c[(int)t]++;
            }

            for (int i = 33; i <= 126; i++)
            {
                sb.AppendLine(string.Format("Символ: {0}  Частота: {1}", (char)i, c[i]));

                if(i == 126)
                {
                    for(int j = 1040; j <= 1103; j++)
                    {
                        sb.AppendLine(string.Format("Символ: {0}  Частота: {1}", (char)j, c[j]));
                    }
                }
            }

            return sb.ToString();
        }
    }
}
