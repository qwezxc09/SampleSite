using Core.Entity;
using Core.Entity.DTO;
using Core.Services;
using OfficeOpenXml;
using Reports7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reports7.Controllers
{
    public class CraneController : Controller
    {
    [Route("crane/getLpuList")]
    [HttpGet]
    public JsonResult GetLpuList()
    {
      var craneService = new CranesService();
      var result = craneService.GetLpuList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("crane/getKPList")]
    [HttpPost]
    public JsonResult GetKPList(GetKPData data)
    {
      var craneService = new CranesService();
      var result = craneService.GetKpList(data.lpuName);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("crane/getReportData")]
    [HttpPost]
    public JsonResult GetCraneDataReport(CraneGetData data)
    {
      var cranesService = new CranesService();
      var result = cranesService.GetReportTable(data.startdt, data.enddt, data.lpuName, data.kpName);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getCraneDataReportExcel")]
    [HttpPost]
    public FileResult GetDataTagListPeriodExcel(GetExcelData data)
    {
      ExcelPackage package = new ExcelPackage();
      var cranesService = new CranesService();
      package = cranesService.GetCranesExcelReport(data.startdt, data.enddt, data.lpuName, data.kpName, data.showAll);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("crane/getNSIData")]
    [HttpPost]
    public JsonResult GetCraneNSIData(CraneGetData data)
    {
      var cranesService = new CranesService();
      var result = cranesService.GetNSIData(data.lpuName, data.kpName);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("crane/checkUserData")]
    [HttpPost]
    public JsonResult CheckUserData(UserData data)
    {
      var cranesService = new CranesService();
      var result = cranesService.CheckUserData(data.userName, data.password);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("saveNSIData")]
    [HttpPost]
    public JsonResult SaveCraneNSIData(GetNsiData data)
    {
      var cranesService = new CranesService();
      var result = cranesService.SaveNsiData(data.nsiList);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
  }
}
