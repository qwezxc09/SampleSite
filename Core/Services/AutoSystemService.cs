using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.ExcelReports;
using Core.Model.DTO;
using Core.Model.Models;
using OfficeOpenXml;

namespace Core.Services
{
    public class AutoSystemService
    {
        public List<NSI_Lpu_DTO> GetLpuList()
        {
            var resList = new List<NSI_Lpu_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                var dbList = db.LPU_nsi.ToList();
                foreach (var a in dbList)
                    resList.Add(new NSI_Lpu_DTO
                    {
                        id_lpu = a.id_lpu,
                        kod_lpu = a.kodlpu,
                        title = a.title
                    });
                resList.Insert(0, new NSI_Lpu_DTO
                {
                    id_lpu = 0,
                    kod_lpu = 0,
                    title = "Все ЛПУ"
                });
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public List<NSI_KS_DTO> GetKSList()
        {
            var resList = new List<NSI_KS_DTO>();
            try 
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                var dbList = db.KS_nsi.ToList();
                foreach (var a in dbList)
                    resList.Add(new NSI_KS_DTO
                    {
                        id_ks = a.id_ks,
                        kod_ks = Convert.ToInt32(a.kodks),
                        title = a.title
                    });
                resList.Insert(0, new NSI_KS_DTO
                {
                    id_ks = 0,
                    kod_ks = 0,
                    title = "Все КС"
                });
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public List<TelemehanicaLevels_DTO> GetLevelList()
        {
            var resList = new List<TelemehanicaLevels_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                var dbList = db.Telemehanica_levels.ToList();
                foreach (var a in dbList)
                    resList.Add(new TelemehanicaLevels_DTO
                    {
                        level_id = a.id_telemehanica_levels,
                        title = a.title
                    });
                resList.Insert(0, new TelemehanicaLevels_DTO
                {
                    level_id = 0,
                    title = "Все уровни автоматизации"
                });
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public List<TelemehanicaTypes_DTO> GetTypeList()
        {
            var resList = new List<TelemehanicaTypes_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                var dbList = db.Telemehanica_types.ToList();
                foreach (var a in dbList)
                    resList.Add(new TelemehanicaTypes_DTO
                    {
                        type_id = a.id_telemehanica_types,
                        title = a.title
                    });
                resList.Insert(0, new TelemehanicaTypes_DTO
                {
                    type_id = 0,
                    title = "Все типы систем"
                });
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public List<TelemehanicaConnectedSystem_DTO> GetTelemehanicaKcData()
        {
            var resList = new List<TelemehanicaConnectedSystem_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.hp_GetTelemehanicaConnectSystemKcData().Select(p => new TelemehanicaConnectedSystem_DTO
                {
                    KsTitle = p.ks_name,
                    KcCount = p.kcCount.HasValue ? p.kcCount.Value : 0,
                    GpaCount = p.agrCount.HasValue ? p.agrCount.Value : 0,
                    KcDataList = new List<KcSauModel>
                {
                     new KcSauModel { KodKc = 1, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_1) ?  p.sau_kc_1.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_1) ?  p.tag_kc_1.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 2, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_2) ?  p.sau_kc_2.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_2) ?  p.tag_kc_2.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 3, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_3) ?  p.sau_kc_3.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_3) ?  p.tag_kc_3.Split(',') : new string[1] { string.Empty } },

                     new KcSauModel { KodKc = 4, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_4) ?  p.sau_kc_4.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_4) ?  p.tag_kc_4.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 5, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_5) ?  p.sau_kc_5.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_5) ?  p.tag_kc_5.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 6, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_6) ?  p.sau_kc_6.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_6) ?  p.tag_kc_6.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 7, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_7) ?  p.sau_kc_7.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_7) ?  p.tag_kc_7.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 8, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_8) ?  p.sau_kc_8.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_8) ?  p.tag_kc_8.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 19, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_9) ?  p.sau_kc_9.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_9) ?  p.tag_kc_9.Split(',') : new string[1] { string.Empty }},

                     new KcSauModel { KodKc = 10, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_10) ?  p.sau_kc_10.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_10) ?  p.tag_kc_10.Split(',') : new string[1] { string.Empty }}
                }
                }).ToList();
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new TelemehanicaConnectedSystem_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportKcData()
        {
            var excelService = new AutoSystemExcelReports();
            return excelService.CreateExcelTelemehanicaKCData(GetTelemehanicaKcData());
        }

        public List<TelemehanicaConnectedSystem_DTO> GetTelemehanicaGpaData()
        {
            var resList = new List<TelemehanicaConnectedSystem_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.hp_GetTelemehanicaConnectSystemGpaData().Select(p => new TelemehanicaConnectedSystem_DTO
                {
                    KsTitle = p.ks_name,
                    KcCount = p.kcCount.HasValue ? p.kcCount.Value : 0,
                    GpaCount = p.agrCount.HasValue ? p.agrCount.Value : 0,
                    KcDataList = new List<KcSauModel>
                {
                     new KcSauModel { KodKc = 1, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_1) ?  p.sau_kc_1.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_1) ?  p.tag_kc_1.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc1},

                     new KcSauModel { KodKc = 2, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_2) ?  p.sau_kc_2.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_2) ?  p.tag_kc_2.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc2},

                     new KcSauModel { KodKc = 3, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_3) ?  p.sau_kc_3.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_3) ?  p.tag_kc_3.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc3},

                     new KcSauModel { KodKc = 4, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_4) ?  p.sau_kc_4.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_4) ?  p.tag_kc_4.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc4},

                     new KcSauModel { KodKc = 5, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_5) ?  p.sau_kc_5.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_5) ?  p.tag_kc_5.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc5},

                     new KcSauModel { KodKc = 6, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_6) ?  p.sau_kc_6.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_6) ?  p.tag_kc_6.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc6},

                     new KcSauModel { KodKc = 7, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_7) ?  p.sau_kc_7.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_7) ?  p.tag_kc_7.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc7},

                     new KcSauModel { KodKc = 8, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_8) ?  p.sau_kc_8.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_8) ?  p.tag_kc_8.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc8},

                     new KcSauModel { KodKc = 19, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_9) ?  p.sau_kc_9.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_9) ?  p.tag_kc_9.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc9},

                     new KcSauModel { KodKc = 10, SauTypeList = !string.IsNullOrEmpty(p.sau_kc_10) ?  p.sau_kc_10.Split(',') : new string[1] { string.Empty },
                     TagCountList = !string.IsNullOrEmpty(p.tag_kc_10) ?  p.tag_kc_10.Split(',') : new string[1] { string.Empty }, GpaCount = p.agrcount_kc10}
                }
                }).ToList();
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new TelemehanicaConnectedSystem_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportGpaData()
        {
            var excelService = new AutoSystemExcelReports();
            return excelService.CreateExcelTelemehanicaGPAData(GetTelemehanicaGpaData());
        }

        public DisplayTelemehanicaValue GetTelemehanicaReportData(int kodlpu, int kodks, int kodlevel, int kodtype)
        {
            var resList = new List<TelemehanicaReportData_DTO>();
            var frozenList = new List<TelemehanicaReportData_DTO>();
            var displayValue = new DisplayTelemehanicaValue();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                SqlParameter Param1 = new SqlParameter("@lpu_id", kodlpu);
                SqlParameter Param2 = new SqlParameter("@ks_id", kodks);
                SqlParameter Param3 = new SqlParameter("@level_id", kodlevel);
                SqlParameter Param4 = new SqlParameter("@telemehanicatype_id", kodtype);
                string sqlQuery = "hp_GetTelemehanicaReportData @lpu_id, @ks_id, @level_id, @telemehanicatype_id";

                var dbList = db.Database.SqlQuery<SpGetTelemehanicaReportData>(sqlQuery, Param1, Param2, Param3, Param4);


                resList = dbList.Select(p => new TelemehanicaReportData_DTO
                {
                    LpuTitle = string.Format("{0} ЛПУ МГ", p.lpu_title),
                    KsTitle = string.Format("КС {0}", p.ks_title),
                    LevelTitle = p.level_title,
                    TelemehanicaTitle = p.telemehanica_title,
                    TagCount = p.tagCount,
                    KcTitle = p.kc_title,
                    AgrTitle = p.agr_title
                }).ToList();

                if (resList.Any())
                {
                    TelemehanicaReportData_DTO itog = new TelemehanicaReportData_DTO
                    {
                        LpuTitle = "Итого:",
                        TagCount = resList.Sum(x => x.TagCount),
                        isItog = true
                    };
                    frozenList.Add(itog);
                }
                displayValue.tableValue = resList;
                displayValue.frozenRaws = frozenList;
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new TelemehanicaReportData_DTO
                {
                    errorMessage = ex.Message,
                    isError = true
                });
            }
            return displayValue;
        }
        public ExcelPackage GetExcelReport(int kodlpu, int kodks, int kodlevel, int kodtype)
        {
            var excelService = new AutoSystemExcelReports();
            var list = GetTelemehanicaReportData(kodlpu, kodks, kodlevel, kodtype).tableValue;
            var list2 = GetTelemehanicaReportData(kodlpu, kodks, kodlevel, kodtype).frozenRaws;
            list.Add(list2[0]);
            return excelService.CreateExcelTelemehanicaReportData(list);
        }
    }
}
