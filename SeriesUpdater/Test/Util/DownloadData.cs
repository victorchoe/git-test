using System;
using System.Text;
using System.Net;

namespace Test.Util
{
    public class DownloadData
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Get Fred Data by json string
        // 주간/월간 자료는 항상 전체
        // 시즌 조정과 특정 지점을 100으로 놓고 보는 시리즈가 많음.
        // 일간은 기간 조건 observation_start 사용
        // "http://api.stlouisfed.org/fred/series/observations?series_id=" + fredID + "&api_key=2663b8d59144b89099b15cac8952d69e&observation_start=" + nextDate
        // GetFredData("http://api.stlouisfed.org/fred/series/observations?series_id=dgs10&api_key=2663b8d59144b89099b15cac8952d69e&file_type=json");
        //List<Price> prices = Parse(csvData);
        public static string GetDownloadString(string url)
        {            
            string myData = string.Empty;
            WebClient client = new WebClient();

            //eurostat의 경우 아래처럼  ie6 환경으로 접근해야 함.
            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                "(compatible; MSIE 6.0; Windows NT 5.1; " +
                ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            //client.Headers.Add ("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");


            client.Encoding = Encoding.UTF8;

            try {
                log.Info($"Download Start for URL : {url}");                
                myData = client.DownloadString(Uri.EscapeUriString(url));
                //myData = client.DownloadString(url);
            } catch (WebException we) {
                myData = string.Empty;
                log.Error("Downloading Error : ",we);
            } finally {
                client.Dispose();
            }
            return myData;            
        }

        public static string GetDownloadDataAsString(string url)
        {
            string myData = string.Empty;
            WebClient client = new WebClient();            

            try
            {
                log.Info($"Download Start for URL : {url}");
                byte[] docBytes =  client.DownloadData(Uri.EscapeUriString(url));
                myData = docBytes.ToString();
                //myData = client.DownloadString(url);
            }
            catch (WebException we)
            {
                myData = string.Empty;
                log.Error("Downloading Error : ", we);
            }
            finally
            {
                client.Dispose();
            }
            return myData;
        }

        //public static string GetYahooDailyData(string itemCode, string startDate, string endDate)
        //{
        //    string yahooData = string.Empty;
        //    return yahooData;
        //}

        // yahoo.finance.historicaldata에 대한 api는 항상 정확한 itemCode, 시작일, 종료일이 있어야 함.
        // 데이터가 없을 경우
        //        {
        //  "query": {
        //    "count": 0,
        //    "created": "2016-12-28T07:50:23Z",
        //    "lang": "en-US",
        //    "results": null
        //  }
        //}

        public static string GetYahooHistoricalData(string itemCode, string startDate, string endDate)        
        {
            string yahooData = string.Empty;
            WebClient client = new WebClient();

            try
            {
                System.Text.StringBuilder url = new System.Text.StringBuilder();
                url.Append("http://query.yahooapis.com/v1/public/yql?");                
                url.Append("q=" + System.Uri.EscapeUriString("select * from yahoo.finance.historicaldata where symbol = '" + itemCode + "' and startDate = '" + startDate + "' and endDate = '" + endDate + "'"));
                url.Append("&format=json");
                url.Append("&env=store://datatables.org/alltableswithkeys");

                //System.Console.WriteLine(url.ToString());

                yahooData = client.DownloadString(url.ToString());
            } catch (WebException) {
                yahooData = string.Empty;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            } finally {
                client.Dispose();
            }
            return yahooData;
        }

        public static string GetYahooCsvData(string id, string startYear, string startMonth, string startDay, string endYear, string endMonth, string endDay)
        {
            string yahooData = string.Empty;

            string requestUrl =
                @"http://ichart.finance.yahoo.com/table.csv?s=[symbol]&a=" +
                "[startMonth]&b=[startDay]&c=[startYear]&d=[endMonth]&e=" +
                "[endDay]&f=[endYear]&g=d&ignore=.csv";

            //월은 -1해야 바르게 적용됨.
            requestUrl = requestUrl.Replace("[symbol]", id);
            requestUrl = requestUrl.Replace("[startMonth]", (System.Convert.ToInt16(startMonth) - 1).ToString());
            requestUrl = requestUrl.Replace("[startDay]", startDay);
            requestUrl = requestUrl.Replace("[startYear]", startYear);
            //requestUrl = requestUrl.Replace("[endMonth]", (Convert.ToInt16(endMonth) - 1).ToString());
            //최근월은 무조건 99로 설정되기 때문에 변수핸들링 불필요
            requestUrl = requestUrl.Replace("[endMonth]", endMonth);
            requestUrl = requestUrl.Replace("[endDay]", endDay);
            requestUrl = requestUrl.Replace("[endYear]", endYear);

            WebClient client = new WebClient();

            try
            {
                yahooData = client.DownloadString(requestUrl);
            }
            catch (WebException)
            {
                //야후에 등록되지 않은 날짜를 요구하면 그냥 공백을 넣어줌
                yahooData = string.Empty;
            }
            finally
            {
                client.Dispose();
            }
            return yahooData;
        }

    }
}
