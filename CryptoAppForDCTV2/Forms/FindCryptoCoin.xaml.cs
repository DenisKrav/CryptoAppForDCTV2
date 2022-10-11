using CryptoAppForDCTV2.Classes;
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

namespace CryptoAppForDCTV2.Forms
{
    /// <summary>
    /// Логика взаимодействия для FindCryptoCoin.xaml
    /// </summary>
    public partial class FindCryptoCoin : Window
    {
        public FindCryptoCoin()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
