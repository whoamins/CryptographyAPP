using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.DialogServices;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainContentWindow.xaml
    /// </summary>
    public partial class MainContentWindow : Window
    {
        #region Поля

        public string Alphabet = "abcdefghijklmnopqrstuvwxyz";

        #endregion

        public MainContentWindow()
        {
            InitializeComponent();
            CipherSelection.SelectedIndex = -1;
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
        /// Обработчик выбранного элемента в ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            // Проверка выбранного элемента в реальном времени, что бы блокировать
            // ввод ключа, в зависимости от выбранного шифры 

            if (CipherKey != null)
            {
                if (CipherSelection.SelectedIndex == 0)
                {
                    CipherKey.IsEnabled = true;
                }
            }
            if (CipherSelection.SelectedIndex == 1)
            {
                CipherKey.IsEnabled = true;
            }
            if (CipherSelection.SelectedIndex == 2)
            {
                CipherKey.IsEnabled = false;
            }
            if (CipherSelection.SelectedIndex == 3)
            {
                CipherKey.IsEnabled = false;
            }
            if (CipherSelection.SelectedIndex == 4)
            {
                CipherKey.IsEnabled = false;
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Зашифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncryptButtonClick(object sender, RoutedEventArgs e)
        {
            // В зависимости от выбранного шифра выдаем разный результат

            if (CipherSelection.SelectedIndex == 0)
            {
                try
                {
                    OutputTextBox.Text = caesarCipher.Encrypt(InputTextBox.Text, Int32.Parse(CipherKey.Text), Alphabet);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ключ должен быть числом!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if(CipherSelection.SelectedIndex == 1)
            { 
                OutputTextBox.Text = vigenere.Encrypt(InputTextBox.Text, CipherKey.Text);
            }
            if(CipherSelection.SelectedIndex == 2)
            {
                OutputTextBox.Text = base64.Base64Encrypt(InputTextBox.Text);
            }
            if(CipherSelection.SelectedIndex == 3)
            {
                OutputTextBox.Text = binary.Encode(InputTextBox.Text);
            }
            if(CipherSelection.SelectedIndex == 4)
            {
                OutputTextBox.Text = atbash.Encrypt(InputTextBox.Text);
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Расшифровать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecryptButtonClick(object sender, RoutedEventArgs e)
        {
            // В зависимости от выбранного шифра выдаем разный результат

            if (CipherSelection.SelectedIndex == 0)
            {
                try
                {
                    OutputTextBox.Text = caesarCipher.Decrypt(InputTextBox.Text, -Int32.Parse(CipherKey.Text), Alphabet);
                }
                catch (Exception)
                {
                    MessageBox.Show("Ключ должен быть числом!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (CipherSelection.SelectedIndex == 1)
            {
                OutputTextBox.Text = vigenere.Decrypt(InputTextBox.Text, CipherKey.Text);
            }
            if (CipherSelection.SelectedIndex == 2)
            {
                OutputTextBox.Text = base64.Base64Decrypt(InputTextBox.Text);
            }
            if (CipherSelection.SelectedIndex == 3)
            {
                OutputTextBox.Text = binary.Decode(InputTextBox.Text);
            }
            if (CipherSelection.SelectedIndex == 4)
            {
                OutputTextBox.Text = atbash.Decrypt(InputTextBox.Text);
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
        /// Загрузка файла при помощи функции Drag&Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragAndDrop(object sender, DragEventArgs e)
        {
            DragNDropService.DragAndDrop(e, InputTextBox);
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
    }
}
