using Music.ViewModel;
using System.Windows.Controls;

namespace Music.View;

/// <summary>
/// Логика взаимодействия для HomePage.xaml
/// </summary>
public partial class HomePage : Page
{
	private readonly HomePageViewModel addPageView;

	public HomePage(MainViewModel viewModel)
	{
		InitializeComponent();
		addPageView = new HomePageViewModel(viewModel);
		DataContext = addPageView;
	}
}