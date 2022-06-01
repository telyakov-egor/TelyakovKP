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
using System.Data.Linq;
using System.Data.Linq.Mapping;
using WpFKPTelyakov.Properties;

namespace WpFKPTelyakov
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
        }

        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //проверка пароля
                string s = txtPassword.Text;
                char[] array = s.ToCharArray(); // раскладываем строку парля на знаки
                int d = s.Length;
                int k = 0;
                int u = 0;
                int b = 0;
                char p = '$';
                char j = '!';
                char f = '@';
                char h = '%';
                char z = '^';
                char x = '#';

                // проверка на Верхний регистр
                for (int i = 0; i < d; i++)
                {
                    if (char.IsUpper(array[i]))//вычисляем регистр
                        k++;
                }

                // проверка на число
                for (int i = 0; i < d; i++)
                {
                    if (char.IsNumber(array[i]))//вычисляем числа
                        u++;
                }

                // проверка на знак
                for (int i = 0; i < d; i++)
                {//вычисляем знак
                    if (Convert.ToChar(p) == (array[i]) || Convert.ToChar(j) ==
                    (array[i]) || Convert.ToChar(h) == (array[i]) || Convert.ToChar(z) == (array[i]) ||
                    Convert.ToChar(f) == (array[i]) || Convert.ToChar(x) == (array[i]))
                        b++;
                }
                if ((k >= 1) && (txtPassword.Text.Length >= 6) && (u >= 1) && (b >= 1))
                {
                    using (DataContext context = new DataContext(Properties.Settings.Default.db))
                    {
                        string log = txtLogin.Text;
                        string pass = txtPassword.Text;
                        string fio = txtFIO.Text;

                        users us = new users();
                        us.login = log;
                        us.password = pass;
                        us.FIO = fio;
                        context.GetTable<users>().InsertOnSubmit(us);
                        context.SubmitChanges();
                        MessageBox.Show("Пользователь добавлен!", "Успешно", MessageBoxButton.OK);
                    }
                    MainWindow vhod = new MainWindow();
                    vhod.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать $ ! @ # ^ %, как минимум 1 цифру, как минимум одну заглавную букву", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            catch
            {
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow vhod = new MainWindow();
            vhod.Show();
            this.Close();
        }
    }
}
