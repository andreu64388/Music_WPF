using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;

namespace MusicAPI.DAL.Repositories.Interfaces;

public interface ILibraryService
{
	public Task<List<Track>> GetTracksFromLibrary(int userId);

	public Task<Track> AddTrackToLibrary(LibraryDto trackDto);

	public Task<Track> RemoveTrackFromLibrary(LibraryDto trackDto);
}