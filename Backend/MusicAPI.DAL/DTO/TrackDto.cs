namespace MusicAPI.DAL.DTO;

public class TrackDto
{
	public string Title { get; set; }
	public int GenreId { get; set; }
	public string Image { get; set; }
	public string Audio { get; set; }
	public int ArtistId { get; set; }
}