using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class Binary
    {
        /// <summary>
        /// Зашифровывает в бинарный код
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encode(string plainText)
        {
            string result = ""; // Пустая строка результат

            // Заполняем строку result символами
            foreach (char i in plainText)
            {
                result += Convert.ToString((int)i, 2).PadLeft(8, '0');
            }

            // Возращаем результат
            return result;
        }

        /// <summary>
        /// Расшифровывает из бинарного кода
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decode(string data)
        {
            // Отлавливаем ошибки
            try
            {
                List<Byte> byteList = new List<Byte>(); // Создаем список байтов.

                if (data.Contains(" ")) // Если исходный текст содержит пробел, заменяем его пустотой
                {
                    data = data.Replace(" ", String.Empty);
                }

                // Каждый байт ( 8 бит ) добавляем в список
                for (int i = 0; i < data.Length; i += 8)
                {
                    byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
                }

                // Возращаем список.
                return Encoding.ASCII.GetString(byteList.ToArray());
            }
            catch (ArgumentOutOfRangeException) // Отлавливаем ошибку, если введено меньше 8 символов
            {
                MessageBox.Show("Введите больше 8 символов!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return data;
            }
            catch (FormatException) // Если указаны неизвестные символы ( не 1 и 0 ), то кидаем Message Box с ошибкой
            {
                MessageBox.Show("Неизвестные символы!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return data;
            }
        }
    }
}
