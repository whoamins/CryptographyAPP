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
    /// Логика взаимодействия для MainContentWindow.xaml
    /// </summary>
    public partial class MainContentWindow : Window
    {
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

            GridCursor.Margin = new Thickness(10 + (150 * index), 0, 0, 0);

            switch (index)
            {
                case 0:
                    GridMain.Background = Brushes.AliceBlue;
                    break;
                case 1:
                    GridMain.Background = Brushes.Red;
                    break;
                case 2:
                    GridMain.Background = Brushes.DarkRed;
                    break;
                case 3:
                    GridMain.Background = Brushes.Green;
                    break;
                case 4:
                    GridMain.Background = Brushes.Red;
                    break;
                case 5:
                    GridMain.Background = Brushes.Yellow;
                    break;
                case 6:
                    GridMain.Background = Brushes.Purple;
                    break;
            }
        }

        private void CloseWindowButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
