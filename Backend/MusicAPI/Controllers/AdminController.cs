using Microsoft.AspNetCore.Mvc;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Attrubutes;

namespace MusicAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AdminController : Controller
{
	private readonly IAdminService _adminService;

	public AdminController(IAdminService adminService)
	{
		_adminService = adminService;
	}

	[UseTokenMiddleware]
	[HttpGet("tracks")]
	public async Task<IActionResult> GetAllTracks()
	{
		try
		{
			var tracks = await _adminService.GetAllTracks();
			return Ok(tracks);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("users")]
	public async Task<IActionResult> GetAllUsers()
	{
		try
		{
			var users = await _adminService.GetAllUsers();
			return Ok(users);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpDelete("track/delete/{trackId}")]
	public async Task<IActionResult> DeleteTrack(int trackId)
	{
		try
		{
			await _adminService.DeleteTrack(trackId);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpDelete("user/delete/{userId}")]
	public async Task<IActionResult> DeleteUser(int userId)
	{
		try
		{
			await _adminService.DeleteUser(userId);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPut("track/update")]
	public async Task<IActionResult> UpdateTrack([FromBody] TrackUpdateDto trackDto)
	{
		try
		{
			await _adminService.UpdateTrack(trackDto);
			return Ok(
				new
				{
					message = "Track updated successfully"
				}
				);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPut("user/update")]
	public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto userDto)
	{
		try
		{
			await _adminService.UpdateUser(userDto);
			return Ok(new
			{
				message = "User updated successfully"
			});
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPost("user/create")]
	public async Task<IActionResult> CreateUser([FromBody] RegisterDto registerDto)
	{
		try
		{
			await _adminService.CreateUser(registerDto);
			return Ok(new
			{
				message = "User created successfully"
			});
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPost("track/create")]
	public async Task<IActionResult> CreateTrack([FromBody] TrackDto trackDto)
	{
		try
		{
			await _adminService.CreateTrack(trackDto);
			return Ok(new
			{
				message = "Track created successfully"
			});
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}
}