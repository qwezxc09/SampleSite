using Core.Model.DTO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Core.ExcelReports
{
    public class FullDataExcelReports
    {
        public ExcelPackage CreateFullDataExcelReport(List<SpGetPeriodStatisticData_DTO> reportList)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("Контроль полноты данных");
            try
            {
                int countPos = 6;
                int count = 1;

                ws.Cells[2, 1, 5, 1].Merge = true;
                ws.Cells[2, 1, 5, 1].Value = "№ п/п";
                ws.Cells[2, 1, 5, 1].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 2, 5, 2].Merge = true;
                ws.Cells[2, 2, 5, 2].Value = "Наименование ЛПУ";
                ws.Cells[2, 2, 5, 2].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 3, 2, 5].Merge = true;
                ws.Cells[2, 3, 2, 5].Value = "Общее количество";
                ws.Cells[2, 3, 2, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 3, 5, 3].Merge = true;
                ws.Cells[3, 3, 5, 3].Value = "Итого";
                ws.Cells[3, 3, 5, 3].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 4, 5, 4].Merge = true;
                ws.Cells[3, 4, 5, 4].Value = "В работе";
                ws.Cells[3, 4, 5, 4].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 5, 5, 5].Merge = true;
                ws.Cells[3, 5, 5, 5].Value = "В ремонте";
                ws.Cells[3, 5, 5, 5].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[2, 6, 2, 15].Merge = true;
                ws.Cells[2, 6, 2, 15].Value = "Полнота сбора данных (в работе)";
                ws.Cells[2, 6, 2, 15].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 6, 3, 13].Merge = true;
                ws.Cells[3, 6, 3, 13].Value = "С хорошим качеством";
                ws.Cells[3, 6, 3, 13].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[4, 6, 4, 7].Merge = true;
                ws.Cells[4, 6, 4, 7].Value = "Итого";
                ws.Cells[4, 6, 4, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[4, 8, 4, 9].Merge = true;
                ws.Cells[4, 8, 4, 9].Value = "В ручном режиме";
                ws.Cells[4, 8, 4, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[4, 10, 4, 11].Merge = true;
                ws.Cells[4, 10, 4, 11].Value = "В ручном режиме при наличии автоматики";
                ws.Cells[4, 10, 4, 11].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[4, 12, 4, 13].Merge = true;
                ws.Cells[4, 12, 4, 13].Value = "С хорошим качеством от автоматики";
                ws.Cells[4, 12, 4, 13].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                ws.Cells[3, 14, 4, 15].Merge = true;
                ws.Cells[3, 14, 4, 15].Value = "С плохим качеством";
                ws.Cells[3, 14, 4, 15].Style.Border.BorderAround(ExcelBorderStyle.Medium);


                for (int i = 0; i < 10; i += 2)
                {
                    ws.Cells[5, 6 + i].Value = "%";
                    ws.Cells[5, 7 + i].Value = "кол-во";
                    ws.Cells[5, 6 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    ws.Cells[5, 7 + i].Style.Border.BorderAround(ExcelBorderStyle.Medium);
                }
                for(int i=0;i<4;i++)
                    ws.Row(2+i).Style.WrapText = true;
                foreach (var a in reportList)
                {
                    ws.Cells[countPos, 1].Value = count;
                    ws.Cells[countPos, 2].Value = a.lpuTitle;
                    ws.Cells[countPos, 3].Value = a.tagCount;
                    ws.Cells[countPos, 4].Value = a.inWorkCount;
                    ws.Cells[countPos, 5].Value = a.repairCount;
                    ws.Cells[countPos, 6].Value = a.fullCollectDataSumPercent;
                    ws.Cells[countPos, 7].Value = a.fullCollectDataSum;
                    ws.Cells[countPos, 8].Value = a.handEnterCountPercent;
                    ws.Cells[countPos, 9].Value = a.handEnterCount;
                    ws.Cells[countPos, 10].Value = a.handEnterAutoCountPercent;
                    ws.Cells[countPos, 11].Value = a.handEnterAutoCount;
                    ws.Cells[countPos, 12].Value = a.goodQualityCountPercent;
                    ws.Cells[countPos, 13].Value = a.goodQualityCount;
                    ws.Cells[countPos, 14].Value = a.bedQualityCountPercent;
                    ws.Cells[countPos, 15].Value = a.bedQualityCount;
                    if (a.isItog)
                    {
                        ws.Cells[countPos, 1, countPos, 15].Style.Font.Bold = true;
                    }
                    ws.Cells[countPos, 1,countPos,15].Style.Border.BorderAround(ExcelBorderStyle.Medium);
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
                    countPos++;
                    count++;

                }
                using (var range = ws.Cells[2, 1, 4, 15])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    range.Style.Border.BorderAround(ExcelBorderStyle.Medium);
                    range.Style.Font.Size = 12;
                }
                using (var range = ws.Cells[2, 1, reportList.Count + 3, 15])
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
