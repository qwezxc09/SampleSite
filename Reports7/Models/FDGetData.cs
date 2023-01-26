using Core.Entity;
using Core.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebReports.Models
{
    public class FDGetData
    {
        public List<NSI_Lpu_DTO> lpuList { get; set; }
        public string startdt { get; set; }
        public string enddt { get; set; }
    }
  public class FDGetDataLive
  {
    public List<NSI_Lpu_DTO> lpuList { get; set; }
  }
}
