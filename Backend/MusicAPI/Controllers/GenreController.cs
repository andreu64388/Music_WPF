using Microsoft.AspNetCore.Mvc;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Attrubutes;

namespace MusicAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class GenresController : Controller
{
	private readonly IGenreService _genreService;
	private readonly ITrackService _trackService;

	public GenresController(IGenreService genreService, ITrackService trackService)
	{
		_genreService = genreService;
		_trackService = trackService;
	}

	[UseTokenMiddleware]
	[HttpGet]
	public async Task<IActionResult> GetAllGenres()
	{
		try
		{
			var genres = await _genreService.GetAllGenres();
			return Ok(genres);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPost]
	public async Task<IActionResult> AddGenre([FromBody] string genre)
	{
		try
		{
			var newGenre = await _genreService.AddGenre(genre);
			return Ok(newGenre);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpGet("{genre}")]
	public async Task<IActionResult> GetTracksByGenre(string genre)
	{
		try
		{
			int genreId = await _genreService.GetGenreIdByName(genre);
			var tracks = await _trackService.GetTracksByGenre(genreId);
			return Ok(tracks);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpDelete("{genreId:int}")]
	public async Task<IActionResult> DeleteGenre(int genreId)
	{
		try
		{
			await _genreService.DeleteGenre(genreId);
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}

	[UseTokenMiddleware]
	[HttpPut]
	public async Task<IActionResult> UpdateGenre([FromBody] string genre)
	{
		try
		{
			var updatedGenre = await _genreService.UpdateGenre(genre);
			return Ok(updatedGenre);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
	}
}