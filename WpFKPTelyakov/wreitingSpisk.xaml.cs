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
    /// Логика взаимодействия для wreitingSpisk.xaml
    /// </summary>
    public partial class wreitingSpisk : System.Windows.Window
    {
        public wreitingSpisk()
        {
            InitializeComponent();
        }
        public void Update()
        {
            using (DataContext db = new DataContext(Properties.Settings.Default.db))
            {

                Table<Otsenki_abityr> tOts = db.GetTable<Otsenki_abityr>();
                Table<Abityrients> abit = db.GetTable<Abityrients>();

               
                dcSpecialDataContext dcSpecial = new dcSpecialDataContext();
                var spec = (from a in dcSpecial.Specialnocti
                            select a.Name_special);
                cmbVibrSpec.ItemsSource = spec;
                
                string s = Convert.ToString(cmbVibrSpec.SelectedItem);
                var query = from a in abit
                            join b in tOts on a.kod_LD equals b.Kod_LD
                            where a.Vibor_special == s
                            orderby b.Sred_ball descending
                            select new { a.kod_LD, a.Familiy, a.Name, a.Otchestvo, a.Pol, a.Data_rozdeniy, a.Phone, a.Vibor_special, b.Sred_ball };
                dtReiting.ItemsSource = query;
            }

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
            cmbVibrSpec.SelectedIndex = 0;
        }

        private void CmbVibrSpec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void BtnSozdOt_Click(object sender, RoutedEventArgs e)
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
            ws.Cells[1, 2] = $"Рейтинговый список по специальности: {cmbVibrSpec.Text}";

            ws.Range["A3"].Value = $"Код личного дела";
            ws.Range["B3"].Value = $"Фамилия";
            ws.Range["C3"].Value = $"Имя";
            ws.Range["D3"].Value = $"Отчество";
            ws.Range["E3"].Value = $"Пол";
            ws.Range["F3"].Value = $"Дата рождения";
            ws.Range["G3"].Value = $"Номер телефона";
            ws.Range["H3"].Value = $"Специальность";
            ws.Range["I3"].Value = $"Ср.балл аттестата";
            for (int i = 0; i < dtReiting.Columns.Count; i++)
            {
                for (int j = 0; j < dtReiting.Items.Count; j++)
                {
                    TextBlock text = dtReiting.Columns[i].GetCellContent(dtReiting.Items[j]) as TextBlock;
                    Range range = (Range)ws.Cells[j + 4, i + 1];
                    range.Value2 = text.Text;
                }
            }
            ws.Columns.EntireColumn.AutoFit();
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            wOthet w1 = new wOthet();
            w1.Show();
            this.Close();
        }
    }
}
