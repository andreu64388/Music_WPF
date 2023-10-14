using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;

namespace MusicAPI.DAL.Repositories.Interfaces;

public interface ITrackService
{
	public Task<Track> AddTrack(TrackDto track);

	public Task<Track> GetTrackById(int id);

	public Task<List<Track>> GetTopTracks();

	public Task<List<Track>> GetTracksByGenre(int genreId);

	public Task IncrementPlayCount(int trackId);

	public Task<List<Track>> GetMyTracks(int userId);

	public Task<List<Track>> SearchTracks(string query);

	public Task<Track> UpdateTrack(TrackUpdateDto trackDto, int artistId);

	public Task DeleteTrack(int id, int artistId);
}