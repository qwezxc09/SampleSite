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
    public class TagListController : Controller
    {
    [Route("tagList/getLpuList")]
    [HttpGet]
    public JsonResult GetLpuList()
    {
      var tagListService = new TagListService();
      var result = tagListService.GetLpuList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("tagList/getQualityList")]
    [HttpGet]
    public JsonResult GetQualityList()
    {
      var tagListService = new TagListService();
      var result = tagListService.GetQualityList();
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataTagList")]
    [HttpPost]
    public JsonResult GetDataTagList(TagListGetData data)
    {
      var tagListService = new TagListService();
      var result = tagListService.GetTagList(data.kodlpu, data.qualityId);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataPeriodTagList")]
    [HttpPost]
    public JsonResult GetDataPeriodTagList(PeriodTagListGetData data)
    {
      var tagListService = new TagListService();
      var result = tagListService.GetPeriodTagList(data.kodlpu, data.qualityId, data.stdate, data.enddt, data.typeData);
      var JsonRez = Json(result, JsonRequestBehavior.AllowGet);

      return JsonRez;
    }
    [Route("getDataTagListExcel")]
    [HttpPost]
    public FileResult GetDataTagListExcel(TagListGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var tagListService = new TagListService();
      package = tagListService.GetExcelReport(data.kodlpu, data.qualityId);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }
    [Route("getDataPeriodTagListExcel")]
    [HttpPost]
    public FileResult GetDataPeriodTagListExcel(PeriodTagListGetData data)
    {
      ExcelPackage package = new ExcelPackage();
      var tagListService = new TagListService();
      package = tagListService.GetPeriodExcelReport(data.kodlpu, data.qualityId, data.stdate, data.enddt, data.typeData);
      byte[] arr = package.GetAsByteArray();
      return new FileContentResult(arr, System.Net.Mime.MediaTypeNames.Application.Octet);
    }
  }
}
