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
using Microsoft;
using Microsoft.Office.Interop.Excel;


namespace WpFKPTelyakov
{
    /// <summary>
    /// Логика взаимодействия для wOthet.xaml
    /// </summary>
    public partial class wOthet : System.Windows.Window
    {
        public wOthet()
        {
            InitializeComponent();
        }

        private void BtnOtshetAbit_Click(object sender, RoutedEventArgs e)
        {
            wSpisocAbityrientov w1 = new wSpisocAbityrientov();
            w1.Show();
            this.Close();
        }

        private void BtnOtshReiting_Click(object sender, RoutedEventArgs e)
        {
            wreitingSpisk wreiting = new wreitingSpisk();
            wreiting.Show();
            this.Close();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            glavn glavn = new glavn();
            glavn.Show();
            this.Close();
        }
    }
}
