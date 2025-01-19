using System;

namespace SeriesUpdater.Util
{
    //데이터 소스별 날짜 포멧 변환
    public class DateConverter
    {
        public static string FredDate(DateTime fredDate)
        {
            return fredDate.ToShortDateString();
        }

        public static string UstreasDate(DateTime ustreasDate)
        {
            return ustreasDate.ToShortDateString();
        }

        public static string EcosDate(DateTime ecosDate)
        {
            return ecosDate.ToString("yyyyMMdd");
        }

        public static string EcosMonthDate(DateTime ecosDate)
        {
            return ecosDate.ToString("yyyyMM");
        }

        public static string YahooDate(DateTime yahooDate)
        {
            return yahooDate.ToShortDateString();
        }

        public static string QuandlDate(DateTime quandlDate)
        {
            return quandlDate.ToShortDateString();
        }

        //yahoo csv download url은 항상 unixtimestamp를 사용한다.
        //아래는 dollar index를 일간으로 5일치를 받는 것인데, 기간을 unixtimestamp 값으로 기간을 설정한다. 항상 지금부터 14일전으로 query
        //https://query1.finance.yahoo.com/v7/finance/download/DX-Y.NYB?period1=1612569600&period2=1613001600&interval=1d&events=history&includeAdjustedClose=true
        public static double ToUnixTimestamp(DateTime datetime)
        {
            //Unix timestamp Is seconds past epoch
            return (datetime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime ToDateTime(double unixTimeStamp)
        {
            //Unix timestamp Is seconds past epoch
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp).ToLocalTime();
        }

    }
}