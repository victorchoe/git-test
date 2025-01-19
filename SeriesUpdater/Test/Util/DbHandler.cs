using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Test.Model;

namespace Test.Util
{    
    class DbHandler
    {
        static string connectionString = Util.Config.connectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //
        // Get index_info table 
        public static List<IndexInfo> GetIndexInfo()
        {
            log.Info("Get INDEX_INFO Table");

            string query = "SELECT * " +
                    "FROM index_info " +
                    "WHERE diss = 0 " +
                    "AND delete_yn = 0 ";

            var listIndexInfo = new List<IndexInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();                

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //listIndexInfo.Add(new IndexInfo(reader.GetString(0),...));
                            var indexInfo                = new IndexInfo();

                            indexInfo.Id                 = reader.GetString(0);
                            indexInfo.EngName            = reader.GetString(1);
                            indexInfo.KorName            = reader.GetString(2);
                            indexInfo.Units              = reader.GetString(3);
                            indexInfo.Frequency          = reader.GetString(4);
                            indexInfo.SeasonalAdjustment = reader.GetString(5);
                            indexInfo.SeriesFirstDate    = reader.GetDateTime(7);
                            indexInfo.SeriesLastDate     = reader.IsDBNull(8) ? null : (DateTime?) reader.GetDateTime(8);
                            indexInfo.DissContinue       = reader.GetByte(9);
                            indexInfo.SeriesType         = reader.GetByte(10);
                            indexInfo.SeriesRegistDate   = reader.GetDateTime(11);
                            indexInfo.SeriesUpdateDate   = reader.GetDateTime(12);
                            indexInfo.DeleteYn           = reader.GetByte(13);

                            listIndexInfo.Add(indexInfo);
                        }
                    }
                }
            }

            return listIndexInfo;
        }

        // 2 type 
        // 1. daily -> parameter insert
        // 2. weekly & monthly all Series Data -> sqlbulkcopy
        // 
        public static void SqlBulkCopyWholeSeries (DataTable myDataTable, string tableName)
        {           

            Console.WriteLine("DataTable Name is : " + myDataTable.TableName);
            //Console.WriteLine("bbb" + myDataTable.Columns);
            Console.ReadKey();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlBulkCopy bcp = new SqlBulkCopy(con, SqlBulkCopyOptions.TableLock, null))
                {

                    //bcp.BatchSize = dataTable.Rows.Count;
                    if (myDataTable.Rows.Count > 1000)
                    {
                        bcp.BatchSize = 1000;
                    }

                    //bcp.DestinationTableName = myDataTable.TableName;
                    bcp.DestinationTableName = tableName;
                    bcp.WriteToServer(myDataTable);
                }
            }
            Console.WriteLine(myDataTable.Rows.Count);
        }



        public static void ParamsInsert(List<Model.FredData> myList, string tableName)
        {
            log.Info("START Param. Insert");
            Console.WriteLine(myList.Count);

            string SQL = string.Empty;            

            //SQL = "insert into FRED_" + seriesId + " values (@business_date, @economic_index);";
            SQL = "insert into " + tableName + " values (@business_date, @economic_index);";

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
                }
                
            }
            log.Info("Done. Param. Insert");
        }

        public static void SimpleSelect()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT item_code,item_name,country FROM dbo.YAHOO_INDEX_CODE";                

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // column value null 처리(as operator) => reader["item_name"] as string
                            Console.WriteLine("{0} | {1} | {2}", reader.GetString(0), reader["item_name"] as string, reader["country"] as string);                            
                        }
                    }
                }
                                
                Console.WriteLine("Connection Open.");
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State);
                
            }
        }



        //        List<String> list = new List<String>() { "A", "B", "C" };
        //using (var con = new SqlConnection(connectionString))
        //{
        //    con.Open();
        //    using (var cmd = new SqlCommand("INSERT INTO TABLE(Column)VALUES(@Column)", con))
        //    {
        //        cmd.Parameters.Add("@Column", SqlDbType.VarChar);
        //        foreach (var value in list)
        //        {
        //            cmd.Parameters["@Column"].Value = value;
        //            int rowsAffected = cmd.ExecuteNonQuery();
        //}
        //    }
        //}
    }
}
