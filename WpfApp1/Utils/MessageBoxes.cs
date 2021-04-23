using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class MessageBoxes
    {
        public static void ErrorMessageBox()
        {
            MessageBox.Show("Неизвестная ошибка", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void CaesarErrorMessageBox(string alphabet)
        {
            string length;

            if(alphabet.Length == 26)
            {
                length = "символов";
            }
            else
            {
                length = "символа";
            }

            MessageBox.Show($"Выбранный вами алфавит содержит {alphabet.Length} {length}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
