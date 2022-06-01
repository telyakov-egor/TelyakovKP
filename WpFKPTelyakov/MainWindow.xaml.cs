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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpFKPTelyakov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
            dcUserDataContext db = new dcUserDataContext();
            var userLogin = (from user in db.users
                             where user.login == txtLogin.Text
                             select user).ToArray();
            var userPassword = (from user in db.users
                                where user.password == txtPassword.Password
                                select user).ToArray();

            try
            {
                if (txtLogin.Text == userLogin[0].login)
                {
                    try
                    {
                        if (txtPassword.Password == userPassword[0].password)
                        {
                            glavn gl = new glavn();
                            gl.Show();
                            this.Close();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Неверный пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Такого пользователя нет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {
            Registr reg = new Registr();
            reg.Show();
            this.Close();
        }
    }
}
