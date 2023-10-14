using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using Music.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Music.ViewModel;

internal class RegisterViewModel : INotifyPropertyChanged

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

	public RegisterViewModel()
	{
		RegisterCommand = new RelayCommand(Register_User);
	}

	private async void Register_User(object? test)
	{
		if (IsLoading == false)
		{
			IsLoading = true;
			var userService = new UserService();
			try
			{
				string emailValue = Email.Replace(" ", "");
				string nameValue = Name.Replace(" ", "");
				string passwordValue = Password.Replace(" ", "");
				string imageValue = Image.Replace(" ", "");

				if (string.IsNullOrWhiteSpace(emailValue) ||
					string.IsNullOrWhiteSpace(nameValue) ||
					string.IsNullOrWhiteSpace(passwordValue) ||
					string.IsNullOrWhiteSpace(imageValue))
				{
					MessageShow("Please fill in all the fields.");
					return;
				}

				if (passwordValue.Length < 6)
				{
					MessageShow("Password should be at least 6 characters long.");
					return;
				}

				if (!Regex.IsMatch(passwordValue, @"\d") || !Regex.IsMatch(passwordValue, "[a-zA-Z]"))
				{
					MessageShow("Password should contain both letters and digits.");
					return;
				}

				if (!Regex.IsMatch(emailValue, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
				{
					MessageShow("Invalid email address.");
					return;
				}

				var registerDto = new RegisterDto
				{
					Email = emailValue,
					Name = nameValue,
					Password = passwordValue,
					Image = imageValue
				};

				var user = await userService.Register(registerDto);

				Home mainWindow = new Home(user);
				mainWindow.Show();

				RegisterSuccess.Invoke(user.Id);
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