using Music.ViewModel;
using System.Windows;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		private readonly LoginViewModel login = new LoginViewModel();

		public Login()
		{
			InitializeComponent();
			login.LoginSuccess += OnLoginSuccess;
			DataContext = login;
		}

		private void OnLoginSuccess(int userId)
		{
			this.Close();
		}

		private void Close(object sender, RoutedEventArgs e) => this.Close();

		private void FullScreen(object sender, RoutedEventArgs e)
		{
			if (WindowState == WindowState.Normal)
			{
				WindowState = WindowState.Maximized;
			}
			else
			{
				WindowState = WindowState.Normal;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MainWindow register = new MainWindow();
			register.Show();
			this.Close();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Home home = new Home(null);
			home.Show();
			this.Close();
		}
	}
}