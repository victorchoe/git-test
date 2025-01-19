using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;
using SeriesUpdater.Util;
using SeriesUpdater.Model;
using System.Collections.Generic;

namespace SeriesUpdater.API
{
    // 모든 씨리즈 리턴은 에러가 나서 없다면, null을 리턴하고 null이면 로깅하고 다음 것을 진행하는 형태로 진행함.
    // 즉, 특정 씨리즈의 에러에 전체가 중단되면 안된다.

    public class FredApi
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string apiKey = Config.fredKey;
        private static string returnType = "json";

        
        public static List<SeriesData> GetSeriesData(string seriesId, string startDate, string endDate)
        {
            var seriesData = new List<SeriesData>();
            string delimiter = "_";
            string fredSeriesId = seriesId.Substring(seriesId.IndexOf(delimiter)+1);

            string result = DownloadData.GetDownloadString(
                string.Format(Urls.FredSeriesObservations, apiKey, fredSeriesId, startDate, endDate, returnType)
                );

            if (!String.IsNullOrEmpty(result))
            {
                JObject fredJson = JObject.Parse(result);

                //var fredData = from p in fredJson["observations"].ToList()
                var fredData = from p in fredJson["observations"].AsParallel().ToList()
                               where (string)p["value"] != "."
                               select new SeriesData
                               {
                                   BusinessDate = (DateTime)p["date"],
                                   EconomicIndex = (decimal)p["value"]
                               };

                seriesData = fredData.ToList();
            }
            else
            {
                log.Info("FRED : Invalid Item Code or No Data");                
            }

            return seriesData;
        }


        public static void GetSeriesInfo(string seriesId)
        {
            log.Info("FRED Get Series Info. : " + seriesId.ToUpper());
            
            string result = DownloadData.GetDownloadString(
                string.Format(Urls.FredSeriesInfo, apiKey, seriesId, returnType)
                );

            //IEnumerable<Model.FredData> fredData;

            // 장애시 null 반환 대응
            // YQL과 다르게 자동 에러 처리되어 null을 받음.
            if (!String.IsNullOrEmpty(result))
            {
                JObject fredJson = JObject.Parse(result);

                //Console.WriteLine(fredJson.ToString());

                var fredInfo = from p in fredJson["seriess"]
                               select new FredSeriesInfo
                               {
                                   Id                      = (string)p["id"],
                                   Title                   = (string)p["title"],
                                   ObservationStart        = (DateTime)p["observation_start"],
                                   ObservationEnd          = (DateTime)p["observation_end"],
                                   Frequency               = (string)p["frequency"],
                                   FrequencyShort          = (string)p["frequency_short"],
                                   Units                   = (string)p["units"],
                                   UnitsShort              = (string)p["units_short"],
                                   SeasonalAdjustment      = (string)p["seasonal_adjustment"],
                                   SeasonalAdjustmentShort = (string)p["seasonal_adjustment_short"],
                                   LastUpdated             = DateTime.ParseExact(p["last_updated"].ToString().Substring(0,19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                                   Popularity              = (int)p["popularity"],
                                   Notes                   = (string)p["notes"]
                               };


                foreach (var item in fredInfo)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}"
                        , item.Id, item.Title, item.ObservationStart, item.ObservationEnd, item.Frequency, item.FrequencyShort
                        , item.Units, item.UnitsShort, item.SeasonalAdjustment, item.SeasonalAdjustmentShort, item.LastUpdated, item.Popularity, item.Notes
                        );                    
                }
                string tdate = "2016-12-30 15:46:26-06";
                Console.WriteLine(tdate.Substring(0,19));
                Console.WriteLine(DateTime.ParseExact(tdate.Substring(0, 19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));

            }
            else
            {
                //Console.WriteLine(yahooJson.ToString());
                log.Info("FRED DB : Invalid Series ID or No Data");                
            }

        }

    }
}
