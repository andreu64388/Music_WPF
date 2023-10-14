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
	/// Логика взаимодействия для EditPageUser.xaml
	/// </summary>
	public partial class EditPageUser : Page
	{
		private readonly UpdateProfileViewModel updateProfileViewModel;

		public EditPageUser(MainViewModel mainViewModel)
		{
			InitializeComponent();

			updateProfileViewModel = new UpdateProfileViewModel(mainViewModel);
			DataContext = updateProfileViewModel;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var translateAnimation = new DoubleAnimation
			{
				From = RightGrid.ActualHeight,
				To = 0,
				Duration = TimeSpan.FromSeconds(0.5),
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
			};

			RightGrid.RenderTransform = new TranslateTransform();
			RightGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, translateAnimation);
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
			}
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{
			LoadedImage.Visibility = Visibility.Collapsed;
			ImageBtn.Visibility = Visibility.Visible;
			LoadedImage.Source = null;
		}
	}
}