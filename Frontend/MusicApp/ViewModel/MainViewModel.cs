using Music.Model;
using Music.Services.DTO;
using Music.Services.Implemetions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Music.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
	public delegate void PlayMusicEventHandler(TrackResponce track);

	public event PlayMusicEventHandler PlayMusicRequested;

	public Frame Pages { get; set; }

	public delegate void BackAndNextyMusicEventHandler(TrackResponce track);

	public event BackAndNextyMusicEventHandler BackAndNext;

	public delegate void Liked();

	public event Liked LikedCheck;

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

	public void CheckLikedTrack()
	{
		LikedCheck?.Invoke();
	}

	public void RaisePlayMusicRequested()
	{
		try
		{
			PlayMusicRequested?.Invoke(CurrentSong);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public void RaiseBackNextMusicRequested()
	{
		BackAndNext?.Invoke(CurrentSong);
	}

	public void ChangeLiked(bool state)
	{
		CurrentSong.IsLiked = state;
		OnPropertyChanged(nameof(CurrentSong));
	}

	public int index { get; set; } = 0;

	private Uri _source;

	public Uri Source
	{
		get { return _source; }
		set
		{
			_source = value;
			OnPropertyChanged(nameof(Source));
		}
	}

	private UserResponce _user;

	public UserResponce User
	{
		get { return _user; }
		set
		{
			_user = value;
			OnPropertyChanged(nameof(User));
		}
	}

	private TrackResponce _CurrentSong;

	public TrackResponce CurrentSong
	{
		get { return _CurrentSong; }
		set
		{
			_CurrentSong = value;
			OnPropertyChanged(nameof(CurrentSong));
		}
	}

	private bool isPlaying;

	public bool IsPlaying
	{
		get { return isPlaying; }
		set
		{
			isPlaying = value;
			OnPropertyChanged(nameof(IsPlaying));
		}
	}

	private List<TrackResponce>? _tracks;

	public List<TrackResponce>? Tracks
	{
		get { return _tracks; }
		set
		{
			_tracks = value;
			OnPropertyChanged(nameof(Tracks));

			if (_tracks != null && _tracks.Count > 0)
			{
				index = _tracks.IndexOf(CurrentSong);
				Source = new Uri(_tracks[index].Source);
			}
			else
			{
				Source = null;
			}
		}
	}

	public event EventHandler PlayRequested;

	public void PlaySong(TrackResponce songSource, List<TrackResponce> tracks)
	{
		try
		{
			CurrentSong = songSource;
			Tracks = tracks;
			index = Tracks.IndexOf(songSource);
			Source = new Uri(Tracks[index]?.Source);
			PlayRequested?.Invoke(this, EventArgs.Empty);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public void PlaySong()
	{
		PlayRequested?.Invoke(this, EventArgs.Empty);
	}

	public MainViewModel()
	{
		LikeCommand = new RelayCommand(Like);
	}

	public async Task<TrackResponce> GetLikedTracksWithArtist(TrackResponce track)
	{
		var libraryService = new LibraryService();
		List<TrackResponce> libraryTracks = await libraryService.GetTracksFromLibrary(User.Id);

		bool isLiked = libraryTracks.Any(libraryTrack => libraryTrack.Id == track.Id);
		track.IsLiked = isLiked;

		return track;
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
					UserId = User.Id,
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
				CurrentSong = await GetLikedTracksWithArtist(CurrentSong);
				CheckLikedTrack();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}