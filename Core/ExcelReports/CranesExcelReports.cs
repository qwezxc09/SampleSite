using Core.Entity.Model;
using Core.Model.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
namespace Core.ExcelReports
{
    public class CranesExcelReports
    {
        public ExcelPackage CreateCranesExcelReport(List<ZAR_STATES_REPORT> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Контроль перестановки кранов");
            try
            {
                int countPos = 4;
                int count = 1;

                ws.Cells[2, 1, 3, 1].Merge = true;
                ws.Cells[2, 1, 3, 1].Value = "№ п/п";
                ws.Cells[2, 1, 3, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 2, 3, 2].Merge = true;
                ws.Cells[2, 2, 3, 2].Value = "Наименование ЛПУМГ";
                ws.Cells[2, 2, 3, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 3, 3, 3].Merge = true;
                ws.Cells[2, 3, 3, 3].Value = "Номер КП";
                ws.Cells[2, 3, 3, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 4, 2, 6].Merge = true;
                ws.Cells[2, 4, 2, 6].Value = "Трубопроводная арматура";
                ws.Cells[2, 4, 2, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 4, 3, 4].Merge = true;
                ws.Cells[3, 4, 3, 4].Value = "Номер крана в СЛТМ";
                ws.Cells[3, 4, 3, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 5, 3, 5].Merge = true;
                ws.Cells[3, 5, 3, 5].Value = "Номер крана в СЛТМ";
                ws.Cells[3, 5, 3, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 6, 3, 6].Merge = true;
                ws.Cells[3, 6, 3, 6].Value = "Имя тэга в СОДУ";
                ws.Cells[3, 6, 3, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 7, 3, 8].Merge = true;
                ws.Cells[2, 7, 3, 8].Value = "Дата перестановки";
                ws.Cells[2, 7, 3, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 9, 3, 12].Merge = true;
                ws.Cells[2, 9, 3, 12].Value = "Состояние крана после перестановки (открыт/закрыт)";
                ws.Cells[2, 9, 3, 12].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                for (int i = 0; i < 2; i++)
                    ws.Row(2 + i).Style.WrapText = true;

                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.LPU_Name;
                    ws.Cells[countPos, 3].Value = a.KP_Name;
                    ws.Cells[countPos, 4].Value = a.kodZAR_SLTM;
                    ws.Cells[countPos, 5].Value = a.kodZAR_SODU;
                    ws.Cells[countPos, 6].Value = a.TagName;
                    ws.Cells[countPos, 7, countPos, 8].Merge = true;
                    ws.Cells[countPos, 7, countPos, 8].Value = a.RearrangeDateDisplay;
                    if (a.Quality == 192)
                    {
                        ws.Cells[countPos, 9, countPos, 12].Merge = true;
                        ws.Cells[countPos, 9, countPos, 12].Value = a.State;
                        ws.Cells[countPos, 9, countPos, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[countPos, 9, countPos, 12].Style.Fill.BackgroundColor.SetColor(Color.DarkGreen);
                    }
                    else if (a.Quality == 219)
                    {
                        ws.Cells[countPos, 9, countPos, 12].Merge = true;
                        ws.Cells[countPos, 9, countPos, 12].Value = a.State;
                        ws.Cells[countPos, 9, countPos, 12].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[countPos, 9, countPos, 12].Style.Fill.BackgroundColor.SetColor(Color.YellowGreen);
                    }
                    else
                    {
                        ws.Cells[countPos, 9, countPos, 12].Merge = true;
                        ws.Cells[countPos, 9, countPos, 12].Value = a.State;
                    }
                    countPos++;
                    count++;

                }
                using (var range = ws.Cells[2, 1, 3, 12])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 12;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 3, 12])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
            }
            catch (Exception ex)
            {
                ws.Cells[2, 1].Value = ex.Message;
                throw ex;
            }
            return package;
        }
    }
}
