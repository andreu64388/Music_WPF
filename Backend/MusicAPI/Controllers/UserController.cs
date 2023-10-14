using Microsoft.AspNetCore.Mvc;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Attrubutes;
using MusicAPI.HELPRES.Helper;

namespace MusicAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController : Controller
{
	private readonly IUserService _userService;

	public UsersController(IUserService userService)
	{
		this._userService = userService;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
	{
		try
		{
			var user = await _userService.Register(registerDto);
			var token = JwtTokenHelper.GenerateToken(user.Id);

			var response = new
			{
				Token = token,
				User = user,
			};

			return Ok(response);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
	{
		try
		{
			var user = await _userService.Login(loginDto);
			var token = JwtTokenHelper.GenerateToken(user.Id);

			var response = new
			{
				Token = token,
				User = user
			};

			return Ok(response);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetUserById(int id)
	{
		try
		{
			var user = await _userService.GetUserById(id);
			return Ok(user);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("get-me")]
	public async Task<IActionResult> GetMe()
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			var user = await _userService.GetUserById(userId);
			return Ok(user);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPut]
	public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto userUpdateDto)
	{
		try
		{
			var user = await _userService.UpdateUser(userUpdateDto);
			return Ok(user);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpDelete]
	public async Task<IActionResult> DeleteUser()
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			await _userService.DeleteUser(userId);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}
}