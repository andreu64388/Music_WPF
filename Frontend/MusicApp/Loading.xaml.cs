using Music.Services.Implemetions;
using Music.View;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Music
{
	/// <summary>
	/// Логика взаимодействия для Loading.xaml
	/// </summary>
	public partial class Loading : Window
	{
		private readonly string[] loadingDescriptions;

		public Loading()
		{
			InitializeComponent();

			Loaded += Window_Loaded;
			using (StreamReader reader = new StreamReader("LoadingDescriptions.txt"))
			{
				string descriptionsText = reader.ReadToEnd();
				loadingDescriptions = descriptionsText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			}

			Random random = new Random();
			string randomDescription = loadingDescriptions[random.Next(loadingDescriptions.Length)];
			txtLoadingDescription.Text = randomDescription;
		}

		private void Close(object sender, RoutedEventArgs e) => this.Close();

		private async Task SimulateLoading()
		{
			await Task.Delay(3000);

			await LoadData();
		}

		private async Task LoadData()
		{
			try
			{
				var userService = new UserService();
				var user = await userService.GetMe();

				if (user != null)
				{
					if (user.Role == Enum.UserRole.Admin)
					{
						Dispatcher.Invoke(() =>
						{
							AdminMain adminMain = new AdminMain(user);
							adminMain.Show();
						});
					}
					else
					{
						Dispatcher.Invoke(() =>
						{
							Home mainWindow = new Home(user);
							mainWindow.Show();
						});
					}
				}
				else
				{
					Dispatcher.Invoke(() =>
					{
						MainWindow register = new MainWindow();
						register.Show();
					});
				}
			}
			catch (Exception ex)
			{
				Dispatcher.Invoke(() =>
				{
					MainWindow register = new MainWindow();
					register.Show();
				});
			}
			finally
			{
				Dispatcher.Invoke(() => Close());
			}
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			await SimulateLoading();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Login login = new Login();
			login.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}
	}
}