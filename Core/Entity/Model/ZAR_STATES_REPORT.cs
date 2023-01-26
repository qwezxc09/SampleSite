using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Model
{
    public class ZAR_STATES_REPORT
    {
        public string LPU_Name { get; set; }
        public string KP_Name { get; set; }
        public string kodZAR_SLTM { get; set; }
        public string kodZAR_SODU { get; set; }
        public string TagName { get; set; }
        public DateTime RearrangeDate { get; set; }
        public string RearrangeDateDisplay
        {
            get
            {
                var dt = new DateTime();
                if (RearrangeDate != dt)
                {
                    return RearrangeDate.ToString("dd.MM.yyyy hh:mm:ss");
                }
                else
                    return "-";
            }
        }
        public double Value { get; set; }
        public string State
        {
            get
            {
                string st = "";
                if (Value == 1)
                    st = "Закрыт";
                else if (Value == 2)
                    st = "Открыт";
                else
                    st = "-";
                return st;
            }
        }
        public int Quality { get; set; }
        public bool isAuto
        {
            get
            {
                if (Quality == 192)
                    return true;
                else
                    return false;
            }
        }
        public bool isManual
        {
            get
            {
                if (Quality == 219 || Quality == 216)
                    return true;
                else
                    return false;
            }
        }
        public bool isNoValue
        {
            get
            {
                if (Value == -1)
                    return true;
                else
                    return false;
            }
        }
        public bool hasRearrange { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
}
