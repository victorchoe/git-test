using Newtonsoft.Json.Linq;
using SeriesUpdater.Model;
using SeriesUpdater.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeriesUpdater.API
{
    public class QuandlApi
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string apiKey = Config.quandlKey;
        private static string returnType = "json";

        public static List<SeriesData> GetSeriesData(string seriesId, string startDate, string endDate, string freq)
        {

            var seriesData = new List<SeriesData>();
            string delimiter = "_";
            string quandlSeriesId = seriesId.Substring(seriesId.IndexOf(delimiter) + 1);
            string databaseCode = DbHandler.GetQuandlDatabaseCode(quandlSeriesId);
            string result = string.Empty;

            if (databaseCode.Length != 0)
            {
                if (freq.Equals("Daily"))
                {
                    result = DownloadData.GetDownloadString(
                        string.Format(Urls.QuandlSeriesObservationsDaily, databaseCode, quandlSeriesId, returnType, apiKey, startDate, endDate)
                    );
                }

            }

            if (!String.IsNullOrEmpty(result))
            {
                JObject quandlJson = JObject.Parse(result);
                //IEnumerable<SeriesData> quandlData;

                try
                {
                    var quandlData = from p in (JArray)quandlJson["dataset"]["data"]
                                     select new SeriesData
                                     {
                                         BusinessDate = (DateTime)p[0],
                                         EconomicIndex = (decimal)p[1]
                                     };

                    seriesData = quandlData.ToList();
                }
                catch (Exception)
                {
                    log.Info("No Data");
                }

                //seriesData = ecosData.ToList();
            }
            else
            {
                //Console.WriteLine(yahooJson.ToString());
                log.Info("Quandl : Invalid Dataset Code or Database Code");
            }

            return seriesData;
        }
    }
}
