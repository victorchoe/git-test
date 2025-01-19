using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Test.Util;
using Test.Model;
using System.Globalization;

namespace Test.API
{
    //월간/일간 분기
    //기타 분기
    public class EcosApi
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                                   StatCode  = (string)p["STAT_CODE"],
                                   StatName  = (string)p["STAT_NAME"],
                                   ItemCode  = (string)p["ITEM_CODE"],
                                   ItemName  = (string)p["ITEM_NAME"],
                                   Cycle     = (string)p["CYCLE"],
                                   StartTime = DateTime.ParseExact(p["START_TIME"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture),
                                   EndTime   = DateTime.ParseExact(p["END_TIME"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture)
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
