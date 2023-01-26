using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.DTO
{
    public class TelemehanicaReportData_DTO
    {
        public string LpuTitle { get; set; }
        public string KsTitle { get; set; }
        public string KcTitle { get; set; }
        public string AgrTitle { get; set; }
        public string LevelTitle { get; set; }
        public string TelemehanicaTitle { get; set; }
        public int? TagCount { get; set; }
        public bool isItog { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
    public class DisplayTelemehanicaValue
    {
        public DisplayTelemehanicaValue()
        {
            tableValue = new List<TelemehanicaReportData_DTO>();
            frozenRaws = new List<TelemehanicaReportData_DTO>();
        }
        public List<TelemehanicaReportData_DTO> tableValue { get; set; }
        public List<TelemehanicaReportData_DTO> frozenRaws { get; set; }
    }
}
