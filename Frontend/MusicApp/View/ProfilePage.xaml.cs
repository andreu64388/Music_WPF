using Music.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для ProfilePage.xaml
	/// </summary>
	public partial class ProfilePage : Page
	{
		private readonly ProfileViewModel mainView;

		public ProfilePage(MainViewModel viewModel)
		{
			InitializeComponent();
			mainView = new ProfileViewModel(viewModel);

			DataContext = mainView;
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var translateAnimation = new DoubleAnimation
			{
				From = -RightGrid.ActualHeight, // Сдвигаем элемент сверху за пределы экрана
				To = 0, // Сдвигаем элемент в исходное положение
				Duration = TimeSpan.FromSeconds(0.5), // Установите желаемую продолжительность анимации
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut } // Настройте функцию ускорения по вашему выбору
			};

			RightGrid.RenderTransform = new TranslateTransform(); // Создайте трансформацию сдвига
			RightGrid.RenderTransform.BeginAnimation(TranslateTransform.YProperty, translateAnimation);
		}
	}
}