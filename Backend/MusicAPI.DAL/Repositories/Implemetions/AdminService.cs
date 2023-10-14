using Microsoft.EntityFrameworkCore;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;
using MusicAPI.DAL.Enum;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Helper;

namespace MusicAPI.DAL.Repositories.Implemetions;

public class AdminService : IAdminService
{
	private readonly AppDbContext _appDbContext;

	public AdminService(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}

	public async Task CreateTrack(TrackDto trackDto)
	{
		var user = await _appDbContext.Users.FindAsync(trackDto.ArtistId)
			?? throw new Exception("User not found with this ID");

		var track = new Track
		{
			Title = trackDto.Title,
			Image = trackDto.Image,
			Genre = trackDto.GenreId,
			Source = trackDto.Audio,
			User = user,
			CreateAt = DateTime.UtcNow,
			PlayCount = 0
		};

		await _appDbContext.Tracks.AddAsync(track);
		await _appDbContext.SaveChangesAsync();
	}

	public async Task CreateUser(RegisterDto registerDto)
	{
		if (_appDbContext.Users.Any(u => u.Email == registerDto.Email))
		{
			throw new Exception("User with this email already exists");
		}

		var passwordHash = PasswordHasher.HashPassword(registerDto.Password);

		var user = new User
		{
			Email = registerDto.Email,
			Password = passwordHash,
			Name = registerDto.Name,
			Image = registerDto.Image,
			CreateAt = DateTime.UtcNow,
			Role = Roles.User
		};

		_appDbContext.Users.Add(user);
		await _appDbContext.SaveChangesAsync();
	}

	public async Task DeleteTrack(int id)
	{
		var track = await _appDbContext.Tracks.FindAsync(id)
			?? throw new Exception("Track not found with this ID");

		_appDbContext.Tracks.Remove(track);
		await _appDbContext.SaveChangesAsync();
	}

	public async Task DeleteUser(int id)
	{
		var user = await _appDbContext.Users.FindAsync(id)
			?? throw new Exception("User not found with this ID");

		_appDbContext.Users.Remove(user);
		await _appDbContext.SaveChangesAsync();
	}

	public async Task<List<Track>> GetAllTracks()
	{
		return await _appDbContext.Tracks.Include(t => t.User).ToListAsync();
	}

	public async Task<List<User>> GetAllUsers()
	{
		return await _appDbContext.Users.ToListAsync();
	}

	public async Task<Track> GetTrackById(int id)
	{
		return await _appDbContext.Tracks.FindAsync(id)
			?? throw new Exception("Track not found with this ID");
	}

	public async Task<User> GetUserById(int id)
	{
		return await _appDbContext.Users.FindAsync(id)
			?? throw new Exception("User not found with this ID");
	}

	public async Task<Track> UpdateTrack(TrackUpdateDto trackDto)
	{
		var track = await _appDbContext.Tracks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == trackDto.Id)
			?? throw new Exception("Track not found with this ID");

		track.Title = trackDto.Title;
		track.Image = trackDto.Image;
		track.Genre = trackDto.GenreId;
		track.UpdateAt = DateTime.UtcNow;

		await _appDbContext.SaveChangesAsync();
		return track;
	}

	public async Task<User> UpdateUser(UserUpdateDto userUpdateDto)
	{
		var user = await _appDbContext.Users.FindAsync(userUpdateDto.Id)
			?? throw new Exception("User not found with this ID");

		user.Name = userUpdateDto.Name ?? user.Name;
		user.Image = userUpdateDto.Image ?? user.Image;
		user.Email = userUpdateDto.Email ?? user.Email;
		user.UpdateAt = DateTime.UtcNow;

		await _appDbContext.SaveChangesAsync();
		return user;
	}
}