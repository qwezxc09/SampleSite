using Core.Model.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Core.ExcelReports
{
    public class AutoSystemExcelReports
    {
        public ExcelPackage CreateExcelTelemehanicaReportData(List<TelemehanicaReportData_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Системы автоматики (Параметры)");
            try
            {
                int countPos = 3;
                int count = 1;
                ws.Column(2).Width = 20;
                ws.Cells[2, 1].Value = "№ п/п";
                ws.Cells[2, 2].Value = "Наименование ЛПУ";
                ws.Cells[2, 3].Value = "Наименование КС";
                ws.Cells[2, 4].Value = "Уровень";
                ws.Cells[2, 5].Value = "Система телемеханики";
                ws.Cells[2, 6].Value = "Цех";
                ws.Cells[2, 7].Value = "Агрегат";
                ws.Cells[2, 8].Value = "Количество тегов";
                ws.Cells[2, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                ws.Cells[2, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.LpuTitle;
                    ws.Cells[countPos, 3].Value = a.KsTitle;
                    ws.Cells[countPos, 4].Value = a.LevelTitle;
                    ws.Cells[countPos, 5].Value = a.TelemehanicaTitle;
                    ws.Cells[countPos, 6].Value = a.KcTitle;
                    ws.Cells[countPos, 7].Value = a.AgrTitle;
                    ws.Cells[countPos, 8].Value = a.TagCount;
                    if (a.isItog)
                    {
                        ws.Cells[countPos, 1].Style.Font.Bold = true;
                        ws.Cells[countPos, 2].Style.Font.Bold = true;
                        ws.Cells[countPos, 3].Style.Font.Bold = true;
                        ws.Cells[countPos, 4].Style.Font.Bold = true;
                        ws.Cells[countPos, 5].Style.Font.Bold = true;
                        ws.Cells[countPos, 6].Style.Font.Bold = true;
                        ws.Cells[countPos, 7].Style.Font.Bold = true;
                        ws.Cells[countPos, 8].Style.Font.Bold = true;
                    }
                    ws.Cells[countPos, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 2, 8])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 13;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 2, 8])
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
        public ExcelPackage CreateExcelTelemehanicaGPAData(List<TelemehanicaConnectedSystem_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Подключенные системы (САУ ГПА)");
            try
            {
                int countPos = 4;
                int count = 1;
                ws.Column(2).Width = 20;
                ws.Cells[2, 1, 3, 1].Merge = true;
                ws.Cells[2, 1, 3, 1].Value = "№ п/п";
                ws.Cells[2, 1, 3, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 2, 3, 2].Merge = true;
                ws.Cells[2, 2, 3, 2].Value = "Наименование КС";
                ws.Cells[2, 2, 3, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 3, 3, 3].Merge = true;
                ws.Cells[2, 3, 3, 3].Value = "Цеха";
                ws.Cells[2, 3, 3, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 4, 3, 4].Merge = true;
                ws.Cells[2, 4, 3, 4].Value = "ГПА";
                ws.Cells[2, 4, 3, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                int countKc = 1;
                for (int i = 0; i < 30; i += 3)
                {
                    ws.Cells[2, 5 + i, 2, 7 + i].Merge = true;
                    ws.Cells[2, 5 + i, 3, 7 + i].Value = "КЦ " + countKc;
                    ws.Cells[2, 5 + i, 3, 7 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[2, 5 + i, 3, 7 + i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, 5 + i].Value = "Типы САУ";
                    ws.Cells[3, 5 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[3, 6 + i].Value = "Кол-во тегов";
                    ws.Cells[3, 6 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[3, 7 + i].Value = "Кол-во агр.";
                    ws.Cells[3, 7 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countKc++;
                }
                foreach (var a in reportList)
                {
                    int countKcList = 0;
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.KsTitle;
                    ws.Cells[countPos, 3].Value = a.KcCount;
                    ws.Cells[countPos, 4].Value = a.GpaCount;
                    ws.Cells[countPos, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    for (int i = 0; i < 30; i += 3)
                    {
                        int sauLenght = a.KcDataList[countKcList].SauTypeList.Length;
                        int tagCountLength = a.KcDataList[countKcList].TagCountList.Length;
                        for (int j = 0; j < sauLenght; j++)
                        {
                            ws.Cells[countPos, 5 + i].Value += a.KcDataList[countKcList].SauTypeList[j] + "\n";
                        }
                        ws.Cells[countPos, 5 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                        for (int j = 0; j < tagCountLength; j++)
                        {
                            ws.Cells[countPos, 6 + i].Value += a.KcDataList[countKcList].TagCountList[j] + "\n";
                        }
                        ws.Cells[countPos, 6 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                        ws.Cells[countPos, 7 + i].Value = a.KcDataList[countKcList].GpaCount;
                        ws.Cells[countPos, 7 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                        countKcList++;
                    }
                    ws.Row(countPos).Style.WrapText = true;
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 3, 34])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 13;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 3, 34])
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
        public ExcelPackage CreateExcelTelemehanicaKCData(List<TelemehanicaConnectedSystem_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Подключенные системы (САУ КЦ)");
            try
            {
                int countPos = 4;
                int count = 1;

                ws.Cells[2, 1, 3, 1].Merge = true;
                ws.Cells[2, 1, 3, 1].Value = "№ п/п";
                ws.Cells[2, 1, 3, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 2, 3, 2].Merge = true;
                ws.Cells[2, 2, 3, 2].Value = "Наименование КС";
                ws.Cells[2, 2, 3, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 3, 3, 3].Merge = true;
                ws.Cells[2, 3, 3, 3].Value = "Цеха";
                ws.Cells[2, 3, 3, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 4, 3, 4].Merge = true;
                ws.Cells[2, 4, 3, 4].Value = "ГПА";
                ws.Cells[2, 4, 3, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                int countKc = 1;
                for (int i = 0; i < 20; i += 2)
                {
                    ws.Cells[2, 5 + i, 2, 6 + i].Merge = true;
                    ws.Cells[2, 5 + i, 3, 6 + i].Value = "КЦ " + countKc;
                    ws.Cells[2, 5 + i, 3, 6 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[2, 5 + i, 3, 6 + i].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells[3, 5 + i].Value = "Типы САУ";
                    ws.Cells[3, 5 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[3, 6 + i].Value = "Кол-во тегов";
                    ws.Cells[3, 6 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countKc++;
                }
                foreach (var a in reportList)
                {
                    int countKcList = 0;
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.KsTitle;
                    ws.Cells[countPos, 3].Value = a.KcCount;
                    ws.Cells[countPos, 4].Value = a.GpaCount;
                    ws.Cells[countPos, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    for (int i = 0; i < 20; i += 2)
                    {
                        int sauLenght = a.KcDataList[countKcList].SauTypeList.Length;
                        int tagCountLength = a.KcDataList[countKcList].TagCountList.Length;
                        for (int j = 0; j < sauLenght; j++)
                        {
                            ws.Cells[countPos, 5 + i].Value += a.KcDataList[countKcList].SauTypeList[j] + "\n";
                        }
                        ws.Cells[countPos, 5 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                        for (int j = 0; j < tagCountLength; j++)
                        {
                            ws.Cells[countPos, 6 + i].Value += a.KcDataList[countKcList].TagCountList[j] + "\n";
                        }
                        ws.Cells[countPos, 6 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                        countKcList++;
                    }
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 3, 24])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 13;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 3, 24])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
            }
            catch (Exception ex)
            {
                ws.Cells[2, 1].Value = ex.Message;
            }
            return package;
        }
    }
}
