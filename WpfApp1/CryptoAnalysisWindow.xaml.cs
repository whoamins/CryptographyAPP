using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.DialogServices;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CryptoAnalysisWindow.xaml
    /// </summary>
    public partial class CryptoAnalysisWindow : Window
    {
        public string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private bool TriggerForPg = false;

        public CryptoAnalysisWindow()
        {
            InitializeComponent();
            AnalysisSelection.SelectedIndex = -1;
        }

        /// <summary>
        /// Переход между страницами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageButtonClick(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(80 + (270 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    var mainWindow = new MainContentWindow();
                    mainWindow.Show();
                    this.Close();
                    break;
                case 1:
                    var hashWindow = new HashWindow();
                    hashWindow.Show();
                    this.Close();
                    break;
                case 2:
                    var analysisWindow = new CryptoAnalysisWindow();
                    analysisWindow.Show();
                    this.Close();
                    break;
                case 3:
                    break;
            }
        }

        /// <summary>
        /// Обработка нажатия на кастомную кнопку закрытия приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Загрузка текста из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadFileClick(object sender, RoutedEventArgs e)
        {
            UploadFileService.UploadFile(InputTextBox);
        }

        /// <summary>
        /// Сохранение файла с расшифрованным текстом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileClick(object sender, RoutedEventArgs e)
        {
            SaveFileService.SaveFile(OutputTextBox);
        }

        /// <summary>
        /// Загрузка файла драгндропом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragAndDrop(object sender, DragEventArgs e)
        {
            DragNDropService.DragAndDrop(e, InputTextBox);
        }

        /// <summary>
        /// Обработчик нажатия кнопки анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalysisButton(object sender, RoutedEventArgs e)
        {
            if (AnalysisSelection.SelectedIndex == 0)
            {
                OutputTextBox.Text = FrequencyAnalysis.Analysis(InputTextBox.Text, OutputTextBox.Text);
            }
            if (AnalysisSelection.SelectedIndex == 1)
            {
                TriggerForPg = true;
                OutputTextBox.Text = VigenereBruteForce.Brute(InputTextBox.Text, KeyLength.Text, ProgressBar);
            }
            if (AnalysisSelection.SelectedIndex == 2)
            {
                OutputTextBox.Text = SHA256Hash.GetHash(InputTextBox.Text);
            }
            if (AnalysisSelection.SelectedIndex == 3)
            {
                OutputTextBox.Text = SHA512Hash.GetHash(InputTextBox.Text);
            }
            if (AnalysisSelection.SelectedIndex == 4)
            {
                OutputTextBox.Text = RIPEMD160Hash.GetHash(InputTextBox.Text);
            }
        }

        //private void Window_ContentRendered(object sender, EventArgs e)
        //{
        //    BackgroundWorker worker = new BackgroundWorker();

        //    if (TriggerForPg)
        //    {
        //        worker.WorkerReportsProgress = true;
        //        worker.DoWork += worker_DoWork;
        //        worker.ProgressChanged += worker_ProgressChanged;
        //    }

        //    worker.RunWorkerAsync();
        //}

        //private void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    bVigenereBruteForce.Brute(sender, InputTextBox.Text, KeyLength.Text, ProgressBar);
        //}

        //private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    ProgressBar.Value++;
        //}
    }
}
