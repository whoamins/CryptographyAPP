using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.Utils;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        ApplicationContext db;

        public RegisterWindow()
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
            #region Data From TextBox

            string login = textBoxLogin.Text.Trim();
            string password = passwordBoxLogin.Password.Trim();
            string repeatPassword = RepeatPasswordBoxLogin.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            #endregion

            #region Credentials Requirements

            if (!CredentialsRequirements.LoginLength(login))
            {
                InvalidData.MarkInvalid(textBoxLogin);
            }
            
            if (!CredentialsRequirements.PasswordLength(password))
            {
                InvalidData.MarkInvalid(passwordBoxLogin);
            }

            if (password != repeatPassword)
            {
                InvalidData.MarkInvalid(passwordBoxLogin);
                InvalidData.MarkInvalid(RepeatPasswordBoxLogin);
            }

            if (!CredentialsRequirements.EmailFormat(email))
            {
                InvalidData.MarkInvalid(textBoxEmail);
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

                // MessageBox.Show("Все ок!");
            }

            #endregion

            #region Registration 
            User user = new User(login, email, EncryptPassword.Encrypt(password));

            db.Users.Add(user);
            db.SaveChanges();

            #endregion

            #region Redirect

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();

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
            Hide();
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
