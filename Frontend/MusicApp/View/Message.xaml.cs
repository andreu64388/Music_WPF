using Music.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для Message.xaml
	/// </summary>
	public partial class Message : Window
	{
		private readonly MessageViewModel messageViewModel = new MessageViewModel();

		public Message(List<string> messages)
		{
			InitializeComponent();
			DataContext = messageViewModel;
			messageViewModel.Messages = messages;
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
	}
}