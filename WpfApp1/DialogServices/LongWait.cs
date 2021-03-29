using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.DialogServices
{
    public class LongWait
    {
        public static bool LongWaitResponseInMessageBox(string output)
        {
            MessageBoxResult result = MessageBox.Show("Это действие может занять много времени", "Вы уверены?", MessageBoxButton.OKCancel);

            switch (result)
            {
                case MessageBoxResult.OK:
                    return true;
                case MessageBoxResult.Cancel:
                    return false;
                default:
                    return true;
            }

        }
    }
}
