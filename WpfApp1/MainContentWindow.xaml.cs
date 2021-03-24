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
    /// Логика взаимодействия для MainContentWindow.xaml
    /// </summary>
    public partial class MainContentWindow : Window
    {
        public string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        public MainContentWindow()
        {
            InitializeComponent();
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            // TODO: Сделать логаут.
        }

        private void PageButtonClick(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (270 * index), 0, 0, 0);

            #region Фулл говно код

            switch (index)
            {
                case 0:
                    GridMain.Visibility = Visibility.Visible;
                    break;
                case 1:
                    GridMain.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            #endregion
        }

        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            if(CipherSelection.SelectedIndex == 0)
            {
                CipherKey.IsEnabled = true;
            }
            if(CipherSelection.SelectedIndex == 1)
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

        private void EncryptButtonClick(object sender, RoutedEventArgs e)
        {
            #region Говнокод

            if (CipherSelection.SelectedIndex == 0)
            {
                OutputTextBox.Text = caesarCipher.Encrypt(InputTextBox.Text, 5, Alphabet);
            }
            if(CipherSelection.SelectedIndex == 1)
            {
                OutputTextBox.Text = vigenere.Encrypt(InputTextBox.Text, "sad");
            }
            if(CipherSelection.SelectedIndex == 2)
            {
                OutputTextBox.Text = base64.Base64Encrypt(InputTextBox.Text);
            }
            if(CipherSelection.SelectedIndex == 3)
            {
                OutputTextBox.Text = binary.Encode(InputTextBox.Text);
            }
            if(CipherSelection.SelectedIndex == 4)
            {
                OutputTextBox.Text = atbash.Encrypt(InputTextBox.Text);
            }

            #endregion
        }

        private void DecryptButtonClick(object sender, RoutedEventArgs e)
        {
            #region Фулл говно код

            if (CipherSelection.SelectedIndex == 0)
            {
                OutputTextBox.Text = caesarCipher.Encrypt(InputTextBox.Text, -5, Alphabet);
            }
            if (CipherSelection.SelectedIndex == 1)
            {
                OutputTextBox.Text = vigenere.Decrypt(InputTextBox.Text, "sad");
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
                OutputTextBox.Text = atbash.Decrypt(InputTextBox.Text);
            }

            #endregion
        }
    }
}
