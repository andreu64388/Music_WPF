using Microsoft.Win32;
using Music.ViewModel;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для AddWindow1.xaml
	/// </summary>
	public partial class AddWindow1 : Window
	{
		private readonly AddWindowViewModel addWindowViewModel;

		public AddWindow1(MainViewModel mainViewModel)
		{
			InitializeComponent();
			addWindowViewModel = new AddWindowViewModel(mainViewModel);
			addWindowViewModel.AddTrackAction += AddUserAdmin;
			DataContext = addWindowViewModel;
		}

		private void AddUserAdmin(int userId)
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

		private void SelectImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

			if (openFileDialog.ShowDialog() == true)
			{
				string selectedImagePath = openFileDialog.FileName;
				selectedImage.Source = new BitmapImage(new Uri(selectedImagePath));
			}
		}

		private void SelectMusic_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Audio files (*.mp3, *.wav) | *.mp3; *.wav";

			if (openFileDialog.ShowDialog() == true)
			{
				string selectedMusicPath = openFileDialog.FileName;

				addWindowViewModel.Track = selectedMusicPath;
				selectedMusicTitle.Text = System.IO.Path.GetFileNameWithoutExtension(selectedMusicPath);
			}
		}

		private void Close_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}