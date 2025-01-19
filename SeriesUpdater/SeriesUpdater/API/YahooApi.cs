using Newtonsoft.Json.Linq;
using SeriesUpdater.Model;
using SeriesUpdater.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeriesUpdater.API
{
    public class YahooApi
    {        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);        
        private static string returnType = "json";

        public static List<SeriesData> GetSeriesData(string seriesId, string startDate)
        {
            var seriesData = new List<SeriesData>();

            //seriesId를 mapId로 
            string mapId = DbHandler.GetYahooId(seriesId);

            string result = DownloadData.GetDownloadString(
                string.Format(Urls.YahooHistoricalData, mapId, (long)DateConverter.ToUnixTimestamp(DateTime.Now.AddDays(-21)), (long)DateConverter.ToUnixTimestamp(DateTime.Now))
                );

            if (!String.IsNullOrEmpty(result))
            {
                var yahooData =
                    from row in result.Split('\n')
                    .Skip(1)
                    let col = row.Split(',')
                    where col.ElementAt(1) != "null" && DateTime.Parse(col.ElementAt(0), System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) >= DateTime.Parse(startDate)
                    select new SeriesData
                    {
                        BusinessDate = DateTime.Parse(col.ElementAt(0), System.Globalization.CultureInfo.CreateSpecificCulture("en-US")),
                        EconomicIndex = decimal.Parse(col.ElementAt(4))
                    };

                seriesData = yahooData.ToList();
            }
            else
            {
                log.Info("Yahoo : No Data");
            }

            return seriesData;
        }

        public static List<SeriesData> GetSeriesData(string seriesId, string startDate, string endDate)
        {
            var seriesData = new List<SeriesData>();
            string delimiter = "_";
            string yahooSeriesId = seriesId.Substring(seriesId.IndexOf(delimiter) + 1);
            //@가 있을 경우에만 ^로 치환
            yahooSeriesId = yahooSeriesId.StartsWith("@") ? yahooSeriesId.Replace("@", "^") : yahooSeriesId;

            string result = DownloadData.GetDownloadString(
                string.Format(Urls.YahooSeriesObservationsDaily, yahooSeriesId, startDate, endDate, returnType)
                );

            Console.WriteLine(result);

            if (!String.IsNullOrEmpty(result))
            {
                JObject yahooJson = JObject.Parse(result);

                //Console.WriteLine(yahooJson.ToString());

                // 0 이상인 것만 정상 컬렉션
                if ((int)yahooJson["query"]["count"] > 1)
                {
                    var yahooData = from p in yahooJson["query"]["results"]["quote"].AsParallel().ToList()
                                    select new SeriesData
                                    {
                                        BusinessDate = (DateTime)p["Date"],
                                        EconomicIndex = (decimal)p["Adj_Close"]
                                    };

                    seriesData = yahooData.ToList();
                }
                // yahoo json 리턴 문서가 1개일 경우와 그 이상일 경우 구조가 다르기에 1개일 경우만 따로 처리함.
                else if ((int)yahooJson["query"]["count"] == 1)
                {
                    seriesData.Add(new SeriesData() { BusinessDate = (DateTime)yahooJson["query"]["results"]["quote"]["Date"], EconomicIndex = (decimal)yahooJson["query"]["results"]["quote"]["Adj_Close"] });
                }
                else
                {
                    log.Info("YQL : Check Collection");
                }
            }
            else
            {
                log.Info("YQL : Invalid Item Code or No Data");
            }

            return seriesData;
        }
    }
}
