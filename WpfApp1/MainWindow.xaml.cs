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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Объявление базы данных
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBoxLogin.Password.Trim();
            string repeatPassword = RepeatPasswordBoxLogin.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            // Проверка введеных значений
            if (login.Length < 3)
            {
                textBoxLogin.ToolTip = "Пароль должен содержать в себе более 3 символов";
                textBoxLogin.Background = Brushes.Red;
            }
            else if (password.Length < 8)
            {
                passwordBoxLogin.ToolTip = "Пароль должен содержать в себе более 8 символов";
                passwordBoxLogin.Background = Brushes.Red;
            }
            else if (password != repeatPassword)
            {
                RepeatPasswordBoxLogin.ToolTip = "Пароли не совпадают";
                RepeatPasswordBoxLogin.Background = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Нужно ввести корректный email";
                textBoxEmail.Background = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passwordBoxLogin.ToolTip = "";
                passwordBoxLogin.Background = Brushes.Transparent;
                RepeatPasswordBoxLogin.ToolTip = "";
                RepeatPasswordBoxLogin.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Все ок!");
            }

            #region Регистрация 

            // Создание нового пользователя с login, email, password полученным из textbox
            User user = new User(login, email, password); 
            
            // Добавляем нового пользователя в базу данных
            db.Users.Add(user);

            // Сохраняем базу данных
            db.SaveChanges();

            #endregion

            #region Редирект

            // Перенаправление на форму входа

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();

            #endregion
        }

        /// <summary>
        /// Обработчик нажатия на кнопку войти.
        /// Переход на AuthWindow.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginWindowButtonClick(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
