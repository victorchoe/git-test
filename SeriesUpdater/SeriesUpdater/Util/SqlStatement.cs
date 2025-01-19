namespace SeriesUpdater.Util
{
    public class SqlStatement
    {
        public static string dropTable               = "if exists (select * from sysobjects where id = object_id('{0}')) drop table {1}";
        public static string createTable             = "create table {0} ( business_date date not null, economic_index decimal(30, 4) not null)";
        public static string addIndex                = "alter table {0} add primary key (business_date)";
        public static string insertSeriesTable       = "insert into {0} values (@business_date, @economic_index)";
        public static string insertUstreasGsTable    = "insert into {0} values(@business_date,@gs1mo,@gs2mo,@gs3mo,@gs6mo,@gs1,@gs2,@gs3,@gs5,@gs7,@gs10,@gs20,@gs30)";
        public static string insertUstreasFiiTable   = "insert into {0} values(@business_date,@fii5,@fii7,@fii10,@fii20,@fii30)";
        public static string updateIndexInfoTable    = "UPDATE INDEX_INFO SET sldate = '{0}', upt_date = '{1}' WHERE id = '{2}'";        
        public static string selectEcosCategoryTable = "SELECT stat_code FROM ECOS_CATEGORY WHERE item_code = '{0}'";
        public static string selectYahooMapTable     = "select map_id from YAHOO_MAP_CODE where id = '{0}'";
        public static string selectQuandlCategoryTable = "SELECT database_code FROM QUANDL_CATEGORY WHERE dataset_code = '{0}'";
        public static string selectIndexInfoDaily    = "SELECT * FROM index_info WHERE diss = 0 AND delete_yn = 0 AND freq = 'D'";
        public static string selectIndexInfoMonthly  = "SELECT * FROM index_info WHERE diss = 0 AND delete_yn = 0 AND freq = 'M'";
    }
}
