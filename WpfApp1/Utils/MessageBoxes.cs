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
    }
}
