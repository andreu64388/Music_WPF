using Microsoft.AspNetCore.Mvc;
using MusicAPI.DAL.DTO;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Attrubutes;

namespace MusicAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TracksController : Controller
{
	private readonly ITrackService _trackService;
	private readonly ILibraryService _libraryService;
	private readonly IGenreService _genreService;

	public TracksController(ITrackService trackService, ILibraryService libraryService, IGenreService genreService)
	{
		_trackService = trackService;
		_libraryService = libraryService;
		_genreService = genreService;
	}

	[UseTokenMiddleware]
	[HttpPost]
	public async Task<IActionResult> AddTrack([FromBody] TrackDto track)
	{
		try
		{
			var newTrack = await _trackService.AddTrack(track);
			return Ok(newTrack);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("top")]
	public async Task<IActionResult> GetTopTracks()
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			var tracks = await _trackService.GetTopTracks();
			var userLibrary = await _libraryService.GetTracksFromLibrary(userId);

			foreach (var track in tracks)
			{
				track.IsLiked = userLibrary.Any(libraryTrack => libraryTrack.Id == track.Id);
			}

			return Ok(tracks);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetTrackById(int id)
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			var track = await _trackService.GetTrackById(id);
			var userLibrary = await _libraryService.GetTracksFromLibrary(userId);

			track.IsLiked = userLibrary.Any(libraryTrack => libraryTrack.Id == track.Id);
			return Ok(track);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPut("count/{id:int}")]
	public async Task<IActionResult> IncrementPlayCount(int id)
	{
		try
		{
			await _trackService.IncrementPlayCount(id);
			return Ok(new { message = "Play count incremented" });
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("my/{id:int}")]
	public async Task<IActionResult> GetMyTracks(int id)
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			var tracks = await _trackService.GetMyTracks(id);
			var userLibrary = await _libraryService.GetTracksFromLibrary(userId);

			foreach (var track in tracks)
			{
				track.IsLiked = userLibrary.Any(libraryTrack => libraryTrack.Id == track.Id);
			}

			return Ok(tracks);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("search/{query}")]
	public async Task<IActionResult> SearchTracks(string query)
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			var tracks = await _trackService.SearchTracks(query);
			var userLibrary = await _libraryService.GetTracksFromLibrary(userId);

			foreach (var track in tracks)
			{
				track.IsLiked = userLibrary.Any(libraryTrack => libraryTrack.Id == track.Id);
			}

			return Ok(tracks);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPut]
	public async Task<IActionResult> UpdateTrack([FromBody] TrackUpdateDto trackDto)
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			var updatedTrack = await _trackService.UpdateTrack(trackDto, userId);
			return Ok(updatedTrack);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpDelete("{id:int}")]
	public async Task<IActionResult> DeleteTrack(int id)
	{
		try
		{
			var userId = (int)HttpContext.Items["UserId"];
			await _trackService.DeleteTrack(id, userId);
			return Ok(new { message = "Track deleted" });
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}
}