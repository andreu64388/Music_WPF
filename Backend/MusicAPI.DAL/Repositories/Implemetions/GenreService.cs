using Microsoft.EntityFrameworkCore;
using MusicAPI.DAL.Entity;
using MusicAPI.DAL.Repositories.Interfaces;

namespace MusicAPI.DAL.Repositories.Implemetions;

public class GenreService : IGenreService
{
	private readonly AppDbContext _appDbContext;

	public GenreService(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}

	public async Task<Genre> AddGenre(string genre)
	{
		var newGenre = new Genre
		{
			Name = genre
		};

		await _appDbContext.Genres.AddAsync(newGenre);
		await _appDbContext.SaveChangesAsync();

		return newGenre;
	}

	public async Task<Genre> DeleteGenre(int id)
	{
		var genre = await _appDbContext.Genres.FindAsync(id)
			?? throw new Exception("Genre not found with this ID");

		_appDbContext.Genres.Remove(genre);
		await _appDbContext.SaveChangesAsync();

		return genre;
	}

	public async Task<List<Genre>> GetAllGenres()
	{
		return await _appDbContext.Genres.ToListAsync();
	}

	public async Task<int> GetGenreIdByName(string genreName)
	{
		var genre = await _appDbContext.Genres
			.FirstOrDefaultAsync(g => g.Name == genreName);

		if (genre != null)
		{
			return genre.Id;
		}

		throw new Exception($"Genre with name '{genreName}' not found.");
	}

	public async Task<Genre> UpdateGenre(string genre)
	{
		var genreToUpdate = await _appDbContext.Genres.FirstOrDefaultAsync(g => g.Name == genre)
			?? throw new Exception("Genre not found with this name");

		genreToUpdate.Name = genre;
		await _appDbContext.SaveChangesAsync();

		return genreToUpdate;
	}
}