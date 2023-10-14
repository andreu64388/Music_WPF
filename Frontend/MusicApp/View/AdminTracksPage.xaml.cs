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
	/// Логика взаимодействия для AdminTracksPage.xaml
	/// </summary>
	public partial class AdminTracksPage : Page
	{
		private readonly AdminTracksPageViewModel adminTracksPageViewModel = new AdminTracksPageViewModel();

		private MainViewModel viewModel = new MainViewModel();

		public AdminTracksPage(MainViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			DataContext = adminTracksPageViewModel;
			GetDataStart();
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
			adminTracksPageViewModel.Tracks = await adminService.GetAllTracks();
			adminTracksPageViewModel.CountTracks = adminTracksPageViewModel.Tracks.Count();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddWindow1 addUser = new AddWindow1(viewModel);
			addUser.Closed += AddUser_Closed;
			addUser.ShowDialog();
		}

		private void AddUser_Closed(object sender, EventArgs e)
		{
			GetDataStart();
		}
	}
}