using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;

namespace EconChartTest
{
	class DbHandle
	{
		//List와 비교해보면 114,512와 116,472로 얼마차이가 안난다. 이것을 좀더 테스트 해봐야 하는데, 테스트로 실시간으로 데이터를 과연 반영하는지를 해볼 것.
		//차트로 뿌리는데 드는 시간은 차이없다.
		//설령 실시간으로 반영한다 하더라도 내가 뿌리는 차트는 모두 그 대상이 아니기에 쉬운 것으로 가자. List로 감.
		public static ObservableCollection<SeriesValue> GetSeriesDataO(string schemaName, string seriesId, string fromDate = null)
		{
			string SQL = string.Empty;

			if (fromDate == null)
			{
				SQL = "SELECT bdate, indx " +
					//"  FROM " + schemaName + "." + seriesId + " " +
					"  FROM " + schemaName + "." + seriesId;
				//"ORDER BY 1 ";				
			}
			else
			{
				SQL = "SELECT bdate, indx " +
					"  FROM " + schemaName + "." + seriesId + " " +
					//" WHERE bdate >= '" + conDate + "' " +
					" WHERE bdate >= '" + fromDate + "' ";
				//"ORDER BY 1 ";
			}

			var myData = new ObservableCollection<SeriesValue>();

			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString))
			{
				con.Open();
				using (SqlCommand cmd = new SqlCommand(SQL, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							myData.Add(new SeriesValue
							{
								businessDate = reader.GetDateTime(0),
								economicIndex = Convert.ToDecimal(reader.GetString(1)) //FRED는 데이터가 스트링
							});
						}
					}
				}
			}
			return myData;
		}

		//1. IEnumerable is an interface, where as List is one specific implementation of IEnumerable. List is a class.
		//2. FOR-EACH loop is the only possible way to iterate through a collection of IEnumerable, where as List can be iterated using several ways. List can also be indexed by an int index, element can be added to and removed from and have items inserted at a particular index.
		//3. IEnumerable doesn't allow random access, where as List does allow random access using integral index.
		//4. In general from a performance standpoint, iterating thru IEnumerable is much faster than iterating thru a List. 
		public static List<SeriesRows> GetSeriesData(string schemaName, string seriesId, string fromDate = null)
		{
			string SQL = string.Empty;

			if (fromDate == null)
			{
				SQL = "SELECT bdate, indx " +
					//"  FROM " + schemaName + "." + seriesId + " " +
					"  FROM " + schemaName + "." + seriesId;
					//"ORDER BY 1 ";				
			}
			else
			{
				SQL = "SELECT bdate, indx " +
					"  FROM " + schemaName + "." + seriesId + " " +
					//" WHERE bdate >= '" + conDate + "' " +
					" WHERE bdate >= '" + fromDate + "' ";
					//"ORDER BY 1 ";
			}

			var myData = new List<SeriesRows>();

			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString))
			{
				con.Open();
				using (SqlCommand cmd = new SqlCommand(SQL, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							myData.Add(new SeriesRows
							{
								businessDate = reader.GetDateTime(0),
								economicIndex = Convert.ToDecimal(reader.GetString(1)) //FRED는 데이터가 스트링
							});
						}
					}
				}
			}
			return myData;
		}

		public static List<SeriesRows> GetSeriesDataAgg(string schemaName, string seriesId, string aggType)
		{
			string SQL = string.Empty;

			if (aggType == "w")
			{
				SQL = "SELECT " +
					" dateadd (wk, datediff (wk, 0, bdate), 0) bdate, avg (cast (indx AS DECIMAL (6, 2))) indx " +
					"  FROM " + schemaName + "." + seriesId +
					" GROUP BY dateadd (wk, datediff (wk, 0, bdate), 0) " +
				    "ORDER BY 1 ";				
			}
			else if (aggType == "m")
			{
				SQL = "SELECT " +
					" dateadd (mm, datediff (mm, 0, bdate), 0) bdate, avg (cast (indx AS DECIMAL (6, 2))) indx " +
					"  FROM " + schemaName + "." + seriesId +
					" GROUP BY dateadd (mm, datediff (mm, 0, bdate), 0) " +
					"ORDER BY 1 ";				
			}
			else if (aggType == "q")
			{
				SQL = "SELECT " +
					" dateadd (q, datediff (q, 0, bdate), 0) bdate, avg (cast (indx AS DECIMAL (6, 2))) indx " +
					"  FROM " + schemaName + "." + seriesId +
					" GROUP BY dateadd (q, datediff (q, 0, bdate), 0) " +
					"ORDER BY 1 ";				
			}			

			var myData = new List<SeriesRows>();

			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString))
			{
				con.Open();
				using (SqlCommand cmd = new SqlCommand(SQL, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							myData.Add(new SeriesRows
							{
								businessDate = reader.GetDateTime(0),
								economicIndex = reader.GetDecimal(1)
							});
						}
					}
				}
			}
			return myData;
		}

		//다른 방법을 찾아보자. 아래의 방법은 노가다인 것 같다.
		//전체를 한꺼번에 표현하는 것은 정말 모든데이터가 올라가므로 엄청나게 메모리가 소모된다. 이는 당연한 것으로
		//특히 예외적일때만 해야 할 것이다. 따라서 크게 롱텀과 미들, 그리고 숏텀으로 3개의 기간으로 나눠야 함.
		//롱텀은 모든기간, 미들텀은 90년대 이후, 숏텀은 5년으로 ...
		//또 롱텀은 모든 씨리즈를, 미들텀과 숏텀은 1m, 3m, 2y, 5y, 10y, 30y
		//롱텀은 월평균으로 처리할 것. 과거흐름만 보면 됨. 미들텀은 주간으로 처리, 숏텀은 일간으로 처리해 메모리와 속도를 관리할 것.
		public static List<SeriesRows> GetUsTreasData(string treasName)
		{
			string SQL = string.Empty;

			if (treasName.Equals("d1mo"))
			{
				SQL = "select bdate, d1mo from ETC.UsTreas where bdate >= '2001-07-31' ";				
			}
			else if (treasName.Equals("d3mo"))
			{
				SQL = "select bdate, d3mo from ETC.UsTreas where bdate >= '1982-01-04' ";				
			}
			else if (treasName.Equals("d6mo"))
			{
				SQL = "select bdate, d6mo from ETC.UsTreas where bdate >= '1982-01-04' ";
			}
			else if (treasName.Equals("d1yr"))
			{
				SQL = "select bdate, d1yr from ETC.UsTreas where bdate >= '1962-01-02' ";
			}
			else if (treasName.Equals("d2yr"))
			{
				SQL = "select bdate, d2yr from ETC.UsTreas where bdate >= '1976-06-01' ";
			}
			else if (treasName.Equals("d3yr"))
			{
				SQL = "select bdate, d3yr from ETC.UsTreas where bdate >= '1962-01-02' ";
			}
			else if (treasName.Equals("d5yr"))
			{
				SQL = "select bdate, d5yr from ETC.UsTreas where bdate >= '1962-01-02' ";
			}
			else if (treasName.Equals("d7yr"))
			{
				SQL = "select bdate, d7yr from ETC.UsTreas where bdate >= '1969-07-01' ";
			}
			else if (treasName.Equals("d10yr"))
			{
				SQL = "select bdate, d10yr from ETC.UsTreas where bdate >= '1962-01-02' ";
			}
			else if (treasName.Equals("d20yr"))
			{
				SQL = "select bdate, d20yr from ETC.UsTreas where bdate >= '1993-10-01' ";
			}
			else if (treasName.Equals("d30yr"))
			{
				SQL = "select bdate, d30yr from ETC.UsTreas where bdate >= '1977-02-15' ";
			}
			else if (treasName.Equals("ie5yr"))
			{
				SQL = "select bdate, ie5yr from ETC.UsTreas where bdate >= '2003-01-02' ";
			}
			else if (treasName.Equals("ie7yr"))
			{
				SQL = "select bdate, ie7yr from ETC.UsTreas where bdate >= '2003-01-02' ";
			}
			else if (treasName.Equals("ie10yr"))
			{
				SQL = "select bdate, ie10yr from ETC.UsTreas where bdate >= '2003-01-02' ";
			}
			else if (treasName.Equals("ie20yr"))
			{
				SQL = "select bdate, ie20yr from ETC.UsTreas where bdate >= '2004-07-27' ";
			}
			else if (treasName.Equals("ie30yr"))
			{
				SQL = "select bdate, ie30yr from ETC.UsTreas where bdate >= '2010-02-22' ";
			}

			var myData = new List<SeriesRows>();

			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString))
			{
				con.Open();
				using (SqlCommand cmd = new SqlCommand(SQL, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							myData.Add(new SeriesRows
							{
								businessDate = reader.GetDateTime(0),
								economicIndex = reader.GetDecimal(1)
							});
						}
					}
				}
			}
			return myData;
		}

		public static List<UsTreasBond> GetUsTreasBondData()
		{
			string SQL = "SELECT bdate, " +
				"       d3mo, " +
				"       d2yr, " +
				"       d5yr, " +
				"       d10yr, " +
				"       d30yr " +
				"  FROM ETC.UsTreas " +
				" WHERE bdate >= dateadd (year, -3, getdate ()) ";

			var myData = new List<UsTreasBond>();

			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString))
			{
				con.Open();
				using (SqlCommand cmd = new SqlCommand(SQL, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							myData.Add(new UsTreasBond
							{
								businessDate = reader.GetDateTime(0),
								series1 = reader.GetDecimal(1),
								series2 = reader.GetDecimal(2),
								series3 = reader.GetDecimal(3),
								series4 = reader.GetDecimal(4),
								series5 = reader.GetDecimal(5),
							});
						}
					}
				}
			}
			return myData;
		}

		public static List<NberRecession> GetNberRecession()
		{
			string SQL = "select peak, case when trough is null then getdate() else trough end trough from ETC.NberRecession";

			var myData = new List<NberRecession>();

			using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString))
			{
				con.Open();
				using (SqlCommand cmd = new SqlCommand(SQL, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							myData.Add(new NberRecession
							{
								peakDate = reader.GetDateTime(0),
								troughDate = reader.GetDateTime(1)
							});
						}
					}
				}
			}
			return myData;
		}
	}

	public class SeriesRows
	{
		public DateTime businessDate { get; set; }
		public decimal economicIndex { get; set; }
	}

	public class UsTreasBond
	{
		public DateTime businessDate { get; set; }
		public decimal series1 { get; set; }
		public decimal series2 { get; set; }
		public decimal series3 { get; set; }
		public decimal series4 { get; set; }
		public decimal series5 { get; set; }
	}

	public class NberRecession
	{
		public DateTime peakDate { get; set; }
		public DateTime troughDate { get; set; }
	}

}
