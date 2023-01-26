using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Models
{
    public class KcSauModel
    {
        public int KodKc { get; set; }
        public string[] SauTypeList { get; set; }
        public string[] TagCountList { get; set; }
        public int? GpaCount { get; set; }
    }
}
