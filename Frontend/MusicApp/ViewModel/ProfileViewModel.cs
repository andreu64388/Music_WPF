using Music.Helper;
using Music.Model;
using Music.Services.Implemetions;
using Music.View;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace Music.ViewModel
{
	internal class ProfileViewModel : INotifyPropertyChanged
	{
		private string _image;

		public string Image
		{
			get { return _image; }
			set
			{
				_image = value;
				OnPropertyChanged(nameof(Image));
			}
		}

		private ICommand _EditCommand;

		public ICommand EditCommand
		{
			get { return _EditCommand; }
			set
			{
				_EditCommand = value;
				OnPropertyChanged(nameof(EditCommand));
			}
		}

		private ICommand _DelCommand;

		public ICommand DelCommand
		{
			get { return _DelCommand; }
			set
			{
				_DelCommand = value;
				OnPropertyChanged(nameof(DelCommand));
			}
		}

		public MainViewModel mainViewModel { get; set; }

		public ProfileViewModel(MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;
			EditCommand = new RelayCommand(Edit);
			DelCommand = new RelayCommand(Delete);
		}

		private void Edit(object? obj)
		{
			EditPageUser editPageUser = new EditPageUser(mainViewModel);
			mainViewModel.Pages.Content = editPageUser;
		}

		private async void Delete(object? obj)
		{
			var userService = new UserService();
			await userService.DeleteUser();
			FileManager.DeleteFileToken();

			Home homeWindow = App.Current.Windows.OfType<Home>().FirstOrDefault();

			if (homeWindow != null)
			{
				Login login = new();
				login.Show();
				homeWindow.Close();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}