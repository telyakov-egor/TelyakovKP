using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace WpFKPTelyakov
{
    class Otschets
    {

        public void SpisokSpec()
        {
            wSpisSpec spisSpec = new wSpisSpec();

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;

            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            DateTime currentDate = DateTime.Now;
            ws.Columns.AutoFit();
            ws.Range["B1"].Value = "Количество поданных заявлений";
            for (int i = 0; i < spisSpec.dgSpec.Columns.Count; i++)
            {
                for (int j = 0; j < spisSpec.dgSpec.Items.Count; j++)
                {
                    System.Windows.Controls.TextBlock text = spisSpec.dgSpec.Columns[i].GetCellContent(spisSpec.dgSpec.Items[j]) as System.Windows.Controls.TextBlock;
                    Range range = (Range)ws.Cells[j + 3, i + 1];
                    range.Value2 = text.Text;
                }
            }
        }
    }
}
