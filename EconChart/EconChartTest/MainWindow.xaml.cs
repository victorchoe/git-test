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

namespace EconChartTest
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

			//LayoutRoot.Children.Add(chart);

			//MessageBox.Show(DbHandle.GetNberRecession().ElementAt(0).peakDate.ToShortDateString());
			//MessageBox.Show(DbHandle.GetNberRecession().Count.ToString());			
		}

		void Chart_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			// Do Something
			//MessageBox.Show("You Click a Chart");
			ElementData elementData = (e.OriginalSource as FrameworkElement).Tag as ElementData;

			if (elementData.Element != null && elementData.Element.GetType() == typeof(DataSeries))
			{
				MessageBox.Show("You have clicked on DataSeries " + (elementData.Element as DataSeries).Name);
			}


		}

		void DataSeries_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("You Click a Series");
		}

		private void NberTrendLine() 
		{
			try
			{
				foreach (var item in DbHandle.GetNberRecession())
				{
					chart.TrendLines.Add(new TrendLine { StartValue = item.peakDate, EndValue = item.troughDate, Orientation = Orientation.Vertical, LineColor = Brushes.Gray });
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}			
		}

		private void ZeroTrendLine()
		{
			chart.TrendLines.Add(new TrendLine { Value = 0, LineColor = Brushes.Red });
		}

		private void IsmTrendLine()
		{
			chart.TrendLines.Add(new TrendLine { Value = 50, LineColor = Brushes.Red });
		}

		private void IsmCurrentTrendLine(string currentIndex)
		{
			chart.TrendLines.Add(new TrendLine { Value = currentIndex, LineColor = Brushes.Black, LineStyle = LineStyles.Dashed });
		}
		
		//메모리 사용량 155,928(오라클) vs 115,008(sql server)
		//차트만드는 시간은 동일함.
		//오라클에서는 계산을 오라클 DB에서 sql로 계산해서 가져와 뿌림.
		//sql server에서는 데이터를 가져와 계산을 Linq로 해서 뿌림.
		//오라클은 데이터와 인덱스 테이블스페이스가 다르지만 sql server는 한곳에 있음
		//오라클은 날짜칼럼이 10자리 문자형으로 10바이트이지만, sql server는 날짜형으로 3바이트임.
		//따라서 인덱스를 읽어야 할 비용이 상대적으로 sql server우세
		//저장용량도 오라클은 데이터나 인덱스 테이블스페이스가 동일하지만 sql server에서는 4(22.8M):1(5.48M)정도로 인덱스가 작게 저장됨.
		//그리고 이상하게 visifire 신버전이 더 느리다. (공개마지막 버전보다.)
		//
		//


		//아래처럼 바로 FRED DB에서 다이렉트로 데이터를 가져와 차팅할 수 있다. 좋은 네트웍상황이라면 이 방안도 쓸만하다.
		//다른 데이터는 디비나 야후에서 불러와 가공하면 돼므로 한층 데이터를 클라이언트에 적게 갖아서 좋다. 관리도 편하다.
		private void Test1_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show(FredApi.GetSeriesData("gdpc1").ElementAt(0).businessDate);
			//MessageBox.Show(FredApi.GetSeriesData("dgs10","2000-01-01").ElementAt(0).businessDate);
			//MessageBox.Show(FredApi.GetSeriesData("dgs10", "2000-01-01", "9999-12-31").ElementAt(1).businessDate);
			//MessageBox.Show(FredApi.GetSeriesData("dgs10", "2000-01-01","9999-12-31","lin","m").ElementAt(0).businessDate);

			//Named Parameters or Optional Parameters or optional arguments라고도 함.
			//MessageBox.Show(FredApi.GetSeriesData("dgs10", freq:"m").ElementAt(0).businessDate);
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				//var myList1 = FredApi.GetSeriesData("gdpc1", units: "pca", from: "1990-01-01");				
				var myList1 = FredApi.GetSeriesData("dgs10", from: "1990-01-01", freq: "m");				

				chart.Titles.Add(new Title { Text = "실업률과 인구대비고용률" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years, Interval = 2 });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });
				//chart.AxesY.Add(new Axis { Title = "%", AxisType = AxisTypes.Secondary, ViewportRangeEnabled = true });

				NberTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				//ds1.LegendText = "EMRATIO";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}						
		}

		private void EmratioAndUnrate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "emratio");
				var myList2 = DbHandle.GetSeriesData("fred", "unrate");

				chart.Titles.Add(new Title { Text = "실업률과 인구대비고용률" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });
				chart.AxesY.Add(new Axis { Title = "%", AxisType = AxisTypes.Secondary, ViewportRangeEnabled = true });

				NberTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "EMRATIO";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.AxisYType = AxisTypes.Secondary;
				ds2.LegendText = "UNRATE";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}						
		}

		//
		private void UsTreasBondShortTerm_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				chart.MouseLeftButtonUp += new MouseButtonEventHandler(Chart_MouseLeftButtonUp);

				var myList1 = DbHandle.GetUsTreasBondData();

				chart.Titles.Add(new Title { Text = "U.S. Bond Short Term" });

				//일간을 뿌릴때는 인터벌 2를 줘서 깨끗하게 차트를 뿌리게 할 것.
				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years, Interval = 2 });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "3m";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "series1" });
				
				//이게 왜 안돼지? => Marker가 없으니 파이어가 안됌.
				ds1.MouseLeftButtonUp += new MouseButtonEventHandler(DataSeries_MouseLeftButtonUp);

				chart.Series.Add(ds1);

				

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList1;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "2yr";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "series2" });

				chart.Series.Add(ds2);

				DataSeries ds3 = new DataSeries();
				ds3.DataSource = myList1;
				ds3.RenderAs = RenderAs.QuickLine;
				ds3.MarkerEnabled = false;
				ds3.XValueType = ChartValueTypes.Date;
				ds3.LegendText = "5yr";

				ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "series3" });

				chart.Series.Add(ds3);

				DataSeries ds4 = new DataSeries();
				ds4.DataSource = myList1;
				ds4.RenderAs = RenderAs.QuickLine;
				ds4.MarkerEnabled = false;
				ds4.XValueType = ChartValueTypes.Date;
				ds4.LegendText = "10yr";

				ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "series4" });

				chart.Series.Add(ds4);

				DataSeries ds5 = new DataSeries();
				ds5.DataSource = myList1;
				ds5.RenderAs = RenderAs.QuickLine;
				ds5.MarkerEnabled = false;
				ds5.XValueType = ChartValueTypes.Date;
				ds5.LegendText = "30yr";

				ds5.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds5.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "series5" });

				chart.Series.Add(ds5);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
				
				//chart.Series.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void UsTreas_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetUsTreasData("d1mo");
				var myList2 = DbHandle.GetUsTreasData("d3mo");
				var myList3 = DbHandle.GetUsTreasData("d6mo");
				var myList4 = DbHandle.GetUsTreasData("d1yr");
				var myList5 = DbHandle.GetUsTreasData("d2yr");
				var myList6 = DbHandle.GetUsTreasData("d3yr");

				chart.Titles.Add(new Title { Text = "US Treas 동향" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years, Interval = 2 });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "1m";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "3m";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				DataSeries ds3 = new DataSeries();
				ds3.DataSource = myList3;
				ds3.RenderAs = RenderAs.QuickLine;
				ds3.MarkerEnabled = false;
				ds3.XValueType = ChartValueTypes.Date;
				ds3.LegendText = "6m";

				ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds3);

				DataSeries ds4 = new DataSeries();
				ds4.DataSource = myList4;
				ds4.RenderAs = RenderAs.QuickLine;
				ds4.MarkerEnabled = false;
				ds4.XValueType = ChartValueTypes.Date;
				ds4.LegendText = "1yr";

				ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds4);

				DataSeries ds5 = new DataSeries();
				ds5.DataSource = myList5;
				ds5.RenderAs = RenderAs.QuickLine;
				ds5.MarkerEnabled = false;
				ds5.XValueType = ChartValueTypes.Date;
				ds5.LegendText = "2yr";

				ds5.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds5.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds5);

				DataSeries ds6 = new DataSeries();
				ds6.DataSource = myList6;
				ds6.RenderAs = RenderAs.QuickLine;
				ds6.MarkerEnabled = false;
				ds6.XValueType = ChartValueTypes.Date;
				ds6.LegendText = "3yr";

				ds6.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds6.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds6);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void UsTreasLongTerm_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesDataAgg("fred", "dgs3mo", "w");
				var myList2 = DbHandle.GetSeriesDataAgg("fred", "dgs2", "w");
				var myList3 = DbHandle.GetSeriesDataAgg("fred", "dgs5", "w");
				var myList4 = DbHandle.GetSeriesDataAgg("fred", "dgs10", "w");
				var myList5 = DbHandle.GetSeriesDataAgg("fred", "dgs30", "w");

				//var myList1 = DbHandle.GetSeriesDataAgg("fred", "dgs3mo", "m");
				//var myList2 = DbHandle.GetSeriesDataAgg("fred", "dgs2", "m");
				//var myList3 = DbHandle.GetSeriesDataAgg("fred", "dgs5", "m");
				//var myList4 = DbHandle.GetSeriesDataAgg("fred", "dgs10", "m");
				//var myList5 = DbHandle.GetSeriesDataAgg("fred", "dgs30", "m");

				//var myList1 = DbHandle.GetSeriesDataAgg("fred", "dgs3mo", "q");
				//var myList2 = DbHandle.GetSeriesDataAgg("fred", "dgs2", "q");
				//var myList3 = DbHandle.GetSeriesDataAgg("fred", "dgs5", "q");
				//var myList4 = DbHandle.GetSeriesDataAgg("fred", "dgs10", "q");
				//var myList5 = DbHandle.GetSeriesDataAgg("fred", "dgs30", "q");

				chart.Titles.Add(new Title { Text = "US Treas 동향" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years, Interval = 2 });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "3mo";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "2yr";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				DataSeries ds3 = new DataSeries();
				ds3.DataSource = myList3;
				ds3.RenderAs = RenderAs.QuickLine;
				ds3.MarkerEnabled = false;
				ds3.XValueType = ChartValueTypes.Date;
				ds3.LegendText = "5yr";

				ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds3);

				DataSeries ds4 = new DataSeries();
				ds4.DataSource = myList4;
				ds4.RenderAs = RenderAs.QuickLine;
				ds4.MarkerEnabled = false;
				ds4.XValueType = ChartValueTypes.Date;
				ds4.LegendText = "10yr";

				ds4.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds4.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds4);

				DataSeries ds5 = new DataSeries();
				ds5.DataSource = myList5;
				ds5.RenderAs = RenderAs.QuickLine;
				ds5.MarkerEnabled = false;
				ds5.XValueType = ChartValueTypes.Date;
				ds5.LegendText = "30yr";

				ds5.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds5.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds5);				

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ForexUsVsKo_Ch_Jp_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "dexkous", "2000-01-01").Select(x => new { businessDate = x.businessDate, economicIndex = 100 / x.economicIndex });
				var myList2 = DbHandle.GetSeriesData("fred", "dexchus", "2000-01-01").Select(x => new { businessDate = x.businessDate, economicIndex = 1 / x.economicIndex });
				var myList3 = DbHandle.GetSeriesData("fred", "dexjpus", "2000-01-01").Select(x => new { businessDate = x.businessDate, economicIndex = 10 / x.economicIndex });

				Title myTitle = new Title();
				myTitle.Text = "한중일, 대미달러 가치";
				chart.Titles.Add(myTitle);

				Axis xAxis = new Axis();
				xAxis.ValueFormatString = "yyyy";
				xAxis.IntervalType = IntervalTypes.Years;
				xAxis.Interval = 2;

				Axis yAxisLeft = new Axis();
				yAxisLeft.Title = "%";
				yAxisLeft.ViewportRangeEnabled = true;

				chart.AxesX.Add(xAxis);
				chart.AxesY.Add(yAxisLeft);

				NberTrendLine();

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;
				ds.LegendText = "Korea 원";

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "China 위안";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				DataSeries ds3 = new DataSeries();
				ds3.DataSource = myList3;
				ds3.RenderAs = RenderAs.QuickLine;
				ds3.MarkerEnabled = false;
				ds3.XValueType = ChartValueTypes.Date;
				ds3.LegendText = "Japan 엔";

				ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds3);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);			
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}									
		}

		private void ForexUsVsKo_Ch_Jp_Test_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesDataO("fred", "dexkous", "2000-01-01").Select(x => new { Xval = x.businessDate, Yval = 100 / x.economicIndex });
				var myList2 = DbHandle.GetSeriesDataO("fred", "dexchus", "2000-01-01").Select(x => new { Xval = x.businessDate, Yval = 1 / x.economicIndex });
				var myList3 = DbHandle.GetSeriesDataO("fred", "dexjpus", "2000-01-01").Select(x => new { Xval = x.businessDate, Yval = 10 / x.economicIndex });

				Title myTitle = new Title();
				myTitle.Text = "한중일, 대미달러 가치";
				chart.Titles.Add(myTitle);

				Axis xAxis = new Axis();
				xAxis.ValueFormatString = "yyyy";
				xAxis.IntervalType = IntervalTypes.Years;
				xAxis.Interval = 2;

				Axis yAxisLeft = new Axis();
				yAxisLeft.ViewportRangeEnabled = true;

				chart.AxesX.Add(xAxis);
				chart.AxesY.Add(yAxisLeft);

				NberTrendLine();

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;
				ds.LegendText = "Korea 원";

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "Xval" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Yval" });

				chart.Series.Add(ds);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "China 위안";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "Xval" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Yval" });

				chart.Series.Add(ds2);

				DataSeries ds3 = new DataSeries();
				ds3.DataSource = myList3;
				ds3.RenderAs = RenderAs.QuickLine;
				ds3.MarkerEnabled = false;
				ds3.XValueType = ChartValueTypes.Date;
				ds3.LegendText = "Japan 엔";

				ds3.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "Xval" });
				ds3.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "Yval" });

				chart.Series.Add(ds3);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}									
		}

		#region Ism
		private void IsmNapm_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napm");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 제조업지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmSdi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmsdi");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 공급자 운송지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmPi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmpi");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 생산지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmNoi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmnoi");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 신규주문지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmIi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmii");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 재고지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmEi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmei");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 고용지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmBi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmbi");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 수주잔고지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmCi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmci");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 소비자재고지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmImp_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmimp");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 수입지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmExi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmexi");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 신규수출주문지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmPri_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmpri");

				chart.Titles.Add(new Title { Text = "ISM 제조업부문: 가격지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfCi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfci");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 서비스업 종합지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfBai_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfbai");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 경기동향지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfEi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfei");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 고용지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfNoi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfnoi");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 신규주문지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfSdi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfsdi");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 공급자 운송지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfBi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfbi");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 수주잔고지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfExi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfexi");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 신규수출주문지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfImi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfimi");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 수입지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfIni_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfini");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 재고지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfInsi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfinsi");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 재고기대지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNmfPi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "nmfpi");

				chart.Titles.Add(new Title { Text = "ISM 서비스부문: 가격지수" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();
				IsmCurrentTrendLine(myList1.Last().economicIndex.ToString());

				DataSeries ds = new DataSeries();
				ds.DataSource = myList1;
				ds.RenderAs = RenderAs.QuickLine;
				ds.MarkerEnabled = false;
				ds.XValueType = ChartValueTypes.Date;

				ds.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmEiAndNmfEi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmei", "1997-07-01");
				var myList2 = DbHandle.GetSeriesData("fred", "nmfei", "1997-07-01");

				chart.Titles.Add(new Title { Text = "ISM 고용지수 종합" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "NAPM";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "NMF";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmPiAndNmfPi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmpi", "1997-07-01");
				var myList2 = DbHandle.GetSeriesData("fred", "nmfpi", "1997-07-01");

				chart.Titles.Add(new Title { Text = "ISM 가격지수 종합" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "NAPM";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "NMF";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmNoiAndNmfNoi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmnoi", "1997-07-01");
				var myList2 = DbHandle.GetSeriesData("fred", "nmfnoi", "1997-07-01");

				chart.Titles.Add(new Title { Text = "ISM 신규주문지수 종합" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "NAPM";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "NMF";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void IsmNapmBiAndNmfBi_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				chart = new Chart();

				chart.AnimatedUpdate = false;
				chart.ZoomingEnabled = true;
				chart.IndicatorEnabled = true;
				chart.AnimationEnabled = false;

				var myList1 = DbHandle.GetSeriesData("fred", "napmbi", "1997-07-01");
				var myList2 = DbHandle.GetSeriesData("fred", "nmfbi", "1997-07-01");

				chart.Titles.Add(new Title { Text = "ISM 수주잔고지수 종합" });

				chart.AxesX.Add(new Axis { ValueFormatString = "yyyy", IntervalType = IntervalTypes.Years });
				chart.AxesY.Add(new Axis { Title = "%", ViewportRangeEnabled = true });

				NberTrendLine();
				IsmTrendLine();

				DataSeries ds1 = new DataSeries();
				ds1.DataSource = myList1;
				ds1.RenderAs = RenderAs.QuickLine;
				ds1.MarkerEnabled = false;
				ds1.XValueType = ChartValueTypes.Date;
				ds1.LegendText = "NAPM";

				ds1.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds1.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds1);

				DataSeries ds2 = new DataSeries();
				ds2.DataSource = myList2;
				ds2.RenderAs = RenderAs.QuickLine;
				ds2.MarkerEnabled = false;
				ds2.XValueType = ChartValueTypes.Date;
				ds2.LegendText = "NMF";

				ds2.DataMappings.Add(new DataMapping() { MemberName = "XValue", Path = "businessDate" });
				ds2.DataMappings.Add(new DataMapping() { MemberName = "YValue", Path = "economicIndex" });

				chart.Series.Add(ds2);

				LayoutRoot.Children.Clear();
				LayoutRoot.Children.Add(chart);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		#endregion		

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
		
	}
}
