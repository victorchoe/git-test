using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Xml.Linq;

namespace EconChartTest
{
	//FRED Api전부를 구현할 필요없음. 내가 사용하는 기능만 구현할 것.
	class FredApi
	{
		//현재 사용중인 R 스크립트를 컨버전할 것.
		//예를 들어 키코드, 범위, units, agg 조건을 받는 것.
		//
		//units
		//lin = Levels (No transformation)
		//chg = Change
		//ch1 = Change from Year Ago
		//pch = Percent Change
		//pc1 = Percent Change from Year Ago
		//pca = Compounded Annual Rate of Change
		//cch = Continuously Compounded Rate of Change
		//cca = Continuously Compounded Annual Rate of Change
		//log = Natural Log

		//freq -> 대부분 널
		//d = Daily
		//w = Weekly
		//bw = Bi-Weekly
		//m = Monthly
		//q = Quarterly
		//sa = Semiannual
		//a = Annual 

		//Named Parameter는 함수 파라미터 순서에서 항상 마지막에서 사용되어야 하지만 Named Parameter 끼리는 순서가 상관 없다.
		//ex> GetSeriesData("dgs10", freq:"m")
		public static IEnumerable<FredData> GetSeriesData(string seriesId, string from = "1776-07-04", string to = "9999-12-31", string units = "lin", string freq = "")
		{
			XElement root;

			if (freq.Equals(""))
			{
				root = XElement.Load("http://api.stlouisfed.org/fred/series/observations?series_id=" + seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"] + "&observation_start=" + from + "&observation_end=" + to + "&units=" + units);								
			}
			else
			{
				root = XElement.Load("http://api.stlouisfed.org/fred/series/observations?series_id=" + seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"] + "&observation_start=" + from + "&observation_end=" + to + "&units=" + units + "&frequency=" + freq);
			}			

			var fredData =
				from el in root.Elements("observation")
				where (string)el.Attribute("value") != "."
				select new FredData
				{
					businessDate = Convert.ToDateTime(el.Attribute("date").Value),
					economicIndex = el.Attribute("value").Value
				};

			return fredData;
		}

		public static IEnumerable<FredData> GetAllSeriesData(string seriesId)
		{
			XElement root = XElement.Load("http://api.stlouisfed.org/fred/series/observations?series_id=" + seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"]);

			var fredData =
				from el in root.Elements("observation")
				where (string)el.Attribute("value") != "."
				select new FredData
				{
					//businessDate = el.Attribute("date").Value,
					businessDate = Convert.ToDateTime(el.Attribute("date").Value),
					economicIndex = el.Attribute("value").Value
				};

			return fredData;
		}

		public static List<FredData> GetAllSeriesDataList(string seriesId)
		{
			XElement root = XElement.Load("http://api.stlouisfed.org/fred/series/observations?series_id=" + seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"]);

			var fredData =
				from el in root.Elements("observation")
				where (string)el.Attribute("value") != "."
				select new FredData
				{
					//businessDate = el.Attribute("date").Value,
					businessDate = Convert.ToDateTime(el.Attribute("date").Value),
					economicIndex = el.Attribute("value").Value
				};

			return fredData.ToList();
		}

		//메소드를 조정 => 마지막날짜는 같게 변경(2011-10-06) -> 부분처리가 없고 전체 아니면 최근 데이터 추가만 하므로.
		//무엇보다 두개의 날짜를 디폴트 처리하는데, 하나의 날짜만 넣지 못하기 때문임.
		//public static DataTable GetFredSeries(string seriesId, string from = "1776-07-04", string to = "9999-12-31")
		public static DataTable GetFredSeries(string seriesId, string from = "1776-07-04")
		{
			string to = "9999-12-31";

			XElement root =
				XElement.Load("http://api.stlouisfed.org/fred/series/observations?series_id=" +
				seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"] +
				"&observation_start=" + from + "&observation_end=" + to);

			var fredData =
				from el in root.Elements("observation").AsParallel() //PLINQ .AsParallel()
				//from el in root.Elements("observation")
				where (string)el.Attribute("value") != "."
				select new
				{
					bdate = el.Attribute("date").Value,
					indx = el.Attribute("value").Value
				};

			//DataTable dataTable = new DataTable("FRED.GDPDEF");
			DataTable dataTable = new DataTable("FRED." + seriesId.ToUpper());
			dataTable.Columns.Add("bdate", typeof(DateTime));
			dataTable.Columns.Add("indx", typeof(string));

			foreach (var item in fredData)
			{
				DataRow dataRow = dataTable.NewRow();
				dataRow["bdate"] = item.bdate;
				dataRow["indx"] = item.indx;
				dataTable.Rows.Add(dataRow);
				//Console.WriteLine("bdate: {0}, indx: {1}", item.bdate, item.indx);
			}

			return dataTable;
		}

		public static IEnumerable<FredData> GetFredSeriesAdd(string seriesId, string from = "1776-07-04")
		{
			string to = "9999-12-31";

			XElement root =
				XElement.Load("http://api.stlouisfed.org/fred/series/observations?series_id=" +
				seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"] +
				"&observation_start=" + from + "&observation_end=" + to);

			var fredData =
				from el in root.Elements("observation")
				where (string)el.Attribute("value") != "."
				select new FredData
				{
					//businessDate = el.Attribute("date").Value,
					businessDate = Convert.ToDateTime(el.Attribute("date").Value),
					economicIndex = el.Attribute("value").Value
				};

			return fredData;
		}

		//해당 카테고리 ID에 속한 모든 씨리즈에 관한 정보
		public static IEnumerable<FredSeriesInfo> GetCategorySeriesInfo(string categoryID)
		{
			XElement root = XElement.Load("http://api.stlouisfed.org/fred/category/series?category_id=" + categoryID + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"]);

			var fredData =
				from el in root.Elements("series")
				select new FredSeriesInfo
				{
					id = el.Attribute("id").Value,
					title = el.Attribute("title").Value,
					freq = el.Attribute("frequency_short").Value,
					unit = el.Attribute("units_short").Value,
					sa = el.Attribute("seasonal_adjustment_short").Value,
					fdate = el.Attribute("observation_start").Value,
					ldate = el.Attribute("observation_end").Value,
					udate = el.Attribute("last_updated").Value.Substring(0, 10)
				};

			return fredData;
		}

		//ID를 입력받아 메타정보를 가져옴.
		public static IEnumerable<FredSeriesInfo> GetSeriesInfo(string seriesId)
		{
			XElement root = XElement.Load("http://api.stlouisfed.org/fred/series?series_id=" + seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"]);

			var fredData =
				from el in root.Elements("series")
				select new FredSeriesInfo
				{
					id = el.Attribute("id").Value,
					title = el.Attribute("title").Value,
					freq = el.Attribute("frequency_short").Value,
					unit = el.Attribute("units_short").Value,
					sa = el.Attribute("seasonal_adjustment_short").Value,
					fdate = el.Attribute("observation_start").Value,
					ldate = el.Attribute("observation_end").Value,
					udate = el.Attribute("last_updated").Value.Substring(0, 10)
				};

			return fredData;
		}



		//public static bool IsUpdated(string seriesId, string lastDate, string updateDate)
		//{
		//    bool isUpdate;
		//    XElement root = XElement.Load("http://api.stlouisfed.org/fred/series?series_id=" + seriesId + "&api_key=" + ConfigurationManager.AppSettings["fredApiKey"]);

		//    var fredData =
		//        from el in root.Elements("series")
		//        select new
		//        {
		//            Edate = el.Attribute("observation_end").Value,
		//            Udate = el.Attribute("last_updated").Value
		//        };

		//    bool isLastDateStat = String.Equals(lastDate, fredData.ElementAt(0).Edate, StringComparison.Ordinal);
		//    bool isUpdateDateStat = String.Equals(updateDate, fredData.ElementAt(0).Udate.Substring(0, 10), StringComparison.Ordinal);

		//    if (isLastDateStat && isUpdateDateStat)
		//    {
		//        isUpdate = true;
		//    }
		//    else
		//    {
		//        isUpdate = false;
		//    }

		//    return isUpdate;
		//}
	}
	
	class FredData
	{ 
		//public string businessDate { get; set; }
		public DateTime businessDate { get; set; }
		public string economicIndex { get; set; }
	}

	class FredSeriesInfo
	{
		public string id { get; set; }
		public string title { get; set; }
		public string freq { get; set; }
		public string unit { get; set; }
		public string sa { get; set; }
		public string fdate { get; set; }
		public string ldate { get; set; }
		public string udate { get; set; }
	}

}
