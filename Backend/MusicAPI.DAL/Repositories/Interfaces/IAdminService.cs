using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;

namespace MusicAPI.DAL.Repositories.Interfaces;

public interface IAdminService
{
	public Task<List<User>> GetAllUsers();

	public Task<User> GetUserById(int id);

	public Task<User> UpdateUser(UserUpdateDto userUpdateDto);

	public Task DeleteUser(int id);

	public Task<List<Track>> GetAllTracks();

	public Task<Track> UpdateTrack(TrackUpdateDto trackDto);

	public Task DeleteTrack(int id);

	public Task CreateUser(RegisterDto user);

	public Task CreateTrack(TrackDto trackDto);
}