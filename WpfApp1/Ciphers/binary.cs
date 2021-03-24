﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class binary
    {
        public static string Encode(string plainText)
        {
            string result = "";

            foreach (char i in plainText)
            {
                result += Convert.ToString((int)i, 2).PadLeft(8, '0');
            }

            return result;
        }

        public static string Decode(string data)
        {
            try
            {
                List<Byte> byteList = new List<Byte>();

                if (data.Contains(" "))
                {
                    data = data.Replace(" ", String.Empty);
                }

                for (int i = 0; i < data.Length; i += 8)
                {
                    byteList.Add(Convert.ToByte(data.Substring(i, 8), 2)); // FIX: <8 CHAR DECODE CRUSH
                }

                return Encoding.ASCII.GetString(byteList.ToArray());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Введите больше 8 символов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return data;
            }
            catch (FormatException)
            {
                MessageBox.Show("Неизвестные символы!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return data;
            }
        }
    }
}
