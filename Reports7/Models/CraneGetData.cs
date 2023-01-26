using Core.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reports7.Models
{
  public class CraneGetData
  {
    public string startdt { get; set; }
    public string enddt { get; set; }
    public string lpuName { get; set; }
    public string kpName { get; set; }
  }
  public class GetKPData
  {
    public string lpuName { get; set; }
  }
  public class GetNsiData
  {
    public List<ZAR_NSI_WEB_DTO> nsiList { get; set; }
  }
  public class GetExcelData
  {
    public string startdt { get; set; }
    public string enddt { get; set; }
    public string lpuName { get; set; }
    public string kpName { get; set; }
    public bool showAll { get; set; }
  }
  public class UserData
  {
    public string userName { get; set; }
    public string password { get; set; }
  }
}
