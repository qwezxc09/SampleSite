using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Models
{
    public class SpGetTelemehanicaReportData
    {
        public string lpu_title { get; set; }
        public Int32? kodlpu { get; set; }
        public string ks_title { get; set; }
        public Int32? kodks { get; set; }
        public string kc_title { get; set; }
        public string agr_title { get; set; }
        public int? kodAgr { get; set; }
        public string telemehanica_title { get; set; }
        public string level_title { get; set; }
        public int? id_telemehanica_levels { get; set; }
        public int? tagCount { get; set; }
    }
}
