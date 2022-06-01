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
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace WpFKPTelyakov
{
    /// <summary>
    /// Логика взаимодействия для wSpisocAbityrientov.xaml
    /// </summary>
    public partial class wSpisocAbityrientov : System.Windows.Window
    {        
        public wSpisocAbityrientov()
        {
            InitializeComponent();
        }

        public void Update()
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.db))
            {
                Table<Abityrients> abit = db.GetTable<Abityrients>();
                var query = from a in abit
                            select new { a.kod_LD, a.Familiy, a.Name, a.Otchestvo,a.Pol,a.Data_rozdeniy, a.Phone, a.Vibor_special };

                dtgAbityrients.ItemsSource = query;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
            
        }
        // поиск по таблице 
        private void TxtPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {

            using (DataContext db = new DataContext(Properties.Settings.Default.db))
            {
                string poisk = txtPoisk.Text;

                dcAbiturDataContext dc1 = new dcAbiturDataContext();

                if (poisk.Length > 0)
                {
                    var kl = (from a in dc1.Abityrients
                              where a.Familiy == poisk
                              select a).ToArray();
                    var kl1 = (from a in dc1.Abityrients
                               where a.Name == poisk
                               select a).ToArray();
                    var kl2 = (from a in dc1.Abityrients
                               where a.Otchestvo == poisk
                               select a).ToArray();
                    var kl3 = (from a in dc1.Abityrients
                               where a.kod_LD == poisk
                               select a).ToArray();
                    Table<Abityrients> uslugis = db.GetTable<Abityrients>();
                    if (kl.Length > 0)
                    {
                        dtgAbityrients.ItemsSource = kl;
                    }
                    else if (kl1.Length > 0)
                    {
                        dtgAbityrients.ItemsSource = kl1;
                    }
                    else if (kl2.Length > 0)
                    {
                        dtgAbityrients.ItemsSource = kl2;
                    }
                    else if (kl3.Length > 0)
                    {
                        dtgAbityrients.ItemsSource = kl3;
                    }

                }
                else Update();
            }
        }
        // действие на конпку удалить 
        private void BtnDelit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new dcAbiturDataContext();

                object item = dtgAbityrients.SelectedItem;
                var vb = (dtgAbityrients.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                var vb1 = (dtgAbityrients.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;

                dcSpecialDataContext dcS = new dcSpecialDataContext();
                Specialnocti spe = dcS.Specialnocti.FirstOrDefault(sp => sp.Name_special.Equals(vb1));
                spe.kolvo_zauav--;
                dcS.SubmitChanges();

                var abit = (from a in db.Abityrients where a.kod_LD == vb select a).Single<Abityrients>();

                dcDocumLicnostDataContext docL = new dcDocumLicnostDataContext();
                var dokL = (from a in docL.Documents_abit where a.Kod_LD == vb select a).Single<Documents_abit>();

                dcAdresAbitDataContext dbAdrAbit = new dcAdresAbitDataContext();
                var adrAb = (from a in dbAdrAbit.Adres_Abityrients where a.kod_LD == vb select a).Single<Adres_Abityrients>();

                dcObrazvAbitDataContext dcObrAbit = new dcObrazvAbitDataContext();
                var obr = (from a in dcObrAbit.Obrazovanie_Abityr where a.Kod_LD == vb select a).Single<Obrazovanie_Abityr>();

                dcOtsenkAbitDataContext dcOtsenAbit = new dcOtsenkAbitDataContext();
                var ots = (from a in dcOtsenAbit.Otsenki_abityr where a.Kod_LD == vb select a).Single<Otsenki_abityr>();

                db.Abityrients.DeleteOnSubmit(abit); db.SubmitChanges();
                docL.Documents_abit.DeleteOnSubmit(dokL); docL.SubmitChanges();
                dbAdrAbit.Adres_Abityrients.DeleteOnSubmit(adrAb); dbAdrAbit.SubmitChanges();
                dcObrAbit.Obrazovanie_Abityr.DeleteOnSubmit(obr); dcObrAbit.SubmitChanges();
                dcOtsenAbit.Otsenki_abityr.DeleteOnSubmit(ots); dcOtsenAbit.SubmitChanges();
                Update();
                MessageBox.Show("Данные удалены!", "Готово", MessageBoxButton.OK);
            }
            catch (Exception)
            {
                MessageBox.Show("Нужно выбрать абитуриента", "Ошибка");
            }
           
        }

        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            glavn g1 = new glavn();
            g1.Show();
            this.Close();
        }

        private void BtnRedact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Redact red = new Redact();
                object item = dtgAbityrients.SelectedItem;
                red.vb = (dtgAbityrients.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                red.Zapoln();
            }
            catch (Exception)
            {
                MessageBox.Show("Нужно выбрать абитуриента", "Ошибка");
            }


        }
        //формирование отчета в эксель
        private void btnOtschet_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;

            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            DateTime currentDate = DateTime.Now;

            ws.Columns.AutoFit();


            Range _excelCells2 = (Range)ws.get_Range("A1", "Z111").Cells;
            _excelCells2.HorizontalAlignment = Constants.xlCenter;
            Range _excelCells1 = (Range)ws.get_Range("B1", "H1").Cells;
            _excelCells1.Merge(Type.Missing);
            ws.Cells[1, 2] = $"Отчет об абитуриентах";

            ws.Range["A3"].Value = $"Код личного дела";
            ws.Range["B3"].Value = $"Фамилия";
            ws.Range["C3"].Value = $"Имя";
            ws.Range["D3"].Value = $"Отчество";
            ws.Range["E3"].Value = $"Пол";
            ws.Range["F3"].Value = $"Дата рождения";
            ws.Range["G3"].Value = $"Номер телефона";
            ws.Range["H3"].Value = $"Специальность";

            for (int i = 0; i < dtgAbityrients.Columns.Count; i++)
            {
                for (int j = 0; j < dtgAbityrients.Items.Count; j++)
                {
                    TextBlock text = dtgAbityrients.Columns[i].GetCellContent(dtgAbityrients.Items[j]) as TextBlock;
                    Range range = (Range)ws.Cells[j + 4, i + 1];
                    range.Value2 = text.Text;
                }
            }
            ws.Columns.EntireColumn.AutoFit();

        }
    }
}
