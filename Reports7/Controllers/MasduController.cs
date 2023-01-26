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
    public class MasduController : Controller
    {
    [Route("masdu/getSessionList")]
    [HttpGet]
    public JsonResult GetLpuList()
    {
      var MasduService = new MasduService();
      var result = MasduService.GetSessionList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getMasduEsgList")]
    [HttpPost]
    public JsonResult GetMasduEsgList(MasduGetData data)
    {
      var MasduService = new MasduService();
      var result = MasduService.GetMasduEsgList(data.session, data.startdt);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getMasduEsgListExcel")]
    [HttpPost]
    public FileResult GetDataTagListExcel(MasduGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var MasduService = new MasduService();
      package = MasduService.GetExcelReport(data.session, data.startdt);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getMasduEsgLpuList")]
    [HttpPost]
    public JsonResult GetMasduEsgLpuList(MasduGetData data)
    {
      var MasduService = new MasduService();
      var result = MasduService.GetMasduEsgLpuList(data.session, data.startdt);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getMasduEsgLpuListExcel")]
    [HttpPost]
    public FileResult GetMasduEsgLpuListExcel(MasduGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var MasduService = new MasduService();
      package = MasduService.GetExcelReportLpu(data.session, data.startdt);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getMasduEsgPeriodList")]
    [HttpPost]
    public JsonResult GetMasduEsgPeriodList(MasduGetData data)
    {
      var MasduService = new MasduService();
      var result = MasduService.GetMasduEsgPeriodList(data.session, data.startdt, data.enddt);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getMasduEsgPeriodListExcel")]
    [HttpPost]
    public FileResult GetMasduEsgPeriodListExcel(MasduGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var MasduService = new MasduService();
      package = MasduService.GetExcelReportPeriod(data.session, data.startdt, data.enddt);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getMasduEsgLpuPeriodList")]
    [HttpPost]
    public JsonResult GetMasduEsgLpuPeriodList(MasduGetData data)
    {
      var MasduService = new MasduService();
      var result = MasduService.GetMasduEsgLpuPeriodList(data.session, data.startdt, data.enddt);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getMasduEsgLpuPeriodListExcel")]
    [HttpPost]
    public FileResult GetMasduEsgLpuPeriodListExcel(MasduGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var MasduService = new MasduService();
      package = MasduService.GetExcelReportLpuPeriod(data.session, data.startdt, data.enddt);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }
  }
}
