using System;

namespace SeriesUpdater.Model
{
    public class YahooData
    {
        public DateTime BusinessDate    { get; set; }
        public decimal  OpenPrice       { get; set; }
        public decimal  HighPrice       { get; set; }
        public decimal  LowPrice        { get; set; }
        public decimal  ClosePrice      { get; set; }
        public long     VolumeSize      { get; set; }
        public decimal  AdjClosePrice   { get; set; }
    }
}
