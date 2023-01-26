using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.ExcelReports;
using Core.Model.Models;
using OfficeOpenXml;
using Core.Model.DTO;
using Core.Entity.DTO;
using System.Configuration;

namespace Core.Services
{
    public class WSPControlService
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
        public List<NSI_KC_DTO> GetKCList(int kodKs)
        {
            var resList = new List<NSI_KC_DTO>();
            try
            {
                if (kodKs != 0)
                {
                    var db = new WEB_REPORTSContext();
                    db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                    var dbList = db.KC_nsi.Where(p => p.kodKs == kodKs && p.id_deleted_nsi_obj == null).ToList();
                    foreach (var a in dbList)
                        resList.Add(new NSI_KC_DTO
                        {
                            id_kc = a.id_kc,
                            kod_kc = Convert.ToInt32(a.kodKc),
                            title = "Цех №" + a.kodKc
                        });
                    resList.Insert(0, new NSI_KC_DTO
                    {
                        id_kc = 0,
                        kod_kc = 0,
                        title = "Все Цеха"
                    });
                }
                else if (kodKs == 0)
                    resList.Insert(0, new NSI_KC_DTO
                    {
                        id_kc = 0,
                        kod_kc = 0,
                        title = "Все Цеха"
                    });
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public List<NSI_Intervals_DTO> GetIntervalList()
        {
            var resList = new List<NSI_Intervals_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.Interval_nsi.Where(p => p.id_deleted_nsi_obj == null).Select(p => new NSI_Intervals_DTO
                {
                    title = p.title,
                    interval_id = p.id_interval
                }).ToList();
                resList.Insert(0, new NSI_Intervals_DTO
                {
                    title = "Все интервалы",
                    interval_id = 0,
                });
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return resList;
        }


        public List<AsoduIntervalsLPU_DTO> GetIntervalsLPU(int kodLpu, string startDate, string endDate, int minLen, int maxLen)
        {
            var resList = new List<AsoduIntervalsLPU_DTO>();
            try
            {
                DateTime dtStart = Convert.ToDateTime(startDate);
                DateTime dtEnd = Convert.ToDateTime(endDate);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.get_Asodu_intervalsLPU(dtStart, dtEnd, Convert.ToInt16(kodLpu), minLen, maxLen)
                    .Select(p => new AsoduIntervalsLPU_DTO
                    {
                        LpuTitle = string.Format("{0} ЛПУ МГ", p.Title),
                        StartDt = p.dt1,
                        EndDt = p.dt2,
                        LengthInterval = p.LenSec,
                        kodLPU = Convert.ToInt32(p.kodLPU),
                        TagValue1 = Convert.ToDecimal(p.TagValue1),
                        TagValue2 = Convert.ToDecimal(p.TagValue2),
                        grpId = Convert.ToInt64(p.grpId)
                    }).ToList();
                if (resList.Count != 0)
                    resList.Add(new AsoduIntervalsLPU_DTO
                    {
                        LpuTitle = "Итого: " + resList.Count.ToString(),
                        isItog = true
                    });
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new AsoduIntervalsLPU_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportLPU(int kodLpu, string startDate, string endDate, int minLen, int maxLen)
        {
            var excelService = new WSPControlExcelReports();
            return excelService.CreateExcelIntervalsLPU(GetIntervalsLPU(kodLpu, startDate, endDate, minLen, maxLen));
        }
        public List<AsoduIntervalKC_DTO> GetIntervalsKC(int kodKC, int kodKS, string startDate, string endDate, int minLen, int maxLen)
        {
            var resList = new List<AsoduIntervalKC_DTO>();
            try
            {
                DateTime dtStart = Convert.ToDateTime(startDate);
                DateTime dtEnd = Convert.ToDateTime(endDate);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.get_Asodu_intervalsKC(dtStart, dtEnd, Convert.ToInt16(kodKS), Convert.ToInt16(kodKC), minLen, maxLen).Select(p => new AsoduIntervalKC_DTO
                {
                    LengthInterval = p.LenSec,
                    StartDt = p.dt1,
                    EndDt = p.dt2,
                    KSName = p.KSName,
                    kodKC = Convert.ToInt32(p.kodKC),
                    kodKS = Convert.ToInt32(p.kodKS),
                    KCName = (p.kodKC != 0) ? string.Format("Цех №{0}", p.kodKC) : "Цех №0"
                }).ToList();
                if (resList.Count != 0)
                    resList.Add(new AsoduIntervalKC_DTO
                    {
                        KSName = "Итого: ",
                        isItog = true
                    });
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new AsoduIntervalKC_DTO
                {
                    errorMessage = ex.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportKC(int kodKC, int kodKS, string startDate, string endDate, int minLen, int maxLen)
        {
            var excelService = new WSPControlExcelReports();
            return excelService.CreateExcelIntervalsKC(GetIntervalsKC(kodKC, kodKS, startDate, endDate, minLen, maxLen));
        }
        public List<AsoduIntervalsManualTags_DTO> GetIntervalsManualTags(int kodKC, int kodKS, string startDate, string endDate, int objType, int minLen, int maxLen)
        {
            var resList = new List<AsoduIntervalsManualTags_DTO>();
            try
            {
                string tagtype = "";
                switch (objType)
                {
                    case 1:
                        tagtype = "avo";
                        break;
                    case 2:
                        tagtype = "pu";
                        break;
                    case 3:
                        tagtype = "fs";
                        break;
                    case 4:
                        tagtype = "valve";
                        break;
                    case 5:
                        tagtype = "valveagr";
                        break;
                    case 6:
                        tagtype = "valvekc";
                        break;
                    case 7:
                        tagtype = "valvegis";
                        break;
                    case 8:
                        tagtype = "kc";
                        break;
                    case 9:
                        tagtype = "gpastate";
                        break;
                }
                DateTime dtStart = Convert.ToDateTime(startDate);
                DateTime dtEnd = Convert.ToDateTime(endDate);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.get_Asodu_intervalsManualTags(dtStart, dtEnd, Convert.ToInt16(kodKS), Convert.ToInt16(kodKC), tagtype, minLen, maxLen).Select(p => new AsoduIntervalsManualTags_DTO
                {
                    StartDt = p.dt1,
                    EndDt = p.dt2,
                    StartValue = p.TagValue1,
                    EndValue = p.TagValue2,
                    kodKC = Convert.ToInt16(p.kodKC),
                    kodKS = Convert.ToInt16(p.kodKS),
                    LengthInterval = p.LenSec,
                    grpId = Convert.ToInt64(p.grpId),
                    TagName = p.TagName,
                    KSName = p.KSName,
                    TagDescription = p.TagDescription,
                    TagType = p.TagType,
                    Period = (p.dt1.HasValue && p.dt2.HasValue) ? p.dt2.Value - p.dt1.Value : new TimeSpan(0),
                }).ToList();
                for (int i = resList.Count - 1; i > -1; i--)
                {
                    if (resList[i].EndValue == 0)
                    {
                        AsoduIntervalsManualTags_DTO key = resList[i];
                        AsoduIntervalsManualTags_DTO next = FindInterval(i, resList, key);
                        if (next != null)
                        {
                            key.EndDt = next.EndDt;
                            key.Period += next.Period;
                            if (next.EndValue >= 216)
                                key.EndValue = next.EndValue;
                            resList.Remove(next);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new AsoduIntervalsManualTags_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportManualTags(int kodKC, int kodKS, string startDate, string endDate, int objType, int minLen, int maxLen)
        {
            var excelService = new WSPControlExcelReports();
            return excelService.CreateExcelIntervalsManualTags(GetIntervalsManualTags(kodKC, kodKS, startDate, endDate, objType, minLen, maxLen));
        }
        private AsoduIntervalsManualTags_DTO FindInterval(int i, List<AsoduIntervalsManualTags_DTO> lv, AsoduIntervalsManualTags_DTO key)
        {
            var res = new AsoduIntervalsManualTags_DTO();
            try
            {
                res = lv.Where(x => x.StartDt > key.EndDt && x.TagName == key.TagName).OrderBy(x => x.EndDt).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return res;
        }
        public List<ObjTypeList_DTO> GetObjTypeList()
        {
            var resList = new List<ObjTypeList_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.hp_GetObjTypeList().Select(p=> new ObjTypeList_DTO { 
                    idTagType = p.idTagType,
                    Description = p.Description
                }).ToList();
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
    }
}
