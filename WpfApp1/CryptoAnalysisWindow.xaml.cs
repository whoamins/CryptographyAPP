﻿using System;
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
        #region Поля

        public string Alphabet;

        #endregion
        public CryptoAnalysisWindow()
        {
            InitializeComponent();
            AnalysisSelection.SelectedIndex = -1;
            LanguageSelection.SelectedIndex = -1;

            if (AuthWindow.UserLogin == "admin")
            {
                AdminPanelButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Переход на админ панель
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminPanelWindow(object sender, RoutedEventArgs e)
        {
            AdminPageWindow admin = new AdminPageWindow();
            admin.Show();
            this.Close();
        }

        /// <summary>
        /// Обработка нажатия на кнопку выхода из аккаунта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            AuthWindow auth = new AuthWindow();
            auth.Show();
            this.Close();
        }

        /// <summary>
        /// Обработчик выбранного языка алфавита
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanguageComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageSelection.SelectedIndex == 0)
            {
                Alphabet = "aбвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            }
            if (LanguageSelection.SelectedIndex == 1)
            {
                Alphabet = "abcdefghijklmnopqrstuvwxyz";
            }
        }

        /// <summary>
        /// Обработчик выбранного элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            if (KeyLength != null)
            {
                if (AnalysisSelection.SelectedIndex == 0)
                {
                    KeyLength.IsEnabled = false;
                    LanguageSelection.IsEnabled = false;
                }
            }
            if (AnalysisSelection.SelectedIndex == 1)
            {
                KeyLength.IsEnabled = true;
                LanguageSelection.IsEnabled = false;
            }
            if (AnalysisSelection.SelectedIndex == 2)
            {
                KeyLength.IsEnabled = false;
                LanguageSelection.IsEnabled = true;
            }
            if (AnalysisSelection.SelectedIndex == 3)
            {
                KeyLength.IsEnabled = true;
                LanguageSelection.IsEnabled = false;
            }
            if (AnalysisSelection.SelectedIndex == 4)
            {
                KeyLength.IsEnabled = true;
                LanguageSelection.IsEnabled = false;
            }
        }

        /// <summary>
        /// Переход между страницами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageButtonClick(object sender, RoutedEventArgs e)
        {
            // Получаем индекс окна
            int index = int.Parse(((Button)e.Source).Uid);

            // Переход между окнами
            switch (index)
            {
                case 0:
                    var mainWindow = new MainContentWindow();
                    mainWindow.Show();
                    this.Hide();
                    break;
                case 1:
                    var hashWindow = new HashWindow();
                    hashWindow.Show();
                    this.Hide();
                    break;
                case 2:
                    var analysisWindow = new CryptoAnalysisWindow();
                    analysisWindow.Show();
                    this.Hide();
                    break;
                case 3:
                    break;
            }
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
            // В зависимости от выбранного анализа выдаем разный результат

            if (AnalysisSelection.SelectedIndex == 0)
            {
                OutputTextBox.Text = FrequencyAnalysis.Analysis(InputTextBox.Text, OutputTextBox.Text);
            }
            if (AnalysisSelection.SelectedIndex == 1)
            {
                if(LongWait.LongWaitResponseInMessageBox(OutputTextBox.Text))
                {
                    OutputTextBox.Text = VigenereBruteForce.BruteWithKeyLength(InputTextBox.Text, KeyLength.Text);
                }
                else
                {
                    
                }
            }
            if (AnalysisSelection.SelectedIndex == 2)
            {
                OutputTextBox.Text = CaesarCipher.Crack(InputTextBox.Text, Alphabet);
            }
            if (AnalysisSelection.SelectedIndex == 3)
            {

            }
            if (AnalysisSelection.SelectedIndex == 4)
            {

            }
        }

        /// <summary>
        /// Перемещение окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку закрытия окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
