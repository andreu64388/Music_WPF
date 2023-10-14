using System.Collections.Generic;
using System.ComponentModel;

namespace Music.ViewModel
{
	public class MessageViewModel : INotifyPropertyChanged
	{
		private List<string> _messsages;

		public List<string> Messages
		{
			get { return _messsages; }
			set
			{
				_messsages = value;
				OnPropertyChanged(nameof(Messages));
			}
		}

		public MessageViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}