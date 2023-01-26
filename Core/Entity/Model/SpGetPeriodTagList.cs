using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Model
{
    public class SpGetPeriodTagList
    {
        public string TagName { get; set; }
        public string Description { get; set; }
        public string lpu_title { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
