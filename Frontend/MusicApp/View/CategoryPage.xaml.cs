using Music.Model;
using Music.Services.Implemetions;
using Music.ViewModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Music.View
{
	/// <summary>
	/// Логика взаимодействия для CategoryPage.xaml
	/// </summary>
	public partial class CategoryPage : Page
	{
		private readonly CategoryPageViewModel CategoryPagePageView;

		public CategoryPage(string title, MainViewModel viewModel)
		{
			InitializeComponent();

			CategoryPagePageView = new CategoryPageViewModel(viewModel);
			CategoryPagePageView.Title = title;
			CategoryPagePageView.IsLoading = true;
			Task.Run(GetDataTracks);
			DataContext = CategoryPagePageView;
		}

		private async void GetDataTracks()
		{
			var trackService = new TrackService();

			var Tracks = await trackService.GetTracksByGenreByName(CategoryPagePageView.Title);

			if (CategoryPagePageView.mainViewModel.IsPlaying)
			{
				foreach (TrackResponce el in Tracks)
				{
					el.IsSelected = (el.Id == CategoryPagePageView.mainViewModel.CurrentSong.Id);
				}
			}
			CategoryPagePageView.Tracks = Tracks;
			CategoryPagePageView.IsLoading = false;
		}
	}
}