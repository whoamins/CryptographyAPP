using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.DialogServices
{
    public class DragNDropService
    {
        /// <summary>
        /// Функция Drag&Drop. Позволяет просто перетаскивать файл
        /// </summary>
        /// <param name="e"></param>
        /// <param name="InputTextBox"></param>
        public static void DragAndDrop(DragEventArgs e, TextBox InputTextBox)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);

                    InputTextBox.Text = File.ReadAllText(file[0]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
