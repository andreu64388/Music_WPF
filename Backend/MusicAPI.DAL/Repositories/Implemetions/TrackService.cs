using Microsoft.EntityFrameworkCore;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;
using MusicAPI.DAL.Repositories.Interfaces;

namespace MusicAPI.DAL.Repositories.Implemetions;

public class TrackService : ITrackService
{
	private readonly AppDbContext _appDbContext;

	public TrackService(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}

	public async Task<Track> AddTrack(TrackDto track)
	{
		var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == track.ArtistId)
			?? throw new Exception("User not found with this ID");

		var newTrack = new Track()
		{
			Title = track.Title,
			Image = track.Image,
			Genre = track.GenreId,
			Source = track.Audio,
			User = user,
			CreateAt = DateTime.UtcNow,
			PlayCount = 0
		};
		await _appDbContext.Tracks.AddAsync(newTrack);
		await _appDbContext.SaveChangesAsync();
		return newTrack;
	}

	public async Task<List<Track>> GetTopTracks()
	{
		return await _appDbContext.Tracks.Include(l => l.User).OrderByDescending(t => t.PlayCount).Take(10).ToListAsync();
	}

	public async Task<Track> GetTrackById(int id)
	{
		var track = await _appDbContext.Tracks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id)
				?? throw new Exception("Track not found with this ID");

		return track;
	}

	public async Task<List<Track>> GetTracksByGenre(int genreId)
	{
		var genre = await _appDbContext.Tracks.Include(t => t.User).Where(t => t.Genre == genreId).Take(10).ToListAsync()
			?? throw new Exception("Track not found with this genre");

		return genre;
	}

	public async Task IncrementPlayCount(int trackId)
	{
		var track = await _appDbContext.Tracks.FindAsync(trackId)
			?? throw new Exception("Track not found with this ID");

		track.PlayCount++;
		await _appDbContext.SaveChangesAsync();
	}

	public async Task<List<Track>> GetMyTracks(int userId)
	{
		var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId)
			?? throw new Exception("User not found with this ID");

		var tracks = await _appDbContext.Tracks.Include(t => t.User).Where(t => t.User == user).ToListAsync()
			?? throw new Exception("Track not found in library");

		return tracks;
	}

	public async Task<List<Track>> SearchTracks(string query)
	{
		var lowerQuery = query.ToLower();

		var tracks = await _appDbContext.Tracks
			.Include(t => t.User)
			.Where(t => t.Title.ToLower().Contains(lowerQuery) || t.User.Name.ToLower().Contains(lowerQuery))
			.ToListAsync() ?? throw new Exception("Track not found with this query");

		return tracks;
	}

	public async Task<Track> UpdateTrack(TrackUpdateDto trackDto, int artistId)
	{
		var track = await _appDbContext.Tracks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == trackDto.Id)
			?? throw new Exception("Track not found with this ID");

		if (track.User.Id != artistId)
		{
			throw new Exception("You are not the owner of this track");
		}

		track.Title = trackDto.Title;
		track.Image = trackDto.Image;
		track.Genre = trackDto.GenreId;
		track.UpdateAt = DateTime.UtcNow;

		await _appDbContext.SaveChangesAsync();
		return track;
	}

	public async Task DeleteTrack(int trackId, int artistId)
	{
		var track = await _appDbContext.Tracks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == trackId)
			?? throw new Exception("Track not found with this ID");

		if (track.User.Id != artistId)
		{
			throw new Exception("You are not the owner of this track");
		}

		_appDbContext.Tracks.Remove(track);
		await _appDbContext.SaveChangesAsync();
	}
}