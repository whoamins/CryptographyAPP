using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public class VigenereBruteForce
    {
        public static string Brute(string input, string keyLength, ProgressBar pb)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                string dict = @"dict.txt";
                List<string> dictionary = new List<string>();

                Dictionary<string, int> countRefs = new Dictionary<string, int> { };


                string value = input;
                string attempt;
                int counter = 0;
                double progress = 0, total = 0;
                int keylength = Int32.Parse(keyLength);
                int limiter = 2;

                using (StreamReader sr = File.OpenText(dict))
                {
                    string wordpre = "";
                    while ((wordpre = sr.ReadLine()) != null)
                    {
                        total += 1;
                        if (wordpre.Length >= limiter)
                            dictionary.Add(wordpre);
                    }
                }

                using (StreamReader sr = File.OpenText(dict))
                {
                    string word = "";
                    while ((word = sr.ReadLine()) != null)
                    {
                        progress += 1;
                        if (isAllLetters(word))
                        {
                            if (word.Length == keylength)
                            {
                                attempt = decipherVeginere(value, word);
                                if (dictionary.Any(attempt.Contains))
                                {
                                    counter += 1;
                                    sb.AppendLine(string.Format("\r[S] " + word + "\t\t" + attempt));

                                    countRefs.Add(word, dictionary.Count(s => attempt.Contains(s)));
                                }
                            }
                        }
                        // ("\r>{0:n}%", (100 / total) * progress);
                    }
                }
                StringBuilder res = new StringBuilder();

                res.AppendLine(string.Format("[Кол-во паролей: {0}]", total));

                res.AppendLine(" > Наиболее вероятные ключи");

                foreach (var item in countRefs.OrderByDescending(r => r.Value).Take(10))
                {
                    res.AppendLine(string.Format("KEY {0}, {1}", item.Key, decipherVeginere(value, item.Key), item.Value));
                }

                return res.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Укажите длину ключа, а не сам ключ!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return input;
        }

        public static bool isAllLetters(string s)
		{
			foreach (char c in s)
			{
				if (!Char.IsLetter(c))
					return false;
			}
			return true;
		}

		static string decipherVeginere(string text, string key)
		{
			StringBuilder result = new StringBuilder();
			int keyLength = key.Length;
			int diff;
			char decoded;

			text = text.Replace(" ", "").ToLower();

			for (int i = 0; i < text.Length; i++)
			{
				diff = text[i] - key[i % keyLength];

				//diff should never be more than 25 or less than -25
				if (diff < 0)
					diff += 26;

				decoded = (char)(diff + 'a');
				result.Append(decoded);
			}

			return result.ToString();
		}
	}
}
