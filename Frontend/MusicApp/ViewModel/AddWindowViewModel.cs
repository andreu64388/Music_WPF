using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using Music.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Music.ViewModel
{
	public class AddWindowViewModel : INotifyPropertyChanged
	{
		public event Action<int> AddTrackAction;

		private string _title;

		public string Title
		{
			get { return _title; }
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		private int _genreId;

		public int GenreId
		{
			get { return _genreId; }
			set
			{
				_genreId = value;
				OnPropertyChanged(nameof(GenreId));
			}
		}

		private TrackResponce? trackMain;

		public TrackResponce? TrackMain
		{
			get { return trackMain; }
			set
			{
				trackMain = value;
				OnPropertyChanged(nameof(TrackMain));
			}
		}

		private string _image;

		public string Image
		{
			get { return _image; }
			set
			{
				_image = value;
				OnPropertyChanged(nameof(Image));
			}
		}

		private string _track;

		public string Track
		{
			get { return _track; }
			set
			{
				_track = value;
				OnPropertyChanged(nameof(Track));
			}
		}

		private List<GenreResponce> _genres;

		public List<GenreResponce> Genres
		{
			get { return _genres; }
			set
			{
				_genres = value;
				OnPropertyChanged(nameof(Genres));
			}
		}

		private ICommand _addcommand;

		public ICommand Addcommand
		{
			get { return _addcommand; }
			set
			{
				_addcommand = value;
				OnPropertyChanged(nameof(Addcommand));
			}
		}

		private ICommand _addcommandAdmin;

		public ICommand AddcommandAdmin
		{
			get { return _addcommandAdmin; }
			set
			{
				_addcommandAdmin = value;
				OnPropertyChanged(nameof(AddcommandAdmin));
			}
		}

		private ICommand _delcommand;

		public ICommand Deletecommand
		{
			get { return _delcommand; }
			set
			{
				_delcommand = value;
				OnPropertyChanged(nameof(Deletecommand));
			}
		}

		private ICommand _Updatecommand;

		public ICommand UpdateCommand
		{
			get { return _Updatecommand; }
			set
			{
				_Updatecommand = value;
				OnPropertyChanged(nameof(UpdateCommand));
			}
		}

		public MainViewModel mainViewModel { get; set; }

		public AddWindowViewModel(MainViewModel mainViewModel)
		{
			LoadGenres();
			Addcommand = new RelayCommand(AddTrack);
			AddcommandAdmin = new RelayCommand(AddTrackAdmin);
			UpdateCommand = new RelayCommand(UpdateTrack);
			Deletecommand = new RelayCommand(DeleteTrack);
			this.mainViewModel = mainViewModel;
		}

		public async Task LoadGenres()
		{
			var genreService = new GenreService();
			Genres = await genreService.GetAllGenres();
		}

		public async void DeleteTrack(object? obj)
		{
			try
			{
				var trackService = new TrackService();
				await trackService.DeleteTrack(TrackMain.Id);
				mainViewModel.Pages.Content = new AddPage(mainViewModel);
			}
			catch { }
		}

		public async void UpdateTrack(object? obj)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(Title) ||

					string.IsNullOrWhiteSpace(Image)
					)
				{
					MessageShow("Please fill in all the fields.");
					return;
				}

				string genre_name = Genres.Find(x => x.Id == GenreId).Name;
				if (TrackMain.Title == Title && TrackMain.Image == Image && TrackMain.Genre == genre_name)
				{
					MessageShow("Please change at least one field.");
					return;
				}

				var trackService = new TrackService();

				var UpdateTrackDto = new TrackUpdateDto
				{
					Id = TrackMain.Id,
					Title = Title.Replace(" ", ""),
					Image = Image,
					GenreId = GenreId
				};

				await trackService.UpdateTrack(UpdateTrackDto);

				mainViewModel.Pages.Content = new AddPage(mainViewModel);
			}
			catch (Exception ex)
			{
				MessageShow($"An error occurred: {ex.Message}");
			}
		}

		public async void AddTrack(object? obj)
		{
			var trackService = new TrackService();
			try
			{
				if (string.IsNullOrWhiteSpace(Title) ||
					string.IsNullOrWhiteSpace(Track) ||
					string.IsNullOrWhiteSpace(Image) ||
					GenreId == null)
				{
					MessageShow("Please fill in all the fields.");
					return;
				}

				var trackDto = new TrackDto
				{
					Title = Title.Replace(" ", ""),
					GenreId = GenreId,
					ArtistId = mainViewModel.User.Id,
					Image = Image,
					Audio = Track
				};
				await trackService.AddTrack(trackDto);

				AddPage addPage = new AddPage(mainViewModel);
				mainViewModel.Pages.Content = addPage;
			}
			catch (Exception ex)
			{
				MessageShow($"An error occurred: {ex.Message}");
			}
		}

		public async void AddTrackAdmin(object? obj)
		{
			var trackService = new TrackService();
			try
			{
				if (string.IsNullOrWhiteSpace(Title) ||
					string.IsNullOrWhiteSpace(Track) ||
					string.IsNullOrWhiteSpace(Image) ||
					GenreId == null)
				{
					MessageShow("Please fill in all the fields.");
					return;
				}

				var trackDto = new TrackDto
				{
					Title = Title,
					GenreId = GenreId,
					ArtistId = mainViewModel.User.Id,
					Image = Image,
					Audio = Track
				};
				await trackService.AddTrack(trackDto);

				AddTrackAction.Invoke(2);
			}
			catch (Exception ex)
			{
				AddTrackAction.Invoke(2);

				MessageShow($"An error occurred: {ex.Message}");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void MessageShow(string? message)
		{
			if (!string.IsNullOrWhiteSpace(message))
			{
				List<string> messages = new List<string> { message };
				Message mes = new Message(messages);
				mes.ShowDialog();
			}
		}
	}
}