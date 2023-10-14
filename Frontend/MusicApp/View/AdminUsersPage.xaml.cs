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
	/// Логика взаимодействия для AdminUsersPage.xaml
	/// </summary>
	public partial class AdminUsersPage : Page
	{
		private readonly AdminUsersPageViewModel adminUsersPageViewModel = new AdminUsersPageViewModel();

		public AdminUsersPage(MainViewModel viewModel)
		{
			InitializeComponent();
			DataContext = adminUsersPageViewModel;
			GetDataStart();
		}

		private async void DataGrid_CellEditEndingUsers(object sender, DataGridCellEditEndingEventArgs e)
		{
			try
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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

		public async void GetDataStart()
		{
			var adminService = new AdminService();
			adminUsersPageViewModel.Users = await adminService.GetAllUsers();
			adminUsersPageViewModel.CountUsers = adminUsersPageViewModel.Users.Count();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddUser addUser = new AddUser();
			addUser.Closed += AddUser_Closed;
			addUser.ShowDialog();
		}

		private void AddUser_Closed(object sender, EventArgs e)
		{
			GetDataStart();
		}
	}
}