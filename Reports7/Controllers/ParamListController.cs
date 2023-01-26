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
    public class ParamListController : Controller
    {
    [Route("getDataParamList")]
    [HttpPost]
    public JsonResult GetDataParamList(ParamListGetData data)
    {
      var paramListService = new ParamListService();
      var result = paramListService.GetParamList(data.session, data.lpuTitle, data.errId, data.dts);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataParamListExcel")]
    [HttpPost]
    public FileResult GetDataParamListExcel(ParamListGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var paramListService = new ParamListService();
      package = paramListService.GetExcelReport(data.session, data.lpuTitle, data.errId, data.dts);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }
  }
}
