using Music.Helper;
using Music.Model;
using Music.Services.Implemetions;
using Music.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для Home.xaml
	/// </summary>
	public partial class Home : Window
	{
		private bool userIsDraggingSlider = false;

		private readonly MainViewModel viewModel = new();

		public Home(UserResponce user)
		{
			InitializeComponent();
			viewModel.User = user;
			Start();
			viewModel.PlayRequested += ViewModel_PlayRequested;
			viewModel.Pages = PageContainer;
			this.DataContext = viewModel;
			this.SizeChanged += MainWindow_SizeChanged;
		}

		private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			// Получаем новые размеры окна
			double windowWidth = e.NewSize.Width;

			// Устанавливаем видимость StackPanel в зависимости от размера окна
			if (windowWidth >= 1200)
			{
				stackPanel.Visibility = Visibility.Visible;
			}
			else
			{
				stackPanel.Visibility = Visibility.Collapsed;
			}
		}

		private void ViewModel_PlayRequested(object sender, EventArgs e)
		{
			try
			{
				Image change_image = (Image)PlayButton2.Template.FindName("change_image", PlayButton2);

				if (viewModel.IsPlaying)
				{
					if (mePlayer.Position == TimeSpan.Zero)
					{
						Task.Run(increment);
					}
					mePlayer.Play();
					change_image.Source = new BitmapImage(new Uri("/View/pause.png", UriKind.Relative));
				}
				else
				{
					mePlayer.Pause();
					change_image.Source = new BitmapImage(new Uri("/View/play.png", UriKind.Relative));
				}
			}
			catch (Exception ex)
			{
			}
		}

		public void HandleTrackSelected(TrackResponce selectedTrack, List<TrackResponce>? tracks)
		{
			viewModel.CurrentSong = selectedTrack;
			viewModel.Tracks = new List<TrackResponce>(tracks);
			viewModel.index = viewModel.Tracks.IndexOf(viewModel.CurrentSong);
			viewModel.Source = new Uri(viewModel.Tracks[viewModel.index]?.Source);
		}

		private void Start()
		{
			PageContainer.Content = new HomePage(viewModel);
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
			mePlayer.MediaEnded += mePlayer_MediaEnded;
		}

		private void PlayNextSong()
		{
			try
			{
				viewModel.index++;
				if (viewModel.index >= viewModel.Tracks.Count)
				{
					viewModel.index = 0;
				}

				viewModel.Source = new Uri(viewModel.Tracks[viewModel.index].Source);
				mePlayer.Play();
				if (mePlayer.Position == TimeSpan.Zero && viewModel.IsPlaying)
				{
					Task.Run(increment);
				}
				viewModel.CurrentSong = viewModel.Tracks[viewModel.index];
				viewModel.RaiseBackNextMusicRequested();
			}
			catch (Exception ex)
			{
			}
		}

		private void mePlayer_MediaEnded(object sender, RoutedEventArgs e)
		{
			PlayNextSong();
		}

		private void btnNext_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				viewModel.index++;
				if (viewModel.index >= viewModel.Tracks.Count)
				{
					viewModel.index = 0;
				}

				viewModel.Source = new Uri(viewModel.Tracks[viewModel.index].Source);
				viewModel.CurrentSong = viewModel.Tracks[viewModel.index];
				viewModel.RaiseBackNextMusicRequested();
				if (mePlayer.Position == TimeSpan.Zero && viewModel.IsPlaying)
				{
					Task.Run(increment);
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				viewModel.index = viewModel.index - 1;
				if (viewModel.index < 0)
				{
					viewModel.index = viewModel.Tracks.Count - 1;
				}

				viewModel.Source = new Uri(viewModel.Tracks[viewModel.index].Source);
				viewModel.CurrentSong = viewModel.Tracks[viewModel.index];
				viewModel.RaiseBackNextMusicRequested();
				if (mePlayer.Position == TimeSpan.Zero && viewModel.IsPlaying)
				{
					Task.Run(increment);
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			viewModel.RaisePlayMusicRequested();

			try
			{
				Image change_image = (Image)PlayButton2.Template.FindName("change_image", PlayButton2);

				if (viewModel.IsPlaying)
				{
					if (mePlayer.Position == TimeSpan.Zero)
					{
						Task.Run(increment);
					}

					mePlayer.Pause();
					viewModel.IsPlaying = false;
				}
				else
				{
					mePlayer.Play();
					viewModel.IsPlaying = true;
				}

				change_image.Source = new BitmapImage(new Uri(viewModel.IsPlaying ? "/View/pause.png" : "/View/play.png", UriKind.Relative));
			}
			catch (Exception ex)
			{
			}
		}

		private async void increment()
		{
			try
			{
				var trackService = new TrackService();
				await trackService.IncrementTrackCount(viewModel.CurrentSong.Id);
			}
			catch (Exception ex)
			{
			}
		}

		private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
		{
			userIsDraggingSlider = true;

			musicProgress.Visibility = Visibility.Collapsed;
		}

		private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
		{
			userIsDraggingSlider = false;
			mePlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);

			musicProgress.Visibility = Visibility.Visible;

			UpdateProgressBarWidth();
		}

		private void UpdateProgressBarWidth()
		{
			double currentTime = mePlayer.Position.TotalSeconds;
			sliProgress.Value = currentTime;

			double progressBarWidth = (currentTime / sliProgress.Maximum) * sliProgress.ActualWidth;
			double remainingWidth = sliProgress.ActualWidth - progressBarWidth;

			musicProgress.Width = progressBarWidth;

			musicProgress.Margin = new Thickness(0, 0, remainingWidth, 0);
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
			{
				sliProgress.Minimum = 0;
				sliProgress.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
				UpdateProgressBarWidth();
			}
		}

		private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = true;
		}

		private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"mm\:ss");
		}

		private void Close(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void HomeButton_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new HomePage(viewModel);
			MenuPopup.IsOpen = false;
		}

		private void SearchButton_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new SearchPage(viewModel);
			MenuPopup.IsOpen = false;
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new AddPage(viewModel);
			MenuPopup.IsOpen = false;
		}
		private void About_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new AboutPage();
			MenuPopup.IsOpen = false;
		}

		private void Library_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new Library(viewModel);
			MenuPopup.IsOpen = false;
		}

		private void Profile_Click(object sender, RoutedEventArgs e)
		{
			PageContainer.Content = new ProfilePage(viewModel);
			MenuPopup.IsOpen = false;
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

		private void TextBlock_Loaded(object sender, RoutedEventArgs e)
		{
			TextBlock textBlock = (TextBlock)sender;
			Canvas canvas = (Canvas)textBlock.Parent;

			double textWidth = MeasureTextWidth(textBlock);

			if (textWidth > canvas.ActualWidth)
			{
				DoubleAnimation animation = new DoubleAnimation
				{
					From = canvas.ActualWidth,
					To = -textWidth,
					Duration = TimeSpan.FromSeconds(10),
					RepeatBehavior = RepeatBehavior.Forever
				};

				textBlock.RenderTransform = new TranslateTransform();
				textBlock.RenderTransform.BeginAnimation(TranslateTransform.XProperty, animation);
			}
			else
			{
				textBlock.HorizontalAlignment = HorizontalAlignment.Center;
			}
		}

		private double MeasureTextWidth(TextBlock textBlock)
		{
			textBlock.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			return textBlock.DesiredSize.Width;
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
			if (WindowState == WindowState.Maximized)
			{
				WindowStyle = WindowStyle.None;
				WindowState = WindowState.Normal;
				ResizeMode = ResizeMode.CanResize;
				Width = 1000;
				Height = 600;
				WindowStartupLocation = WindowStartupLocation.CenterOwner;
			}
			else
			{
				WindowStyle = WindowStyle.None;
				WindowState = WindowState.Maximized;
				ResizeMode = ResizeMode.NoResize;
				WindowStartupLocation = WindowStartupLocation.CenterScreen;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}
	}
}