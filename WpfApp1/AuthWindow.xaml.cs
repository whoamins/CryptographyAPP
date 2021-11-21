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
using WpfApp1.Utils;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public static User LoggedUser { get; private set; }

        public AuthWindow()
        {
            InitializeComponent();

            // For remember me feauture
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
            string login = textBoxLogin.Text.Trim();
            string password = EncryptPassword.Encrypt(passwordBoxLogin.Password).Trim();

            if (login != "" && password != "")
            {
                User loginUser;

                using (ApplicationContext db = new ApplicationContext())
                {
                    loginUser = db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                    LoggedUser = loginUser;
                }


                if (loginUser != null)
                {
                    if (CredentialsRequirements.IsAdmin(loginUser))
                    {
                        AdminPageWindow adminPageWindow = new AdminPageWindow();
                        adminPageWindow.Show();
                        Hide();
                    }
                    else
                    {
                        MainContentWindow mainContentWindow = new MainContentWindow();
                        mainContentWindow.Show();
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show("oOoOoOPs! Try Again!", "Try Again!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
            if((bool)RememberMe.IsChecked)
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
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            Hide();
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
                DragMove();
            }
        }
    }
}
