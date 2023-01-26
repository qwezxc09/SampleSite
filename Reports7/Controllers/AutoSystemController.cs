using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Entity;
using Core.Model.DTO;
using Core.Model.Models;
using Core.Services;
using Newtonsoft.Json;
using OfficeOpenXml;
using WebReports.Models;

namespace Reports7.Controllers
{
    public class AutoSystemController : Controller
    {
    [Route("autosystem/getLpuList")]
    [HttpGet]
    public JsonResult GetLpuList()
    {
      var AutoSystemService = new AutoSystemService();
      var result = AutoSystemService.GetLpuList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("autosystem/getKSList")]
    [HttpGet]
    public JsonResult GetKSList()
    {
      var AutoSystemService = new AutoSystemService();
      var result = AutoSystemService.GetKSList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("autosystem/getLevelList")]
    [HttpGet]
    public JsonResult GetLevelList()
    {
      var AutoSystemService = new AutoSystemService();
      var result = AutoSystemService.GetLevelList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("autosystem/getTypesList")]
    [HttpGet]
    public JsonResult GetTypesList()
    {
      var AutoSystemService = new AutoSystemService();
      var result = AutoSystemService.GetTypeList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getTelemehanicaKcData")]
    [HttpGet]
    public JsonResult GetTelemehanicaKcData()
    {
      var AutoSystemService = new AutoSystemService();
      var result = AutoSystemService.GetTelemehanicaKcData();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getTelemehanicaKcDataExcel")]
    [HttpPost]
    public FileResult GetTelemehanicaKcDataExcel(AutoSystemGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var AutoSystemService = new AutoSystemService();
      package = AutoSystemService.GetExcelReportKcData();
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getTelemehanicaGpaData")]
    [HttpGet]
    public JsonResult GetTelemehanicaGpaData()
    {
      var AutoSystemService = new AutoSystemService();
      var result = AutoSystemService.GetTelemehanicaGpaData();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getTelemehanicaGpaDataExcel")]
    [HttpPost]
    public FileResult GetTelemehanicaGpaDataExcel(AutoSystemGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var AutoSystemService = new AutoSystemService();
      package = AutoSystemService.GetExcelReportGpaData();
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getTelemehanicaReportData")]
    [HttpPost]
    public JsonResult GetTelemehanicaReportData(AutoSystemGetData data)
    {
      var AutoSystemService = new AutoSystemService();
      var result = AutoSystemService.GetTelemehanicaReportData(data.kodlpu, data.kodks, data.kodlevel, data.kodtype);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getTelemehanicaReportDataExcel")]
    [HttpPost]
    public FileResult GetTelemehanicaReportDataExcel(AutoSystemGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var AutoSystemService = new AutoSystemService();
      package = AutoSystemService.GetExcelReport(data.kodlpu, data.kodks, data.kodlevel, data.kodtype);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }
  }
}
