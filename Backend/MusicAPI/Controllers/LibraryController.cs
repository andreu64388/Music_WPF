using Microsoft.AspNetCore.Mvc;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Attrubutes;

namespace MusicAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class LibrariesController : Controller
{
	private readonly ILibraryService _libraryService;

	public LibrariesController(ILibraryService libraryService)
	{
		_libraryService = libraryService;
	}

	[UseTokenMiddleware]
	[HttpPost]
	public async Task<IActionResult> AddTrackToLibrary([FromBody] LibraryDto trackDto)
	{
		try
		{
			var newTrack = await _libraryService.AddTrackToLibrary(trackDto);
			return Ok(new { message = "Add track to library successfully" });
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("{userId:int}")]
	public async Task<IActionResult> GetTracksFromLibrary(int userId)
	{
		try
		{
			var tracks = await _libraryService.GetTracksFromLibrary(userId);
			foreach (var track in tracks)
			{
				track.IsLiked = true;
			}

			return Ok(tracks);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpDelete]
	public async Task<IActionResult> RemoveTrackFromLibrary([FromBody] LibraryDto trackDto)
	{
		try
		{
			var newTrack = await _libraryService.RemoveTrackFromLibrary(trackDto);
			return Ok(newTrack);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}
}