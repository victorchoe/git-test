using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace EconChartTest
{
	public class ValuesCollection : ObservableCollection<SeriesValue> { };

	public class SeriesValue : INotifyPropertyChanged
	{
		public DateTime businessDate
		{
			get
			{
				return _XValue;
			}
			set
			{
				_XValue = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("XValue"));
			}
		}

		public decimal economicIndex
		{
			get
			{
				return _yValue;
			}
			set
			{
				_yValue = value;
				if (PropertyChanged != null)
					PropertyChanged(this, new PropertyChangedEventArgs("YValue"));
			}
		}

		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		decimal _yValue;
		DateTime _XValue;
	}
}
