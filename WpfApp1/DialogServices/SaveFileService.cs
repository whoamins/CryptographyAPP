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
            SaveFileDialog fileSave = new SaveFileDialog();

            fileSave.Filter = "Text file(*.txt)|*.txt|C# File (*.cs)|*cs";
            fileSave.InitialDirectory = @"c:\";
            fileSave.ShowDialog();

            if(fileSave.FileName != "")
            {
                File.WriteAllText(fileSave.FileName, OutputTextBox.Text);
            }
        }
    }
}
