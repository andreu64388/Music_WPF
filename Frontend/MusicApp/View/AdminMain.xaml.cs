using Music.Helper;
using Music.Model;
using Music.ViewModel;
using System.Windows;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для AdminMain.xaml
	/// </summary>
	public partial class AdminMain : Window
	{
		private readonly MainViewModel viewModel = new();
		private bool isFullscreen = true;

		public AdminMain(UserResponce user)
		{
			InitializeComponent();
			this.DataContext = viewModel;
			viewModel.User = user;
			Start();
			viewModel.Pages = PageContainer;
		}

		private void Start()
		{
			PageContainer.Content = new AdminHomePage(viewModel);
		}

		private void Close(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new AdminHomePage(viewModel);
		}

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new AdminUsersPage(viewModel);
		}

		private void Library_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new AdminTracksPage(viewModel);
		}

		private void MenuButton_Click(object sender, RoutedEventArgs e)
		{
			if (MenuPopup.IsOpen)
			{
				MenuPopup.IsOpen = false;
			}
			else
			{
				MenuPopup.IsOpen = true;
			}
		}

		private void Exit(object sender, RoutedEventArgs e)
		{
			FileManager.DeleteFileToken();
			Login login = new();
			login.Show();
			this.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (isFullscreen)
			{
				WindowStyle = WindowStyle.None;
				WindowState = WindowState.Normal;
				ResizeMode = ResizeMode.CanResize;
				Width = 1000;
				Height = 600;
				WindowStartupLocation = WindowStartupLocation.CenterScreen;
				isFullscreen = false;
			}
			else
			{
				WindowStyle = WindowStyle.None;
				WindowState = WindowState.Maximized;
				ResizeMode = ResizeMode.NoResize;
				isFullscreen = true;
				WindowStartupLocation = WindowStartupLocation.CenterScreen;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}
	}
}