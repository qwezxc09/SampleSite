using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model.DTO
{
    public class SpGetPeriodStatisticData_DTO
    {
        public string lpuTitle { get; set; }
        public int kodlpu { get; set; }
        public int? id_deleted_nsi_obj { get; set; }
        public int tagCount { get; set; }
        public int inWorkCount { get; set; }
        public int handEnterCount { get; set; }
        public double handEnterCountPercent { get; set; }
        public int handEnterAutoCount { get; set; }
        public double handEnterAutoCountPercent { get; set; }
        public int goodQualityCount { get; set; }
        public double goodQualityCountPercent { get; set; }
        public int repairCount { get; set; }
        public double repairCountPercent { get; set; }
        public int bedQualityCount { get; set; }
        public double bedQualityCountPercent { get; set; }
        public int fullCollectDataSum
        {
            get { return handEnterCount+handEnterAutoCount+goodQualityCount; }
        }
        public double fullCollectDataSumPercent { get; set; }
        public int? tagCountAllinPds { get; set; }
        public bool isLive { get; set; }
        public bool isItog { get; set; }
        public bool isError { get; set; }
        public string errorMessage { get; set; }
    }
    public class DisplayPeriodsValue
    {
        public DisplayPeriodsValue()
        {
            tableValue = new List<SpGetPeriodStatisticData_DTO>();
            frozenRaws = new List<SpGetPeriodStatisticData_DTO>();
        }
        public List<SpGetPeriodStatisticData_DTO> tableValue { get; set; }
        public List<SpGetPeriodStatisticData_DTO> frozenRaws { get; set; }
    }
}
