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
		public static string Analysis(string input, TextBox output)
        {
            char ch;
            for (ch = 'A'; ch <= 'Z'; ch++)
            {
                int count = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (ch == input[i] || input[i] == (ch + 32))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    output.Text = "Char " + ch + "having Freq of " + count;
                }
            }

            return input;
        }
	}
}
