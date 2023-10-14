using Music.Model;
using Music.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для ProfileAboutPage.xaml
	/// </summary>
	public partial class ProfileAboutPage : Page
	{
		private readonly ProfileAboutViewModel mainView;

		public ProfileAboutPage(MainViewModel viewModel, UserResponce user)
		{
			InitializeComponent();
			mainView = new ProfileAboutViewModel(viewModel, user);

			DataContext = mainView;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var translateAnimationUp = new DoubleAnimation
			{
				From = -RightGrid.ActualHeight,
				To = 0,
				Duration = TimeSpan.FromSeconds(0.5),
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
			};

			RightGrid.RenderTransform = new TranslateTransform();
			RightGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, translateAnimationUp);

			var translateAnimationDown = new DoubleAnimation
			{
				From = DownGrid.ActualHeight,
				To = 0,
				Duration = TimeSpan.FromSeconds(0.5),
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
			};

			DownGrid.RenderTransform = new TranslateTransform();
			DownGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, translateAnimationDown);
		}
	}
}