using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.DialogServices
{
    public class SaveFileService
    {
        public static void SaveFile(TextBox OutputTextBox)
        {
            SaveFileDialog fileSave = new SaveFileDialog(); // Создаем экземпляр

            fileSave.Filter = "Text file(*.txt)|*.txt|C# File (*.cs)|*cs"; // Расширения файла, в которых можно сохранить
            fileSave.InitialDirectory = @"c:\"; // Начальная директория в окне сохранения
            fileSave.ShowDialog(); // Показать диалоговое окно

            if(fileSave.FileName != "") // Если файл загружен
            {
                File.WriteAllText(fileSave.FileName, OutputTextBox.Text); // Сохранить текст из текстового поля OutputTextBox в файл 
            }
        }
    }
}
