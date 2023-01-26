using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.DTO
{
    public class GetTagList_DTO
    {
        public string lpuTitle { get; set; }
        public string tagDescription { get; set; }
        public string tagName { get; set; }
        public int quality { get; set; }
        public double value { get; set; }
        public string dts { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
}
