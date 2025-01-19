using System;
using System.Globalization;
using System.Linq;
using SeriesUpdater.Util;
using SeriesUpdater.Model;
using System.Xml.Linq;
using System.Collections.Generic;

namespace SeriesUpdater.API
{
    public class UstreasApi
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public static List<UsTreasData> GetUSTreasRates(string seriesId, string startDate, string endDate)
        //debug용, id별 개별 호출
        public static List<UsTreasData> GetUSTreasRates(string seriesId, string startDate)
        {
            var seriesData = new List<UsTreasData>();
            log.Info(seriesId);

            if (seriesId.Equals("USTREAS_GS"))
            {
                //log.Info("ustreas id : " + seriesId);
                //log.Info(string.Format(Urls.ustreasYieldCurveRateUrl));
                seriesData = YieldCurveRate(startDate);
            }
            else
            {
                //log.Info(string.Format(Urls.ustreasRealYieldCurveRateUrl));
                seriesData = RealYieldCurveRate(startDate);
            }
            //string result = DownloadData.GetDownloadString(
            //    string.Format(Urls.ustreasRealYieldCurveRateUrl)
            //    );
            return seriesData;

        }

        static List<UsTreasData> YieldCurveRate(string startDate)
        {
            var seriesData = new List<UsTreasData>();

            string result = DownloadData.GetDownloadString(
                string.Format(Urls.ustreasYieldCurveRateUrl)
                );

            //log.Info(result);
            //log.Info("Debug : YieldCurveRate Download Completed");
            XElement yield = XElement.Parse(result);

            if (!yield.IsEmpty)
            {
                //log.Info("Debug : YieldCurveRate yieldData");

                var yieldData =
                    from el in yield.Descendants("G_NEW_DATE")
                    where !el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_1MONTH").Value.Equals("") &&
                    DateTime.Parse(el.Element("BID_CURVE_DATE").Value, CultureInfo.CreateSpecificCulture("en-US")) > DateTime.Parse(startDate)
                    let BID_CURVE_DATE = DateTime.Parse(el.Element("BID_CURVE_DATE").Value, CultureInfo.CreateSpecificCulture("en-US"))
                    let BC_1MONTH = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_1MONTH").Value), 2)
                    let BC_2MONTH = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_2MONTH").Value), 2)
                    let BC_3MONTH = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_3MONTH").Value), 2)
                    let BC_6MONTH = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_6MONTH").Value), 2)
                    let BC_1YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_1YEAR").Value), 2)
                    let BC_2YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_2YEAR").Value), 2)
                    let BC_3YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_3YEAR").Value), 2)
                    let BC_5YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_5YEAR").Value), 2)
                    let BC_7YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_7YEAR").Value), 2)
                    let BC_10YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_10YEAR").Value), 2)
                    let BC_20YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_20YEAR").Value), 2)
                    let BC_30YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_BC_CAT").Element("G_BC_CAT").Element("BC_30YEAR").Value), 2)
                    select new UsTreasData
                    {
                        BusinessDate = BID_CURVE_DATE,
                        Series1 = BC_1MONTH,
                        Series2 = BC_2MONTH,
                        Series3 = BC_3MONTH,
                        Series4 = BC_6MONTH,
                        Series5 = BC_1YEAR,
                        Series6 = BC_2YEAR,
                        Series7 = BC_3YEAR,
                        Series8 = BC_5YEAR,
                        Series9 = BC_7YEAR,
                        Series10 = BC_10YEAR,
                        Series11 = BC_20YEAR,
                        Series12 = BC_30YEAR
                    };

                //log.Info(yieldData.Count());

                //foreach (var item in yieldData)
                //{
                //    log.Info(item.BusinessDate.ToShortDateString() + " : " + item.Series1 + " : " + item.Series2);
                //}
                //log.Info("Debug : YieldCurveRate yieldData Completed");

                seriesData = yieldData.ToList();

                //log.Info("Debug : YieldCurveRate yieldData Return");

            }
            else
            {
                log.Info("USTreas : No Data");
            }

            return seriesData;
        }

        static List<UsTreasData> RealYieldCurveRate(string startDate)
        {
            var seriesData = new List<UsTreasData>();

            string result = DownloadData.GetDownloadString(
                string.Format(Urls.ustreasRealYieldCurveRateUrl)
                );

            //log.Info(result);
            XElement yield = XElement.Parse(result);

            if (!yield.IsEmpty)
            {
                var yieldData =
                    from el in yield.Descendants("G_NEW_DATE")
                    where !el.Element("LIST_G_TC_5YEAR").Element("G_TC_5YEAR").Element("TC_5YEAR").Value.Equals("") && 
                    DateTime.Parse(el.Element("TIPS_CURVE_DATE").Value, CultureInfo.CreateSpecificCulture("en-US")) > DateTime.Parse(startDate)
                    let TIPS_CURVE_DATE = DateTime.Parse(el.Element("TIPS_CURVE_DATE").Value, CultureInfo.CreateSpecificCulture("en-US"))
                    let TC_5YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_TC_5YEAR").Element("G_TC_5YEAR").Element("TC_5YEAR").Value), 2)
                    let TC_7YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_TC_5YEAR").Element("G_TC_5YEAR").Element("TC_7YEAR").Value), 2)
                    let TC_10YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_TC_5YEAR").Element("G_TC_5YEAR").Element("TC_10YEAR").Value), 2)
                    let TC_20YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_TC_5YEAR").Element("G_TC_5YEAR").Element("TC_20YEAR").Value), 2)
                    let TC_30YEAR = Math.Round(decimal.Parse(el.Element("LIST_G_TC_5YEAR").Element("G_TC_5YEAR").Element("TC_30YEAR").Value), 2)
                    select new UsTreasData
                    {
                        BusinessDate = TIPS_CURVE_DATE,
                        Series1 = TC_5YEAR,
                        Series2 = TC_7YEAR,
                        Series3 = TC_10YEAR,
                        Series4 = TC_20YEAR,
                        Series5 = TC_30YEAR
                    };

                //log.Info(yieldData.Count());

                //foreach (var item in yieldData)
                //{
                //    log.Info(item.BusinessDate.ToShortDateString() + " : " + item.Series1 + " : " + item.Series2);
                //}

                seriesData = yieldData.ToList();
            }
            else
            {
                log.Info("USTreas : No Data");
            }

            return seriesData;
        }

    }
}
