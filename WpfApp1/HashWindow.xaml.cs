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
    /// Логика взаимодействия для HashWindow.xaml
    /// </summary>
    public partial class HashWindow : Window
    {
        public HashWindow()
        {
            InitializeComponent();

            HashSelection.SelectedIndex = -1;
        }

        /// <summary>
        /// Переход между страницами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageButtonClick(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(80 + (270 * index), 0, 0, 0);

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
                    GridMain.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    break;
            }
        }
    }
}
