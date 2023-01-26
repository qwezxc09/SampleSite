using Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.DTO
{
    public class TelemehanicaConnectedSystem_DTO
    {
        public string KsTitle { get; set; }
        public int KcCount { get; set; }
        public int GpaCount { get; set; }
        public List<KcSauModel> KcDataList { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
}
