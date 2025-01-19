using System;

namespace Test.Model
{
    public class IndexInfo
    {
        public string Id { get; set; }
        public string EngName { get; set; }
        public string KorName { get; set; }
        public string Units { get; set; }
        public string Frequency { get; set; }
        public string SeasonalAdjustment { get; set; }
        public string CountryCode { get; set; }
        public DateTime SeriesFirstDate { get; set; }
        public DateTime? SeriesLastDate { get; set; }
        public int DissContinue { get; set; }
        public int SeriesType { get; set; }
        public DateTime SeriesRegistDate { get; set; }
        public DateTime SeriesUpdateDate { get; set; }
        public int DeleteYn { get; set; }
    }
}
