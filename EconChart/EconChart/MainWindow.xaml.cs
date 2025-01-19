using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Visifire.Charts;
using Visifire.Commons;
using EconChart.Util;
using EconChart.Model;

namespace EconChart
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		Chart chart = null;
		

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

        private void NberTrendLine()
        {
            List<(DateTime start, DateTime end)> recessionPeriods = new List<(DateTime, DateTime)>
			    {
					(new DateTime(2007, 12, 1), new DateTime(2009, 6, 1)),
					(new DateTime(2001, 3, 1), new DateTime(2001, 11, 1)),
					(new DateTime(1990, 7, 1), new DateTime(1991, 3, 1)),
					(new DateTime(1981, 7, 1), new DateTime(1982, 11, 1)),
					(new DateTime(1980, 1, 1), new DateTime(1980, 7, 1)),
					(new DateTime(1973, 11, 1), new DateTime(1975, 3, 1)),
					(new DateTime(1969, 12, 1), new DateTime(1970, 11, 1)),
					(new DateTime(1960, 4, 1), new DateTime(1961, 2, 1)),
					(new DateTime(1957, 8, 1), new DateTime(1958, 4, 1)),
					(new DateTime(1953, 7, 1), new DateTime(1954, 5, 1)),
					(new DateTime(1948, 11, 1), new DateTime(1949, 10, 1)),
					(new DateTime(1945, 2, 1), new DateTime(1945, 10, 1)),
					(new DateTime(1937, 5, 1), new DateTime(1938, 6, 1)),
					(new DateTime(1929, 8, 1), new DateTime(1933, 3, 1)),
					(new DateTime(1926, 10, 1), new DateTime(1927, 11, 1)),
					(new DateTime(1923, 5, 1), new DateTime(1924, 7, 1)),
					(new DateTime(1920, 1, 1), new DateTime(1921, 7, 1)),
					(new DateTime(1918, 8, 1), new DateTime(1919, 3, 1)),
					(new DateTime(1913, 1, 1), new DateTime(1914, 12, 1)),
					(new DateTime(2020, 2, 1), new DateTime(2020, 4, 1))
				};

            foreach (var period in recessionPeriods)
            {
                TrendLine trendLine = new TrendLine()
                {
                    StartValue = period.start,
                    EndValue = period.end,
                    Orientation = Orientation.Vertical,
                    LineColor = Brushes.Gray
                };

                chart.TrendLines.Add(trendLine);
            }
        }

        // DB화 진행-> 취소하고 코드 간략화(chatgpt3.5)

        //private void NberTrendLine()
        //{
        //	//NBER Recession
        //	//TrendLine myTrendLine1 = new TrendLine();
        //	//myTrendLine1.StartValue = new DateTime(2007, 12, 1); // Convert.ToDateTime("2007-12-01");
        //	//myTrendLine1.EndValue = new DateTime(2009, 6, 1);
        //	//myTrendLine1.Orientation = Orientation.Vertical;
        //	//myTrendLine1.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine1 = new TrendLine()
        //	{
        //		StartValue = new DateTime(2007, 12, 1), // Convert.ToDateTime("2007-12-01");
        //		EndValue = new DateTime(2009, 6, 1),
        //		Orientation = Orientation.Vertical,
        //		LineColor = Brushes.Gray
        //	};

        //	TrendLine myTrendLine2 = new TrendLine();
        //	myTrendLine2.StartValue = new DateTime(2001, 3, 1);
        //	myTrendLine2.EndValue = new DateTime(2001, 11, 1);
        //	myTrendLine2.Orientation = Orientation.Vertical;
        //	myTrendLine2.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine3 = new TrendLine();
        //	myTrendLine3.StartValue = new DateTime(1990, 7, 1);
        //	myTrendLine3.EndValue = new DateTime(1991, 3, 1);
        //	myTrendLine3.Orientation = Orientation.Vertical;
        //	myTrendLine3.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine4 = new TrendLine();
        //	myTrendLine4.StartValue = new DateTime(1981, 7, 1);
        //	myTrendLine4.EndValue = new DateTime(1982, 11, 1);
        //	myTrendLine4.Orientation = Orientation.Vertical;
        //	myTrendLine4.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine5 = new TrendLine();
        //	myTrendLine5.StartValue = new DateTime(1980, 1, 1);
        //	myTrendLine5.EndValue = new DateTime(1980, 7, 1);
        //	myTrendLine5.Orientation = Orientation.Vertical;
        //	myTrendLine5.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine6 = new TrendLine();
        //	myTrendLine6.StartValue = new DateTime(1973, 11, 1);
        //	myTrendLine6.EndValue = new DateTime(1975, 3, 1);
        //	myTrendLine6.Orientation = Orientation.Vertical;
        //	myTrendLine6.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine7 = new TrendLine();
        //	myTrendLine7.StartValue = new DateTime(1969, 12, 1);
        //	myTrendLine7.EndValue = new DateTime(1970, 11, 1);
        //	myTrendLine7.Orientation = Orientation.Vertical;
        //	myTrendLine7.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine8 = new TrendLine();
        //	myTrendLine8.StartValue = new DateTime(1960, 4, 1);
        //	myTrendLine8.EndValue = new DateTime(1961, 2, 1);
        //	myTrendLine8.Orientation = Orientation.Vertical;
        //	myTrendLine8.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine9 = new TrendLine();
        //	myTrendLine9.StartValue = new DateTime(1957, 8, 1);
        //	myTrendLine9.EndValue = new DateTime(1958, 4, 1);
        //	myTrendLine9.Orientation = Orientation.Vertical;
        //	myTrendLine9.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine10 = new TrendLine();
        //	myTrendLine10.StartValue = new DateTime(1953, 7, 1);
        //	myTrendLine10.EndValue = new DateTime(1954, 5, 1);
        //	myTrendLine10.Orientation = Orientation.Vertical;
        //	myTrendLine10.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine11 = new TrendLine();
        //	myTrendLine11.StartValue = new DateTime(1948, 11, 1);
        //	myTrendLine11.EndValue = new DateTime(1949, 10, 1);
        //	myTrendLine11.Orientation = Orientation.Vertical;
        //	myTrendLine11.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine12 = new TrendLine();
        //	myTrendLine12.StartValue = new DateTime(1945, 2, 1);
        //	myTrendLine12.EndValue = new DateTime(1945, 10, 1);
        //	myTrendLine12.Orientation = Orientation.Vertical;
        //	myTrendLine12.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine13 = new TrendLine();
        //	myTrendLine13.StartValue = new DateTime(1937, 5, 1);
        //	myTrendLine13.EndValue = new DateTime(1938, 6, 1);
        //	myTrendLine13.Orientation = Orientation.Vertical;
        //	myTrendLine13.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine14 = new TrendLine();
        //	myTrendLine14.StartValue = new DateTime(1929, 8, 1);
        //	myTrendLine14.EndValue = new DateTime(1933, 3, 1);
        //	myTrendLine14.Orientation = Orientation.Vertical;
        //	myTrendLine14.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine15 = new TrendLine();
        //	myTrendLine15.StartValue = new DateTime(1926, 10, 1);
        //	myTrendLine15.EndValue = new DateTime(1927, 11, 1);
        //	myTrendLine15.Orientation = Orientation.Vertical;
        //	myTrendLine15.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine16 = new TrendLine();
        //	myTrendLine16.StartValue = new DateTime(1923, 5, 1);
        //	myTrendLine16.EndValue = new DateTime(1924, 7, 1);
        //	myTrendLine16.Orientation = Orientation.Vertical;
        //	myTrendLine16.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine17 = new TrendLine();
        //	myTrendLine17.StartValue = new DateTime(1920, 1, 1);
        //	myTrendLine17.EndValue = new DateTime(1921, 7, 1);
        //	myTrendLine17.Orientation = Orientation.Vertical;
        //	myTrendLine17.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine18 = new TrendLine();
        //	myTrendLine18.StartValue = new DateTime(1918, 8, 1);
        //	myTrendLine18.EndValue = new DateTime(1919, 3, 1);
        //	myTrendLine18.Orientation = Orientation.Vertical;
        //	myTrendLine18.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine19 = new TrendLine();
        //	myTrendLine19.StartValue = new DateTime(1913, 1, 1);
        //	myTrendLine19.EndValue = new DateTime(1914, 12, 1);
        //	myTrendLine19.Orientation = Orientation.Vertical;
        //	myTrendLine19.LineColor = Brushes.Gray;

        //	TrendLine myTrendLine20 = new TrendLine();
        //	myTrendLine20.StartValue = new DateTime(2020, 02, 01);
        //	//myTrendLine20.EndValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        //	myTrendLine20.EndValue = new DateTime(2020, 04, 01);
        //	myTrendLine20.Orientation = Orientation.Vertical;
        //	myTrendLine20.LineColor = Brushes.Gray;

        //	chart.TrendLines.Add(myTrendLine1);
        //	chart.TrendLines.Add(myTrendLine2);
        //	chart.TrendLines.Add(myTrendLine3);
        //	chart.TrendLines.Add(myTrendLine4);
        //	chart.TrendLines.Add(myTrendLine5);
        //	chart.TrendLines.Add(myTrendLine6);
        //	chart.TrendLines.Add(myTrendLine7);
        //	chart.TrendLines.Add(myTrendLine8);
        //	chart.TrendLines.Add(myTrendLine9);
        //	chart.TrendLines.Add(myTrendLine10);
        //	chart.TrendLines.Add(myTrendLine11);
        //	chart.TrendLines.Add(myTrendLine12);
        //	chart.TrendLines.Add(myTrendLine13);
        //	chart.TrendLines.Add(myTrendLine14);
        //	chart.TrendLines.Add(myTrendLine15);
        //	chart.TrendLines.Add(myTrendLine16);
        //	chart.TrendLines.Add(myTrendLine17);
        //	chart.TrendLines.Add(myTrendLine18);
        //	chart.TrendLines.Add(myTrendLine19);
        //	chart.TrendLines.Add(myTrendLine20);
        //}

        private void ZeroTrendLine()
		{
			chart.TrendLines.Add(new TrendLine { Value = 0, LineColor = Brushes.Red });
		}

        //ds.ColorSet = "VisiBlue" //VisiOrange, VisiRed, VisiGray, VisiGreen, VisiViolet, VisiAqua
        enum LineColors { VisiBlue, VisiOrange, VisiRed, VisiGray, VisiGreen, VisiViolet, VisiAqua };

		#region Chart List

		#region Fred Exchange Rate List
		// Wilshire 5000 Total Market Full Cap Index
		// S&P 500
		// NASDAQ Composite Index
		// Dow Jones Transportation Average
		// Dow Jones Industrial Average
		private void DowJonesIndex_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetDowJonesIndex();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "DOW Index";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "DOW Index";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		private void NasdaqIndex_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetNasdaqCompoIndex();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "NASDAQ Index";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "NASDAQ Index";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		private void Snp500Index_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetSnP500Index();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "S&P 500 Index";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "S&P 500 Index";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}


        //
        private void FredDgs10Dgs2SpreadCompareDexkous_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredDgs10Dgs2SpreadCompareDexkous();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "달러/원 환율과 미국채 10-2 Spread 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "달러/원";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LegendText = "TB 10y-2y Spread";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }


        //VIX and SP500
        private void WtiAndOilVix_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetWtiAndOilVix();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "WTI and Oil VIX";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "WTI";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "Oil VIX";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		private void FedFundRate_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFedFundRate();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Fed Fund Rate";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Fed Fund Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//
		private void FedFundRateDgs2AndDgs10_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFedFundRateDgs2AndDgs10();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

            Title myTitle = new Title
            {
                Text = "Fed Fund Rate, DGS2 and DGS10",
                DockInsidePlotArea = true
            };
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis
            {
                ValueFormatString = "yyyy",
                IntervalType = IntervalTypes.Years,
                Interval = 2
            };

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

            DataSeries ds = new DataSeries
            {
                DataSource = myList,
                RenderAs = RenderAs.QuickLine,
                MarkerEnabled = false,
                XValueType = ChartValueTypes.Date,
                LegendText = "Fed Fund Rate",
                LineThickness = 3,
                ColorSet = LineColors.VisiBlue.ToString()
            };
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });
			ds.ToolTipText = "FFR : #XValue, #YValue";

            DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "DGS2";
			ds2.ColorSet = LineColors.VisiGreen.ToString();
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });
            ds2.ToolTipText = "DGS2 : #XValue, #YValue";

            DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "DGS10";
			ds3.ColorSet = LineColors.VisiRed.ToString();
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });
            ds3.ToolTipText = "DGS10 : #XValue, #YValue";

            chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

        //
        private void BokKeyRateKtb10AndDgs10_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetBokKeyRateKtb10AndDgs10();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title
            {
                Text = "BOK Key Rate, KTB10 and DGS10",
                DockInsidePlotArea = true
            };
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis
            {
                ValueFormatString = "yyyy",
                IntervalType = IntervalTypes.Years,
                Interval = 2
            };

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries
            {
                DataSource = myList,
                RenderAs = RenderAs.QuickLine,
                MarkerEnabled = false,
                XValueType = ChartValueTypes.Date,
                LegendText = "BOK Key Rate",
                LineThickness = 3,
                ColorSet = LineColors.VisiBlue.ToString()
            };
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });
            ds.ToolTipText = "BOKRATE : #XValue, #YValue";

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "KTB10";
            ds2.ColorSet = LineColors.VisiGreen.ToString();
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });
            ds2.ToolTipText = "KTB10 : #XValue, #YValue";

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "DGS10";
            ds3.ColorSet = LineColors.VisiRed.ToString();
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });
            ds3.ToolTipText = "DGS10 : #XValue, #YValue";

            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //
        private void BOKRateKtb3Ktb10_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();
			
            var myList = new List<ChartSeries>();
            myList = DbHandler.GetBOKRateKtb3Ktb10();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BOK Keyrate, KTB3, KTB10";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "BOK Keyrate";
            ds.LineThickness = 3;
            ds.ColorSet = LineColors.VisiBlue.ToString();
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "KTB3";
            ds2.ColorSet = LineColors.VisiGreen.ToString();
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "KTB10";
            ds3.ColorSet = LineColors.VisiRed.ToString();
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //
        private void FedFundRateDgs20AndDgs30_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetDffDgs20Dgs30();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "Fed Fund Rate, DGS20 and DGS30";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Fed Fund Rate";
            ds.LineThickness = 3;
            ds.ColorSet = LineColors.VisiBlue.ToString();
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "DGS20";
            ds2.ColorSet = LineColors.VisiGreen.ToString();
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "DGS30";
            ds3.ColorSet = LineColors.VisiRed.ToString();
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //VIX and SP500
        private void VixVsSp500Day_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetVixVsSp500Day();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "VIX and SP500";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "VIX";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "SP500";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//VIX 3mo and SP500 
		private void Vix3moVsSp500Day_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetVix3moVsSp500Day();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "VIX 3MO and SP500";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "VIX 3MO";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "SP500";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//VIX and DGS10
		private void VixVsDgs10_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetVixVsDgs10();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "VIX and DGS10";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "DGS10 VIX";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "DGS10";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//VIX and WTI
		private void VixVsWti_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetVixVsWti();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "VIX and WTI";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Oil VIX";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "WTI";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 U.S. Treasury 10년 채권 동향
		private void UsGB10YSMA_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetUsGB10YSMA();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 미국채 10년물 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "일간";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "20 SMA";
            ds2.ColorSet = "VisiOrange";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "60 SMA";
            ds3.ColorSet = "VisiRed";
            ds3.LineThickness = 3;
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

            DataSeries ds4 = new DataSeries();
            ds4.DataSource = myList;
            ds4.RenderAs = RenderAs.QuickLine;
            ds4.MarkerEnabled = false;
            ds4.XValueType = ChartValueTypes.Date;
            ds4.LegendText = "200 SMA";
            ds4.ColorSet = "VisiGray";
            ds4.LineThickness = 5;
            ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series4" });


            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);
            chart.Series.Add(ds4);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //일간 U.S. Treasury vs 한국 국채 10년 채권 동향
        private void UsGB10YvsKrGB10Y_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetUsGB10YvsKrGB10Y();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 U.S. Treasury vs 한국 국채 10년 채권 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "KTB 10Y";
            ds.ColorSet = LineColors.VisiBlue.ToString();
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "UST 10Y";
            ds2.LineThickness = 2;            
            ds2.ColorSet = LineColors.VisiViolet.ToString();
            //ds2.ColorSet = Colors.Black.ToString();
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "SPREAD";            
            ds3.AxisYType = AxisTypes.Secondary;
            ds3.ColorSet = LineColors.VisiRed.ToString();
            ds3.LineThickness = 3;
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // Brazil / U.S. Foreign Exchange Rate(일간)
        private void FredDexBzUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexBzUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Brazil / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Brazil / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Canada / U.S. Foreign Exchange Rate(일간)
		private void FredDexCaUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexCaUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Canada / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Canada / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// China / U.S. Foreign Exchange Rate(일간)
		private void FredDexChUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexChUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "China / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "China / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// India / U.S. Foreign Exchange Rate(일간)
		private void FredDexInUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexInUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "India / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "India / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Japan / U.S. Foreign Exchange Rate(일간)
		private void FredDexJpUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexJpUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Japan / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Japan / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Korea / U.S. Foreign Exchange Rate(일간)
		private void FredDexKoUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexKoUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Korea / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Korea / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Malaysia / U.S. Foreign Exchange Rate(일간)
		private void FredDexMaUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexMaUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Malaysia / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Malaysia / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Mexico / U.S. Foreign Exchange Rate(일간)
		private void FredDexMxUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexMxUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Mexico / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Mexico / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Sweden / U.S. Foreign Exchange Rate(일간)
		private void FredDexSdUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexSdUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Sweden / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Sweden / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// South Africa / U.S. Foreign Exchange Rate(일간)
		private void FredDexSfUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexSfUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "South Africa / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "South Africa / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Singapore / U.S. Foreign Exchange Rate(일간)
		private void FredDexSiUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexSiUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Singapore / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Singapore / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Switzerland / U.S. Foreign Exchange Rate(일간)
		private void FredDexSzUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexSzUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Switzerland / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Switzerland / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Taiwan / U.S. Foreign Exchange Rate(일간)
		private void FredDexTaUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexTaUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Taiwan / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Taiwan / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Thailand / U.S. Foreign Exchange Rate(일간)
		private void FredDexThUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexThUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Thailand / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Thailand / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Venezuela / U.S. Foreign Exchange Rate(일간)
		private void FredDexVzUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexVzUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Venezuela / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Venezuela / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// U.S. / Australia Foreign Exchange Rate(일간)
		private void FredDexUsAl_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexUsAl();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Australia / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Australia / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// U.S. / Euro Foreign Exchange Rate(일간)
		private void FredDexUsEu_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexUsEu();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Euro / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Euro / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// U.S. / New Zealand Foreign Exchange Rate(일간)
		private void FredDexUsNz_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexUsNz();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "New Zealand / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "New Zealand / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// U.S. / U.K. Foreign Exchange Rate(일간)
		private void FredDexUsUk_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDexUsUk();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "U.K. / U.S.(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "U.K. / U.S.";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Trade Weighted U.S. Dollar Index: Broad(Euro Area, Canada, Japan, Mexico, China, United Kingdom, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Switzerland, Thailand, Philippines, Australia, Indonesia, India, Israel, Saudi Arabia, Russia, Sweden, Argentina, Venezuela, Chile, Colombia)(일간)
		private void FredDtwExb_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDtwExb();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Trade Weighted U.S. Dollar Index: Broad(Euro Area, Canada, Japan, Mexico, China, United Kingdom, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Switzerland, Thailand, Philippines, Australia, Indonesia, India, Israel, Saudi Arabia, Russia, Sweden, Argentina, Venezuela, Chile, Colombia)(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Trade Weighted U.S. Dollar Index: Broad";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Trade Weighted U.S. Dollar Index: Major Currencies(Euro Area, Canada, Japan, United Kingdom, Switzerland, Australia, Sweden)
		private void FredDtwExm_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDtwExm();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Trade Weighted U.S. Dollar Index: Major Currencies(Euro Area, Canada, Japan, United Kingdom, Switzerland, Australia, Sweden)(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Trade Weighted U.S. Dollar Index: Major Currencies";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// Trade Weighted U.S. Dollar Index: Other Important Trading Partners(Mexico, China, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Thailand, Philippines, Indonesia, India, Israel, Saudi Arabia, Russia, Argentina, Venezuela, Chile, Colombia)
		private void FredDtwExo_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDtwExo();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Trade Weighted U.S. Dollar Index: Other Important Trading Partners(Mexico, China, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Thailand, Philippines, Indonesia, India, Israel, Saudi Arabia, Russia, Argentina, Venezuela, Chile, Colombia)(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Trade Weighted U.S. Dollar Index: Other Important Trading Partners";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 일간 WTI, Trade Weighted U.S. Dollar Index: Other Important Trading Partners
		private void FredWtiAndTwExo_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredWtiAndTwExo();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "WTI, Trade Weighted U.S. Dollar Index: Other Important Trading Partners (일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "WTI";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "Trade Weighted U.S. Dollar Index: Other Important Trading Partners";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for Brazil, DEXBZUS
		private void FredEffExBzEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExBzEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for Brazil, DEXBZUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Brazil / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Brazil";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for Canada, DEXCAUS
		private void FredEffExCaEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExCaEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for Canada, DEXCAUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Canada / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Canada";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for China, DEXCHUS
		private void FredEffExChEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExChEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for China, DEXCHUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "China / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for China";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for India, DEXINUS
		private void FredEffExInEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExInEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for India, DEXINUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "India / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for India";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for Japan, DEXJPUS
		private void FredEffExJpEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExJpEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for Japan, DEXJPUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Japan / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Japan";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for Korea, DEXKOUS
		private void FredEffExKoEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExKoEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for Korea, DEXKOUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Korea / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Korea";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for Malaysia, DEXMAUS
		private void FredEffExMaEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExMaEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for Malaysia, DEXMAUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Malaysia / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Malaysia";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// BIS Real Broad Effective Exchange Rate for Mexico, DEXMXUS
		private void FredEffExMxEx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredEffExMxEx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "BIS Real Broad Effective Exchange Rate for Mexico, DEXMXUS (월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Mexico / U.S. Foreign Exchange Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Mexico";
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

        // BIS Real Broad Effective Exchange Rate for Sweden, DEXSDUS
        private void FredEffExSdEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExSdEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Sweden, DEXSDUS (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Sweden / U.S. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Sweden";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for South Africa, DEXSFUS
        private void FredEffExSfEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExSfEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for South Africa, DEXSFUS (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "South Africa / U.S. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for South Africa";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for Singapore, DEXSIUS
        private void FredEffExSiEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExSiEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Singapore, DEXSIUS (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Singapore / U.S. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Singapore";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for Switzerland, DEXSZUS
        private void FredEffExSzEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExSzEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Switzerland, DEXSZUS (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Switzerland / U.S. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Switzerland";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for Taiwan, DEXTAUS
        private void FredEffExTaEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExTaEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Taiwan, DEXTAUS (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Taiwan / U.S. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Taiwan";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for Thailand, DEXTHUS
        private void FredEffExThEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExThEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Thailand, DEXTHUS (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Thailand / U.S. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Thailand";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for Australia, DEXUSAL
        private void FredEffExAlEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExAlEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Australia, DEXUSAL (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "U.S. / Australia Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Australia";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for Euro, DEXUSEU
        private void FredEffExEuEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExEuEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Euro, DEXUSEU (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "U.S. / EU Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for EU";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for New Zealand, DEXUSNZ
        private void FredEffExNzEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExNzEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for New Zealand, DEXUSNZ (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "U.S. / New Zealand Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for New Zealand";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for U.K., DEXUSUK
        private void FredEffExUkEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExUkEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for U.K., DEXUSUK (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "U.S. / U.K. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for U.K.";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // BIS Real Broad Effective Exchange Rate for Venezuela, DEXVZUS
        private void FredEffExVzEx_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredEffExVzEx();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "BIS Real Broad Effective Exchange Rate for Venezuela, DEXVZUS (월간)";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Venezuela / U.S. Foreign Exchange Rate";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "BIS Real Broad Effective Exchange Rate for Venezuela";
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // 일간 미일 2년물 스프레드와 엔달러 환율
        private void UsJpBond2ySpreadAndYenDollar_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetUsJpBond2ySpreadAndYenDollar();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 미일 2년물 스프레드와 엔달러 환율";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "미일 2년물 Spread";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LegendText = "DEXJPUS";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // 국고채 3년, 통안2년 스프레드와 원달러 환율
        private void KoKtb3Msb2SpreadDexkous_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetKoKtb3Msb2SpreadDexkous();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 국고채 3년, 통안2년 스프레드와 원달러 환율";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "국고채 3년, 통안2년 스프레드";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LegendText = "DEXKOUS";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //한미일 2년물 스프레드 동향
        private void KoUsJp2yrSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetKoUsJp2yrSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 한미일 2년물 스프레드 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "한일 ";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;            
            ds2.LegendText = "미일 ";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }



        #endregion

        #region Ecos Interest Rate
        //일간 ECOS 채권 동향
        private void EcosKtbStatus_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtbStatus();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 ECOS 채권 동향";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			
			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "CD(91일)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });
            ds.ToolTipText = "CD(91일) : #XValue, #YValue";

            DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "국고채(1년)";
			ds2.ColorSet = "VisiOrange";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });
            ds2.ToolTipText = "국고채(1년) : #XValue, #YValue";

            DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "국고채(3년)";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });
            ds3.ToolTipText = "국고채(3년) : #XValue, #YValue";

            DataSeries ds4 = new DataSeries();
			ds4.DataSource = myList;
			ds4.RenderAs = RenderAs.QuickLine;
			ds4.MarkerEnabled = false;
			ds4.XValueType = ChartValueTypes.Date;
			ds4.LegendText = "국고채(5년)";
			ds4.ColorSet = "VisiGray";
			ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series4" });
            ds4.ToolTipText = "국고채(5년) : #XValue, #YValue";

            DataSeries ds5 = new DataSeries();
			ds5.DataSource = myList;
			ds5.RenderAs = RenderAs.QuickLine;
			ds5.MarkerEnabled = false;
			ds5.XValueType = ChartValueTypes.Date;
			ds5.LegendText = "국고채(10년)";
			ds5.ColorSet = "VisiGreen";
			ds5.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds5.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series5" });
            ds5.ToolTipText = "국고채(10년) : #XValue, #YValue";

            DataSeries ds6 = new DataSeries();
			ds6.DataSource = myList;
			ds6.RenderAs = RenderAs.QuickLine;
			ds6.MarkerEnabled = false;
			ds6.XValueType = ChartValueTypes.Date;
			ds6.LegendText = "국고채(20년)";
			ds6.ColorSet = "VisiViolet";
			ds6.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds6.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series6" });
            ds6.ToolTipText = "국고채(20년) : #XValue, #YValue";

            DataSeries ds7 = new DataSeries();
			ds7.DataSource = myList;
			ds7.RenderAs = RenderAs.QuickLine;
			ds7.MarkerEnabled = false;
			ds7.XValueType = ChartValueTypes.Date;
			ds7.LegendText = "국고채(30년)";
			ds7.ColorSet = "VisiAqua";
			ds7.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds7.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series7" });
            ds7.ToolTipText = "국고채(30년) : #XValue, #YValue";

            DataSeries ds8 = new DataSeries();
			ds8.DataSource = myList;
			ds8.RenderAs = RenderAs.QuickLine;
			ds8.MarkerEnabled = false;
			ds8.XValueType = ChartValueTypes.Date;
			ds8.LegendText = "콜금리";
			ds8.LineThickness = 2;
			ds8.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds8.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series8" });
            ds8.ToolTipText = "콜금리 : #XValue, #YValue";

            chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);
			chart.Series.Add(ds4);
			chart.Series.Add(ds5);
			chart.Series.Add(ds6);
			chart.Series.Add(ds7);
			chart.Series.Add(ds8);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 통안증권(91일물)
		private void EcosMsb91D_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosMsb91D();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 통안증권(91일물)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 통안증권(91일물)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "MSB91D-TB3Mo Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 CD(91일)
		private void EcosCd91D_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosCd91D();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 CD(91일)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 CD(91일)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "CD91D-TB3Mo Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 국고채(30년)
		private void EcosKtb30Y_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtb30Y();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 국고채(30년)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 국고채(30년)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "KTB30Y-TB30Y Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 국고채(20년)
		private void EcosKtb20Y_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtb20Y();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 국고채(20년)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 국고채(20년)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "KTB20Y-TB20Y Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 국고채(10년)
		private void EcosKtb10Y_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtb10Y();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 국고채(10년)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 국고채(10년)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "일간 미국채(10년)";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 국고채(5년)
		private void EcosKtb5Y_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtb5Y();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 국고채(5년)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 국고채(5년)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "KTB5Y-TB5Y Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

        //

        private void KospiAndSnp_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetKospiAndSnp();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 KOSPI and S&P 500";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "일간 KOSPI";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "S&P 500";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //
        private void DxyAndFedFundRate_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetDxyAndFedFundRate();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 Dollar Index and Federal Fund Rate";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "일간 DXY";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LegendText = "FFR";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        private void MoveAndDexkous_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetMoveAndDexkous();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 Move Index and 달러-원 환율";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "MOVE";
            ds.ColorSet = "VisiBlue";			
			ds.LineThickness = 2;
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LegendText = "DEXKOUS";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        private void MoveAndDgs10_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetMoveAndDgs10();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 Move Index and DGS10";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "MOVE";
            ds.ColorSet = "VisiBlue";
            ds.LineThickness = 2;
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LegendText = "DGS10";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        private void MoveAndKtb10_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetMoveAndKtb10();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 Move Index and 국고채10년물";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "MOVE";
            ds.ColorSet = "VisiBlue";
            ds.LineThickness = 2;
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LegendText = "KTB10";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //일간 국고채(3년)
        private void EcosKtb3Y_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtb3Y();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 국고채(3년)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 국고채(3년)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "일간 미국채(3년)";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 국고채(1년)
		private void EcosKtb1Y_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtb1Y();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 국고채(1년)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 국고채(1년)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "KTB1Y-TB1Y Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 KORIBOR(3개월)
		private void EcosKoribor3M_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKoribor3M();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 KORIBOR(3개월)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 KORIBOR(3개월)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "KORIBOR-LIBOR Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });
						
			chart.Series.Add(ds);
			chart.Series.Add(ds2);            

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 KORIBOR(6개월)
		private void EcosKoribor6M_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKoribor6M();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 KORIBOR(6개월)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 KORIBOR(6개월)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "KORIBOR-LIBOR Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 KORIBOR(12개월)
		private void EcosKoribor12M_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKoribor12M();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 KORIBOR(12개월)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 KORIBOR(12개월)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "KORIBOR-LIBOR Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 콜금리(익일물, 중개회사거래)
		private void EcosCallRate_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosCallRate();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 콜금리(익일물, 중개회사거래)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일간 콜금리(익일물, 중개회사거래)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "콜금리-FFR Spread";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

        //일간 10Y KTB Minus 3M CD
        //and 10Y KTB Minus 2Y MSB
        private void EcosCycleSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcosCycleSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "The Spread : Business Cycle";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "10Y KTB Minus 2Y MSB";
            ds.ColorSet = "VisiBlue";
            ds.LineThickness = 2;
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "10Y KTB Minus 3M CD";
            ds2.ColorSet = "VisiRed";
            ds2.LineThickness = 2;
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //일간 국고채(3년), 국고채(10년), 스프레드
        private void EcosKtb3YKtb10YSpread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosKtb3YKtb10YSpread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 국고채(3년), 국고채(10년), 스프레드";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Spread";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//월간 독일 10년물, 미국채 10년물, 스프레드
		private void EcosBund10YDgs10YSpread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosBund10YDgs10YSpread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 독일 10년물, 미국채 10년물, 스프레드";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "독일 10년물";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "미국채 10년물";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "Spread";
			ds3.ColorSet = "VisiGray";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

        //KOSPI 와 미국채 10년물 동향
        private void EcosKospiAndDgs10_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcosKospiAndDgs10();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "KOSPI 와 미국채 10년물 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "KOSPI";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "미국채 10년물";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //CD금리와 미국채 3개월물 동향
        private void Ecos90DDgs3MoSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcos90DDgs3MoSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "CD금리와 미국채 3개월물 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            //Axis yAxisRight = new Axis();
            //yAxisRight.AxisType = AxisTypes.Secondary;
            //yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            //chart.AxesY.Add(yAxisRight);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "한국 CD금리";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "미국채 3개월물 금리";
            ds2.ColorSet = "VisiRed";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            //ds3.AxisYType = AxisTypes.Secondary;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "Spread";
            ds3.ColorSet = "VisiGray";
            ds3.LineThickness = 3;
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //월간 영국 10년물, 미국채 10년물, 스프레드
        private void EcosEgb10YDgs10YSpread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosEgb10YDgs10YSpread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 영국 10년물, 미국채 10년물, 스프레드";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "영국 10년물";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "미국채 10년물";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "Spread";
			ds3.ColorSet = "VisiGray";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//월간 일본 10년물, 미국채 10년물, 스프레드
		private void EcosJgb10YDgs10YSpread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosJgb10YDgs10YSpread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 일본 10년물, 미국채 10년물, 스프레드";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "일본 10년물";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "미국채 10년물";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "Spread";
			ds3.ColorSet = "VisiGray";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

        //국고채 3년물-회사채(3년,AA-) 스프레드
        private void EcosKtb3Cb3aaSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcosKtb3Cb3aaSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "국고채 3년물-회사채(3년,AA-) 스프레드";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "스프레드";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //국고채 3년물-회사채(3년)(BBB-) 스프레드
        private void EcosKtb3Cb3bbbSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcosKtb3Cb3bbbSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "국고채 3년물-회사채(3년,BBB-) 스프레드";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "스프레드";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //국고채 5년물-회사채(3년,AA-) 스프레드
        private void EcosKtb5Cb3aaSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcosKtb5Cb3aaSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "국고채 5년물-회사채(3년,AA-) 스프레드";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "스프레드";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //국고채 5년물-회사채(3년)(BBB-) 스프레드
        private void EcosKtb5Cb3bbbSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcosKtb5Cb3bbbSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "국고채 5년물-회사채(3년,BBB-) 스프레드";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "스프레드";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //국고채 3년물-콜금리 스프레드
        private void EcosKtb3CallSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetEcosKtb3CallSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "국고채 3년물-콜금리 스프레드";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "스프레드";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        #endregion

        #region Ecos Exchange Rate List
        // 원/위안(매매기준율)(일간)
        private void EcosDexKoCn_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoCn();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/위안(매매기준율)(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/위안(매매기준율)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/남아프리카공화국 랜드(일간)
		private void EcosDexKoZa_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoZa();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/남아프리카공화국 랜드(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/남아프리카공화국 랜드";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/터키 리라(일간)
		private void EcosDexKoTr_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoTr();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/터키 리라(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/터키 리라";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/러시아 루블(일간)
		private void EcosDexKoRu_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoRu();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/러시아 루블(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/러시아 루블";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/아르헨티나 페소(일간)
		private void EcosDexKoAr_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoAr();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/아르헨티나 페소(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/아르헨티나 페소";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/브라질 헤알(일간)
		private void EcosDexKoBr_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoBr();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/브라질 헤알(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/브라질 헤알";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/멕시코 페소(일간)
		private void EcosDexKoMx_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoMx();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/멕시코 페소(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/멕시코 페소";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/인도 루피(일간)
		private void EcosDexKoIn_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoIn();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/인도 루피(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/인도 루피";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/베트남 동(일간)
		private void EcosDexKoVn_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoVn();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/베트남 동(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/베트남 동";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/인도네시아 루피아(100루피아) (일간)
		private void EcosDexKoId_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoId();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/인도네시아 루피아(100루피아) (일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/인도네시아 루피아(100루피아)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/필리핀 페소(일간)
		private void EcosDexKoPh_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoPh();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/필리핀 페소(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/필리핀 페소";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/대만 달러(일간)
		private void EcosDexKoTa_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoTa();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/대만 달러(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/대만 달러";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/태국 바트(일간)
		private void EcosDexKoTh_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoTh();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/태국 바트(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/태국 바트";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/뉴질랜드 달러(일간)
		private void EcosDexKoNz_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoNz();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/뉴질랜드 달러(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/뉴질랜드 달러";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 원/말레이지아 링기트(일간)
		private void EcosDexKoMa_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoMa();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/말레이지아 링기트(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/말레이지아 링기트";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 원/싱가폴 달러(일간)
		private void EcosDexKoSi_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoSi();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/싱가폴 달러(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/싱가폴 달러";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 원/호주 달러(일간)
		private void EcosDexKoAl_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoAl();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/호주 달러(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/호주 달러";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 원/스웨덴 크로나(일간)
		private void EcosDexKoSd_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoSd();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/스웨덴 크로나(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/스웨덴 크로나";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;            
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}


		// 원/스위스 프랑(일간)
		private void EcosDexKoSz_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoSz();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/스위스 프랑(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/스위스 프랑";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 원/캐나다달러(일간)
		private void EcosDexKoCa_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoCa();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/캐나다달러(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/캐나다달러";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 원/영국파운드(일간)
		private void EcosDexKoUk_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoUk();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/영국파운드(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/영국파운드";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 원/Euro
		private void EcosDexKoEu_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoEu();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/Euro(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/Euro";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 원/엔 재정환율
		private void EcosDexKoJp_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoJp();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/100엔(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/100엔";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 원/달러
		private void EcosDexKoUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/달러(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/달러";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "60 SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200 SMA";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 원/달러, 엔/달러, 원/엔 재정환율
		private void DexKoUs_JpUs_KoJp_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetDexKoUs_JpUs_KoJp();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;
			

			Title myTitle = new Title();
			myTitle.Text = "일간 원/달러, 엔/달러, 원/엔 재정환율";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;            
			ds.LegendText = "원/엔 재정환율";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "엔/달러";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "원/달러";
			ds3.ColorSet = "VisiRed";
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 원/달러 환율과 외국인 거래소 순매수 90일 이동평균
		private void EcosDexKoUsAndBuySell90Sma_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoUsAndBuySell90Sma();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "원/달러 환율과 외국인 거래소 순매수 90일 이동평균";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/달러 환율 90D SMA";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "외국인 거래소 순매수 90D SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });
			
			chart.Series.Add(ds);
			chart.Series.Add(ds2);            

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 월간 미일 CD금리차, 한미 CD금리차, 원엔 재정환율
		private void CdSpreadJpUsAndKoUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetCdSpreadJpUsAndKoUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 미일 CD금리차, 한미 CD금리차, 원엔 재정환율";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "미일 CD금리차";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "한미 CD금리차";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "원엔 재정환율";
			ds3.ColorSet = "VisiRed";

			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		private void Ktb10AndGs10AndKRW_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetKtb10AndGs10AndKRW();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "KTB10, GS10 and KRW";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "KTB10";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "GS10";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "KRW";
			ds3.ColorSet = "VisiRed";

			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 원/달러, BofA Merrill Lynch Asia Emerging Markets Corporate Plus Sub-Index Option-Adjusted Spreadⓒ
		private void EcosDexKoUsAndAsiaEmergingMarketsCorporatePlusSubIndex_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoUsAndAsiaEmergingMarketsCorporatePlusSubIndex();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "원/달러, BofA Merrill Lynch Asia Emerging Markets Corporate Plus Sub-Index Option-Adjusted Spreadⓒ";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/달러";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "BofA Merrill Lynch Asia Emerging Markets Corporate Plus Sub-Index Option-Adjusted Spreadⓒ";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds2);
			
			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

        //

        private void KrKeyRateAndUsFfrSpreadVsDexKoUs_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetKrKeyRateAndUsFfrSpreadVsDexKoUs();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "원/달러, 한미 양국 기준 금리차";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            // Y축 : 오른쪽 
            Axis yAxisRight = new Axis();
            yAxisRight.AxisType = AxisTypes.Secondary;
            yAxisRight.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);
            chart.AxesY.Add(yAxisRight);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "원/달러";
            ds.ColorSet = "VisiBlue";

            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.AxisYType = AxisTypes.Secondary;
            ds2.LineThickness = 2;
            ds2.LegendText = "한미 양국 기준 금리차";
            ds2.ColorSet = "VisiGreen";

            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();

        }

        // 일간 원/달러, WTI
        private void EcosDexKoUsAndWti_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoUsAndWti();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 원/달러, WTI";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/달러";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "WTI";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 원/달러, Trade Weighted U.S. Dollar Index: Other Important Trading Partners
		private void EcosDexKoUsAndTwExo_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosDexKoUsAndTwExo();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 원/달러, WTI";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/달러";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "Trade Weighted U.S. Dollar Index: Other Important Trading Partners";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

        #endregion

        #region Fred Interest Rate
        //일간 10-Year Treasury Constant Maturity Minus 3 Month Treasury Constant Maturity 
        //and 10-Year Treasury Constant Maturity Minus 2-Year Treasury Constant Maturity
        private void FredCycleSpread_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredCycleSpread();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "The Spread : Business Cycle";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "10-Year Treasury Constant Maturity Minus 2-Year Treasury Constant Maturity";
            ds.ColorSet = "VisiBlue";
            ds.LineThickness = 2;
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "10-Year Treasury Constant Maturity Minus 3 Month Treasury Constant Maturity";
            ds2.ColorSet = "VisiRed";
            ds2.LineThickness = 2;
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        //
        private void KrKeyRateAndUsFFR_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetKrKeyRateAndUsFFR();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "한미 양국 기준금리";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "KR Key Rates";
            ds.ColorSet = "VisiBlue";
            ds.LineThickness = 2;
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "US FFR";
            ds2.ColorSet = "VisiRed";
            ds2.LineThickness = 2;
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // 일간 10-Year Treasury Constant Maturity Minus Federal Funds Rate and Ted Spread
        private void FredDgs10DffSpreadAndTedRate_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDgs10DffSpreadAndTedRate();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "10-Year Treasury Constant Maturity Minus Federal Funds Rate(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			//Axis yAxisLeft = new Axis();
			//yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			//chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "10-Year Treasury Constant Maturity Minus Federal Funds Rate";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			//TedRate가 다른 시리즈로 대체되면서 종료됨.
			//DataSeries ds2 = new DataSeries();
			//ds2.DataSource = myList;
			//ds2.RenderAs = RenderAs.QuickLine;
			//ds2.MarkerEnabled = false;
			//ds2.XValueType = ChartValueTypes.Date;
			//ds2.LegendText = "Ted Spread";
			//ds2.ColorSet = "VisiGreen";
			//ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			//ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			//chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 일간 10-Year Treasury Constant Maturity Minus 3 Month Treasury Constant Maturity
		private void FredDgs10Dgs3moSpread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDgs10Dgs3moSpread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "10-Year Treasury Constant Maturity Minus 3 Month Treasury Constant Maturity(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "spread";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 일간 10-Year Treasury Constant Maturity Minus DBAA
		private void FredDgs10DbaaSpread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDgs10DbaaSpread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "10-Year Treasury Constant Maturity Minus DBAA(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "spread";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 일간 10-Year Treasury Constant Maturity Minus 2-Year Treasury Constant Maturity
		private void FredDgs10Dgs2Spread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDgs10Dgs2Spread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "10-Year Treasury Constant Maturity Minus 2-Year Treasury Constant Maturity(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "spread";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 일간 5-Year Treasury Constant Maturity Minus 5-Year Treasury Inflation-Indexed Security Constant Maturity
		private void FredDgs5Dfii5Spread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDgs5Dfii5Spread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "5-Year Treasury Constant Maturity Minus 5-Year Treasury Inflation-Indexed Security Constant Maturity(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();            

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "spread";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 일간 10-Year Treasury Constant Maturity Minus 10-Year Treasury Inflation-Indexed Security Constant Maturity
		private void FredDgs10Dfii10Spread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredDgs10Dfii10Spread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "10-Year Treasury Constant Maturity Minus 10-Year Treasury Inflation-Indexed Security Constant Maturity(일간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();            

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "spread";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

        //일간 U.S. Treasury 채권 동향
		//10년물 -> 기업 대출 기준물
		//30년물 -> 모기지 대출 기준물
		//중요성이 떨어지는 물건 제외
        private void FredTbStatus_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredTbStatus();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 U.S. Treasury 채권 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "3Mo";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });
            ds.ToolTipText = "DGS3MO : #XValue, #YValue";

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "TB(2년)";
            ds2.ColorSet = "VisiOrange";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });
            ds2.ToolTipText = "DGS2 : #XValue, #YValue";

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "TB(10년)";
            ds3.ColorSet = "VisiRed";
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });
            ds3.ToolTipText = "DGS10 : #XValue, #YValue";

            DataSeries ds4 = new DataSeries();
            ds4.DataSource = myList;
            ds4.RenderAs = RenderAs.QuickLine;
            ds4.MarkerEnabled = false;
            ds4.XValueType = ChartValueTypes.Date;
            ds4.LegendText = "TB(30년)";
            ds4.ColorSet = "VisiGray";
            ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series4" });
            ds4.ToolTipText = "DGS30 : #XValue, #YValue";


            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);
            chart.Series.Add(ds4);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }
        #endregion

        #region Fred Commitities
        // Crude Oil Prices: West Texas Intermediate (WTI) - Cushing, Oklahoma
        private void FredWti_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredWti();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Crude Oil Prices: West Texas Intermediate (WTI)(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();            

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Crude Oil Prices: West Texas Intermediate (WTI)";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;            
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Crude Oil Prices: Brent - Europe
		private void FredBrent_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredBrent();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Crude Oil Prices: Brent - Europe(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Crude Oil Prices: Brent - Europe";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Conventional Gasoline Prices: U.S. Gulf Coast, Regular
		private void FredGasolinePrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredGasolinePrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Conventional Gasoline Prices: U.S. Gulf Coast, Regular(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Conventional Gasoline Prices: U.S. Gulf Coast, Regular";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Henry Hub Natural Gas Spot Price
		private void FredNaturalGasPrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredNaturalGasPrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Henry Hub Natural Gas Spot Price(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Henry Hub Natural Gas Spot Price";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Kerosene-Type Jet Fuel Prices: U.S. Gulf Coast
		private void FredJetFuelPrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredJetFuelPrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Kerosene-Type Jet Fuel Prices: U.S. Gulf Coast(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Kerosene-Type Jet Fuel Prices: U.S. Gulf Coast";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Propane Prices: Mont Belvieu, Texas
		private void FredPropanePrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredPropanePrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Propane Prices: Mont Belvieu, Texas(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Propane Prices: Mont Belvieu, Texas";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// No. 2 Heating Oil Prices: New York Harbor
		private void FredHeatingOilPrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredHeatingOilPrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "No. 2 Heating Oil Prices: New York Harbor(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "No. 2 Heating Oil Prices: New York Harbor";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Global price of Iron Oreⓒ
		private void FredIronOrePrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredIronOrePrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Global price of Iron Oreⓒ(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Global price of Iron Oreⓒ";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Global price of Coal, Australiaⓒ
		private void FredCoalPrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredCoalPrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Global price of Coal, Australiaⓒ(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Global price of Coal, Australiaⓒ";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Global price of Cottonⓒ
		private void FredCottonPrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredCottonPrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Global price of Cottonⓒ(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Global price of Cottonⓒ";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Global price of Palm Oilⓒ
		private void FredPalmOilPrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredPalmOilPrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Global price of Palm Oilⓒ(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Global price of Palm Oilⓒ";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// Global price of Wheatⓒ
		private void FredWheatPrice_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredWheatPrice();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;


			Title myTitle = new Title();
			myTitle.Text = "Global price of Wheatⓒ(월간)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Global price of Wheatⓒ";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });


			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "3M SMA";
			ds2.ColorSet = "VisiGreen";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "PCYA";
			ds3.ColorSet = "VisiRed";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

        // Gas Margin
        private void FredGasWtiMargin_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredGasWtiMargin();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "Gas Margin";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Margin";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // Diesel Margin
        private void FredDieselWtiMargin_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredDieselWtiMargin();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "Diesel Margin";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Margin";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // Jet Margin
        private void FredJetWtiMargin_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredJetWtiMargin();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "Jet Margin";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Margin";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // Propane Margin
        private void FredPropaneWtiMargin_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredPropaneWtiMargin();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "Propane Margin";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Margin";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

        // Heating Oil Margin
        private void FredHeatingOilWtiMargin_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetFredHeatingOilWtiMargin();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "HeatingOil Margin";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "Margin";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            chart.Series.Add(ds);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

		#endregion

		#region ETC
		//일간 UsTreasSimple
		private void UsTreasSimple_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetUsTreasSimple();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 미 재무부 채권 Simple";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "3mo";
			ds.ColorSet = LineColors.VisiGreen.ToString();
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "2년";
			ds2.ColorSet = LineColors.VisiBlue.ToString();
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "10년";
			ds3.ColorSet = LineColors.VisiRed.ToString();
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// OAS Spread : 무위험 수익률
		private void BofAMerrillLynchOptionAdjustedSpread_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetBofAMerrillLynchOptionAdjustedSpread();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "OAS Spread : 무위험 수익률";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;
						
			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);            

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "US Corporate Master";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "Euro High Yield Index";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;            
			ds3.LegendText = "US High Yield";

			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds3);

			DataSeries ds4 = new DataSeries();
			ds4.DataSource = myList;
			ds4.RenderAs = RenderAs.QuickLine;
			ds4.MarkerEnabled = false;
			ds4.XValueType = ChartValueTypes.Date;
			ds4.LegendText = "Asia Emerging Markets Corporate Plus Sub-Index";

			ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series4" });

			chart.Series.Add(ds4);

			DataSeries ds5 = new DataSeries();
			ds5.DataSource = myList;
			ds5.RenderAs = RenderAs.QuickLine;
			ds5.MarkerEnabled = false;
			ds5.XValueType = ChartValueTypes.Date;
			ds5.LegendText = "Emerging Markets Corporate Plus Index";

			ds5.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds5.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series5" });

			chart.Series.Add(ds5);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 이머징 마켙 회사채-미국 회사채, 원달러
		private void FredBamlSpread1DexKoUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredBamlSpread1DexKoUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "이머징 마켙 회사채-미국 회사채, 원달러";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "이머징 마켙 회사채-미국 회사채";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "원달러";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 이머징 마켙 아시아 회사채-미국 회사채, 원달러
		private void FredBamlSpread2DexKoUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetFredBamlSpread2DexKoUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "이머징 마켙 아시아 회사채-미국 회사채, 원달러";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "이머징 마켙 아시아 회사채-미국 회사채";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "원달러";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		//일간 외국인 거래소 순매수 잠정치 60, 200 SMA
		private void ForeignKospiBuySell_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetForeignKospiBuySell();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 외국인 거래소";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "60SMA";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "200SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 외국인 KOSDAQ 순매수 잠정치 60, 200 SMA
		private void ForeignKosdaqBuySell_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetForeignKosdaqBuySell();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 외국인 KOSDAQ";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();
			ZeroTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "60SMA";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "200SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 수출 3개월, PCYA
		private void EcosExport3SmaPcya_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosExport3SmaPcya();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 수출";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "3개월 SMA";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "PCYA";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 수입 3개월, PCYA
		private void EcosImport3SmaPcya_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosImport3SmaPcya();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 수입";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "3개월 SMA";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "PCYA";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 비거주자 예수금: 원화예금 3개월, PCYA
		private void NonResidentWonDeposit3SmaPcya_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetNonResidentWonDeposit3SmaPcya();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 비거주자 예수금: 원화예금";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "3개월 SMA";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "PCYA";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 비거주자 예수금: 외화예금 3개월, PCYA
		private void NonResidentExDeposit3SmaPcya_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetNonResidentExDeposit3SmaPcya();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 비거주자 예수금: 외화예금";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "3개월 SMA";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "PCYA";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 대출/수신금리 및 순이자 마진(NIM)
		private void EcosLoanReceiveNim_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetEcosLoanReceiveNim();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "월간 대출/수신금리 및 순이자 마진(NIM)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "대출금리";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;            
			ds2.LegendText = "수신금리";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.Column;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.AxisYType = AxisTypes.Secondary;
			ds3.LegendText = "순이자 마진(NIM)";
			ds3.ColorSet = "VisiGreen";

			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 외국인 거래소 순매수 잠정치와 KOSPI
		private void YahooKospiAndEcosForeignKospiBuySell_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooKospiAndEcosForeignKospiBuySell();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 외국인 거래소 순매수 잠정치와 KOSPI";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "KOSPI";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.Column;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "외국인 KOSPI 순매수";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 외국인 KOSDAQ 순매수 잠정치와 KOSDAQ
		private void YahooKosdaqAndEcosForeignKosdaqBuySell_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooKosdaqAndEcosForeignKosdaqBuySell();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 외국인 KOSDAQ 순매수 잠정치와 KOSDAQ";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "KOSDAQ";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.Column;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LegendText = "외국인 KOSDAQ 순매수";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		// 일간 KOSPI 달러 환산 동향
		private void YahooKospiAndEcosDexKoUs_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooKospiAndEcosDexKoUs();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 외국인 거래소 달러 환산 지수";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "달러 환산 지수";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "60SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 2;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		private void YahooSectorEtfXLF_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLF();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Financial Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLF";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}



		private void YahooSectorEtfXLE_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLE();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Energy Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLE";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}



		private void YahooSectorEtfXLU_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLU();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Utilities Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLU";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}



		private void YahooSectorEtfXLP_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLP();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Consumer Staples Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLP";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}


		private void YahooSectorEtfXLY_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLY();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Consumer Discretionary Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLY";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}


		private void YahooSectorEtfXLI_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLI();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Industrial Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLI";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}



		private void YahooSectorEtfXLB_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLB();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Materials Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLB";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}



		private void YahooSectorEtfXLV_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLV();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Health Care Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLV";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}


		private void YahooSectorEtfXLK_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLK();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Technology Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLK";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}



		private void YahooSectorEtfXLC_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLC();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Communication Services Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLC";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		private void YahooSectorEtfXLRE_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooSectorEtfXLRE();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "The Real Estate Select Sector SPDR Fund";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "XLRE";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		// 
		private void YahooYahooDollarIndex_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooYahooDollarIndex();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 Dollar Index (DXY)";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "DXY";
			ds.ColorSet = "VisiBlue";
			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.LegendText = "50SMA";
			ds2.ColorSet = "VisiRed";
			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			DataSeries ds3 = new DataSeries();
			ds3.DataSource = myList;
			ds3.RenderAs = RenderAs.QuickLine;
			ds3.MarkerEnabled = false;
			ds3.XValueType = ChartValueTypes.Date;
			ds3.LegendText = "200SMA";
			ds3.ColorSet = "VisiViolet";
			ds3.LineThickness = 4;
			ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

			chart.Series.Add(ds);
			chart.Series.Add(ds2);
			chart.Series.Add(ds3);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();
		}

		//일간 BOJ 채권 동향
		private void QuandlBojStatus_Click(object sender, RoutedEventArgs e)
        {
            chart = null;
            chart = new Chart();

            var myList = new List<ChartSeries>();
            myList = DbHandler.GetBojJtbStatus();

            chart.AnimatedUpdate = false;
            chart.ZoomingEnabled = true;
            chart.IndicatorEnabled = true;
            chart.AnimationEnabled = false;

            Title myTitle = new Title();
            myTitle.Text = "일간 BOJ 채권 동향";
            myTitle.DockInsidePlotArea = true;
            chart.Titles.Add(myTitle);

            // X축 : 날짜
            Axis xAxis = new Axis();
            xAxis.ValueFormatString = "yyyy";
            xAxis.IntervalType = IntervalTypes.Years;
            xAxis.Interval = 2;

            // Y축 : 기본 왼쪽 
            Axis yAxisLeft = new Axis();
            yAxisLeft.ViewportRangeEnabled = true;

            chart.AxesX.Add(xAxis);
            chart.AxesY.Add(yAxisLeft);

            NberTrendLine();
            ZeroTrendLine();

            DataSeries ds = new DataSeries();
            ds.DataSource = myList;
            ds.RenderAs = RenderAs.QuickLine;
            ds.MarkerEnabled = false;
            ds.XValueType = ChartValueTypes.Date;
            ds.LegendText = "1년";
            ds.ColorSet = "VisiBlue";
            ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

            DataSeries ds2 = new DataSeries();
            ds2.DataSource = myList;
            ds2.RenderAs = RenderAs.QuickLine;
            ds2.MarkerEnabled = false;
            ds2.XValueType = ChartValueTypes.Date;
            ds2.LegendText = "2년";
            ds2.ColorSet = "VisiOrange";
            ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

            DataSeries ds3 = new DataSeries();
            ds3.DataSource = myList;
            ds3.RenderAs = RenderAs.QuickLine;
            ds3.MarkerEnabled = false;
            ds3.XValueType = ChartValueTypes.Date;
            ds3.LegendText = "3년";
            ds3.ColorSet = "VisiRed";
            ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series3" });

            DataSeries ds4 = new DataSeries();
            ds4.DataSource = myList;
            ds4.RenderAs = RenderAs.QuickLine;
            ds4.MarkerEnabled = false;
            ds4.XValueType = ChartValueTypes.Date;
            ds4.LegendText = "5년";
            ds4.ColorSet = "VisiGray";
            ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series4" });

            DataSeries ds5 = new DataSeries();
            ds5.DataSource = myList;
            ds5.RenderAs = RenderAs.QuickLine;
            ds5.MarkerEnabled = false;
            ds5.XValueType = ChartValueTypes.Date;
            ds5.LegendText = "7년";
            ds5.ColorSet = "VisiGreen";
            ds5.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds5.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series5" });

            DataSeries ds6 = new DataSeries();
            ds6.DataSource = myList;
            ds6.RenderAs = RenderAs.QuickLine;
            ds6.MarkerEnabled = false;
            ds6.XValueType = ChartValueTypes.Date;
            ds6.LegendText = "10년";
            ds6.ColorSet = "VisiViolet";
            ds6.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds6.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series6" });

            DataSeries ds7 = new DataSeries();
            ds7.DataSource = myList;
            ds7.RenderAs = RenderAs.QuickLine;
            ds7.MarkerEnabled = false;
            ds7.XValueType = ChartValueTypes.Date;
            ds7.LegendText = "20년";
            ds7.ColorSet = "VisiAqua";
            ds7.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds7.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series7" });

            DataSeries ds8 = new DataSeries();
            ds8.DataSource = myList;
            ds8.RenderAs = RenderAs.QuickLine;
            ds8.MarkerEnabled = false;
            ds8.XValueType = ChartValueTypes.Date;
            ds8.LegendText = "30년";
            ds8.LineThickness = 2;
            ds8.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
            ds8.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series8" });

            chart.Series.Add(ds);
            chart.Series.Add(ds2);
            chart.Series.Add(ds3);
            chart.Series.Add(ds4);
            chart.Series.Add(ds5);
            chart.Series.Add(ds6);
            chart.Series.Add(ds7);
            chart.Series.Add(ds8);

            LayoutRoot.Children.Clear();
            LayoutRoot.Children.Add(chart);

            myList.Clear();
        }

		private void YahooDollarIndexAndKRW_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooDollarIndexAndKRW();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 원/달러, DXY";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/달러";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "DXY";
			ds2.ColorSet = "VisiGreen";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		private void DEXKOUS52W_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetDEXKOUS52W();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 원/달러";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "원/달러";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "52주 평균";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		private void DXY52W_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetDXY52W();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 Dollar Index";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Dollar Index";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "52주 평균";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		private void DOLLARGAPINDEX_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetDOLLARGAPINDEX();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "Dollar GAP Index";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			//Axis yAxisRight = new Axis();
			//yAxisRight.AxisType = AxisTypes.Secondary;
			//yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			//chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "Dollar GAP Index";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			//ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "52주 평균";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}


		#endregion

		#region Yahoo Series

		private void YahooEtfEdvVsDgs20_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooEtfEdvVsDgs20();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 EDV ETF vs DGS20";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "EDV";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "DGS20";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		private void YahooEtfTltVsDgs20_Click(object sender, RoutedEventArgs e)
		{
			chart = null;
			chart = new Chart();

			var myList = new List<ChartSeries>();
			myList = DbHandler.GetYahooEtfTltVsDgs20();

			chart.AnimatedUpdate = false;
			chart.ZoomingEnabled = true;
			chart.IndicatorEnabled = true;
			chart.AnimationEnabled = false;

			Title myTitle = new Title();
			myTitle.Text = "일간 TLT ETF vs DGS20";
			myTitle.DockInsidePlotArea = true;
			chart.Titles.Add(myTitle);

			// X축 : 날짜
			Axis xAxis = new Axis();
			xAxis.ValueFormatString = "yyyy";
			xAxis.IntervalType = IntervalTypes.Years;
			xAxis.Interval = 2;

			// Y축 : 기본 왼쪽 
			Axis yAxisLeft = new Axis();
			yAxisLeft.ViewportRangeEnabled = true;

			// Y축 : 오른쪽 
			Axis yAxisRight = new Axis();
			yAxisRight.AxisType = AxisTypes.Secondary;
			yAxisRight.ViewportRangeEnabled = true;

			chart.AxesX.Add(xAxis);
			chart.AxesY.Add(yAxisLeft);
			chart.AxesY.Add(yAxisRight);

			NberTrendLine();

			DataSeries ds = new DataSeries();
			ds.DataSource = myList;
			ds.RenderAs = RenderAs.QuickLine;
			ds.MarkerEnabled = false;
			ds.XValueType = ChartValueTypes.Date;
			ds.LegendText = "TLT";
			ds.ColorSet = "VisiBlue";

			ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series1" });

			chart.Series.Add(ds);

			DataSeries ds2 = new DataSeries();
			ds2.DataSource = myList;
			ds2.RenderAs = RenderAs.QuickLine;
			ds2.MarkerEnabled = false;
			ds2.XValueType = ChartValueTypes.Date;
			ds2.AxisYType = AxisTypes.Secondary;
			ds2.LineThickness = 2;
			ds2.LegendText = "DGS20";
			ds2.ColorSet = "VisiRed";

			ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "BusinessDate" });
			ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Series2" });

			chart.Series.Add(ds2);

			LayoutRoot.Children.Clear();
			LayoutRoot.Children.Add(chart);

			myList.Clear();

		}

		#endregion

		#endregion

		#region DataGrid List
		private void RecentlyUpdatedList_Click(object sender, RoutedEventArgs e)
		{
			DataGrid recentlyUpdated = new DataGrid();

			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "ID", Binding = new Binding("SeriesId") });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "Englsh Name", Binding = new Binding("EnglishName") });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "Korean Name", Binding = new Binding("KoreanName") });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "Units", Binding = new Binding("Units") });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "Frequency", Binding = new Binding("Freq") });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "Seasonal Adj.", Binding = new Binding("Sa") });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "First Date", Binding = new Binding("SeriesFirstDate") { StringFormat = "yyyy-MM-dd" } });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "Last Date", Binding = new Binding("SeriesLastDate") { StringFormat = "yyyy-MM-dd" } });
			recentlyUpdated.Columns.Add(new DataGridTextColumn() { Header = "Update Date", Binding = new Binding("UpdateDate") { StringFormat = "yyyy-MM-dd" } });

			recentlyUpdated.ItemsSource = DbHandler.GetRecentlyUpdatedList();
			recentlyUpdated.AutoGenerateColumns = false;
			recentlyUpdated.IsReadOnly = true;
			recentlyUpdated.AlternatingRowBackground = Brushes.Gainsboro;
			recentlyUpdated.AlternationCount = 2;

			LayoutRoot.Children.Clear(); // So that Chart objects don't build up each time we add one.
			LayoutRoot.Children.Add(recentlyUpdated);
		}

		//
		private void RecentlyUsTreasList_Click(object sender, RoutedEventArgs e)
		{
			DataGrid recentlyUsTreas = new DataGrid();

			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "date", Binding = new Binding("BusinessDate") { StringFormat = "yyyy-MM-dd" } });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "1mo" , Binding = new Binding("Series1") } );
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "2mo", Binding = new Binding("Series2") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "3mo", Binding = new Binding("Series3") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "6mo", Binding = new Binding("Series4") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "1yr", Binding = new Binding("Series5") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "2yr", Binding = new Binding("Series6") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "3yr", Binding = new Binding("Series7")  });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "5yr", Binding = new Binding("Series8")  });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "7yr", Binding = new Binding("Series9") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "10yr", Binding = new Binding("Series10") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "20yr", Binding = new Binding("Series11") });
			recentlyUsTreas.Columns.Add(new DataGridTextColumn() { Header = "30yr", Binding = new Binding("Series12") });

			recentlyUsTreas.ItemsSource = DbHandler.GetRecentlyUsTreasList();
			recentlyUsTreas.AutoGenerateColumns = false;
			recentlyUsTreas.IsReadOnly = true;
			recentlyUsTreas.AlternatingRowBackground = Brushes.Gainsboro;
			recentlyUsTreas.AlternationCount = 2;
			recentlyUsTreas.FontSize = 15;

			LayoutRoot.Children.Clear(); // So that Chart objects don't build up each time we add one.
			LayoutRoot.Children.Add(recentlyUsTreas);
		}
		#endregion
	}
}
