using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Entity;

namespace MusicAPI.DAL.Repositories.Interfaces;

public interface IUserService
{
	public Task<User> Register(RegisterDto registerDto);

	public Task<User> Login(LoginDto loginDto);

	public Task<User> GetUserById(int id);

	public Task<User> GetUserByEmail(string email);

	public Task<User> UpdateUser(UserUpdateDto userUpdateDto);

	public Task DeleteUser(int id);
}