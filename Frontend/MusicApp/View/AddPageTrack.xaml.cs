using Microsoft.Win32;
using Music.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для AddPageTrack.xaml
	/// </summary>
	public partial class AddPageTrack : Page
	{
		private readonly AddWindowViewModel addWindowViewModel;

		public AddPageTrack(MainViewModel mainViewModel)
		{
			InitializeComponent();
			addWindowViewModel = new AddWindowViewModel(mainViewModel);
			DataContext = addWindowViewModel;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var translateAnimation = new DoubleAnimation
			{
				From = -leftGrid.ActualWidth,
				To = 0,
				Duration = TimeSpan.FromSeconds(0.5),
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
			};

			leftGrid.RenderTransform = new TranslateTransform();
			leftGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, translateAnimation);
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
	}
}