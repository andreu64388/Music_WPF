using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using Music.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для AdminHomePage.xaml
	/// </summary>
	public partial class AdminHomePage : Page
	{
		private readonly AdminHomePageViewModel adminHomePageViewModel = new AdminHomePageViewModel();

		public AdminHomePage(MainViewModel viewModel)
		{
			InitializeComponent();
			DataContext = adminHomePageViewModel;
			GetDataStart();
		}

		private async void DataGrid_CellEditEndingUsers(object sender, DataGridCellEditEndingEventArgs e)
		{
			var dataGrid = (DataGrid)sender;
			var editedItem = dataGrid.SelectedItem as UserResponce;
			var editedColumn = e.Column as DataGridTextColumn;
			var bindingPath = (editedColumn.Binding as Binding)?.Path.Path;
			var oldValue = e.Row.DataContext.GetType().GetProperty(bindingPath).GetValue(e.Row.DataContext);
			var newValue = (e.EditingElement as TextBox)?.Text;

			if (oldValue != null && newValue != null && !oldValue.Equals(newValue))
			{
				var adminService = new AdminService();

				var updateUser = new UserUpdateDto
				{
					Id = editedItem.Id,
				};
				if (bindingPath == "Email")
				{
					updateUser.Email = newValue;
				}
				else if (bindingPath == "Name")
				{
					updateUser.Name = newValue;
				}

				await adminService.UpdateUser(updateUser);

				MessageBox.Show($"Saved changes for user with ID: {editedItem.Id} in field: {bindingPath}");
				GetDataStart();
			}
		}

		private async void DeleteButton_ClickUsers(object sender, RoutedEventArgs e)
		{
			var button = (Button)sender;
			var user = button.DataContext as UserResponce;

			if (user != null)
			{
				var adminService = new AdminService();
				await adminService.DeleteUser(user.Id);
				MessageBox.Show($"Deleted user with ID: {user.Id}");
				GetDataStart();
			}
		}

		private async void DataGrid_CellEditEndingTracks(object sender, DataGridCellEditEndingEventArgs e)
		{
			var adminService = new AdminService();
			try
			{
				var dataGrid = (DataGrid)sender;
				var editedItem = dataGrid.SelectedItem as TrackResponce;
				var editedColumn = e.Column as DataGridTextColumn;
				var bindingPath = (editedColumn.Binding as Binding)?.Path.Path;
				var oldValue = e.Row.DataContext.GetType().GetProperty(bindingPath).GetValue(e.Row.DataContext);
				var newValue = (e.EditingElement as TextBox)?.Text;

				if (oldValue != null && newValue != null && !oldValue.Equals(newValue))
				{
					var trackUpdateDto = new TrackUpdateDto
					{
						Id = editedItem.Id
					};

					if (bindingPath == "Title")
					{
						trackUpdateDto.Title = newValue;
					}
					else if (bindingPath == "GenreId")
					{
						trackUpdateDto.GenreId = int.Parse(newValue);
					}
					else if (bindingPath == "Image")
					{
						trackUpdateDto.Image = newValue;
					}

					await adminService.UpdateTrack(trackUpdateDto);

					MessageBox.Show($"Saved changes for user with ID: {editedItem.Id} in field: {bindingPath}");
					GetDataStart();
				}
			}
			catch (Exception ex) { }
		}

		private async void DeleteButton_ClickTracks(object sender, RoutedEventArgs e)
		{
			var button = (Button)sender;
			var track = button.DataContext as TrackResponce;

			var adminService = new AdminService();

			if (track != null)
			{
				await adminService.DeleteTrack(track.Id);

				MessageBox.Show($"Deleted user with ID: {track.Id}");
				GetDataStart();
			}
		}

		public async void GetDataStart()
		{
			var adminService = new AdminService();

			adminHomePageViewModel.Tracks = await adminService.GetAllTracks();
			adminHomePageViewModel.CountTracks = adminHomePageViewModel.Tracks.Count();
			adminHomePageViewModel.Users = await adminService.GetAllUsers();
			adminHomePageViewModel.CountUsers = adminHomePageViewModel.Users.Count();
			adminHomePageViewModel.LimitedUsers = adminHomePageViewModel.Users.Take(5).ToList();
			adminHomePageViewModel.LimitedTracks = adminHomePageViewModel.Tracks.Take(5).ToList();
			adminHomePageViewModel.StartAnimation();
			adminHomePageViewModel.StartAnimatioTracks();
		}
	}
}