using Music.Model;
using System.Collections.Generic;
using System.ComponentModel;

namespace Music.ViewModel
{
	public class AdminUsersPageViewModel : INotifyPropertyChanged
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

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}