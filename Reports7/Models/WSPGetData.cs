using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebReports.Models
{
    public class WSPGetDataLpu
    {
        public int kodlpu { get; set; }
        public string startdt { get; set; }
        public string enddt { get; set; }
        public int minLen { get; set; }
        public int maxLen { get; set; }
    }
    public class WSPGetDataKC
    {
        public int kodkc { get; set; }
        public int kodks { get; set; }
        public string startdt { get; set; }
        public string enddt { get; set; }
        public int minLen { get; set; }
        public int maxLen { get; set; }
    }
    public class WSPGetDataManualTags
    {
        public int kodkc { get; set; }
        public int kodks { get; set; }
        public int objId { get; set; }
        public string startdt { get; set; }
        public string enddt { get; set; }
        public int minLen { get; set; }
        public int maxLen { get; set; }
    }
    public class KodKs
    {
        public int kodks { get; set; }
    }
}
