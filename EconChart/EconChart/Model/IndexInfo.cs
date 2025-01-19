using System;

namespace EconChart.Model
{
    public class IndexInfo
    {
        public string SeriesId { get; set; }
        public string EnglishName { get; set; }
        public string KoreanName { get; set; }
        public string Units { get; set; }
        public string Freq { get; set; }
        public string Sa { get; set; }
        public DateTime SeriesFirstDate { get; set; }
        public DateTime SeriesLastDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
