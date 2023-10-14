namespace MusicAPI.DAL.DTO;

public class TrackUpdateDto
{
	public int Id { get; set; }
	public string Title { get; set; }
	public int GenreId { get; set; }
	public string Image { get; set; }
}