using Microsoft.EntityFrameworkCore;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;
using MusicAPI.DAL.Repositories.Interfaces;

namespace MusicAPI.DAL.Repositories.Implemetions;

public class LibraryService : ILibraryService
{
	private readonly AppDbContext _appDbContext;

	public LibraryService(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}

	public async Task<Track> AddTrackToLibrary(LibraryDto trackDto)
	{
		var track = await _appDbContext.Tracks.FindAsync(trackDto.TrackId);
		var user = await _appDbContext.Users.FindAsync(trackDto.UserId);
		if (track == null || user == null)
		{
			throw new Exception("Track or user not found");
		}
		var library = new Library
		{
			Track = track,
			User = user
		};
		await _appDbContext.Libraries.AddAsync(library);
		await _appDbContext.SaveChangesAsync();
		return track;
	}

	public async Task<List<Track>> GetTracksFromLibrary(int userId)
	{
		var tracks = await _appDbContext.Libraries
			.Where(l => l.UserId == userId)
			.Include(l => l.Track.User)
			.Select(l => l.Track)
			.ToListAsync();

		return tracks;
	}

	public async Task<Track> RemoveTrackFromLibrary(LibraryDto libraryDto)
	{
		var library = await _appDbContext.Libraries
		 .FirstOrDefaultAsync(l => l.UserId == libraryDto.UserId && l.TrackId == libraryDto.TrackId);

		if (library == null)
		{
			throw new Exception("Track not found in library");
		}

		_appDbContext.Libraries.Remove(library);
		await _appDbContext.SaveChangesAsync();
		return library.Track;
	}
}