using System;

namespace Test.Model
{
    public class FredSeriesInfo
    {
        public string   Id                      { get; set; }
        public string   Title                   { get; set; }
        public DateTime ObservationStart        { get; set; }
        public DateTime ObservationEnd          { get; set; }
        public string   Frequency               { get; set; }
        public string   FrequencyShort          { get; set; }
        public string   Units                   { get; set; }
        public string   UnitsShort              { get; set; }
        public string   SeasonalAdjustment      { get; set; }
        public string   SeasonalAdjustmentShort { get; set; }
        public DateTime LastUpdated             { get; set; }
        public int      Popularity              { get; set; }
        public string   Notes                   { get; set; }
    }
}
