using Core.Entity.DTO;
using Core.Model.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Core.ExcelReports
{
    public class TagListExcelReport
    {
        public ExcelPackage CreateExcelTagList(List<GetTagList_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Контроль ручного ввода");
            try
            {
                int countPos = 3;
                int count = 1;
                ws.Cells[2, 1].Value = "№ п/п";
                ws.Cells[2, 2].Value = "Наименование ЛПУ";
                ws.Cells[2, 3].Value = "Описание тега";
                ws.Cells[2, 4].Value = "Наименование тега";
                ws.Cells[2, 5].Value = "Качество";
                ws.Cells[2, 6].Value = "Значение";
                ws.Cells[2, 7].Value = "Время";
                ws.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.lpuTitle;
                    ws.Cells[countPos, 3].Value = a.tagDescription;
                    ws.Cells[countPos, 4].Value = a.tagName;
                    ws.Cells[countPos, 5].Value = a.quality;
                    ws.Cells[countPos, 6].Value = a.value;
                    ws.Cells[countPos, 7].Value = a.dts;

                    ws.Cells[countPos, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 2, 7])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 13;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 2, 7])
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
        public ExcelPackage CreatePeriodExcelTagList(List<GetTagList_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Контроль ручного ввода");
            try
            {
                int countPos = 3;
                int count = 1;
                ws.Cells[2, 1].Value = "№ п/п";
                ws.Cells[2, 2].Value = "Наименование ЛПУ";
                ws.Cells[2, 3].Value = "Описание тега";
                ws.Cells[2, 4].Value = "Наименование тега";
                ws.Cells[2, 5].Value = "Время";
                ws.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.lpuTitle;
                    ws.Cells[countPos, 3].Value = a.tagDescription;
                    ws.Cells[countPos, 4].Value = a.tagName;
                    ws.Cells[countPos, 5].Value = a.dts;

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
            catch (Exception ex)
            {
                ws.Cells[2, 1].Value = ex.Message;
                throw ex;
            }
            return package;
        }
    }
}
