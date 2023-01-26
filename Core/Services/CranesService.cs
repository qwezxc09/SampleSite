using Core.Entity;
using Core.Entity.DTO;
using Core.Entity.Model;
using Core.ExcelReports;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CranesService
    {
        public List<ZAR_STATES_REPORT> GetReportTable(string startDate, string endDate, string lpuName, string kpName)
        {
            var result = new List<ZAR_STATES_REPORT>();
            try
            {
                DateTime dtStart = Convert.ToDateTime(startDate);
                DateTime dtEnd = Convert.ToDateTime(endDate);
                var db = new WEB_REPORTSContext();
                if (lpuName == "Все ЛПУ" && kpName == "Все КП")
                {
                    result = db.ZAR_STATES_ALL.Join(db.ZAR_NSI_WEB, p => p.TagName.Replace(".Value", ""), t => t.Tagname, (p, t) => new ZAR_STATES_REPORT
                    {
                        LPU_Name = t.LPU_Name,
                        KP_Name = t.KP_Name,
                        kodZAR_SLTM = t.kodZAR_SLTM,
                        kodZAR_SODU = t.kodZAR_SODU,
                        TagName = t.Tagname,
                        RearrangeDate = p.DateTime,
                        Value = p.Value,
                        Quality = p.Quality,
                        hasRearrange = true
                    }).Where(p=>p.RearrangeDate>=dtStart && p.RearrangeDate <= dtEnd).ToList();
                    var tagList = result.Select(p => p.TagName).ToList();
                    var nsiList = db.ZAR_NSI_WEB.Where(p => !tagList.Contains(p.Tagname)).Select(p => new ZAR_STATES_REPORT
                    {
                        LPU_Name = p.LPU_Name,
                        KP_Name = p.KP_Name,
                        kodZAR_SLTM = p.kodZAR_SLTM,
                        kodZAR_SODU = p.kodZAR_SODU,
                        TagName = p.Tagname,
                        hasRearrange = true,
                        Value = -1,
                    }).ToList();
                    foreach(var a in nsiList)
                    {
                        result.Add(a);
                    }
                    result = result.OrderBy(p => p.LPU_Name).ThenBy(p=>p.RearrangeDate).ToList();
                }
                else if (kpName == "Все КП")
                {
                    result = db.ZAR_STATES_ALL.Join(db.ZAR_NSI_WEB, p => p.TagName.Replace(".Value", ""), t => t.Tagname, (p, t) => new ZAR_STATES_REPORT
                    {
                        LPU_Name = t.LPU_Name,
                        KP_Name = t.KP_Name,
                        kodZAR_SLTM = t.kodZAR_SLTM,
                        kodZAR_SODU = t.kodZAR_SODU,
                        TagName = t.Tagname,
                        RearrangeDate = p.DateTime,
                        Value = p.Value,
                        Quality = p.Quality,
                        hasRearrange = true
                    }).Where(p => p.RearrangeDate >= dtStart && p.RearrangeDate <= dtEnd && p.LPU_Name == lpuName).OrderBy(p => p.RearrangeDate).ToList();
                }
                else
                    result = db.ZAR_STATES_ALL.Join(db.ZAR_NSI_WEB, p => p.TagName.Replace(".Value", ""), t => t.Tagname, (p, t) => new ZAR_STATES_REPORT
                    {
                        LPU_Name = t.LPU_Name,
                        KP_Name = t.KP_Name,
                        kodZAR_SLTM = t.kodZAR_SLTM,
                        kodZAR_SODU = t.kodZAR_SODU,
                        TagName = t.Tagname,
                        RearrangeDate = p.DateTime,
                        Value = p.Value,
                        Quality = p.Quality,
                        hasRearrange = true
                    }).Where(p => p.RearrangeDate >= dtStart && p.RearrangeDate <= dtEnd && p.LPU_Name == lpuName && p.KP_Name == kpName).OrderBy(p => p.RearrangeDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                result.Add(new ZAR_STATES_REPORT
                {
                    errorMessage = ex.Message,
                    isError = true
                });
                return result;
            }
        }
        public ExcelPackage GetCranesExcelReport(string startDate, string endDate, string lpuName, string kpName, bool showAll)
        {
            var excelService = new CranesExcelReports();
            var list = GetReportTable(startDate, endDate, lpuName, kpName);
            if (!showAll)
                list = list.Where(p => p.isNoValue == false).OrderBy(p=>p.LPU_Name).ThenBy(p=>p.RearrangeDate).ToList();
            return excelService.CreateCranesExcelReport(list);
        }
        public List<DislpayNSI> GetLpuList()
        {
            var result = new List<DislpayNSI>();
            result.Add(new DislpayNSI { Id = 1, NsiValue = "Все ЛПУ" });
            try
            {
                var db = new WEB_REPORTSContext();
                var list = db.ZAR_NSI_WEB.Select(p => p.LPU_Name).Distinct().OrderBy(p => p).ToList();
                int i = 2;
                foreach (var a in list)
                {
                    result.Add(new DislpayNSI { Id = i, NsiValue = a });
                    i++;
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
        public List<DislpayNSI> GetKpList(string lpuName)
        {
            var result = new List<DislpayNSI>();
            result.Add(new DislpayNSI { Id = 1, NsiValue = "Все КП" });
            try
            {
                if (lpuName != "")
                {
                    var db = new WEB_REPORTSContext();
                    var list = db.ZAR_NSI_WEB.Where(p=>p.LPU_Name == lpuName).Select(p => p.KP_Name).Distinct().OrderBy(p => p).ToList();
                    int i = 2;
                    foreach (var a in list)
                    {
                        result.Add(new DislpayNSI { Id = i, NsiValue = a });
                        i++;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
        public List<ZAR_NSI_WEB_DTO> GetNSIData(string lpuName, string kpName)
        {
            var result = new List<ZAR_NSI_WEB_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                if (lpuName == "Все ЛПУ" && kpName == "Все КП")
                {
                    var dbList = db.ZAR_NSI_WEB.ToList();
                    foreach(var a in dbList)
                    {
                        result.Add(new ZAR_NSI_WEB_DTO
                        {
                            Id = a.Id,
                            LPU_Name = a.LPU_Name,
                            KP_Name = a.KP_Name,
                            Comment = a.Comment,
                            kodZAR_SLTM = a.kodZAR_SLTM,
                            kodZAR_SODU = a.kodZAR_SODU,
                            Tagname = a.Tagname,
                            ShortZAR_Name = a.ShortZAR_Name,
                            LongZAR_Name = a.LongZAR_Name,
                            Added = false,
                            Changed = false,
                            Deleted = false
                        });
                    }
                }
                else if (kpName == "Все КП")
                {
                    var dbList = db.ZAR_NSI_WEB.Where(p=>p.LPU_Name == lpuName).ToList();
                    foreach (var a in dbList)
                    {
                        result.Add(new ZAR_NSI_WEB_DTO
                        {
                            Id = a.Id,
                            LPU_Name = a.LPU_Name,
                            KP_Name = a.KP_Name,
                            Comment = a.Comment,
                            kodZAR_SLTM = a.kodZAR_SLTM,
                            kodZAR_SODU = a.kodZAR_SODU,
                            Tagname = a.Tagname,
                            ShortZAR_Name = a.ShortZAR_Name,
                            LongZAR_Name = a.LongZAR_Name,
                            Added = false,
                            Changed = false,
                            Deleted = false
                        });
                    }
                }
                else
                {
                    var dbList = db.ZAR_NSI_WEB.Where(p => p.LPU_Name == lpuName && p.KP_Name == kpName).ToList();
                    foreach (var a in dbList)
                    {
                        result.Add(new ZAR_NSI_WEB_DTO
                        {
                            Id = a.Id,
                            LPU_Name = a.LPU_Name,
                            KP_Name = a.KP_Name,
                            Comment = a.Comment,
                            kodZAR_SLTM = a.kodZAR_SLTM,
                            kodZAR_SODU = a.kodZAR_SODU,
                            Tagname = a.Tagname,
                            ShortZAR_Name = a.ShortZAR_Name,
                            LongZAR_Name = a.LongZAR_Name,
                            Added = false,
                            Changed = false,
                            Deleted = false
                        });
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Clear();
                result.Add(new ZAR_NSI_WEB_DTO
                {
                    errorMessage = ex.Message,
                    isError = true
                });
                return result;
            }
        }
        public bool SaveNsiData(List<ZAR_NSI_WEB_DTO> nsiList) 
        {
            var result = false;
            try
            {
                var db = new WEB_REPORTSContext();
                if(nsiList != null)
                {
                    foreach (var a in nsiList)
                    {
                        if (a.Changed && !a.Added && !a.Deleted)
                        {
                            var item = db.ZAR_NSI_WEB.Where(p => p.Id == a.Id).FirstOrDefault();
                            if (item != null)
                            {
                                item.LPU_Name = a.LPU_Name;
                                item.KP_Name = a.KP_Name;
                                item.kodZAR_SLTM = a.kodZAR_SLTM;
                                item.kodZAR_SODU = a.kodZAR_SODU;
                                item.Comment = a.Comment;
                                item.Tagname = a.Tagname;
                                item.LongZAR_Name = a.LongZAR_Name;
                                item.ShortZAR_Name = a.ShortZAR_Name;
                                db.Entry(item).State = EntityState.Modified;
                            }
                        }
                        else if (a.Changed && a.Added && !a.Deleted)
                        {
                            var item = new ZAR_NSI_WEB
                            {
                                LPU_Name = a.LPU_Name,
                                KP_Name = a.KP_Name,
                                kodZAR_SLTM = a.kodZAR_SLTM,
                                kodZAR_SODU = a.kodZAR_SODU,
                                Comment = a.Comment,
                                Tagname = a.Tagname,
                                LongZAR_Name = a.LongZAR_Name,
                                ShortZAR_Name = a.ShortZAR_Name
                            };
                            db.ZAR_NSI_WEB.Add(item);
                        }
                        else if (a.Deleted && !a.Added)
                        {
                            var item = db.ZAR_NSI_WEB.Where(p => p.Id == a.Id).FirstOrDefault();
                            if (item != null)
                                db.ZAR_NSI_WEB.Remove(item);
                        }
                    }
                    db.SaveChanges();
                }
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
        }
        public bool CheckUserData(string userName, string password)
        {
            var result = false;
            try
            {
                if (userName.ToLower() == "ius\\testadmin" && password == "xelJdfht704")
                    result = true;
                return result;
            }
            catch (Exception ex)
            {

                return result;
            }
        }
    }
}
