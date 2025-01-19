using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SeriesUpdater.Model;
using SeriesUpdater.API;
using System.Linq;

namespace SeriesUpdater.Util
{    
    class DbHandler
    {
        static string connectionString = Config.connectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Get Index_Info Table - Monthly
        public static List<IndexInfo> GetIndexInfoMonthly()
        {
            log.Info("Get INDEX_INFO Table for Monthly Series");

            string SQL = SqlStatement.selectIndexInfoMonthly;

            var listIndexInfo = new List<IndexInfo>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //listIndexInfo.Add(new IndexInfo(reader.GetString(0),...));
                                var indexInfo = new IndexInfo();

                                indexInfo.Id = reader.GetString(0);
                                indexInfo.EngName = reader.GetString(1);
                                indexInfo.KorName = reader.GetString(2);
                                indexInfo.Units = reader.GetString(3);
                                indexInfo.Frequency = reader.GetString(4);
                                indexInfo.SeasonalAdjustment = reader.GetString(5);
                                indexInfo.SeriesFirstDate = reader.GetDateTime(6);
                                indexInfo.SeriesLastDate = reader.IsDBNull(7) ? null : (DateTime?)reader.GetDateTime(7);
                                indexInfo.DissContinue = reader.GetByte(8);
                                indexInfo.SeriesType = reader.GetByte(9);
                                indexInfo.SeriesRegistDate = reader.GetDateTime(10);
                                indexInfo.SeriesUpdateDate = reader.GetDateTime(11);
                                indexInfo.DeleteYn = reader.GetByte(12);

                                listIndexInfo.Add(indexInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error INDEX_INFO Table for Daily Series", ex);
                throw;
            }

            return listIndexInfo;
        }
        #endregion

        #region Get Index_Info Table - Daily
        public static List<IndexInfo> GetIndexInfoDaily()
        {
            log.Info("Get INDEX_INFO Table for Daily Series");

            string SQL = SqlStatement.selectIndexInfoDaily;

            var listIndexInfo = new List<IndexInfo>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //listIndexInfo.Add(new IndexInfo(reader.GetString(0),...));
                                var indexInfo = new IndexInfo();

                                indexInfo.Id = reader.GetString(0);
                                indexInfo.EngName = reader.GetString(1);
                                indexInfo.KorName = reader.GetString(2);
                                indexInfo.Units = reader.GetString(3);
                                indexInfo.Frequency = reader.GetString(4);
                                indexInfo.SeasonalAdjustment = reader.GetString(5);
                                indexInfo.SeriesFirstDate = reader.GetDateTime(6);
                                indexInfo.SeriesLastDate = reader.IsDBNull(7) ? null : (DateTime?)reader.GetDateTime(7);
                                indexInfo.DissContinue = reader.GetByte(8);
                                indexInfo.SeriesType = reader.GetByte(9);
                                indexInfo.SeriesRegistDate = reader.GetDateTime(10);
                                indexInfo.SeriesUpdateDate = reader.GetDateTime(11);
                                indexInfo.DeleteYn = reader.GetByte(12);

                                listIndexInfo.Add(indexInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                log.Error("Error INDEX_INFO Table for Daily Series", ex);
                throw;
            }

            return listIndexInfo;
        }
        #endregion

        //index_info id를 yahoo id로 변환
        public static string GetYahooId(string indexId)
        {
            log.Info("Get Ecos StatCode");
            string SQL = string.Format(SqlStatement.selectYahooMapTable, indexId);
            string mapId = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mapId = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error INDEX_INFO Table for Daily Series", ex);
                throw;
            }

            return mapId;
        }

        //itemcode로 ecos_category에서 stat_code를 획득하여 값을 가져옴
        public static string GetEcosStatCode(string itemCode)
        {
            log.Info("Get Ecos StatCode");
            string SQL = string.Format(SqlStatement.selectEcosCategoryTable, itemCode);
            string statCode = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                statCode = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error INDEX_INFO Table for Daily Series", ex);
                throw;
            }

            return statCode;
        }

        //ecos처럼 다운로드 링크에 데이터 베이스 코드까지 들어가는 2개의 매개변수가 필요
        //dataset_code로 quandl_category에서 database_code를 획득하여 값을 가져옴
        public static string GetQuandlDatabaseCode(string datasetCode)
        {
            log.Info("Get Quandl DatabaseCode");
            string SQL = string.Format(SqlStatement.selectQuandlCategoryTable, datasetCode);
            string statCode = string.Empty;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                statCode = reader.GetString(0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error INDEX_INFO Table for Daily Series", ex);
                throw;
            }

            return statCode;
        }


        //sldate가 null이면 씨리즈 초기화로 보고 Full Sync
        //null이 아니면 truncate and insert
        public static void InsertMonthlySeriesData(string seriesId, int seriesType, DateTime seriesFirstDate, DateTime? seriesLastDate)
        {
            if (!seriesLastDate.HasValue)
            {
                log.Info("InsertMonthlySeriesData : Full Sync Mode - " + seriesId);
                switch (seriesType)
                {
                    case 1:
                        InsertProcessMonthlyFredSeries(seriesId, DateConverter.FredDate(seriesFirstDate), DateConverter.FredDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)), "F");
                        //log.Info(seriesId + DateConverter.FredDate(seriesFirstDate) + DateConverter.FredDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)) + "F");//월간이므로 매월 1일로 변경해야 함.
                        break;
                    case 2:
                        InsertProcessMonthlyEcosSeries(seriesId, DateConverter.EcosMonthDate(seriesFirstDate), DateConverter.EcosMonthDate(DateTime.Now), "F");
                        break;
                    default:
                        Console.WriteLine("Unknown argument: {0}", seriesType);
                        break;
                }
            }
            else
            {
                log.Info("InsertMonthlySeriesData : Append Mode - " + seriesId);
                switch (seriesType)
                {
                    case 1:
                        InsertProcessMonthlyFredSeries(seriesId, DateConverter.FredDate(seriesLastDate.Value.AddMonths(1)), DateConverter.FredDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)), "A");                        
                        //log.Info(seriesId + DateConverter.FredDate(seriesLastDate.Value.AddMonths(1)) + DateConverter.FredDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)) + "A"); //월간이므로 매월 1일로 변경해야 함.

                        break;
                    case 2:
                        InsertProcessMonthlyEcosSeries(seriesId, DateConverter.EcosMonthDate(seriesLastDate.Value.AddMonths(1)), DateConverter.EcosMonthDate(DateTime.Now), "A");
                        break;
                    default:
                        Console.WriteLine("Unknown argument: {0}", seriesType);
                        break;
                }
                //call getseriesdata
            }
        }

        public static void InsertProcessMonthlyFredSeries(string seriesId, string seriesFirstDate, string seriesLastDate, string mode)
        {
            var listSeriesData = new List<SeriesData>();

            //Console.WriteLine("{0} : {1} : {2} : {3} : {4}", seriesId, seriesType,seriesFirstDate,seriesLastDate, mode);

            switch (mode)
            {
                case "F":
                    log.Info("InsertProcessMonthlyFredSeries(Full) : " + seriesId);
                    listSeriesData = FredApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate); //ecos와는 달리 fred는 일간/월간을 내부에서 처리해준다.

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessMonthlyFredSeries(Full) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }

                    break;
                case "A":
                    log.Info("InsertProcessMonthlyFredSeries(Append) : " + seriesId);
                    listSeriesData = FredApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate);

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessMonthlyFredSeries(Append) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    else
                    {
                        log.Info("InsertProcessMonthlyFredSeries : No Data");
                    }

                    break;
                default:
                    log.Info("No Handle of Process");
                    break;
            }
        }

        //append개념이 월간부터는 없다. 시즌 조정으로 데이터 전체가 바뀌는 통계적 한계가 있기 때문
        //상기의 이유로 월간은 nsa만 연동하고 sa는 필요에 따라 그때그때 웹서비스를 이용하거나 엑셀로 편집한다.
        public static void InsertProcessMonthlyEcosSeries(string seriesId, string seriesFirstDate, string seriesLastDate, string mode)
        {
            var listSeriesData = new List<SeriesData>();

            //Console.WriteLine("{0} : {1} : {2} : {3} : {4}", seriesId, seriesType,seriesFirstDate,seriesLastDate, mode);

            switch (mode)
            {
                case "F":
                    log.Info("InsertProcessMonthlyEcosSeries(Full) : " + seriesId);
                    listSeriesData = EcosApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate,Frequency.Monthly.ToString());

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessMonthlyEcosSeries(Full) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }

                    break;
                case "A":
                    log.Info("InsertProcessMonthlyEcosSeries(Append) : " + seriesId);
                    listSeriesData = EcosApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate,Frequency.Monthly.ToString());

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessMonthlyEcosSeries(Append) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    else
                    {
                        log.Info("InsertProcessMonthlyEcosSeries : No Data");
                    }

                    break;
                default:
                    log.Info("No Handle of Process");
                    break;
            }
        }


        //SeriesLastDate가 null이면 처음부터 오늘까지
        //null이 아니면 append
        public static void InsertSeriesData(string seriesId, int seriesType, DateTime seriesFirstDate, DateTime? seriesLastDate)
        {            
            if (!seriesLastDate.HasValue)
            {
                log.Info("InsertSeriesData : Full Sync Mode - " + seriesId);
                switch (seriesType)
                {
                    case 1:
                        InsertProcessFredSeries(seriesId, DateConverter.FredDate(seriesFirstDate), DateConverter.FredDate(DateTime.Now),"F");
                        break;
                    case 2:
                        InsertProcessEcosSeries(seriesId, DateConverter.EcosDate(seriesFirstDate), DateConverter.EcosDate(DateTime.Now),"F");
                        break;
                    case 3:
                        InsertProcessYahooSeries(seriesId, DateConverter.YahooDate(seriesFirstDate), DateConverter.YahooDate(DateTime.Now), "F");
                        break;
                    case 4:
                        InsertProcessQuandlSeries(seriesId, DateConverter.QuandlDate(seriesFirstDate), DateConverter.QuandlDate(DateTime.Now), "F");
                        break;
                    case 6:
                        InsertProcessUStreasSeries(seriesId, DateConverter.UstreasDate(seriesFirstDate), DateConverter.UstreasDate(DateTime.Now), "F");
                        break;
                    default:
                        Console.WriteLine("Unknown argument: {0}", seriesType);
                        break;
                }                
            }
            else
            {
                log.Info("InsertSeriesData : Append Mode - " + seriesId);
                switch (seriesType)
                {
                    case 1:
                        InsertProcessFredSeries(seriesId, DateConverter.FredDate(seriesLastDate.Value.AddDays(1)), DateConverter.FredDate(DateTime.Now), "A");
                        break;
                    case 2:
                        InsertProcessEcosSeries(seriesId, DateConverter.EcosDate(seriesLastDate.Value.AddDays(1)), DateConverter.EcosDate(DateTime.Now), "A");
                        break;
                    case 3:
                        InsertProcessYahooSeries(seriesId, DateConverter.YahooDate(seriesLastDate.Value.AddDays(1)), DateConverter.YahooDate(DateTime.Now), "A");
                        break;
                    case 4:
                        InsertProcessQuandlSeries(seriesId, DateConverter.QuandlDate(seriesLastDate.Value.AddDays(1)), DateConverter.QuandlDate(DateTime.Now), "A");
                        break;
                    case 6:
                        //InsertProcessUStreasSeries(seriesId, DateConverter.UstreasDate(seriesFirstDate), DateConverter.UstreasDate((DateTime)seriesLastDate), "A");
                        InsertProcessUStreasSeries(seriesId, DateConverter.UstreasDate(seriesLastDate.Value), DateConverter.UstreasDate(DateTime.Now), "A");
                        break;
                    default:
                        Console.WriteLine("Unknown argument: {0}", seriesType);
                        break;
                }
                //call getseriesdata
            }
        }

        public static void InsertProcessUStreasSeries(string seriesId, string seriesFirstDate, string seriesLastDate, string mode)
        {
            var listSeriesData = new List<UsTreasData>();

            //log.Info("InsertProcessUStreasSeries(Append) : " + seriesId);
            listSeriesData = UstreasApi.GetUSTreasRates(seriesId, seriesFirstDate);

            //foreach (var item in listSeriesData)
            //{
            //    log.Info(item.BusinessDate.ToShortDateString() + " : " + item.Series1 + " : " + item.Series2 + " : " + item.Series3 + " : " + item.Series4 + " : " + item.Series5 + " : " + item.Series6 + " : " + item.Series7 + " : " + item.Series8 + " : " + item.Series9 + " : " + item.Series10 + " : " + item.Series11 + " : " + item.Series12);
            //}


            if (listSeriesData.Count > 0)
            {
                log.Info("InsertProcessUSTreasSeries(Append) : " + seriesId);
                ParameterInsertUSTreas(listSeriesData, seriesId);
            }
            else
            {
                log.Info("InsertProcessUSTreasSeries : No Data");
            }



        }

        public static void InsertProcessFredSeries(string seriesId, string seriesFirstDate, string seriesLastDate, string mode)
        {
            var listSeriesData = new List<SeriesData>();            

            //Console.WriteLine("{0} : {1} : {2} : {3} : {4}", seriesId, seriesType,seriesFirstDate,seriesLastDate, mode);
            
            switch (mode)
            {
                case "F":                    
                    log.Info("InsertProcessFredSeries(Full) : " + seriesId);
                    listSeriesData = FredApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate);
                    
                    if (listSeriesData.Count>0)
                    {
                        log.Info("InsertProcessFredSeries(Full) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    break;
                case "A":
                    log.Info("InsertProcessFredSeries(Append) : " + seriesId);
                    listSeriesData = FredApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate);

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessFredSeries(Append) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    else
                    {
                        log.Info("InsertProcessFredSeries : No Data");
                    }

                    break;
                default:
                    log.Info("No Handle of Process");
                    break;
            }

        }
                
        public static void InsertProcessEcosSeries(string seriesId, string seriesFirstDate, string seriesLastDate, string mode)
        {
            var listSeriesData = new List<SeriesData>();

            //Console.WriteLine("{0} : {1} : {2} : {3} : {4}", seriesId, seriesType,seriesFirstDate,seriesLastDate, mode);

            switch (mode)
            {
                case "F":
                    log.Info("InsertProcessEcosSeries(Full) : " + seriesId);
                    listSeriesData = EcosApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate, Frequency.Daily.ToString());
                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessEcosSeries(Full) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }                    
                    break;
                case "A":
                    log.Info("InsertProcessEcosSeries(Append) : " + seriesId);
                    listSeriesData = EcosApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate, Frequency.Daily.ToString());

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessEcosSeries(Append) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    else
                    {
                        log.Info("InsertProcessEcosSeries : No Data");
                    }
                    break;
                default:
                    log.Info("No Handle of Process");
                    break;
            }
        }

        public static void InsertProcessYahooSeries(string seriesId, string seriesFirstDate, string seriesLastDate, string mode)
        {
            var listSeriesData = new List<SeriesData>();

            //Console.WriteLine("{0} : {1} : {2} : {3} : {4}", seriesId, seriesType,seriesFirstDate,seriesLastDate, mode);

            switch (mode)
            {
                case "F":
                    listSeriesData = YahooApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate);

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessYahooSeries(Full) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    break;
                case "A":                    
                    //log.Info(seriesFirstDate + " : " +seriesLastDate);
                    listSeriesData = YahooApi.GetSeriesData(seriesId, seriesFirstDate);

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessYahooSeries(Append) : " + seriesId);
                        //foreach (var item in listSeriesData)
                        //{
                        //    log.Info(item.BusinessDate + " : " + item.EconomicIndex);
                        //}
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    else
                    {
                        log.Info("InsertProcessYahooSeries : No Data");
                    }

                    break;
                default:
                    log.Info("No Handle of Process");
                    break;
            }

        }

        // edit
        // like ecos series
        public static void InsertProcessQuandlSeries(string seriesId, string seriesFirstDate, string seriesLastDate, string mode)
        {
            var listSeriesData = new List<SeriesData>();
            //Console.WriteLine("{0} : {1} : {2} : {3} : {4}", seriesId, seriesType,seriesFirstDate,seriesLastDate, mode);

            switch (mode)
            {
                case "F":
                    log.Info("InsertProcessQuandlSeries(Full) : " + seriesId);
                    listSeriesData = QuandlApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate, Frequency.Daily.ToString());
                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessQuandlSeries(Full) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    break;
                case "A":
                    log.Info("InsertProcessQuandlSeries(Append) : " + seriesId);
                    listSeriesData = QuandlApi.GetSeriesData(seriesId, seriesFirstDate, seriesLastDate, Frequency.Daily.ToString());

                    if (listSeriesData.Count > 0)
                    {
                        log.Info("InsertProcessQuandlSeries(Append) : " + seriesId);
                        ParameterInsert(listSeriesData, seriesId, mode);
                    }
                    else
                    {
                        log.Info("InsertProcessQuandlSeries : No Data");
                    }
                    break;
                default:
                    log.Info("No Handle of Process");
                    break;
            }
        }

        public static void ParameterInsertUSTreas(List<UsTreasData> myList, string tableName)
        {
            log.Info("Parameter Insert : " + myList.Count);

            if (tableName.Equals("USTREAS_GS"))
            {
                //log.Info("Table Name : " + tableName);
                string SQL = string.Format(SqlStatement.insertUstreasGsTable, tableName);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = SQL;

                        command.Parameters.Add("@business_date", SqlDbType.Date);
                        command.Parameters.Add("@gs1mo", SqlDbType.Decimal);
                        command.Parameters.Add("@gs2mo", SqlDbType.Decimal);
                        command.Parameters.Add("@gs3mo", SqlDbType.Decimal);
                        command.Parameters.Add("@gs6mo", SqlDbType.Decimal);
                        command.Parameters.Add("@gs1", SqlDbType.Decimal);
                        command.Parameters.Add("@gs2", SqlDbType.Decimal);
                        command.Parameters.Add("@gs3", SqlDbType.Decimal);
                        command.Parameters.Add("@gs5", SqlDbType.Decimal);
                        command.Parameters.Add("@gs7", SqlDbType.Decimal);
                        command.Parameters.Add("@gs10", SqlDbType.Decimal);
                        command.Parameters.Add("@gs20", SqlDbType.Decimal);
                        command.Parameters.Add("@gs30", SqlDbType.Decimal);

                        foreach (var item in myList)
                        {
                            command.Parameters["@business_date"].Value = item.BusinessDate;
                            command.Parameters["@gs1mo"].Value = item.Series1;
                            command.Parameters["@gs2mo"].Value = item.Series2;
                            command.Parameters["@gs3mo"].Value = item.Series3;
                            command.Parameters["@gs6mo"].Value = item.Series4;
                            command.Parameters["@gs1"].Value = item.Series5;
                            command.Parameters["@gs2"].Value = item.Series6;
                            command.Parameters["@gs3"].Value = item.Series7;
                            command.Parameters["@gs5"].Value = item.Series8;
                            command.Parameters["@gs7"].Value = item.Series9;
                            command.Parameters["@gs10"].Value = item.Series10;
                            command.Parameters["@gs20"].Value = item.Series11;
                            command.Parameters["@gs30"].Value = item.Series12;

                            command.ExecuteNonQuery();
                        }

                        log.Info("Update INDEX_INFO's sldate : " + myList.Max(x => x.BusinessDate.ToShortDateString()));
                        SQL = string.Format(SqlStatement.updateIndexInfoTable, myList.Max(x => x.BusinessDate.ToShortDateString()), DateTime.Now.ToShortDateString(), tableName);

                        command.CommandType = CommandType.Text;
                        command.CommandText = SQL;
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                //log.Info("Table Name : " + tableName);
                string SQL = string.Format(SqlStatement.insertUstreasFiiTable, tableName);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = SQL;

                        command.Parameters.Add("@business_date", SqlDbType.Date);
                        command.Parameters.Add("@fii5", SqlDbType.Decimal);
                        command.Parameters.Add("@fii7", SqlDbType.Decimal);
                        command.Parameters.Add("@fii10", SqlDbType.Decimal);
                        command.Parameters.Add("@fii20", SqlDbType.Decimal);
                        command.Parameters.Add("@fii30", SqlDbType.Decimal);

                        foreach (var item in myList)
                        {
                            command.Parameters["@business_date"].Value = item.BusinessDate;
                            command.Parameters["@fii5"].Value = item.Series1;
                            command.Parameters["@fii7"].Value = item.Series2;
                            command.Parameters["@fii10"].Value = item.Series3;
                            command.Parameters["@fii20"].Value = item.Series4;
                            command.Parameters["@fii30"].Value = item.Series5;

                            command.ExecuteNonQuery();
                        }

                        log.Info("Update INDEX_INFO's sldate : " + myList.Max(x => x.BusinessDate.ToShortDateString()));
                        SQL = string.Format(SqlStatement.updateIndexInfoTable, myList.Max(x => x.BusinessDate.ToShortDateString()), DateTime.Now.ToShortDateString(), tableName);

                        command.CommandType = CommandType.Text;
                        command.CommandText = SQL;
                        command.ExecuteNonQuery();
                    }
                }

            }

        }

        //mode가 f인 경우에만 truncate table or create table
        //sldate가 null이라 함은 '초기화'의 의미도 포함됨
        //따라서 null인 경우 테이블이 존재하면 드랍하고 다시 생성하는 메서드 호출 함.
        //=> index_info에 sldate를 null로 집어 넣으면 싱크할 때, 신규 씨리즈로 판단하여 테이블부터 생성하고 진행하는 프로세스
        public static void ParameterInsert(List<SeriesData> myList, string tableName, string mode)
        {
            log.Info("Parameter Insert : " + myList.Count);

            if (mode.Equals("F"))
            {
                // call truncate or create table
                CreateTable(tableName);
            }

            //string SQL = "insert into " + tableName + " values (@business_date, @economic_index);";            
            string SQL = string.Format(SqlStatement.insertSeriesTable, tableName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQL;

                    command.Parameters.Add("@business_date", SqlDbType.Date);
                    command.Parameters.Add("@economic_index", SqlDbType.Decimal);

                    foreach (var item in myList)
                    {
                        command.Parameters["@business_date"].Value = item.BusinessDate;
                        command.Parameters["@economic_index"].Value = item.EconomicIndex;

                        command.ExecuteNonQuery();
                    }

                    //update indexinfo sldate column
                    //"UPDATE INDEX_INFO SET sldate = '{0}', upt_date = '{1}' WHERE id = '{2}'"
                    //SQL = string.Format(SqlStatement.updateIndexInfoTable, lastDate.ToShortDateString(), DateTime.Now.ToShortDateString(), seriesId);
                    //full datetime으로 입력하면 안됨
                    //toshortdatestring으로 처리해야 함. 왜냐하면 쿼리문 작성에 대입해야 하기 때문.

                    log.Info("Update INDEX_INFO's sldate : " + myList.Max(x => x.BusinessDate.ToShortDateString()));
                    SQL = string.Format(SqlStatement.updateIndexInfoTable, myList.Max(x => x.BusinessDate.ToShortDateString()), DateTime.Now.ToShortDateString(), tableName);

                    //버그 : 날짜 갱신 오류, list의 데이터가 비정렬 데이터로 보고 그냥 날짜필드에 max 함수 처리(2017-03-19)
                    //SQL = string.Format(SqlStatement.updateIndexInfoTable, myList[myList.Count - 1].BusinessDate.ToShortDateString(), DateTime.Now.ToShortDateString(), tableName);
                    //Console.WriteLine("{0} - {1} - {2}", myList[myList.Count - 1].BusinessDate.ToShortDateString(), DateTime.Now.ToShortDateString(), tableName);
                    command.CommandType = CommandType.Text;
                    command.CommandText = SQL;
                    command.ExecuteNonQuery();
                }
            }

            //문제 발견 -> 서로 다른 트랜잭션으로 묶여 연동에 문제가 됨.
            //UpdateSeriesLastDate(myList[myList.Count-1].BusinessDate, tableName);
        }
        
        // 트랜잭션 일원화로 파라메타 인서트로 변경
        //public static void UpdateSeriesLastDate(DateTime lastDate, string seriesId)
        //{
        //    log.Info("Update INDEX_INFO's sldate");            

        //    //string SQL = "UPDATE INDEX_INFO SET sldate = '" + lastDate.ToShortDateString() + "', upt_date = '" + DateTime.Now.ToShortDateString() + "' WHERE id = '" + seriesId + "'";
        //    string SQL = string.Format(SqlStatement.updateIndexInfoTable, lastDate.ToShortDateString(), DateTime.Now.ToShortDateString(), seriesId);            

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand())
        //        {
        //            command.Connection = connection;
        //            command.CommandType = CommandType.Text;
        //            command.CommandText = SQL;
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        public static void CreateTable(string tableName)
        {
            log.Info("Create Table : " + tableName);

            string dropTableSql = string.Format(SqlStatement.dropTable, tableName, tableName);
            string createTableSql = string.Format(SqlStatement.createTable, tableName);
            string addIndexSql = string.Format(SqlStatement.addIndex, tableName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = dropTableSql;
                    command.ExecuteNonQuery();
                    command.CommandText = createTableSql;
                    command.ExecuteNonQuery();
                    command.CommandText = addIndexSql;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
