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
    public class FullDataController : Controller
    {
    [Route("fulldata/getLpuList")]
    [HttpGet]
    public JsonResult GetLpuList()
    {
      var FDataService = new FullDataControlService();
      var result = FDataService.GetLpuList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataListPeriod")]
    [HttpPost]
    public JsonResult GetDataListPeriod(FDGetData data)
    {
      var FDataService = new FullDataControlService();
      var result = FDataService.GetDataValuePeriod(data.lpuList, data.startdt, data.enddt);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataListPeriodExcel")]
    [HttpPost]
    public FileResult GetDataTagListPeriodExcel(FDGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var FDataService = new FullDataControlService();
      package = FDataService.GetExcelReportPeriod(data.lpuList, data.startdt, data.enddt);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getDataListLive")]
    [HttpPost]
    public JsonResult GetDataListLive(FDGetDataLive data)
    {
      var FDataService = new FullDataControlService();
      var result = FDataService.GetDataValueLive(data.lpuList);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataListLive2")]
    [HttpPost]
    public JsonResult GetDataListLive2(FDGetData data)
    {
      var FDataService = new FullDataControlService();
      var result = FDataService.GetDataValueLive(data.lpuList);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataListLiveExcel")]
    [HttpPost]
    public FileResult GetDataTagListLiveExcel(FDGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var FDataService = new FullDataControlService();
      package = FDataService.GetExcelReportLive(data.lpuList);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getDataListDay")]
    [HttpPost]
    public JsonResult GetDataListDay(FDGetData data)
    {
      var FDataService = new FullDataControlService();
      var result = FDataService.GetDataValueDay(data.lpuList, data.startdt);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataListDayExcel")]
    [HttpPost]
    public FileResult GetDataTagListDayExcel(FDGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var FDataService = new FullDataControlService();
      package = FDataService.GetExcelReportDay(data.lpuList, data.startdt);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }
  }
}
