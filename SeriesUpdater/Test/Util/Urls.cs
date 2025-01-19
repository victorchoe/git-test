﻿namespace Test.Util
{
    public class Urls
    {
        public static readonly string fredBaseUrl = "http://api.stlouisfed.org/fred/";
        public static readonly string yahooBaseUrl = "http://query.yahooapis.com/v1/public/yql?q=";
        public static readonly string ecosBaseUrl = "http://ecos.bok.or.kr/api/";
        public static readonly string quandlBaseUrl = "https://www.quandl.com/api/v3/datasets/";


        // 아래 daily url 들은 모두 처음 통계 포팅용이 아님.
        // 갱신용이기 때문에 그 데이터 핸들링 폭을 작게 설정함.

        //한번에 모든 데이터 가져올 수 있음.
        //        
        public static string FredSeriesObservations =
            fredBaseUrl +
            "series/observations?api_key={0}&series_id={1}&observation_start={2}&observation_end={3}&file_type={4}";

        //http://api.stlouisfed.org/fred/series?series_id=" + seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"]
        public static string FredSeriesInfo =
            fredBaseUrl +
            "series?api_key={0}&series_id={1}&file_type={2}";

        //https://www.quandl.com/api/v3/datasets/MOFJ/INTEREST_RATE_JAPAN_1Y.json?api_key=zgHbAUU3sZz6KctAGdPV&start_date=1985-05-01&end_date=1997-07-01
        public static string QuandlSeriesObservationDaily = quandlBaseUrl + "{0}/{1}.{2}?api_key={3}&start_date={4}&end_date={5}";

        //한번에 모든 데이터를 가져올 수 없음.
        //씨리즈를 추가하는 데에만 사용
        //
        public static string YahooSeriesObservationsDaily =
            yahooBaseUrl +
            "select * from yahoo.finance.historicaldata where symbol = '{0}' and startDate = '{1}' and endDate = '{2}'&format={3}&env=store://datatables.org/alltableswithkeys&diagnostics=false";

        public static string YahooSeriesQuotes =
            yahooBaseUrl +
            "select * from yahoo.finance.quotes where symbol = '{0}'&format={1}&env=store://datatables.org/alltableswithkeys&diagnostics=false";

        public static string YahooSeriesQuotesList =
            yahooBaseUrl +
            "select * from yahoo.finance.quoteslist where symbol = '{0}'&format={1}&env=store://datatables.org/alltableswithkeys&diagnostics=false";

        public static string YahooSeriesBalanceSheet =
            yahooBaseUrl +
            "select * from yahoo.finance.balancesheet where symbol = '{0}'&format={1}&env=store://datatables.org/alltableswithkeys&diagnostics=false";

        public static string YahooSeriesKeyStats =
            yahooBaseUrl +
            "select * from yahoo.finance.keystats where symbol = '{0}'&format={1}&env=store://datatables.org/alltableswithkeys&diagnostics=false";

        public static string YahooSeriesQuant =
            yahooBaseUrl +
            "select * from yahoo.finance.quant where symbol = '{0}'&format={1}&env=store://datatables.org/alltableswithkeys&diagnostics=false";

        #region ecos urls
        //씨리즈 정보 (통계코드 정보), FRED와 다르게 대분류 코드를 입력해 상세코드 목록을 받는다.
        //http://ecos.bok.or.kr/api/StatisticItemList/ZZFMSCRGD24H9X50HMCP/json/kr/1/100000/060Y001/
        public static string EcosSeriesInfo =
            ecosBaseUrl +
            "StatisticItemList/{0}/{1}/kr/1/100000/{2}";



        //
        //http://ecos.bok.or.kr/api/StatisticSearch/ZZFMSCRGD24H9X50HMCP/json/kr/1/100000/060Y001/DD/20161201/20161229/010200000
        public static string EcosSeriesObservationsDaily =
            ecosBaseUrl +
            "StatisticSearch/{0}/{1}/kr/1/100000/{2}/DD/{3}/{4}/{5}";
        #endregion

        #region cf. Xaye Lib.
        public static string Releases =
            fredBaseUrl +
            "releases?api_key={0}&realtime_start={1}&realtime_end={2}&limit={3}&offset={4}&order_by={5}&sort_order={6}";

        public static string Release =
            fredBaseUrl +
            "release?api_key={0}&release_id={1}&realtime_start={2}&realtime_end={3}";

        public static string ReleaseSeries =
            fredBaseUrl +
            "release/series?api_key={0}&release_id={1}&realtime_start={2}&realtime_end={3}&limit={4}&offset={5}&order_by={6}&sort_order={7}&filter_variable={8}&filter_value={9}";

        public static string ReleasesDates =
            fredBaseUrl +
            "releases/dates?api_key={0}&realtime_start={1}&realtime_end={2}&limit={3}&offset={4}&order_by={5}&sort_order={6}&include_release_dates_with_no_data={7}";

        public static string ReleaseDates =
            fredBaseUrl +
            "release/dates?api_key={0}&release_id={1}&realtime_start={2}&realtime_end={3}&limit={4}&offset={5}&sort_order={6}&include_release_dates_with_no_data={7}";

        public static string ReleaseSources =
            fredBaseUrl +
            "release/sources?api_key={0}&release_id={1}&realtime_start={2}&realtime_end={3}";

        public static string Series =
            fredBaseUrl + "series?api_key={0}&series_id={1}&realtime_start={2}&realtime_end={3}";

        public static string SeriesCategories =
            fredBaseUrl + "series/categories?api_key={0}&series_id={1}&realtime_start={2}&realtime_end={3}";

        public static string SeriesRelease =
            fredBaseUrl + "series/release?api_key={0}&series_id={1}&realtime_start={2}&realtime_end={3}";

        public static string SeriesSearch =
            fredBaseUrl +
            "series/search?api_key={0}&realtime_start={1}&realtime_end={2}&limit={3}&offset={4}&order_by={5}&sort_order={6}&filter_variable={7}&filter_value={8}&search_type={9}&search_text={10}";

        public static string SeriesUpdates =
            fredBaseUrl +
            "series/updates?api_key={0}&realtime_start={1}&realtime_end={2}&limit={3}&offset={4}&filter_value={5}";

        public static string SeriesVintageDates =
            fredBaseUrl +
            "series/vintagedates?api_key={0}&series_id={1}&realtime_start={2}&realtime_end={3}&limit={4}&offset={5}&sort_order={6}";

        public static string SeriesObservations =
            fredBaseUrl +
            "series/observations?api_key={0}&series_id={1}&realtime_start={2}&realtime_end={3}&limit={4}&offset={5}&sort_order={6}&observation_start={7}&observation_end={8}&units={9}&frequency={10}&aggregation_method={11}&output_type={12}&file_type={13}&vintage_dates={14}";

        public static string Category = fredBaseUrl + "category?api_key={0}&category_id={1}";

        public static string CategoryRelated =
            fredBaseUrl + "category/related?api_key={0}&category_id={1}&realtime_start={2}&realtime_end={3}";

        public static string CategoryChildern =
            fredBaseUrl + "category/children?api_key={0}&category_id={1}&realtime_start={2}&realtime_end={3}";

        public static string CategorySeries =
            fredBaseUrl +
            "category/series?api_key={0}&category_id={1}&realtime_start={2}&realtime_end={3}&limit={4}&offset={5}&order_by={6}&sort_order={7}&filter_variable={8}&filter_value={9}";

        public static string Sources =
            fredBaseUrl +
            "sources?api_key={0}&realtime_start={1}&realtime_end={2}&limit={3}&offset={4}&order_by={5}&sort_order={6}";

        public static string Source =
            fredBaseUrl + "source?api_key={0}&source_id={1}&realtime_start={2}&realtime_end={3}";

        public static string SourceReleases =
            fredBaseUrl +
            "source/releases?api_key={0}&source_id={1}&realtime_start={2}&realtime_end={3}&limit={4}&offset={5}&order_by={6}&sort_order={7}";
#endregion

    }
}