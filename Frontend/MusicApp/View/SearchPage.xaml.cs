using Music.Model;
using Music.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для SearchPage.xaml
	/// </summary>
	public partial class SearchPage : Page
	{
		private readonly SearchPageViewModel LibraryPageView;

		public SearchPage(MainViewModel viewModel)
		{
			InitializeComponent();
			LibraryPageView = new SearchPageViewModel(viewModel);
			LibraryPageView.Tracks = new List<TrackResponce>();
			DataContext = LibraryPageView;
		}

		private void SearchTextBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				string TextSearch = SearchTextBox.Text;

				if (TextSearch == null || TextSearch.Length == 0)
				{
					MessageBox.Show(TextSearch);
					LibraryPageView.Tracks = new List<TrackResponce>();
				}
				else
				{
					LibraryPageView.SearchTitleTracks(TextSearch);
					
				}


			}
		}

	}
}