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
    /// Логика взаимодействия для CoinInformation.xaml
    /// </summary>
    public partial class CoinInformation : Window
    {
        public CoinInformation()
        {
            InitializeComponent();

            DataContext = new ApplicationViewModel();
        }
    }
}
