using MusicAPI.DAL.Entity;

namespace MusicAPI.DAL.Repositories.Interfaces;

public interface IGenreService
{
	public Task<List<Genre>> GetAllGenres();

	public Task<Genre> AddGenre(string genre);

	public Task<Genre> UpdateGenre(string genre);

	public Task<Genre> DeleteGenre(int id);

	public Task<int> GetGenreIdByName(string genre);
}