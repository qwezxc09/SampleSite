using Core.Entity;
using Core.ExcelReports;
using Core.Model.DTO;
using Core.Model.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class MasduService
    {
        public List<SessionList_DTO> GetSessionList()
        {
            var resList = new List<SessionList_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.v_SessionList.Select(p => new SessionList_DTO
                {
                    session_id = p.ID,
                    cod = p.NAME,
                    description = p.DESCRIPTION
                }).ToList();
                resList.Insert(0, new SessionList_DTO
                {
                    session_id = 0,
                    cod = "all",
                    description = "Все сеансы"
                });
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public List<SpGetAsduEsg_DTO> GetMasduEsgList(string session, string date)
        {
            var resList = new List<SpGetAsduEsg_DTO>();
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.hp_GetAsduEsg1(session, dt).OrderBy(p => p.DTS).Select(p => new SpGetAsduEsg_DTO
                {
                    Session = p.Session,
                    DTS = Convert.ToDateTime(p.DTS).ToString("dd.MM.yyyy HH:mm:ss"),
                    CommonCount = Convert.ToInt32(p.CommonCount),
                    PeredDost = Convert.ToInt32(p.PeredDost),
                    PeredDostPersent = Math.Round(Convert.ToInt32(p.PeredDost) * 100 / Convert.ToDouble(p.CommonCount),2),
                    PeredNeDost = Convert.ToInt32(p.PeredNeDost),
                    PeredNeDostPercent = Math.Round(Convert.ToDouble(p.PeredNeDost * 100 / p.CommonCount), 2),
                    Pustoe = Convert.ToInt32(p.Pustoe),
                    PustoePercent = Math.Round(Convert.ToDouble(p.Pustoe * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeChislo = Convert.ToInt32(p.NeChislo),
                    NeChisloPercent = Math.Round(Convert.ToDouble(p.NeChislo * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeVhodVInt = Convert.ToInt32(p.NeVhodVInt),
                    NeVhodVIntPercent = Math.Round(Convert.ToDouble(p.NeVhodVInt * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    OtsutPriv = Convert.ToInt32(p.OtsutPriv),
                    OtsutPrivPercent = Math.Round(Convert.ToDouble(p.OtsutPriv * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NePeredSummPercent = Math.Round(Convert.ToDouble((p.Pustoe + p.NeChislo + p.NeVhodVInt + p.OtsutPriv) * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    MsgType = p.MsgType
                }).ToList();
                if (resList.Count != 0)
                    resList.Add(new SpGetAsduEsg_DTO
                    {
                        Session = "Итого",
                        DTS = date,
                        CommonCount = resList.Sum(p => p.CommonCount),
                        PeredDost = resList.Sum(p => p.PeredDost),
                        PeredDostPersent = Math.Round(Convert.ToDouble(resList.Sum(p => p.PeredDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))),2),
                        PeredNeDost = resList.Sum(p => p.PeredNeDost),
                        PeredNeDostPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.PeredNeDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        Pustoe = resList.Sum(p => p.Pustoe),
                        PustoePercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.Pustoe * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeChislo = resList.Sum(p => p.NeChislo),
                        NeChisloPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeChislo * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeVhodVInt = resList.Sum(p => p.NeVhodVInt),
                        NeVhodVIntPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeVhodVInt) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        OtsutPriv = resList.Sum(p => p.OtsutPriv),
                        OtsutPrivPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.OtsutPriv * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NePeredSummPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NePeredSumm) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        isItog = true
                    });
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new SpGetAsduEsg_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }

        public ExcelPackage GetExcelReport(string session, string date)
        {
            var excelService = new MasduExcelReports();
            return excelService.CreateAsduEsgExcelReport(GetMasduEsgList(session, date));
        }
        public List<SpGetAsduEsgLPU_DTO> GetMasduEsgLpuList(string session, string date)
        {
            var resList = new List<SpGetAsduEsgLPU_DTO>();
            try
            {
                DateTime dt = Convert.ToDateTime(date);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.hp_GetAsduEsgLPU(session, dt).OrderBy(p => p.DTS).Select(p => new SpGetAsduEsgLPU_DTO
                {
                    LPUTitle = p.LPUTitle,
                    Session = p.Session,
                    DTS = Convert.ToDateTime(p.DTS).ToString("dd.MM.yyyy HH:mm:ss"),
                    CommonCount = Convert.ToInt32(p.CommonCount),
                    PeredDost = Convert.ToInt32(p.PeredDost),
                    PeredDostPersent = Math.Round(Convert.ToDouble(p.PeredDost * 100 / Convert.ToDouble(p.CommonCount)),2),
                    PeredNeDost = Convert.ToInt32(p.PeredNeDost),
                    PeredNeDostPercent = Math.Round(Convert.ToDouble(p.PeredNeDost * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    Pustoe = Convert.ToInt32(p.Pustoe),
                    PustoePercent = Math.Round(Convert.ToDouble(p.Pustoe * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeChislo = Convert.ToInt32(p.NeChislo),
                    NeChisloPercent = Math.Round(Convert.ToDouble(p.NeChislo * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeVhodVInt = Convert.ToInt32(p.NeVhodVInt),
                    NeVhodVIntPercent = Math.Round(Convert.ToDouble(p.NeVhodVInt * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    OtsutPriv = Convert.ToInt32(p.OtsutPriv),
                    OtsutPrivPercent = Math.Round(Convert.ToDouble(p.OtsutPriv * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NePeredSummPercent = Math.Round(Convert.ToDouble((p.Pustoe + p.NeChislo + p.NeVhodVInt + p.OtsutPriv) * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    MsgType = p.MsgType
                }).ToList();
                if (resList.Count != 0)
                    resList.Add(new SpGetAsduEsgLPU_DTO
                    {
                        LPUTitle = "Итого",
                        DTS = date,
                        CommonCount = resList.Sum(p => p.CommonCount),
                        PeredDost = resList.Sum(p => p.PeredDost),
                        PeredDostPersent = Math.Round(resList.Sum(p => p.PeredDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount)), 2),
                        PeredNeDost = resList.Sum(p => p.PeredNeDost),
                        PeredNeDostPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.PeredNeDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        Pustoe = resList.Sum(p => p.Pustoe),
                        PustoePercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.Pustoe * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeChislo = resList.Sum(p => p.NeChislo),
                        NeChisloPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeChislo * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeVhodVInt = resList.Sum(p => p.NeVhodVInt),
                        NeVhodVIntPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeVhodVInt) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        OtsutPriv = resList.Sum(p => p.OtsutPriv),
                        OtsutPrivPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.OtsutPriv * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NePeredSummPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NePeredSumm) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        isItog = true
                    });
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new SpGetAsduEsgLPU_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportLpu(string session, string date)
        {
            var excelService = new MasduExcelReports();
            return excelService.CreateAsduEsgLpuExcelReport(GetMasduEsgLpuList(session, date));
        }
        public List<SpGetAsduEsg_DTO> GetMasduEsgPeriodList(string session, string dateStart, string dateEnd)
        {
            var resList = new List<SpGetAsduEsg_DTO>();
            try
            {
                DateTime dtStart = Convert.ToDateTime(dateStart);
                DateTime dtEnd = Convert.ToDateTime(dateEnd);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.hp_GetAsduEsg1Period(session, dtStart, dtEnd).OrderBy(p => p.DTS).Select(p => new SpGetAsduEsg_DTO
                {
                    Session = p.Session,
                    PeredDost = Convert.ToInt32(p.PeredDost),
                    DTS = Convert.ToDateTime(p.DTS).ToString("dd.MM.yyyy HH:mm:ss"),
                    CommonCount = Convert.ToInt32(p.CommonCount),
                    PeredDostPersent = Math.Round(Convert.ToDouble(p.PeredDost * 100 / Convert.ToDouble(p.CommonCount)),2),
                    PeredNeDost = Convert.ToInt32(p.PeredNeDost),
                    PeredNeDostPercent = Math.Round(Convert.ToDouble(p.PeredNeDost * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    Pustoe = Convert.ToInt32(p.Pustoe),
                    PustoePercent = Math.Round(Convert.ToDouble(p.Pustoe * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeChislo = Convert.ToInt32(p.NeChislo),
                    NeChisloPercent = Math.Round(Convert.ToDouble(p.NeChislo * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeVhodVInt = Convert.ToInt32(p.NeVhodVInt),
                    NeVhodVIntPercent = Math.Round(Convert.ToDouble(p.NeVhodVInt * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    OtsutPriv = Convert.ToInt32(p.OtsutPriv),
                    OtsutPrivPercent = Math.Round(Convert.ToDouble(p.OtsutPriv * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NePeredSummPercent = Math.Round(Convert.ToDouble((p.Pustoe + p.NeChislo + p.NeVhodVInt + p.OtsutPriv) * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    MsgType = p.MsgType
                }).ToList();
                if (resList.Count != 0)
                    resList.Add(new SpGetAsduEsg_DTO
                    {
                        Session = "Итого",
                        DTS = dateStart + "-" + dateEnd,
                        CommonCount = resList.Sum(p => p.CommonCount),
                        PeredDost = resList.Sum(p => p.PeredDost),
                        PeredDostPersent = Math.Round(resList.Sum(p => p.PeredDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount)),2),
                        PeredNeDost = resList.Sum(p => p.PeredNeDost),
                        PeredNeDostPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.PeredNeDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        Pustoe = resList.Sum(p => p.Pustoe),
                        PustoePercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.Pustoe * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeChislo = resList.Sum(p => p.NeChislo),
                        NeChisloPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeChislo * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeVhodVInt = resList.Sum(p => p.NeVhodVInt),
                        NeVhodVIntPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeVhodVInt) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        OtsutPriv = resList.Sum(p => p.OtsutPriv),
                        OtsutPrivPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.OtsutPriv * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NePeredSummPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NePeredSumm) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        isItog = true
                    });
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new SpGetAsduEsg_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportPeriod(string session, string dateStart, string dateEnd)
        {
            var excelService = new MasduExcelReports();
            return excelService.CreateAsduEsgExcelReport(GetMasduEsgPeriodList(session, dateStart, dateEnd));
        }
        public List<SpGetAsduEsgLPU_DTO> GetMasduEsgLpuPeriodList(string session, string dateStart, string dateEnd)
        {
            var resList = new List<SpGetAsduEsgLPU_DTO>();
            try
            {
                DateTime dtStart = Convert.ToDateTime(dateStart);
                DateTime dtEnd = Convert.ToDateTime(dateEnd);
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.hp_GetAsduEsgLPUPeriod(session, dtStart, dtEnd).OrderBy(p => p.DTS).Select(p => new SpGetAsduEsgLPU_DTO
                {
                    LPUTitle = p.LPUTitle,
                    Session = p.Session,
                    DTS = Convert.ToDateTime(p.DTS).ToString("dd.MM.yyyy HH:mm:ss"),
                    CommonCount = Convert.ToInt32(p.CommonCount),
                    PeredDost = Convert.ToInt32(p.PeredDost),
                    PeredDostPersent = Math.Round(Convert.ToDouble(p.PeredDost * 100 / Convert.ToDouble(p.CommonCount)),2),
                    PeredNeDost = Convert.ToInt32(p.PeredNeDost),
                    PeredNeDostPercent = Math.Round(Convert.ToDouble(p.PeredNeDost * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    Pustoe = Convert.ToInt32(p.Pustoe),
                    PustoePercent = Math.Round(Convert.ToDouble(p.Pustoe * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeChislo = Convert.ToInt32(p.NeChislo),
                    NeChisloPercent = Math.Round(Convert.ToDouble(p.NeChislo * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NeVhodVInt = Convert.ToInt32(p.NeVhodVInt),
                    NeVhodVIntPercent = Math.Round(Convert.ToDouble(p.NeVhodVInt * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    OtsutPriv = Convert.ToInt32(p.OtsutPriv),
                    OtsutPrivPercent = Math.Round(Convert.ToDouble(p.OtsutPriv * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    NePeredSummPercent = Math.Round(Convert.ToDouble((p.Pustoe + p.NeChislo + p.NeVhodVInt + p.OtsutPriv) * 100 / Convert.ToDouble(p.CommonCount)), 2),
                    MsgType = p.MsgType
                }).ToList();
                if (resList.Count != 0)
                    resList.Add(new SpGetAsduEsgLPU_DTO
                    {
                        LPUTitle = "Итого",
                        DTS = dateStart + "-" + dateEnd,
                        CommonCount = resList.Sum(p => p.CommonCount),
                        PeredDost = resList.Sum(p => p.PeredDost),
                        PeredDostPersent = Math.Round(resList.Sum(p => p.PeredDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount)),2),
                        PeredNeDost = resList.Sum(p => p.PeredNeDost),
                        PeredNeDostPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.PeredNeDost) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        Pustoe = resList.Sum(p => p.Pustoe),
                        PustoePercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.Pustoe * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeChislo = resList.Sum(p => p.NeChislo),
                        NeChisloPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeChislo * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NeVhodVInt = resList.Sum(p => p.NeVhodVInt),
                        NeVhodVIntPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NeVhodVInt) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        OtsutPriv = resList.Sum(p => p.OtsutPriv),
                        OtsutPrivPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.OtsutPriv * 100) / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        NePeredSummPercent = Math.Round(Convert.ToDouble(resList.Sum(p => p.NePeredSumm) * 100 / Convert.ToDouble(resList.Sum(p => p.CommonCount))), 2),
                        isItog = true
                    });
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new SpGetAsduEsgLPU_DTO
                {
                    errorMessage = ex.InnerException.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReportLpuPeriod(string session, string dateStart, string dateEnd)
        {
            var excelService = new MasduExcelReports();
            return excelService.CreateAsduEsgLpuExcelReport(GetMasduEsgLpuPeriodList(session, dateStart, dateEnd));
        }
    }
}
