using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.DTO
{
    public class ZAR_NSI_WEB_DTO
    {
        public int Id { get; set; }
        public string LPU_Name { get; set; }
        public string KP_Name { get; set; }
        public string kodZAR_SLTM { get; set; }
        public string kodZAR_SODU { get; set; }
        public string Tagname { get; set; }
        public string ShortZAR_Name { get; set; }
        public string Comment { get; set; }
        public string LongZAR_Name { get; set; }
        public bool Added { get; set; }
        public bool Deleted { get; set; }
        public bool Changed { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
}
