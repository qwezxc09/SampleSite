using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.DTO
{
    public class SpGetAsduEsgLPU_DTO
    {
        public string LPUTitle { get; set; }
        public string Session { get; set; }
        public string MsgType { get; set; }
        public string DTS { get; set; }
        public int CommonCount { get; set; }
        public int PeredDost { get; set; }
        public double PeredDostPersent { get; set; }
        public int PeredNeDost { get; set; }
        public double PeredNeDostPercent { get; set; }
        public int Pustoe { get; set; }
        public double PustoePercent { get; set; }
        public int NeChislo { get; set; }
        public double NeChisloPercent { get; set; }
        public int NeVhodVInt { get; set; }
        public double NeVhodVIntPercent { get; set; }
        public int OtsutPriv { get; set; }
        public double OtsutPrivPercent { get; set; }
        public int NePeredSumm
        {
            get { return Pustoe + NeChislo + NeVhodVInt + OtsutPriv; }
        }
        public double NePeredSummPercent { get; set; }
        public bool isItog { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
}
