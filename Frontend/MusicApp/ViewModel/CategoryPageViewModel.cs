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
	public class CategoryPageViewModel : INotifyPropertyChanged
	{
		public event EventHandler PlayMusicRequested;

		public event EventHandler NextAndBack;

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

		private ICommand _back;

		public ICommand BackCommand
		{
			get { return _back; }
			set
			{
				_back = value;
				OnPropertyChanged(nameof(BackCommand));
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

		public MainViewModel mainViewModel;

		public CategoryPageViewModel(MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;
			PlayCommand = new RelayCommand(PlayMusic);
			LikeCommand = new RelayCommand(Like);
			BackCommand = new RelayCommand(Back);
			ProfileCommand = new RelayCommand(Profile);
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

		public void Back(object? obj)
		{
			mainViewModel.Pages.Content = new SearchPage(mainViewModel);
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

		private async void Like(object? obj)
		{
			var libraryService = new LibraryService();
			try
			{
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