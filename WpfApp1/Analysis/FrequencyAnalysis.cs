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
        public static string Analysis(string input, string output)
        {
            int[] c = new int[(int)char.MaxValue];

            StringBuilder sb = new StringBuilder();

            string s = input;

            foreach (char t in s)
            {
                c[(int)t]++;
            }

            // 33 -> 126
            // 472 -> 535

            for (int i = 33; i < 126; i++)
            {
                sb.AppendLine(string.Format("Letter: {0}  Frequency: {1}", (char)i, c[i]));
            }
            //for(int i = 472; i < 535; i++)
            //{
            //    sb.AppendLine(string.Format("Letter: {0}  Frequency: {1}", (char)i, c[i]));
            //}

            output = sb.ToString();

            return output;
        }
	}
}
