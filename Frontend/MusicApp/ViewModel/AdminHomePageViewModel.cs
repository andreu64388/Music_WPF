using Music.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Music.ViewModel
{
	public class AdminHomePageViewModel : INotifyPropertyChanged
	{
		private List<UserResponce> _users;

		public List<UserResponce> Users
		{
			get { return _users; }
			set
			{
				_users = value;
				OnPropertyChanged(nameof(Users));
			}
		}

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

		private List<UserResponce> _limitedUsers;

		public List<UserResponce> LimitedUsers
		{
			get { return _limitedUsers; }
			set
			{
				_limitedUsers = value;
				OnPropertyChanged(nameof(LimitedUsers));
			}
		}

		private List<TrackResponce> _limitedTracks;

		public List<TrackResponce> LimitedTracks
		{
			get { return _limitedTracks; }
			set
			{
				_limitedTracks = value;
				OnPropertyChanged(nameof(LimitedTracks));
			}
		}

		private int _circleValue;

		public int CircleValue
		{
			get { return _circleValue; }
			set
			{
				_circleValue = value;
				OnPropertyChanged(nameof(CircleValue));
			}
		}

		private int _circleValueTracks;

		public int CircleValueTracks
		{
			get { return _circleValueTracks; }
			set
			{
				_circleValueTracks = value;
				OnPropertyChanged(nameof(CircleValueTracks));
			}
		}

		public AdminHomePageViewModel()
		{
		}

		public async void StartAnimation()
		{
			for (int i = 0; i <= CountUsers; i++)
			{
				CircleValue = i;
				await Task.Delay(100);
			}
		}

		public async void StartAnimatioTracks()
		{
			for (int i = 0; i <= CountTracks; i++)
			{
				CircleValueTracks = i;
				await Task.Delay(100);
			}
		}

		private int _countUsers;

		public int CountUsers
		{
			get { return _countUsers; }
			set
			{
				_countUsers = value;
				OnPropertyChanged(nameof(CountUsers));
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