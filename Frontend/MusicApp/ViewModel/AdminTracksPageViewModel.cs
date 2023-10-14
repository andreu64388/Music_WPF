using Music.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Music.ViewModel
{
	public class AdminTracksPageViewModel : INotifyPropertyChanged
	{
		private List<TrackResponce> _tracks;

		public List<TrackResponce> Tracks
		{
			get { return _tracks; }
			set
			{
				_tracks = value;
				OnPropertyChanged(nameof(Tracks));
			}
		}

		private int _countTracks;

		public int CountTracks
		{
			get { return _countTracks; }
			set
			{
				_countTracks = value;
				OnPropertyChanged(nameof(CountTracks));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}