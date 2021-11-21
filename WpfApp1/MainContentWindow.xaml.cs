using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.DialogServices;
using WpfApp1.Utils;

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

            if(CredentialsRequirements.IsAdmin(AuthWindow.LoggedUser))
            {
                AuthWindow.LoggedUser.Login = "qwe";
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
        /// Обработчик выбранного элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedItem(object sender, SelectionChangedEventArgs e)
        {
            try
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
                    KeyLength.IsEnabled = false;
                    LanguageSelection.IsEnabled = false;
                }
                if (AnalysisSelection.SelectedIndex == 2)
                {
                    KeyLength.IsEnabled = true;
                    LanguageSelection.IsEnabled = false;
                }
                if (AnalysisSelection.SelectedIndex == 3)
                {
                    KeyLength.IsEnabled = false;
                    LanguageSelection.IsEnabled = true;
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
                    OutputTextBoxCrypto.Text = CaesarCipher.Encrypt(InputTextBoxCrypto.Text, Int32.Parse(CipherKey.Text), Alphabet);
                }
                if (CipherSelection.SelectedIndex == 1)
                {
                    OutputTextBoxCrypto.Text = Vigenere.Encrypt(InputTextBoxCrypto.Text, CipherKey.Text, Alphabet);
                }
                if (CipherSelection.SelectedIndex == 2)
                {
                    OutputTextBoxCrypto.Text = Base64.Base64Encrypt(InputTextBoxCrypto.Text);
                }
                if (CipherSelection.SelectedIndex == 3)
                {
                    OutputTextBoxCrypto.Text = Binary.Encode(InputTextBoxCrypto.Text);
                }
                if (CipherSelection.SelectedIndex == 4)
                {
                    OutputTextBoxCrypto.Text = new Atbash().Encrypt(InputTextBoxCrypto.Text, Alphabet);
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
                    OutputTextBoxCrypto.Text = CaesarCipher.Decrypt(InputTextBoxCrypto.Text, -Int32.Parse(CipherKey.Text), Alphabet);
                }
                if (CipherSelection.SelectedIndex == 1)
                {
                    OutputTextBoxCrypto.Text = Vigenere.Decrypt(InputTextBoxCrypto.Text, CipherKey.Text, Alphabet);
                }
                if (CipherSelection.SelectedIndex == 2)
                {
                    OutputTextBoxCrypto.Text = Base64.Base64Decrypt(InputTextBoxCrypto.Text);
                }
                if (CipherSelection.SelectedIndex == 3)
                {
                    OutputTextBoxCrypto.Text = Binary.Decode(InputTextBoxCrypto.Text);
                }
                if (CipherSelection.SelectedIndex == 4)
                {
                    OutputTextBoxCrypto.Text = new Atbash().Decrypt(InputTextBoxCrypto.Text, Alphabet);
                }
        }



        /// <summary>
        /// Обработчик нажатия кнопки хеширования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HashButton(object sender, RoutedEventArgs e)
        {
            // В зависимости от выбранного хэш-алгоритма выдаем разный результат

            try
            {
                if (HashSelection.SelectedIndex == 0)
                {
                    OutputTextBoxHash.Text = new MD5Hash().GetHash(InputTextBoxHash.Text);
                }
                if (HashSelection.SelectedIndex == 1)
                {
                    OutputTextBoxHash.Text = new SHA1Hash().GetHash(InputTextBoxHash.Text);
                }
                if (HashSelection.SelectedIndex == 2)
                {
                    OutputTextBoxHash.Text = new SHA256Hash().GetHash(InputTextBoxHash.Text);
                }
                if (HashSelection.SelectedIndex == 3)
                {
                    OutputTextBoxHash.Text = new SHA512Hash().GetHash(InputTextBoxHash.Text);
                }
                if (HashSelection.SelectedIndex == 4)
                {
                    OutputTextBoxHash.Text = new RIPEMD160Hash().GetHash(InputTextBoxHash.Text);
                }
            }
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки анализа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalysisButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // В зависимости от выбранного анализа выдаем разный результат

                if (AnalysisSelection.SelectedIndex == 0)
                {
                    OutputTextBoxAnalysis.Text = FrequencyAnalysis.Analysis(InputTextBoxAnalysis.Text, OutputTextBoxAnalysis.Text);
                }
                if (AnalysisSelection.SelectedIndex == 1)
                {
                    OutputTextBoxAnalysis.Text = FrequencyAnalysisDecrypt.Decrypt(InputTextBoxAnalysis.Text);
                }
                if (AnalysisSelection.SelectedIndex == 2)
                {
                    if (LongWait.LongWaitResponseInMessageBox(OutputTextBoxAnalysis.Text))
                    {
                        OutputTextBoxAnalysis.Text = BruteForce.BruteWithKeyLength(InputTextBoxAnalysis.Text, KeyLength.Text);
                    }
                    else
                    {

                    }
                }
                if (AnalysisSelection.SelectedIndex == 3)
                {
                    OutputTextBoxAnalysis.Text = CaesarCipherAnalysis.Crack(InputTextBoxAnalysis.Text, Alphabet);
                }
            }
            catch (Exception)
            {
                MessageBoxes.ErrorMessageBox();
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
                UploadFileService.UploadFile(InputTextBoxCrypto);
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
                DragNDropService.DragAndDrop(e, InputTextBoxCrypto);
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
                SaveFileService.SaveFile(OutputTextBoxCrypto);
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
