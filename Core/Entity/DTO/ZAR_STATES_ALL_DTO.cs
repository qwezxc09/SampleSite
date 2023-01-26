using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.DTO
{
    public class ZAR_STATES_ALL_DTO
    {
        public int id { get; set; }
        public DateTime DateTime { get; set; }
        public string TagName { get; set; }
        public double Value { get; set; }
        public int Quality { get; set; }
    }
}
