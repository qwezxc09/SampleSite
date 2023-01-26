using Core.Model.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Core.ExcelReports
{
    public class MasduExcelReports
    {
        public ExcelPackage CreateAsduEsgExcelReport(List<SpGetAsduEsg_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("М АСДУ ЕСГ");
            try
            {
                int countPos = 5;
                int count = 1;

                ws.Cells[2, 1, 4, 1].Merge = true;
                ws.Cells[2, 1, 4, 1].Value = "Сеанс";
                ws.Cells[2, 1, 4, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 2, 4, 2].Merge = true;
                ws.Cells[2, 2, 4, 2].Value = "Дата,время последней отправки";
                ws.Cells[2, 2, 4, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 3, 4, 3].Merge = true;
                ws.Cells[2, 3, 4, 3].Value = "Общее количество";
                ws.Cells[2, 3, 4, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 4, 3, 5].Merge = true;
                ws.Cells[2, 4, 3, 5].Value = "Передано достоверно";
                ws.Cells[2, 4, 3, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 6, 3, 7].Merge = true;
                ws.Cells[2, 6, 3, 7].Value = "Передано недостоверно";
                ws.Cells[2, 6, 3, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 8, 2, 17].Merge = true;
                ws.Cells[2, 8, 2, 17].Value = "Не передано";
                ws.Cells[2, 8, 2, 17].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 8, 3, 9].Merge = true;
                ws.Cells[3, 8, 3, 9].Value = "Всего";
                ws.Cells[3, 8, 3, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 10, 3, 11].Merge = true;
                ws.Cells[3, 10, 3, 11].Value = "Пустое";
                ws.Cells[3, 10, 3, 11].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 12, 3, 13].Merge = true;
                ws.Cells[3, 12, 3, 13].Value = "Не число";
                ws.Cells[3, 12, 3, 13].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 14, 3, 15].Merge = true;
                ws.Cells[3, 14, 3, 15].Value = "Не входит в интервал";
                ws.Cells[3, 14, 3, 15].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 16, 3, 17].Merge = true;
                ws.Cells[3, 16, 3, 17].Value = "Отсутствует привязка";
                ws.Cells[3, 16, 3, 17].Style.Border.BorderAround(ExcelBorderStyle.Medium);


                for (int i = 0; i < 14; i+=2)
                {
                    ws.Cells[4, 4 + i].Value = "%";
                    ws.Cells[4, 5 + i].Value = "кол-во";
                    ws.Cells[4, 4 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[4, 5 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                for (int i = 0; i < 3; i++)
                    ws.Row(2 + i).Style.WrapText = true;
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = a.Session;
                    ws.Cells[countPos, 2].Value = a.DTS;
                    ws.Cells[countPos, 3].Value = a.CommonCount;
                    ws.Cells[countPos, 4].Value = a.PeredDostPersent;
                    ws.Cells[countPos, 5].Value = a.PeredDost;
                    ws.Cells[countPos, 6].Value = a.PeredNeDostPercent;
                    ws.Cells[countPos, 7].Value = a.PeredNeDost;
                    ws.Cells[countPos, 8].Value = a.NePeredSummPercent;
                    ws.Cells[countPos, 9].Value = a.NePeredSumm;
                    ws.Cells[countPos, 10].Value = a.PustoePercent;
                    ws.Cells[countPos, 11].Value = a.Pustoe;
                    ws.Cells[countPos, 12].Value = a.NeChisloPercent;
                    ws.Cells[countPos, 13].Value = a.NeChislo;
                    ws.Cells[countPos, 14].Value = a.NeVhodVIntPercent;
                    ws.Cells[countPos, 15].Value = a.NeVhodVInt;
                    ws.Cells[countPos, 16].Value = a.OtsutPrivPercent;
                    ws.Cells[countPos, 17].Value = a.OtsutPriv;
                    if (a.isItog)
                    {
                        ws.Cells[countPos, 1, countPos, 17].Style.Font.Bold = true;
                    }
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
                    ws.Cells[countPos, 11].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 12].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 13].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 14].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 15].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 16].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 17].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 4, 17])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 12;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 3, 17])
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
        public ExcelPackage CreateAsduEsgLpuExcelReport(List<SpGetAsduEsgLPU_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("М АСДУ ЕСГ (ЛПУ)");
            try
            {
                int countPos = 5;
                int count = 1;
                ws.Column(15).Width = 15;
                ws.Column(18).Width = 15;
                ws.Cells[2, 1, 4, 1].Merge = true;
                ws.Cells[2, 1, 4, 1].Value = "№ п/п";
                ws.Cells[2, 1, 4, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 2, 4, 2].Merge = true;
                ws.Cells[2, 2, 4, 2].Value = "ЛПУ";
                ws.Cells[2, 2, 4, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 3, 4, 3].Merge = true;
                ws.Cells[2, 3, 4, 3].Value = "Дата,время последней отправки";
                ws.Cells[2, 3, 4, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 4, 4, 4].Merge = true;
                ws.Cells[2, 4, 4, 4].Value = "Общее количество";
                ws.Cells[2, 4, 4, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 5, 3, 6].Merge = true;
                ws.Cells[2, 5, 3, 6].Value = "Передано достоверно";
                ws.Cells[2, 5, 3, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 7, 3, 8].Merge = true;
                ws.Cells[2, 7, 3, 8].Value = "Передано недостоверно";
                ws.Cells[2, 7, 3, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 9, 2, 18].Merge = true;
                ws.Cells[2, 9, 2, 18].Value = "Не передано";
                ws.Cells[2, 9, 2, 18].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 9, 3, 10].Merge = true;
                ws.Cells[3, 9, 3, 10].Value = "Всего";
                ws.Cells[3, 9, 3, 10].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 11, 3, 12].Merge = true;
                ws.Cells[3, 11, 3, 12].Value = "Пустое";
                ws.Cells[3, 11, 3, 12].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 13, 3, 14].Merge = true;
                ws.Cells[3, 13, 3, 14].Value = "Не число";
                ws.Cells[3, 13, 3, 14].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 15, 3, 16].Merge = true;
                ws.Cells[3, 15, 3, 16].Value = "Не входит в интервал";
                ws.Cells[3, 15, 3, 16].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 17, 3, 18].Merge = true;
                ws.Cells[3, 17, 3, 18].Value = "Отсутствует привязка";
                ws.Cells[3, 17, 3, 18].Style.Border.BorderAround(ExcelBorderStyle.Medium);


                for (int i = 0; i < 14; i += 2)
                {
                    ws.Cells[4, 5 + i].Value = "%";
                    ws.Cells[4, 6 + i].Value = "кол-во";
                    ws.Cells[4, 5 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[4, 6 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                for (int i = 0; i < 3; i++)
                    ws.Row(2 + i).Style.WrapText = true;
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.LPUTitle;
                    ws.Cells[countPos, 3].Value = a.DTS;
                    ws.Cells[countPos, 4].Value = a.CommonCount;
                    ws.Cells[countPos, 5].Value = a.PeredDostPersent;
                    ws.Cells[countPos, 6].Value = a.PeredDost;
                    ws.Cells[countPos, 7].Value = a.PeredNeDostPercent;
                    ws.Cells[countPos, 8].Value = a.PeredNeDost;
                    ws.Cells[countPos, 9].Value = a.NePeredSummPercent;
                    ws.Cells[countPos, 10].Value = a.NePeredSumm;
                    ws.Cells[countPos, 11].Value = a.PustoePercent;
                    ws.Cells[countPos, 12].Value = a.Pustoe;
                    ws.Cells[countPos, 13].Value = a.NeChisloPercent;
                    ws.Cells[countPos, 14].Value = a.NeChislo;
                    ws.Cells[countPos, 15].Value = a.NeVhodVIntPercent;
                    ws.Cells[countPos, 16].Value = a.NeVhodVInt;
                    ws.Cells[countPos, 17].Value = a.OtsutPrivPercent;
                    ws.Cells[countPos, 18].Value = a.OtsutPriv;
                    if (a.isItog)
                    {
                        ws.Cells[countPos, 1, countPos, 18].Style.Font.Bold = true;
                    }
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
                    ws.Cells[countPos, 11].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 12].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 13].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 14].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 15].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 16].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 17].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[countPos, 18].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    countPos++;
                    count++;
                }
                using (var range = ws.Cells[2, 1, 4, 18])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 12;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 3, 18])
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
