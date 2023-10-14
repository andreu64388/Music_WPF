using Microsoft.Win32;
using Music.Model;
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
	/// Логика взаимодействия для EditPageTrack.xaml
	/// </summary>
	public partial class EditPageTrack : Page
	{
		private readonly AddWindowViewModel addWindowViewModel;

		public EditPageTrack(MainViewModel mainViewModel, TrackResponce track)
		{
			InitializeComponent();

			addWindowViewModel = new AddWindowViewModel(mainViewModel);
			DataContext = addWindowViewModel;
			addWindowViewModel.TrackMain = track;
			addWindowViewModel.Title = track.Title;
			addWindowViewModel.Image = track.Image;
			addWindowViewModel.Track = track.Source;
			addWindowViewModel.GenreId = 1;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var translateAnimation = new DoubleAnimation
			{
				From = RightGrid.ActualWidth,
				To = 0,
				Duration = TimeSpan.FromSeconds(0.5),
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
			};

			RightGrid.RenderTransform = new TranslateTransform();
			RightGrid.RenderTransform.BeginAnimation(TranslateTransform.XProperty, translateAnimation);
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
	}
}