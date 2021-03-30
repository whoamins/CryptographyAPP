﻿using System;
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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public static string UserLogin;
        public AuthWindow()
        {
            InitializeComponent();

            // Для функции "Запомнить меня".
            // Проверка, не пустые ли значения из настроек.
            // Если не пустые, то подгружаем их и устанавливаем их.
            if (Properties.Settings.Default.username != string.Empty)
            {
                textBoxLogin.Text = Properties.Settings.Default.username;
                passwordBoxLogin.Password = Properties.Settings.Default.password;
            }
        }

        /// <summary>
        /// Обработка нажатия на кнопку войти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            // Получаем логин, обрезая пробелы в конце и в начале
            string login = textBoxLogin.Text.Trim();

            // Хешируем пароль, что бы сравнить с захешированным в базе данных. Так же обрезаем пробелы.
            string password = EncryptPassword.Encrypt(passwordBoxLogin.Password).Trim();

            // Проверка, не пустые ли логин и пароль
            if (login != "" && password != "")
            {
                User loginUser = null;

                // Using - автоматически вызывает Dispose() в конце блока
                using (ApplicationContext db = new ApplicationContext())
                {
                    // Ищем пользователя с веденным логином и паролем в базе данных
                    loginUser = db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                }

                UserLogin = loginUser.Login;

                // Если залогинлся админ(т.е. пользователя с id = 0) -> подгрузить пользователю админ панель
                if (loginUser != null && loginUser.id == 0)
                {
                    AdminPageWindow adminPageWindow = new AdminPageWindow();
                    adminPageWindow.Show();
                    this.Hide();
                }
                else if (loginUser != null) // Если обычный пользователь, то подгрузить главную страницу
                {
                    MainContentWindow mainContentWindow = new MainContentWindow();
                    mainContentWindow.Show();
                    this.Hide();
                }
                else // Если не получилось залогинется выдаем ошибку
                {
                    MessageBox.Show("Что-то не так!");
                }
            }
            
            // Если поставлена галочка на функцию "Запомнить меня", то сохраняем данные аккаунта. 
            if(RememberMe.IsChecked == true)
            {
                Properties.Settings.Default.username = textBoxLogin.Text;
                Properties.Settings.Default.password = passwordBoxLogin.Password;
                Properties.Settings.Default.Save();
            }
        }

       /// <summary>
       /// Редирект на страницу регистрации
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void RegisterWindowButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
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
    }
}
