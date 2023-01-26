using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.Model.DTO;
using Core.Model.Models;
using OfficeOpenXml;

namespace Core.Services
{
    public class ParamListService
    {
        public List<GetParamList_DTO> GetParamList(string session, string lpuTitle, int errId, string dts)
        {
            var resList = new List<GetParamList_DTO>();
            try
            {
                DateTime dt = Convert.ToDateTime(dts);
                var db = new WEB_REPORTSContext();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resList;
        }
        public ExcelPackage GetExcelReport(string session, string lpuTitlem, int errId, string dts)
        {
            var package = new ExcelPackage();
            ExcelWorksheet ws = package.Workbook.Worksheets.Add("header");
            ws.Cells[1, 1].Value = "dsfsdf";
            return package;
        }
    }
}
