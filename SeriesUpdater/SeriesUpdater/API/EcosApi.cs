using Newtonsoft.Json.Linq;
using SeriesUpdater.Model;
using SeriesUpdater.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SeriesUpdater.API
{
    public class EcosApi
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string apiKey = Config.ecosKey;
        private static string returnType = "json";

        public static List<SeriesData> GetSeriesData(string seriesId, string startDate, string endDate, string freq)
        {

            var seriesData = new List<SeriesData>();
            string delimiter = "_";
            string ecosSeriesId = seriesId.Substring(seriesId.IndexOf(delimiter) + 1);
            string statCode = DbHandler.GetEcosStatCode(ecosSeriesId);
            string result = string.Empty;
                        
            if (statCode.Length != 0)
            {
                if (freq.Equals("Daily"))
                {
                    result = DownloadData.GetDownloadString(
                        string.Format(Urls.EcosSeriesObservationsDaily, apiKey, returnType, statCode, startDate, endDate, ecosSeriesId)
                    );
                }
                else if (freq.Equals("Monthly"))
                {
                    result = DownloadData.GetDownloadString(
                        string.Format(Urls.EcosSeriesObservationsMonthly, apiKey, returnType, statCode, startDate, endDate, ecosSeriesId)
                    );
                }
                
            }            

            if (!String.IsNullOrEmpty(result))
            {
                JObject ecosJson = JObject.Parse(result);
                IEnumerable<SeriesData> ecosData;
                try
                {
                    ecosData = from p in ecosJson["StatisticSearch"]["row"].AsParallel()
                               //where p["DATA_VALUE"] != null
                               select new SeriesData
                                   {
                                       //BusinessDate = DateTime.ParseExact((string)p["TIME"], "yyyyMMdd", CultureInfo.InvariantCulture),
                                       BusinessDate = freq.Equals("Daily") ? DateTime.ParseExact((string)p["TIME"], "yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.ParseExact((string)p["TIME"], "yyyyMM", CultureInfo.InvariantCulture),
                                       EconomicIndex = (decimal)p["DATA_VALUE"]
                                   };
                    seriesData = ecosData.ToList();
                }
                catch (Exception)
                {
                    //ecosData = null;
                    //seriesData = null;
                    log.Info("No Data");
                }                

                //seriesData = ecosData.ToList();
            }
            else
            {
                //Console.WriteLine(yahooJson.ToString());
                log.Info("ECOS : Invalid Item Code or Stat Code");
            }

            return seriesData;
        }

        public static void GetSeriesInfo(string statCode)
        {
            log.Info("ECOS Get Series Info. : " + statCode.ToUpper());
            string apiKey = Config.ecosKey;
            string returnType = "json";

            string result = DownloadData.GetDownloadString(
                string.Format(Urls.EcosSeriesInfo, apiKey, returnType, statCode)
                );

            //IEnumerable<Model.FredData> fredData;

            // 장애시 null 반환 대응
            // YQL과 다르게 자동 에러 처리되어 null을 받음.
            if (!String.IsNullOrEmpty(result))
            {
                JObject ecosJson = JObject.Parse(result);

                //Console.WriteLine(fredJson.ToString());

                var ecosInfo = from p in ecosJson["StatisticItemList"]["row"]
                               select new EcosSeriesInfo
                               {
                                   StatCode = (string)p["STAT_CODE"],
                                   StatName = (string)p["STAT_NAME"],
                                   ItemCode = (string)p["ITEM_CODE"],
                                   ItemName = (string)p["ITEM_NAME"],
                                   Cycle = (string)p["CYCLE"],
                                   StartTime = DateTime.ParseExact(p["START_TIME"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture),
                                   EndTime = DateTime.ParseExact(p["END_TIME"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture)
                               };


                foreach (var item in ecosInfo)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}"
                        , item.StatCode, item.StatName, item.ItemCode, item.ItemName, item.Cycle, item.StartTime, item.EndTime
                        );
                }
                //string tdate = "2016-12-30 15:46:26-06";
                //Console.WriteLine(tdate.Substring(0, 19));
                //Console.WriteLine(DateTime.ParseExact(tdate.Substring(0, 19), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));

            }
            else
            {                
                log.Info("Ecos DB : Invalid Series ID or No Data");
            }

        }

    }
}
