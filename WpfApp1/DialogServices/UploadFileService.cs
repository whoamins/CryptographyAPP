using Microsoft.Win32;
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
    public class UploadFileService
    {
        public static void UploadFile(TextBox InputTextBox)
        {
            OpenFileDialog uploadedFile = new OpenFileDialog();
            uploadedFile.ShowDialog();

            if(uploadedFile.FileName != "")
            {
                try
                {
                    StreamReader streamFile = new StreamReader(uploadedFile.FileName);

                    InputTextBox.Text = streamFile.ReadToEnd();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не получилось открыть файл!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
