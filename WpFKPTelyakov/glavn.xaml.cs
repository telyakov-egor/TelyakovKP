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

namespace WpFKPTelyakov
{
    /// <summary>
    /// Логика взаимодействия для glavn.xaml
    /// </summary>
    public partial class glavn : Window
    {
        public glavn()
        {
            InitializeComponent();
        }

        private void btnNewZayav_Click(object sender, RoutedEventArgs e)
        {
            Zayavlenie z1 = new Zayavlenie();
            z1.Show();
            this.Close();
        }

        private void BtnSpicokAbit_Click(object sender, RoutedEventArgs e)
        {
            wSpisocAbityrientov spis = new wSpisocAbityrientov();
            spis.Show();
            this.Close();
        }

        private void BtnSpisokSpec_Click(object sender, RoutedEventArgs e)
        {
            wSpisSpec w1 = new wSpisSpec();
            w1.Show();
            this.Close();
        }

        private void btnReitingSpisok_Click(object sender, RoutedEventArgs e)
        {
            wOthet w1 = new wOthet();
            w1.Show();
            this.Close();
        }
    }
}
