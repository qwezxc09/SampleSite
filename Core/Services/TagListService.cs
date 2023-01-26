using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.Entity.DTO;
using Core.Entity.Model;
using Core.ExcelReports;
using Core.Model.DTO;
using Core.Model.Models;
using OfficeOpenXml;

namespace Core.Services
{
    public class TagListService
    {
        public List<NSI_Lpu_DTO> GetLpuList()
        {
            var resList = new List<NSI_Lpu_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                var dbList = db.LPU_nsi.Where(p => p.id_deleted_nsi_obj != 1).ToList();
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
        public List<QualityTypes_DTO> GetQualityList()
        {
            var resList = new List<QualityTypes_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                resList = db.Quality_types.Select(p => new QualityTypes_DTO
                {
                    type_id = p.id_quality_types,
                    title = p.title
                }).ToList();
            }
            catch(Exception ex)
            {
                //throw ex;
            }
            return resList;
        }
        public List<GetTagList_DTO> GetTagList(int kodLpu, int qualityId)
        {
            var resList = new List<GetTagList_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                SqlParameter Param1 = new SqlParameter("@kodlpu", kodLpu);
                SqlParameter Param2 = new SqlParameter("@qualitytypeid", qualityId);
                string sqlQuery = "hp_GetLiveTagList @kodlpu, @qualitytypeid";

                var dbList = db.Database.SqlQuery<SpGetLiveTagList>(sqlQuery, Param1, Param2);


                resList = dbList.Select(p => new GetTagList_DTO
                {
                    lpuTitle = p.lpu_title,
                    tagDescription = p.Description,
                    value = Convert.ToDouble(p.Value),
                    dts = Convert.ToDateTime(p.DateTime).ToString("dd.MM.yyyy HH:mm:ss"),
                    quality = Convert.ToInt32(p.OPCQuality),
                    tagName = p.Tagname
                }).ToList();
            }
            catch(Exception ex)
            {
                resList.Clear();
                resList.Add(new GetTagList_DTO
                {
                    errorMessage = ex.Message,
                    isError = true
                });
            }
            return resList;
        }
        public List<GetTagList_DTO> GetPeriodTagList(int kodLpu, int qualityId, string startDate, string endDate, int typeData)
        {
            var resList = new List<GetTagList_DTO>();
            try
            {
                var db = new WEB_REPORTSContext();
                DateTime dtStart = new DateTime();
                DateTime dtEnd = new DateTime();
                if (typeData == 2)
                {
                    dtStart = Convert.ToDateTime(startDate);
                    dtEnd = Convert.ToDateTime(startDate).AddDays(+1);
                }
                else if (typeData == 3)
                {
                    dtStart = Convert.ToDateTime(startDate);
                    dtEnd = Convert.ToDateTime(endDate);
                }

                db.Database.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["timeOut"]);
                SqlParameter Param1 = new SqlParameter("@kodlpu", kodLpu);
                SqlParameter Param2 = new SqlParameter("@qualitytypeid", qualityId);
                SqlParameter Param3 = new SqlParameter("@startDt", dtStart.ToString("yyyy-MM-dd"));
                SqlParameter Param4 = new SqlParameter("@endDt", dtEnd.ToString("yyyy-MM-dd"));
                string sqlQuery = "hp_GetPeriodTagList @kodlpu, @qualitytypeid, @startDt, @endDt";

                var dbList = db.Database.SqlQuery<SpGetPeriodTagList>(sqlQuery, Param1, Param2, Param3, Param4);

                resList = dbList.Select(p => new GetTagList_DTO
                {
                    lpuTitle = p.lpu_title,
                    tagDescription = p.Description,
                    dts = Convert.ToDateTime(p.DateTime).ToString("dd.MM.yyyy HH:mm:ss"),
                    tagName = p.TagName
                }).ToList();
            }
            catch (Exception ex)
            {
                resList.Clear();
                resList.Add(new GetTagList_DTO
                {
                    errorMessage = ex.Message,
                    isError = true
                });
            }
            return resList;
        }
        public ExcelPackage GetExcelReport(int kodLpu, int qualityId)
        {
            var excelService = new TagListExcelReport();
            return excelService.CreateExcelTagList(GetTagList(kodLpu, qualityId));
        }
        public ExcelPackage GetPeriodExcelReport(int kodLpu, int qualityId, string startDate, string endDate, int typeData)
        {
            var excelService = new TagListExcelReport();
            return excelService.CreatePeriodExcelTagList(GetPeriodTagList(kodLpu, qualityId, startDate, endDate, typeData));
        }
    }
}
