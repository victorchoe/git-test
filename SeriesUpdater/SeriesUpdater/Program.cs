using SeriesUpdater.Model;
using SeriesUpdater.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeriesUpdater
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        static void Main(string[] args)
        {
            if (NetworkCheck.IsInternetConnected())
            {
                DailyUpdater();
                MonthlyUpdater();
            }
            else
            {
                log.Error("Check!! Internet");
            }
        }

        static void MonthlyUpdater()
        {
            log.Info("-- //--------------------------------------------------------------------------");
            log.Info("Monthly Updater : Start");
            log.Info("-- //--------------------------------------------------------------------------");

            List<IndexInfo> listIndexInfo = DbHandler.GetIndexInfoMonthly();

            if (listIndexInfo.Count > 0)
            {
                var fredSeries = listIndexInfo.Where(stype => stype.SeriesType == 1);
                var ecosSeries = listIndexInfo.Where(stype => stype.SeriesType == 2);

                MonthlyFred(fredSeries.ToList());
                MonthlyEcos(ecosSeries.ToList());
            }
            else
            {
                log.Info("Monthly Updater : Check Index_Info table");
            }

            log.Info("-- //--------------------------------------------------------------------------");
            log.Info("Monthly Updater : End");
            log.Info("-- //--------------------------------------------------------------------------");
        }

        static void MonthlyEcos(List<IndexInfo> ecosSeries)
        {
            log.Info("Monthly Ecos List : " + ecosSeries.Count);
            foreach (var item in ecosSeries)
            {
                //Console.WriteLine("{0} : {1} : {2}", item.Id, item.SeriesFirstDate.ToString("yyyy-MM-dd"), item.SeriesLastDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"));
                DbHandler.InsertMonthlySeriesData(item.Id, item.SeriesType, item.SeriesFirstDate, item.SeriesLastDate);

            }
        }

        static void MonthlyFred(List<IndexInfo> fredSeries)
        {
            log.Info("Monthly Fred List : " + fredSeries.Count);
            foreach (var item in fredSeries)
            {
                //Console.WriteLine("{0} : {1} : {2}", item.Id, item.SeriesFirstDate.ToString("yyyy-MM-dd"), item.SeriesLastDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"));
                DbHandler.InsertMonthlySeriesData(item.Id, item.SeriesType, item.SeriesFirstDate, item.SeriesLastDate);

            }
        }

        // (index_info's stype)
        // FRED Series  : SeriesType = 1  
        // ECOS Series  : SeriesType = 2
        // Yahoo Series : SeriesType = 3
        // QUANDL Series : SeriesType = 4
        // USTreas Series : SeriesType = 6
        static void DailyUpdater()
        {
            log.Info("-- //--------------------------------------------------------------------------");
            log.Info("Daily Updater : Start");
            log.Info("-- //--------------------------------------------------------------------------");

            List<IndexInfo> listIndexInfo = DbHandler.GetIndexInfoDaily();
            //select id, stype, sfdate, sldate FROM index_info WHERE diss = 0 AND delete_yn = 0 AND freq = 'D' and stype=6;

            if (listIndexInfo.Count > 0)
            {
                var fredSeries = listIndexInfo.Where(stype => stype.SeriesType == 1);
                var ecosSeries = listIndexInfo.Where(stype => stype.SeriesType == 2);
                var quandlSeries = listIndexInfo.Where(stype => stype.SeriesType == 4);
                var ustreasSeries = listIndexInfo.Where(stype => stype.SeriesType == 6);

                // yahoo api 서비스 중단, csv 다운로드는 계속
                var yahooSeries = listIndexInfo.Where(stype => stype.SeriesType == 3);
                
                try
                {
                    Parallel.Invoke(
                        () =>
                        {
                            DailyFred(fredSeries.ToList());
                        }
                        ,
                        () =>
                        {
                            DailyEcos(ecosSeries.ToList());
                        }
                        ,
                        () =>
                        {
                            DailyQuandl(quandlSeries.ToList());
                        }
                        ,
                        () =>
                        {
                            DailyUstreas(ustreasSeries.ToList());
                        }
                        ,
                        () =>
                        {
                            DailyYahoo(yahooSeries.ToList());
                        }
                    );
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("\nThere were exceptions:\n");
                    foreach (var exception in ex.InnerExceptions)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

                //DailyFred(fredSeries.ToList());
                //DailyEcos(ecosSeries.ToList());
                //DailyYahoo(yahooSeries.ToList());
            }
            else
            {
                log.Info("Daily Updater : Check Index_Info table");
            }

            log.Info("-- //--------------------------------------------------------------------------");
            log.Info("Daily Updater : End");
            log.Info("-- //--------------------------------------------------------------------------");

        }

        // 아래는 동일한 내용. 별다른 분기 없으면 하나로. 아니면 위에서 처리
        // 
        static void DailyFred(List<IndexInfo> fredSeries)
        {
            log.Info("Daily Fred List : " + fredSeries.Count);
            foreach (var item in fredSeries)
            {
                //Console.WriteLine("{0} : {1} : {2}", item.Id, item.SeriesFirstDate.ToString("yyyy-MM-dd"), item.SeriesLastDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"));
                DbHandler.InsertSeriesData(item.Id, item.SeriesType, item.SeriesFirstDate, item.SeriesLastDate);
            }
        }

        static void DailyEcos(List<IndexInfo> ecosSeries)
        {
            log.Info("Daily Ecos List : " + ecosSeries.Count);
            foreach (var item in ecosSeries)
            {
                //Console.WriteLine("{0} : {1} : {2}", item.Id, item.SeriesFirstDate.ToString("yyyy-MM-dd"), item.SeriesLastDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"));
                DbHandler.InsertSeriesData(item.Id, item.SeriesType, item.SeriesFirstDate, item.SeriesLastDate);
            }
        }

        static void DailyQuandl(List<IndexInfo> quandlSeries)
        {
            log.Info("Daily Quandl List : " + quandlSeries.Count);
            foreach (var item in quandlSeries)
            {
                //Console.WriteLine("{0} : {1} : {2}", item.Id, item.SeriesFirstDate.ToString("yyyy-MM-dd"), item.SeriesLastDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"));
                DbHandler.InsertSeriesData(item.Id, item.SeriesType, item.SeriesFirstDate, item.SeriesLastDate);
            }
        }

        static void DailyUstreas(List<IndexInfo> ustreasSeries)
        {
            log.Info("Daily US Treas List : " + ustreasSeries.Count);
            foreach (var item in ustreasSeries)
            {
                //Console.WriteLine("{0} : {1} : {2}", item.Id, item.SeriesFirstDate.ToString("yyyy-MM-dd"), item.SeriesLastDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"));
                //log.Info(item.Id + ":" + item.SeriesType + ":" + item.SeriesFirstDate + ":" + item.SeriesLastDate);
                
                DbHandler.InsertSeriesData(item.Id, item.SeriesType, item.SeriesFirstDate, item.SeriesLastDate);
            }
        }

        
        static void DailyYahoo(List<IndexInfo> yahooSeries)
        {
            log.Info("Daily Yahoo List : " + yahooSeries.Count);
            foreach (var item in yahooSeries)
            {
                //Console.WriteLine("{0} : {1} : {2}", item.Id, item.SeriesFirstDate.ToString("yyyy-MM-dd"), item.SeriesLastDate?.ToString("yyyy-MM-dd") ?? DateTime.Now.ToString("yyyy-MM-dd"));
                DbHandler.InsertSeriesData(item.Id, item.SeriesType, item.SeriesFirstDate, item.SeriesLastDate);

            }
        }
        
    }
}
