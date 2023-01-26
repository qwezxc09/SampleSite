using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.Models
{
    public class SpGetLiveTagList
    {
        public string Tagname { get; set; }
        public string Description { get; set; }
        public double? Value { get; set; }
        public int? OPCQuality { get; set; }
        public string lpu_title { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
