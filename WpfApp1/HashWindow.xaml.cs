using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для HashWindow.xaml
    /// </summary>
    public partial class HashWindow : Window
    {
        public HashWindow()
        {
            InitializeComponent();
            HashSelection.SelectedIndex = -1;

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
        /// Обработчик нажатия кнопки хеширования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HashButton(object sender, RoutedEventArgs e)
        {
            // В зависимости от выбранного хэш-алгоритма выдаем разный результат

            if (HashSelection.SelectedIndex == 0)
            {
                OutputTextBox.Text = MD5Hash.GetHash(InputTextBox.Text);
            }
            if (HashSelection.SelectedIndex == 1)
            {
                OutputTextBox.Text = SHA1Hash.GetHash(InputTextBox.Text);
            }
            if (HashSelection.SelectedIndex == 2)
            {
                OutputTextBox.Text = SHA256Hash.GetHash(InputTextBox.Text);
            }
            if (HashSelection.SelectedIndex == 3)
            {
                OutputTextBox.Text = SHA512Hash.GetHash(InputTextBox.Text);
            }
            if (HashSelection.SelectedIndex == 4)
            {
                OutputTextBox.Text = RIPEMD160Hash.GetHash(InputTextBox.Text);
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
