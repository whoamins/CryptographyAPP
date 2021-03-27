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
                // Проверка, доступны ли данные в указанном формате, или возможность их преобразования в указанный формат.
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // Получаем строки
                    string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);

                    // Выводим строки из файла в InputTextBox
                    InputTextBox.Text = File.ReadAllText(file[0]);
                }
            }
            catch (Exception) // Если получаем исключение, выдаем ошибку
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
