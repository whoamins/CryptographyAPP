using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1.Utils
{
    class InvalidData
    {
        public static void MarkInvalid(Control control)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            control.ToolTip = "Поле введено не корректно!";
            control.Background = Brushes.Red;
        }
    }
}
