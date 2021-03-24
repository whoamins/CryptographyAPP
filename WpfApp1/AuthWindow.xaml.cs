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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public string Username2 { get; set; }
        public AuthWindow()
        {
            InitializeComponent();

            if (Properties.Settings.Default.username != string.Empty)
            {
                textBoxLogin.Text = Properties.Settings.Default.username;
                passwordBoxLogin.Password = Properties.Settings.Default.password;
            }
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBoxLogin.Password.Trim();

            if (login != "" && password != "")
            {
                User loginUser = null;

                using (ApplicationContext db = new ApplicationContext())
                {
                    loginUser = db.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                }

                if (loginUser != null && loginUser.Login == "admin")
                {
                    AdminPageWindow adminPageWindow = new AdminPageWindow();
                    adminPageWindow.Show();
                    this.Hide();
                }
                else if (loginUser != null)
                {
                    MessageBox.Show("Все ок!");

                    MainContentWindow mainContentWindow = new MainContentWindow();
                    mainContentWindow.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Что-то не так!");
                }
            }

            if(RememberMe.IsChecked == true)
            {
                Properties.Settings.Default.username = textBoxLogin.Text;
                Properties.Settings.Default.password = passwordBoxLogin.Password;
                Properties.Settings.Default.Save();
            }
        }

        private void RegisterWindowButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
