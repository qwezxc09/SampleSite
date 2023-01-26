using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebReports.Models
{
  public class TagListGetData
  {
    public int kodlpu { get; set; }
    public int qualityId { get; set; }
  }
  public class PeriodTagListGetData
  {
    public int kodlpu { get; set; }
    public int qualityId { get; set; }
    public string stdate { get; set; }
    public string enddt { get; set; }
    public int typeData { get; set; }
  }
}
