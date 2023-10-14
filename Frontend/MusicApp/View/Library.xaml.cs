using Music.ViewModel;
using System.Windows.Controls;

namespace Music.View;

/// <summary>
/// Логика взаимодействия для Library.xaml
/// </summary>
public partial class Library : Page
{
	private readonly LibraryPageViewModel LibraryPageView;

	public Library(MainViewModel viewModel)
	{
		InitializeComponent();
		LibraryPageView = new LibraryPageViewModel(viewModel);

		DataContext = LibraryPageView;
	}
}