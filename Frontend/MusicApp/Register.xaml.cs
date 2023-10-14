using Microsoft.Win32;
using Music.View;
using Music.ViewModel;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Music
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly RegisterViewModel register = new RegisterViewModel();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = register;
			register.RegisterSuccess += OnRegisterSuccess;
		}

		private void OnRegisterSuccess(int userId)
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

		private void ImageBtn_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

			if (openFileDialog.ShowDialog() == true)
			{
				string imagePath = openFileDialog.FileName;
				BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));

				LoadedImage.Source = bitmapImage;
				LoadedImage.Visibility = Visibility.Visible;
				ImageBtn.Visibility = Visibility.Collapsed;
				CancelBtn.Visibility = Visibility.Visible;
			}
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{
			LoadedImage.Visibility = Visibility.Collapsed;
			ImageBtn.Visibility = Visibility.Visible;
			LoadedImage.Source = null;
			CancelBtn.Visibility = Visibility.Collapsed;
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