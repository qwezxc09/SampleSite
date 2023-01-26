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
    public class WSPController : Controller
    {
    [Route("wsp/getLpuList")]
    [HttpGet]
    public JsonResult GetLpuList()
    {
      var WSPService = new WSPControlService();
      var result = WSPService.GetLpuList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("wsp/getKSList")]
    [HttpGet]
    public JsonResult GetKSList()
    {
      var WSPService = new WSPControlService();
      var result = WSPService.GetKSList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("wsp/getKCList")]
    [HttpPost]
    public JsonResult GetKCList(KodKs data)
    {
      var WSPService = new WSPControlService();
      var result = WSPService.GetKCList(data.kodks);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("wsp/getObjTypeList")]
    [HttpGet]
    public JsonResult GetObjTypeList()
    {
      var WSPService = new WSPControlService();
      var result = WSPService.GetObjTypeList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("wsp/getIntervalsList")]
    [HttpGet]
    public JsonResult GetIntervalsList()
    {
      var WSPService = new WSPControlService();
      var result = WSPService.GetIntervalList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataIntervalsLPU")]
    [HttpPost]
    public JsonResult GetDataIntervalsLPU(WSPGetDataLpu data)
    {
      //var data = JsonConvert.DeserializeObject<WSPGetDataLpu>(body.ToString());
      var WSPService = new WSPControlService();
      var result = WSPService.GetIntervalsLPU(data.kodlpu, data.startdt, data.enddt, data.minLen, data.maxLen);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataIntervalsLPUExcel")]
    [HttpPost]
    public FileResult GetDataTagListLPUExcel(WSPGetDataLpu data)
    {
      ExcelPackage package = new ExcelPackage();
      //var data = JsonConvert.DeserializeObject<WSPGetDataLpu>(body.ToString());
      var WSPService = new WSPControlService();
      package = WSPService.GetExcelReportLPU(data.kodlpu, data.startdt, data.enddt, data.minLen, data.maxLen);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getDataIntervalsKC")]
    [HttpPost]
    public JsonResult GetDataIntervalsKC(WSPGetDataKC data)
    {
      //var data = JsonConvert.DeserializeObject<WSPGetDataKC>(body.ToString());
      var WSPService = new WSPControlService();
      var result = WSPService.GetIntervalsKC(data.kodkc, data.kodks, data.startdt, data.enddt, data.minLen, data.maxLen);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataIntervalsKCExcel")]
    [HttpPost]
    public FileResult GetDataTagListKCExcel(WSPGetDataKC data)
    {
      ExcelPackage package = new ExcelPackage();
      //var data = JsonConvert.DeserializeObject<WSPGetDataKC>(body.ToString());
      var WSPService = new WSPControlService();
      package = WSPService.GetExcelReportKC(data.kodkc, data.kodks, data.startdt, data.enddt, data.minLen, data.maxLen);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }

    [Route("getDataIntervalsManualTags")]
    [HttpPost]
    public JsonResult GetDataIntervalsManualTags(WSPGetDataManualTags data)
    {
      //var data = JsonConvert.DeserializeObject<WSPGetDataManualTags>(body.ToString());
      var WSPService = new WSPControlService();
      var result = WSPService.GetIntervalsManualTags(data.kodkc, data.kodks, data.startdt, data.enddt, data.objId, data.minLen, data.maxLen);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataIntervalsManualTagsExcel")]
    [HttpPost]
    public FileResult GetDataTagListManualTagsExcel(WSPGetDataManualTags data)
    {
      ExcelPackage package = new ExcelPackage();
      //var data = JsonConvert.DeserializeObject<WSPGetDataManualTags>(body.ToString());
      var WSPService = new WSPControlService();
      package = WSPService.GetExcelReportManualTags(data.kodkc, data.kodks, data.startdt, data.enddt, data.objId, data.minLen, data.maxLen);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }
  }
}
