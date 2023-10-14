using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using Music.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Music.ViewModel
{
	public class UpdateProfileViewModel : INotifyPropertyChanged
	{
		private string _email;

		public string Email
		{
			get { return _email; }
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}

		private string _name;

		public UserResponce User { get; set; }

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

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

		private ICommand _registerCommand;

		public ICommand UpdateCommand
		{
			get { return _registerCommand; }
			set
			{
				_registerCommand = value;
				OnPropertyChanged(nameof(UpdateCommand));
			}
		}

		public MainViewModel mainViewModel { get; set; }

		public UpdateProfileViewModel(MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;
			Email = mainViewModel.User.Email;
			Name = mainViewModel.User.Name;
			Image = mainViewModel.User.Image;
			UpdateCommand = new RelayCommand(Update);
		}

		private async void Update(object? test)
		{
			try
			{
				ProfilePage profile = new ProfilePage(mainViewModel);
				string emailValue = Email;
				string nameValue = Name;

				string imageValue = Image;

				if (string.IsNullOrWhiteSpace(emailValue) ||
				string.IsNullOrWhiteSpace(nameValue)
			 ||
				string.IsNullOrWhiteSpace(imageValue))
				{
					MessageShow("Please fill in all the fields.");
					return;
				}

				if (!Regex.IsMatch(emailValue, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
				{
					MessageShow("Invalid email address.");
					return;
				}

				if (mainViewModel.User.Name == nameValue && mainViewModel.User.Email == emailValue && mainViewModel.User.Image == imageValue)
				{
					mainViewModel.Pages.Content = profile;
					return;
				}
				var userServices = new UserService();
				var user = new UserUpdateDto
				{
					Id = mainViewModel.User.Id,
					Email = emailValue,
					Name = nameValue,
					Image = imageValue
				};
				var updateUser = await userServices.UpdateUser(user);
				mainViewModel.User = updateUser;

				mainViewModel.Pages.Content = profile;
			}
			catch (Exception ex)
			{
				MessageShow(ex.Message);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void MessageShow(string? message)
		{
			if (!string.IsNullOrWhiteSpace(message))
			{
				List<string> messages = new List<string> { message };
				Message mes = new Message(messages);
				mes.ShowDialog();
			}
		}
	}
}