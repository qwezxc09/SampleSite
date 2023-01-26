using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Models
{
    public partial class SpGetLiveStatisticData
    {
        public int? kodlpu { get; set; }
        public string lpuTitle { get; set; }
        public int? id_deleted_nsi_obj { get; set; }
        public int? tagCount { get; set; }
        public int? goodQualityCount { get; set; }
        public int? handenter { get; set; }
        public int? handenter_auto { get; set; }
        public int? repair { get; set; }
        public int? bedQuality { get; set; }
        public int? tagCountAllInPDS { get; set; }
    }
}
