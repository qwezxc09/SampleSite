using Core.Entity;
using Core.ExcelReports;
using Core.Model.DTO;
using Core.Model.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class FullDataControlService
    {
        public List<NSI_Lpu_DTO> GetLpuList()
        {
            var resList = new List<NSI_Lpu_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                var dbList = db.LPU_nsi.Where(p=>p.id_deleted_nsi_obj != 1).ToList();
                foreach (var a in dbList)
                    resList.Add(new NSI_Lpu_DTO
                    {
                        id_lpu = a.id_lpu,
                        kod_lpu = a.kodlpu,
                        title = a.title
                    });
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public DisplayPeriodsValue GetDataValuePeriod(List<NSI_Lpu_DTO> Lpu, string startDate, string endDate)
        {
            var resList = new List<SpGetPeriodStatisticData_DTO>();
            var frozenList = new List<SpGetPeriodStatisticData_DTO>();
            var displayResult = new DisplayPeriodsValue();
            if (Lpu == null)
                return displayResult;
            try
            {
                var kodList = Lpu.Select(p => p.kod_lpu).ToList();
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                DateTime dtStart = Convert.ToDateTime(startDate);
                DateTime dtEnd = Convert.ToDateTime(endDate);
                resList = db.hp_GetPeriodStatisticData(dtStart.ToString("yyyy-MM-dd"), dtEnd.ToString("yyyy-MM-dd")).Where(p => { return kodList.Contains(Convert.ToInt32(p.kodlpu)) && (p.id_deleted_nsi_obj == null); }).Select(p => new SpGetPeriodStatisticData_DTO
                {
                    lpuTitle = p.lpuTitle,
                    kodlpu = Convert.ToInt32(p.kodlpu),
                    id_deleted_nsi_obj = p.id_deleted_nsi_obj,
                    tagCount = Convert.ToInt32(p.tagCount),
                    inWorkCount = Convert.ToInt32(p.tagCount - p.repairCount),
                    handEnterCount = Convert.ToInt32(p.handEnterCount),
                    handEnterCountPercent = Math.Round((Convert.ToDouble(p.handEnterCount) * 100 / Convert.ToDouble(p.tagCount - p.repairCount)), 2),
                    handEnterAutoCount = Convert.ToInt32(p.handEnterAutoCount),
                    handEnterAutoCountPercent = Math.Round(Convert.ToDouble(p.handEnterAutoCount * 100 / Convert.ToDouble(p.tagCount - p.repairCount)), 2),
                    goodQualityCount = Convert.ToInt32(p.goodQualityCount),
                    goodQualityCountPercent = Math.Round(Convert.ToDouble(p.goodQualityCount * 100 / Convert.ToDouble(p.tagCount - p.repairCount)), 2),
                    repairCount = Convert.ToInt32(p.repairCount),
                    repairCountPercent = Math.Round(Convert.ToDouble(p.repairCount * 100 / Convert.ToDouble(p.tagCount - p.repairCount)), 2),
                    bedQualityCount = Convert.ToInt32(p.bedQualityCount),
                    bedQualityCountPercent = Math.Round(Convert.ToDouble(p.bedQualityCount * 100 / Convert.ToDouble(p.tagCount - p.repairCount)), 2),
                    fullCollectDataSumPercent = Math.Round(Convert.ToDouble((p.handEnterCount + p.handEnterAutoCount + p.goodQualityCount) * 100 / Convert.ToDouble(p.tagCount - p.repairCount)), 2),
                    isLive = false,
                    tagCountAllinPds = Convert.ToInt32(p.tagCountAllInPDS)
                }).ToList();
                if (resList.Count != 0)
                    frozenList.Add(new SpGetPeriodStatisticData_DTO
                    {
                        lpuTitle = "Итого по всем ЛПУ",
                        tagCount = resList.Sum(p => p.tagCount),
                        inWorkCount = resList.Sum(p => p.inWorkCount),
                        handEnterCount = resList.Sum(p => p.handEnterCount),
                        handEnterCountPercent = Math.Round(resList.Sum(p => p.handEnterCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)), 2),
                        handEnterAutoCount = resList.Sum(p => p.handEnterAutoCount),
                        handEnterAutoCountPercent = Math.Round(resList.Sum(p => p.handEnterAutoCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)), 2),
                        goodQualityCount = resList.Sum(p => p.goodQualityCount),
                        goodQualityCountPercent = Math.Round(resList.Sum(p => p.goodQualityCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)), 2),
                        repairCount = resList.Sum(p => p.repairCount),
                        repairCountPercent = Math.Round(resList.Sum(p => p.repairCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)), 2),
                        bedQualityCount = resList.Sum(p => p.bedQualityCount),
                        bedQualityCountPercent = Math.Round(resList.Sum(p => p.bedQualityCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)), 2),
                        fullCollectDataSumPercent = Math.Round(resList.Sum(p => p.fullCollectDataSum) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)), 2),
                        isItog = true,
                        tagCountAllinPds = resList.Sum(p => p.tagCountAllinPds)
                    });
                displayResult.tableValue = resList;
                displayResult.frozenRaws = frozenList;

            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new SpGetPeriodStatisticData_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return displayResult;
        }
        public ExcelPackage GetExcelReportPeriod(List<NSI_Lpu_DTO> Lpu, string startDate, string endDate)
        {
            var excelService = new FullDataExcelReports();
            var list = GetDataValuePeriod(Lpu, startDate, endDate).tableValue;
            var list2 = GetDataValuePeriod(Lpu, startDate, endDate).frozenRaws;
            list.Add(list2[0]);
            return excelService.CreateFullDataExcelReport(list);
        }
        public DisplayPeriodsValue GetDataValueDay(List<NSI_Lpu_DTO> Lpu, string date)
        {
            var resList = new List<SpGetPeriodStatisticData_DTO>();
            var frozenList = new List<SpGetPeriodStatisticData_DTO>();
            var displayResult = new DisplayPeriodsValue();
            if (Lpu == null)
                return displayResult;
            try
            {
                var kodList = Lpu.Select(p => p.kod_lpu).ToList();
                DateTime dt = Convert.ToDateTime(date);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                var lpuList = db.LPU_nsi.Where(p => kodList.Contains(p.kodlpu) && (p.id_deleted_nsi_obj == null)).ToList();
                var dbList = db.AsoduStatisticNew.Where(p => (p.createDt == dt) && kodList.Contains(p.kodLpu)).ToList();
                resList = dbList.Join(lpuList, p => p.kodLpu, t => t.kodlpu, (p, t) => new SpGetPeriodStatisticData_DTO
                {
                    lpuTitle = t.title,
                    kodlpu = p.kodLpu,
                    tagCount = p.tagCount,
                    inWorkCount = p.tagCount-p.repairCount,
                    handEnterCount = p.handEnterCount,
                    handEnterCountPercent = Math.Round(p.handEnterCount * 100 / Convert.ToDouble(p.tagCount-p.repairCount),2),
                    handEnterAutoCount = p.handEnterAutoCount,
                    handEnterAutoCountPercent = Math.Round(p.handEnterAutoCount * 100 / Convert.ToDouble(p.tagCount - p.repairCount),2),
                    goodQualityCount = p.goodQualityCount,
                    goodQualityCountPercent = Math.Round(p.goodQualityCount * 100 / Convert.ToDouble(p.tagCount - p.repairCount),2),
                    repairCount = p.repairCount,
                    repairCountPercent = Math.Round(p.repairCount * 100 / Convert.ToDouble(p.tagCount - p.repairCount),2),
                    bedQualityCount = Convert.ToInt32(p.bedQualityCount),
                    bedQualityCountPercent = Math.Round(Convert.ToInt32(p.bedQualityCount) * 100 / Convert.ToDouble(p.tagCount - p.repairCount),2),
                    fullCollectDataSumPercent = Math.Round(Convert.ToDouble((p.handEnterCount + p.handEnterAutoCount + p.goodQualityCount) * 100 / Convert.ToDouble(p.tagCount - p.repairCount)), 2),
                    isLive = false,
                    tagCountAllinPds = Convert.ToInt32(p.tagCountAllInPDS)
                }).ToList();
                if (resList.Count != 0)
                    frozenList.Add(new SpGetPeriodStatisticData_DTO
                    {
                        lpuTitle = "Итого по всем ЛПУ",
                        tagCount = resList.Sum(p => p.tagCount),
                        inWorkCount = resList.Sum(p=>p.inWorkCount),
                        handEnterCount = resList.Sum(p => p.handEnterCount),
                        handEnterCountPercent = Math.Round(resList.Sum(p => p.handEnterCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        handEnterAutoCount = resList.Sum(p => p.handEnterAutoCount),
                        handEnterAutoCountPercent = Math.Round(resList.Sum(p => p.handEnterAutoCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        goodQualityCount = resList.Sum(p => p.goodQualityCount),
                        goodQualityCountPercent = Math.Round(resList.Sum(p => p.goodQualityCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        repairCount = resList.Sum(p => p.repairCount),
                        repairCountPercent = Math.Round(resList.Sum(p => p.repairCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        bedQualityCount = resList.Sum(p => p.bedQualityCount),
                        bedQualityCountPercent = Math.Round(resList.Sum(p => p.bedQualityCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        fullCollectDataSumPercent = Math.Round(resList.Sum(p => p.fullCollectDataSum) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        isItog = true,
                        tagCountAllinPds = resList.Sum(p => p.tagCountAllinPds)
                    });
                displayResult.tableValue = resList;
                displayResult.frozenRaws = frozenList;
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new SpGetPeriodStatisticData_DTO
                {
                    errorMessage = ex.Message,
                    isError = true
                });
            }
            return displayResult;
        }
        public ExcelPackage GetExcelReportDay(List<NSI_Lpu_DTO> Lpu, string date)
        {
            var excelService = new FullDataExcelReports();
            var list = GetDataValueDay(Lpu, date).tableValue;
            var list2 = GetDataValueDay(Lpu, date).frozenRaws;
            list.Add(list2[0]);
            return excelService.CreateFullDataExcelReport(list);
        }
        public DisplayPeriodsValue GetDataValueLive(List<NSI_Lpu_DTO> Lpu)
        {
            var resList = new List<SpGetPeriodStatisticData_DTO>();
            var frozenList = new List<SpGetPeriodStatisticData_DTO>();
            var displayResult = new DisplayPeriodsValue();
            if (Lpu == null)
                return displayResult;
            try
            {
                var kodStr = "";
                var kodList = Lpu.Select(p => p.kod_lpu).ToList();
                foreach (var a in kodList)
                    kodStr += a.ToString() + ";";
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                SqlParameter Param1 = new SqlParameter("@objectString", kodStr);
                string sqlQuery = "hp_GetLiveStatisticData_RepairNew @objectString";
                var dbList = db.Database.SqlQuery<SpGetLiveStatisticData>(sqlQuery,Param1);

                resList = dbList.Where(a => kodList.Contains(Convert.ToInt32(a.kodlpu)) && (a.id_deleted_nsi_obj == null)).Select(a => new SpGetPeriodStatisticData_DTO
                {
                    lpuTitle = a.lpuTitle,
                    kodlpu = Convert.ToInt32(a.kodlpu),
                    tagCount = Convert.ToInt32(a.tagCount),
                    inWorkCount = Convert.ToInt32(a.tagCount - a.repair),
                    handEnterCount = Convert.ToInt32(a.handenter),
                    handEnterCountPercent = Math.Round(Convert.ToDouble(a.handenter * 100 / Convert.ToDouble(a.tagCount - a.repair)), 2),
                    handEnterAutoCount = Convert.ToInt32(a.handenter_auto),
                    handEnterAutoCountPercent = Math.Round(Convert.ToDouble(a.handenter_auto * 100 / Convert.ToDouble(a.tagCount - a.repair)), 2),
                    goodQualityCount = Convert.ToInt32(a.goodQualityCount),
                    goodQualityCountPercent = Math.Round(Convert.ToDouble(a.goodQualityCount * 100 / Convert.ToDouble(a.tagCount - a.repair)), 2),
                    repairCount = Convert.ToInt32(a.repair),
                    repairCountPercent = Math.Round(Convert.ToDouble(a.repair * 100 / Convert.ToDouble(a.tagCount - a.repair)), 2),
                    bedQualityCount = Convert.ToInt32(a.bedQuality),
                    bedQualityCountPercent = Math.Round(Convert.ToDouble(Convert.ToInt32(a.bedQuality) * 100 / Convert.ToDouble(a.tagCount - a.repair)), 2),
                    fullCollectDataSumPercent = Math.Round(Convert.ToDouble((a.handenter + a.handenter_auto + a.goodQualityCount) * 100 / Convert.ToDouble(a.tagCount - a.repair)), 2),
                    isLive = true,
                    tagCountAllinPds = Convert.ToInt32(a.tagCountAllInPDS)
                }).ToList();
                if (resList.Count != 0)
                    frozenList.Add(new SpGetPeriodStatisticData_DTO
                    {
                        lpuTitle = "Итого по всем ЛПУ",
                        tagCount = resList.Sum(p => p.tagCount),
                        inWorkCount = resList.Sum(p=>p.inWorkCount),
                        handEnterCount = resList.Sum(p => p.handEnterCount),
                        handEnterCountPercent = Math.Round(resList.Sum(p => p.handEnterCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        handEnterAutoCount = resList.Sum(p => p.handEnterAutoCount),
                        handEnterAutoCountPercent = Math.Round(resList.Sum(p => p.handEnterAutoCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        goodQualityCount = resList.Sum(p => p.goodQualityCount),
                        goodQualityCountPercent = Math.Round(resList.Sum(p => p.goodQualityCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        repairCount = resList.Sum(p => p.repairCount),
                        repairCountPercent = Math.Round(resList.Sum(p => p.repairCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        bedQualityCount = resList.Sum(p => p.bedQualityCount),
                        bedQualityCountPercent = Math.Round(resList.Sum(p => p.bedQualityCount) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        fullCollectDataSumPercent = Math.Round(resList.Sum(p => p.fullCollectDataSum) * 100 / Convert.ToDouble(resList.Sum(p => p.inWorkCount)),2),
                        isItog = true,
                        tagCountAllinPds = resList.Sum(p => p.tagCountAllinPds)
                    });
                displayResult.tableValue = resList;
                displayResult.frozenRaws = frozenList;
            }
            catch (Exception ex)
            {
                resList.Clear();
                resList.Add(new SpGetPeriodStatisticData_DTO
                {
                    errorMessage = ex.Message,
                    isError = true
                });
            }
            return displayResult;
        }
        public ExcelPackage GetExcelReportLive(List<NSI_Lpu_DTO> Lpu)
        {
            var excelService = new FullDataExcelReports();
            var list = GetDataValueLive(Lpu).tableValue;
            var list2 = GetDataValueLive(Lpu).frozenRaws;
            list.Add(list2[0]);
            return excelService.CreateFullDataExcelReport(list);
        }
    }
}
