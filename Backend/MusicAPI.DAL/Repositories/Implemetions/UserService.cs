using Microsoft.EntityFrameworkCore;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;
using MusicAPI.DAL.Enum;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Helper;

namespace MusicAPI.DAL.Repositories.Implemetions;

public class UserService : IUserService
{
	private readonly AppDbContext _appDbContext;

	public UserService(AppDbContext appDbContext)
	{
		this._appDbContext = appDbContext;
	}

	public async Task<User> Login(LoginDto loginDto)
	{
		var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email)
				   ?? throw new Exception("User not found with this email");

		return PasswordHasher.VerifyPassword(user.Password, loginDto.Password) ? user
			: throw new Exception("Password is incorrect");
	}

	public async Task<User> Register(RegisterDto registerDto)
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

		return user;
	}

	public async Task<User> GetUserByEmail(string email)
	{
		var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email)
				   ?? throw new Exception("User not found with this email");

		return user;
	}

	public async Task<User> GetUserById(int id)
	{
		var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id)
				   ?? throw new Exception("User not found with this ID");

		return user;
	}

	public async Task<User> UpdateUser(UserUpdateDto userUpdateDto)
	{
		var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userUpdateDto.Id)
				   ?? throw new Exception("User not found with this ID");

		if (_appDbContext.Users.Any(u => u.Email == userUpdateDto.Email && u.Id != userUpdateDto.Id))
		{
			throw new Exception("User with this email already exists");
		}

		user.Name = userUpdateDto.Name ?? user.Name;
		user.Image = userUpdateDto.Image ?? user.Image;
		user.Email = userUpdateDto.Email ?? user.Email;
		user.UpdateAt = DateTime.UtcNow;

		await _appDbContext.SaveChangesAsync();

		return user;
	}

	public async Task DeleteUser(int id)
	{
		var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id)
				   ?? throw new Exception("User not found with this ID");

		_appDbContext.Users.Remove(user);
		await _appDbContext.SaveChangesAsync();
	}
}