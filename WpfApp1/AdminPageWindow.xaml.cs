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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AdminPageWindow.xaml
    /// </summary>
    public partial class AdminPageWindow : Window
    {
        public AdminPageWindow()
        {
            InitializeComponent();

            // Экземпляр базы данных
            ApplicationContext db = new ApplicationContext();
            
            // Получаем всех пользователей в списке.
            List<User> users = db.Users.ToList();

            // Выводим их на страницу
            listOfUsers.ItemsSource = users;
        }

        /// <summary>
        /// Редирект на главную страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainContentWindowButtonClick(object sender, RoutedEventArgs e)
        {
            MainContentWindow mainContentWindow = new MainContentWindow();
            mainContentWindow.Show();
            this.Hide();
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
