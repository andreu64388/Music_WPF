using Music.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Music.View
{
	public partial class AddPage : Page
	{
		private readonly AddPageViewModel addPageView;

		public AddPage(MainViewModel viewModel)
		{
			InitializeComponent();
			addPageView = new AddPageViewModel(viewModel);
			DataContext = addPageView;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			AddPageTrack addPageTrack = new AddPageTrack(addPageView.mainViewModel);
			addPageView.mainViewModel.Pages.Content = addPageTrack;
		}
	}
}