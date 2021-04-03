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
                MarkInvalid(textBoxLogin);
            }
            else if (password.Length < 8)
            {
                MarkInvalid(passwordBoxLogin);
            }
            else if (password != repeatPassword)
            {
                MarkInvalid(passwordBoxLogin);
                MarkInvalid(RepeatPasswordBoxLogin);
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                MarkInvalid(textBoxEmail);
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
            User user = new User(login, email, EncryptPassword.Encrypt(password));

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
        /// Отображение ошибки в поле
        /// </summary>
        /// <param name="control"></param>
        public void MarkInvalid(Control control)
        {
            control.ToolTip = "Поле введено не корректно!";
            control.Background = Brushes.Red;
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
