using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using Music.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Music.ViewModel
{
	public class LoginViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public event Action<int> LoginSuccess;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private bool isLoading;

		public bool IsLoading
		{
			get { return isLoading; }
			set
			{
				isLoading = value;
				OnPropertyChanged(nameof(IsLoading));
			}
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

		private ICommand _loginCommand;

		public ICommand LoginCommand
		{
			get { return _loginCommand; }
			set
			{
				_loginCommand = value;
				OnPropertyChanged(nameof(LoginCommand));
			}
		}

		public LoginViewModel()
		{
			LoginCommand = new RelayCommand(LoginUser);
		}

		public async void LoginUser(object? obj)
		{
			if (IsLoading == false)
			{
				isLoading = true;
				var userService = new UserService();

				try
				{
					if (string.IsNullOrWhiteSpace(Email) ||
					  string.IsNullOrWhiteSpace(Password))

					{
						MessageShow("Please fill in all the fields.");
						return;
					}

					var loginDto = new LoginDto
					{
						Email = Email,
						Password = Password,
					};

					var user = await userService.Login(loginDto);

					if (user.Role == Enum.UserRole.Admin)
					{
						AdminMain adminMain = new AdminMain(user);
						adminMain.Show();
					}
					else
					{
						Home mainWindow = new Home(user);
						mainWindow.Show();
					}
					LoginSuccess.Invoke(user.Id);
				}
				catch (Exception ex)
				{
					MessageShow(ex.Message);
				}
				finally
				{
					IsLoading = false;
				}
			}
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