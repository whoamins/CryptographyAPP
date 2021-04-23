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

        private string Alphabet;

        #endregion

        public MainContentWindow()
        {
            InitializeComponent();
            CipherSelection.SelectedIndex = -1;
            LanguageSelection.SelectedIndex = -1;

            if(AuthWindow.UserLogin == "admin")
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
        /// Переход между страницами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageButtonClick(object sender, RoutedEventArgs e)  
        {
            try
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
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
            }
        }

        /// <summary>
        /// Обработчик выбранного шифра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            // Проверка выбранного элемента в реальном времени, что бы блокировать
            // ввод ключа, в зависимости от выбранного шифры 

            try
            {
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
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
            }
        }

        /// <summary>
        /// Обработчик выбранного языка алфавита
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LanguageComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
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
                    OutputTextBox.Text = caesarCipher.Encrypt(InputTextBox.Text, Int32.Parse(CipherKey.Text), Alphabet);
                }
                if (CipherSelection.SelectedIndex == 1)
                {
                    OutputTextBox.Text = vigenere.Encrypt(InputTextBox.Text, CipherKey.Text, Alphabet);
                }
                if (CipherSelection.SelectedIndex == 2)
                {
                    OutputTextBox.Text = base64.Base64Encrypt(InputTextBox.Text);
                }
                if (CipherSelection.SelectedIndex == 3)
                {
                    OutputTextBox.Text = binary.Encode(InputTextBox.Text);
                }
                if (CipherSelection.SelectedIndex == 4)
                {
                    OutputTextBox.Text = atbash.Encrypt(InputTextBox.Text, Alphabet);
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
                    OutputTextBox.Text = caesarCipher.Decrypt(InputTextBox.Text, -Int32.Parse(CipherKey.Text), Alphabet);
                }
                if (CipherSelection.SelectedIndex == 1)
                {
                    OutputTextBox.Text = vigenere.Decrypt(InputTextBox.Text, CipherKey.Text, Alphabet);
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
                    OutputTextBox.Text = atbash.Decrypt(InputTextBox.Text, Alphabet);
                }
        }

        /// <summary>
        /// Загрузка текста из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                UploadFileService.UploadFile(InputTextBox);
            }
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
            }
        }

        /// <summary>
        /// Загрузка файла при помощи функции Drag&Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragAndDrop(object sender, DragEventArgs e)
        {
            try
            {
                DragNDropService.DragAndDrop(e, InputTextBox);
            }
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
            }
        }

        /// <summary>
        /// Сохранение файла с расшифрованным текстом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileService.SaveFile(OutputTextBox);
            }
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
            }
        }

        /// <summary>
        /// Перемещение окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
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
