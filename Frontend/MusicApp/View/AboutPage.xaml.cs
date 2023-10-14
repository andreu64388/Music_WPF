using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для AboutPage.xaml
	/// </summary>
	public partial class AboutPage : Page
	{
		public AboutPage()
		{
			InitializeComponent();
		}
		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
	
			SetInitialOpacity(0, Expander1, Expander2, Expander3, Expander4, Expander5, Up, Down);

			await AnimateElementAsync(Up, 50);
			await AnimateElementAsync(Expander1, 100);
			await AnimateElementAsync(Expander2, 150);
			await AnimateElementAsync(Expander3, 200);
			await AnimateElementAsync(Expander4, 250);
			await AnimateElementAsync(Expander5, 300);
			await AnimateElementAsync(Down, 350);
		}

		private async Task AnimateElementAsync(UIElement element, int delayMilliseconds)
		{
			await Task.Delay(delayMilliseconds);

			var translateXAnimation = new DoubleAnimation
			{
				From = -element.RenderSize.Width,
				To = 0,
				Duration = TimeSpan.FromSeconds(0.5),
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
			};

			var opacityAnimation = new DoubleAnimation
			{
				From = 0,
				To = 1,
				Duration = TimeSpan.FromSeconds(0.5),
				EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
			};

			element.RenderTransform = new TranslateTransform();
			element.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
			element.RenderTransform.BeginAnimation(TranslateTransform.XProperty, translateXAnimation);
		}

		private void SetInitialOpacity(double opacity, params UIElement[] elements)
		{
			foreach (var element in elements)
			{
				element.Opacity = opacity;
			}
		}

		private void TelegramButton_Click(object sender, RoutedEventArgs e)
		{
		
			string telegramLink = "https://t.me/andr_15_sh";
			Process.Start(new ProcessStartInfo(telegramLink) { UseShellExecute = true });
		}

		private void LinkedInButton_Click(object sender, RoutedEventArgs e)
		{
		
			string linkedInLink = "https://www.linkedin.com/in/andrey-korenchuck-5b4686238/";
			Process.Start(new ProcessStartInfo(linkedInLink) { UseShellExecute = true });
		}

		private void GitHubButton_Click(object sender, RoutedEventArgs e)
		{
			
			string githubLink = "https://github.com/andreu64388";
			Process.Start(new ProcessStartInfo(githubLink) { UseShellExecute = true });
		}
		private async void StartAnimation()
		{
			await Task.Delay(2000); // Задержка 2 секунды
			AnimateExpander(Expander1);

			await Task.Delay(2000); // Задержка 2 секунды
			AnimateExpander(Expander2);

			await Task.Delay(2000); // Задержка 2 секунды
			AnimateExpander(Expander3);

			await Task.Delay(2000); // Задержка 2 секунды
			AnimateExpander(Expander4);

			await Task.Delay(2000); // Задержка 2 секунды
			AnimateExpander(Expander5);
		}

		private void AnimateExpander(Expander expander)
		{
			var animation = new DoubleAnimation
			{
				From = 0,
				To = 1,
				Duration = TimeSpan.FromSeconds(2) // Длительность анимации 2 секунды
			};

			expander.BeginAnimation(UIElement.OpacityProperty, animation);
		}

	}
}
