using System.ComponentModel.DataAnnotations;

namespace MusicAPI.DAL.Entity;

public class Genre
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; }

	public ICollection<Track> Tracks { get; set; }
}