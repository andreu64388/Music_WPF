using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using Music.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Music.ViewModel
{
	public class SearchPageViewModel : INotifyPropertyChanged
	{
		public event EventHandler PlayMusicRequested;

		public event EventHandler NextAndBack;

		private string? _SearchTitle;

		public string? SearchTitle
		{
			get { return _SearchTitle; }
			set
			{
				_SearchTitle = value;
				OnPropertyChanged(nameof(SearchTitle));
			}
		}

		private bool isLoading;

		public bool IsLoading
		{
			get { return isLoading; }
			set
			{
				isLoading = value;
				OnPropertyChanged(nameof(IsLoading));
			}
		}

		private List<TrackResponce> _tracks;

		public List<TrackResponce> Tracks
		{
			get { return _tracks; }
			set
			{
				_tracks = value;
				OnPropertyChanged(nameof(Tracks));
			}
		}

		private ICommand _ProfileCommand;

		public ICommand ProfileCommand
		{
			get { return _ProfileCommand; }
			set
			{
				_ProfileCommand = value;
				OnPropertyChanged(nameof(ProfileCommand));
			}
		}

		private ICommand _play;

		public ICommand PlayCommand
		{
			get { return _play; }
			set
			{
				_play = value;
				OnPropertyChanged(nameof(PlayCommand));
			}
		}

		private ICommand _EditCommand;

		public ICommand EditCommand
		{
			get { return _EditCommand; }
			set
			{
				_EditCommand = value;
				OnPropertyChanged(nameof(EditCommand));
			}
		}

		private ICommand _LikeCommand;

		public ICommand LikeCommand
		{
			get { return _LikeCommand; }
			set
			{
				_LikeCommand = value;
				OnPropertyChanged(nameof(LikeCommand));
			}
		}

		private ICommand _Category;

		public ICommand Category
		{
			get { return _Category; }
			set
			{
				_Category = value;
				OnPropertyChanged(nameof(Category));
			}
		}

		private ICommand _search;

		public ICommand SearchCommand
		{
			get { return _search; }
			set
			{
				_search = value;
				OnPropertyChanged(nameof(SearchCommand));
			}
		}

		public MainViewModel mainViewModel;

		public SearchPageViewModel(MainViewModel mainViewModel)
		{
			Tracks = new List<TrackResponce>();
			this.mainViewModel = mainViewModel;
			PlayCommand = new RelayCommand(PlayMusic);
			LikeCommand = new RelayCommand(Like);
			SearchCommand = new RelayCommand(Search);
			ProfileCommand = new RelayCommand(Profile);
			Category = new RelayCommand(CategoryClick);
			EditCommand = new RelayCommand(Edit);
			this.mainViewModel.PlayMusicRequested += MainViewModel_PlayMusicRequested;
			this.mainViewModel.BackAndNext += RaiseBackNextMusicRequested;
			this.mainViewModel.LikedCheck += ChekedLiked;
		}

		private void Profile(object? obj)
		{
			if (obj is TrackResponce track)
			{
				if (track.User.Id == mainViewModel.User.Id)
				{
					mainViewModel.Pages.Content = new ProfilePage(mainViewModel);
				}
				else
				{
					mainViewModel.Pages.Content = new ProfileAboutPage(mainViewModel, track.User);
				}
			}
		}

		public async void ChekedLiked()
		{
			try
			{
				Tracks = await GetLikedTracksWithArtist(Tracks);
				RefreshTracks();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public async Task<List<TrackResponce>> GetLikedTracksWithArtist(List<TrackResponce> allTracks)
		{
			var libraryService = new LibraryService();
			List<TrackResponce> libraryTracks = await libraryService.GetTracksFromLibrary(mainViewModel.User.Id);
			List<TrackResponce> tracks = new();

			foreach (TrackResponce track in allTracks)
			{
				bool isLiked = libraryTracks.Any(libraryTrack => libraryTrack.Id == track.Id);

				track.IsLiked = isLiked;

				tracks.Add(track);
			}

			return tracks;
		}

		private async void Update_Closed(object sender, EventArgs e)
		{
			RefreshTracks();
		}

		private void Edit(object? obj)
		{
			if (obj is TrackResponce track)
			{
				if (track.User.Id == mainViewModel.User.Id)
				{
					EditPageTrack editPageTrack = new EditPageTrack(mainViewModel, track);
					mainViewModel.Pages.Content = editPageTrack;
				}
				else
				{
					List<string> test = new List<string>();
					test.Add("You dont have accsec");
					Message message = new Message(test);
					message.ShowDialog();
				}
			}
		}

		private void CategoryClick(object? obj)
		{
			if (obj != null && obj is string category)
			{
				mainViewModel.Pages.Content = new CategoryPage(category, mainViewModel);
			}
		}

		private async void Like(object? obj)
		{
			try
			{
				var libraryService = new LibraryService();
				if (obj is TrackResponce selectedTrack)
				{
					var libraryDto = new LibraryDto
					{
						UserId = mainViewModel.User.Id,
						TrackId = selectedTrack.Id
					};

					if (selectedTrack != null && selectedTrack.IsLiked == false)
					{
						await libraryService.AddLibrary(libraryDto);
					}
					else
					{
						await libraryService.DeleteFromLibrary(libraryDto);
					}

					if (mainViewModel.CurrentSong != null && selectedTrack.Id == mainViewModel.CurrentSong.Id)
					{
						bool state = !selectedTrack?.IsLiked ?? false;
						mainViewModel.ChangeLiked(state);
					}
					SearchTitleTracks(SearchTitle);
					Tracks = await GetLikedTracksWithArtist(Tracks);
					RefreshTracks();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void RaiseBackNextMusicRequested(TrackResponce track)
		{
			if (mainViewModel.IsPlaying)
			{
				foreach (TrackResponce el in Tracks)
				{
					el.IsSelected = (el.Id == track.Id);
				}
			}
			else
			{
				foreach (TrackResponce el in Tracks)
				{
					el.IsSelected = false;
				}
			}

			RefreshTracks();
		}

		private void MainViewModel_PlayMusicRequested(TrackResponce track)
		{
			if (!mainViewModel.IsPlaying)
			{
				foreach (TrackResponce el in Tracks)
				{
					el.IsSelected = (el.Id == track.Id);
				}
			}
			else
			{
				foreach (TrackResponce el in Tracks)
				{
					el.IsSelected = false;
				}
			}

			RefreshTracks();
		}

		public void PlayMusic(object? obj)
		{
			try
			{
				if (obj is TrackResponce selectedTrack)
				{
					if (selectedTrack?.Id == mainViewModel?.CurrentSong?.Id)
					{
						if (mainViewModel.IsPlaying)
						{
							mainViewModel.IsPlaying = false;
							foreach (TrackResponce el in Tracks)
							{
								el.IsSelected = false;
							}
							mainViewModel.PlaySong();
						}
						else
						{
							mainViewModel.IsPlaying = true;

							foreach (TrackResponce el in Tracks)
							{
								el.IsSelected = (el.Id == selectedTrack.Id);
							}
							mainViewModel.PlaySong();
						}
					}
					else
					{
						mainViewModel.IsPlaying = true;
						foreach (TrackResponce el in Tracks)
						{
							el.IsSelected = (el.Id == selectedTrack.Id);
						}
						mainViewModel.PlaySong(selectedTrack, Tracks);
					}

					RefreshTracks();
				}
			}
			catch (Exception ex)
			{
			}
		}

		public async void SearchTitleTracks(string SearchTitle)
		{
			try
			{
				IsLoading = true;

				var trackService = new TrackService();
				var searchResults = await trackService.SearchTracks(SearchTitle);
				Tracks = searchResults;
				if (Tracks.Count == 0)
				{
					IsLoading = false;
					List<string> test = new List<string>();
					test.Add("Not found " + SearchTitle);
					Message message = new Message(test);
					message.ShowDialog();
				}
				else
				{
					if (mainViewModel.IsPlaying)
					{
						foreach (TrackResponce el in Tracks)
						{
							el.IsSelected = (el.Id == mainViewModel.CurrentSong.Id);
						}
					}

					Tracks = await GetLikedTracksWithArtist(Tracks);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				IsLoading = false;
			}
		}

		public void Search(object? obj)
		{
		
			
			string? searchText = SearchTitle;
			
			if (SearchTitle == null || SearchTitle.Length == 0)
			{
				MessageBox.Show(searchText);
				Tracks = new List<TrackResponce>();
			}
			else
			{
				SearchTitleTracks(searchText);
			}
		}

		private void RefreshTracks()
		{
			List<TrackResponce> updatedTracks = new List<TrackResponce>(Tracks);
			Tracks = updatedTracks;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}