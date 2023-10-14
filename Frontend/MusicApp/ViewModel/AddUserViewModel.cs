using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Music.ViewModel
{
	public class AddUserViewModel
	   : INotifyPropertyChanged

	{
		public event PropertyChangedEventHandler PropertyChanged;

		public event Action<int> RegisterSuccess;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

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

		public ICommand RegisterCommand
		{
			get { return _registerCommand; }
			set
			{
				_registerCommand = value;
				OnPropertyChanged(nameof(RegisterCommand));
			}
		}

		public AddUserViewModel()
		{
			RegisterCommand = new RelayCommand(Register_User);
		}

		private async void Register_User(object? test)
		{
			try
			{
				string emailValue = Email;
				string nameValue = Name;
				string passwordValue = Password;
				string imageValue = Image;

				if (string.IsNullOrWhiteSpace(emailValue) ||
					string.IsNullOrWhiteSpace(nameValue) ||
					string.IsNullOrWhiteSpace(passwordValue) ||
					string.IsNullOrWhiteSpace(imageValue))
				{
					MessageBox.Show("Please fill in all the fields.");
					return;
				}

				var adminService = new AdminService();

				var user = new RegisterDto
				{
					Email = emailValue,
					Name = nameValue,
					Password = passwordValue,
					Image = imageValue
				};

				await adminService.CreateUser(user);
				RegisterSuccess.Invoke(1);

				MessageBox.Show("User created successfully.");
			}
			catch (Exception ex)
			{
				RegisterSuccess.Invoke(1);
			}
		}
	}
}