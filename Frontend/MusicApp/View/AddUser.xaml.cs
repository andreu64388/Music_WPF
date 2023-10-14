using Microsoft.Win32;
using Music.ViewModel;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для AddUser.xaml
	/// </summary>
	public partial class AddUser : Window
	{
		private readonly AddUserViewModel adduser = new AddUserViewModel();

		public AddUser()
		{
			InitializeComponent();
			adduser.RegisterSuccess += AddUserSuccess;
			DataContext = adduser;
		}

		private void AddUserSuccess(int userId)
		{
			this.Close();
		}

		private void Close(object sender, RoutedEventArgs e) => this.Close();

		private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{
			LoadedImage.Visibility = Visibility.Collapsed;
			ImageBtn.Visibility = Visibility.Visible;
			LoadedImage.Source = null;
			CancelBtn.Visibility = Visibility.Collapsed;
		}

		private void ImageBtn_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png|All Files (*.*)|*.*";

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
	}
}