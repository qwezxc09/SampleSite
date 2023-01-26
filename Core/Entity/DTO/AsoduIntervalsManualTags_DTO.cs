using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.DTO
{
    public class AsoduIntervalsManualTags_DTO
    {
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public string StartInterval
        {
            get { return StartDt.HasValue ? StartDt.Value.ToString("dd.MM.yyyy HH:mm") : string.Empty; }
        }
        public string EndInterval
        {
            get { return EndDt.HasValue ? EndDt.Value.ToString("dd.MM.yyyy HH:mm") : string.Empty; }
        }
        public int? StartValue { get; set; }
        public int? EndValue { get; set; }
        public int kodKS { get; set; }
        public int kodKC { get; set; }
        public Int64 grpId { get; set; }
        public int? LengthInterval { get; set; }
        public string LengthIntervalStr
        {
            get
            {
                if (LengthInterval == null)
                    return string.Empty;

                TimeSpan ts = TimeSpan.FromSeconds(LengthInterval.Value);
                if (LengthInterval.Value >= 86400)
                    return string.Format("{0} д {1} час {2} мин {3} сек", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                else if (LengthInterval.Value >= 3600)
                    return string.Format("{0} час {1} мин {2} сек", ts.Hours, ts.Minutes, ts.Seconds);
                else if (LengthInterval.Value >= 60)
                    return string.Format("{0} мин {1} сек", ts.Minutes, ts.Seconds);
                else
                    return string.Format("{0} сек", LengthInterval.Value.ToString());
            }
        }
        public string AgrTitle
        {
            get { return TagName.Length > 12 ? string.Format("{0}{1}", Convert.ToInt32(TagName.Substring(7, 2)), Convert.ToInt32(TagName.Substring(10, 2))) : string.Empty; }
        }
        public string KSName { get; set; }
        public string KCName { get { return (kodKC != 0) ? string.Format("Цех №{0}", kodKC) : "Цех №0"; } }
        public string TagName { get; set; }
        public string TagDescription { get; set; }
        public TimeSpan Period { get; set; }
        public string TagType { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
}
