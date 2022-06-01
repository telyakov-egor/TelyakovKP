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
    /// Логика взаимодействия для wSpisSpec.xaml
    /// </summary>
    public partial class wSpisSpec : System.Windows.Window
    {
        public wSpisSpec()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new DataContext(Properties.Settings.Default.db))
            {
                Table<Specialnocti> spec = db.GetTable<Specialnocti>();                               
                var query = from a in spec
                            select new { a.Kod_specialnosti, a.Name_special, a.kolvo_zauav};
                dgSpec.ItemsSource = query;
            }
        }

        private void BtnNazad_Click(object sender, RoutedEventArgs e)
        {
            glavn g1 = new glavn();
            g1.Show();
            this.Close();
        }
        // формирование отчетв в эксель
        private void BtnOtset_Click(object sender, RoutedEventArgs e)
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
            Range _excelCells3 = (Range)ws.get_Range("B4", "B111").Cells;
            _excelCells3.HorizontalAlignment = Constants.xlLeftToRight;
            Range _excelCells1 = (Range)ws.get_Range("A1", "C1").Cells;
            _excelCells1.Merge(Type.Missing);
            ws.Cells[1, 1] = $"Количество поданных заявлений";
            ws.Range["A3"].Value = $"Код специальности";
            ws.Range["B3"].Value = $"Наименование специальности";
            ws.Range["C3"].Value = $"Кол-во заявлений";
            for (int i = 0; i < dgSpec.Columns.Count; i++)
            {
                for (int j = 0; j < dgSpec.Items.Count; j++)
                {
                    TextBlock text = dgSpec.Columns[i].GetCellContent(dgSpec.Items[j]) as TextBlock;
                    Range range = (Range)ws.Cells[j + 4, i + 1];
                    range.Value2 = text.Text;
                }
            }
            ws.Columns.EntireColumn.AutoFit();
        }
    }
}
