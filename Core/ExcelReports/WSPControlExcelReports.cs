using Core.Model.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Core.ExcelReports
{
    public class WSPControlExcelReports
    {
        public ExcelPackage CreateExcelIntervalsLPU(List<AsoduIntervalsLPU_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Контроль передачи данных с ЛПУ");
            try
            {
                int countPos = 3;
                int count = 1;
                ws.Cells[2, 1].Value = "№ п/п";
                ws.Cells[2, 2].Value = "Наименование ЛПУ";
                ws.Cells[2, 3].Value = "Начало отключения";
                ws.Cells[2, 4].Value = "Окончание отклюючения";
                ws.Cells[2, 5].Value = "Интервал отключения";
                ws.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.LpuTitle;
                    ws.Cells[countPos, 3].Value = a.StartInterval;
                    ws.Cells[countPos, 4].Value = a.EndInterval;
                    ws.Cells[countPos, 5].Value = a.LengthIntervalStr;
                    if (a.isItog)
                    {
                        ws.Cells[countPos, 1].Style.Font.Bold = true;
                        ws.Cells[countPos, 2].Style.Font.Bold = true;
                        ws.Cells[countPos, 3].Style.Font.Bold = true;
                        ws.Cells[countPos, 4].Style.Font.Bold = true;
                        ws.Cells[countPos, 5].Style.Font.Bold = true;
                    }
                    ws.Cells[countPos, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 2, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 13;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 2, 5])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
            }
            catch(Exception ex)
            {
                ws.Cells[2, 1].Value = ex.Message;
                throw ex;
            }
            return package;
        }
        public ExcelPackage CreateExcelIntervalsKC(List<AsoduIntervalKC_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Контроль передачи данных с КЦ");
            try
            {
                int countPos = 3;
                int count = 1;
                ws.Cells[2, 1].Value = "№ п/п";
                ws.Cells[2, 2].Value = "Наименование КС";
                ws.Cells[2, 3].Value = "Номер цеха";
                ws.Cells[2, 4].Value = "Начало отключения";
                ws.Cells[2, 5].Value = "Окончание отключения";
                ws.Cells[2, 6].Value = "Интервал отключения";
                ws.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.KSName;
                    ws.Cells[countPos, 3].Value = a.KCName;
                    ws.Cells[countPos, 4].Value = a.StartInterval;
                    ws.Cells[countPos, 5].Value = a.EndInterval;
                    ws.Cells[countPos, 6].Value = a.LengthIntervalStr;
                    if (a.isItog)
                    {
                        ws.Cells[countPos, 1].Style.Font.Bold = true;
                        ws.Cells[countPos, 2].Style.Font.Bold = true;
                        ws.Cells[countPos, 3].Style.Font.Bold = true;
                        ws.Cells[countPos, 4].Style.Font.Bold = true;
                        ws.Cells[countPos, 5].Style.Font.Bold = true;
                        ws.Cells[countPos, 6].Style.Font.Bold = true;
                    }
                    ws.Cells[countPos, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 2, 6])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 13;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 2, 6])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
            }
            catch(Exception ex)
            {
                ws.Cells[2, 1].Value = ex.Message;
                throw ex;
            }
            return package;
        }
        public ExcelPackage CreateExcelIntervalsManualTags(List<AsoduIntervalsManualTags_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Контроль ручного ввода");
            try
            {
                int countPos = 3;
                int count = 1;
                ws.Cells[2, 1].Value = "№ п/п";
                ws.Cells[2, 2].Value = "Наименование КС";
                ws.Cells[2, 3].Value = "Цех";
                ws.Cells[2, 4].Value = "Агрегат";
                ws.Cells[2, 5].Value = "Описание тега";
                ws.Cells[2, 6].Value = "Начало РВ";
                ws.Cells[2, 7].Value = "Окончание РВ";
                ws.Cells[2, 8].Value = "Интервал РВ";
                ws.Cells[2, 9].Value = "Значение в начале интервала РВ";
                ws.Cells[2, 10].Value = "Значение в конце интервала РВ";
                ws.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 10].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.KSName;
                    ws.Cells[countPos, 3].Value = a.KCName;
                    ws.Cells[countPos, 4].Value = a.AgrTitle;
                    ws.Cells[countPos, 5].Value = a.TagDescription;
                    ws.Cells[countPos, 6].Value = a.StartInterval;
                    ws.Cells[countPos, 7].Value = a.EndInterval;
                    ws.Cells[countPos, 8].Value = a.LengthIntervalStr;
                    ws.Cells[countPos, 9].Value = a.StartValue;
                    ws.Cells[countPos, 10].Value = a.EndValue;
                    ws.Cells[countPos, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 10].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 2, 10])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 13;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 2, 10])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
            }
            catch(Exception ex)
            {
                ws.Cells[2, 1].Value = ex.Message;
                throw ex;
            }
            return package;
        }
    }
}
