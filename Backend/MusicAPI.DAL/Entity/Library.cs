using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.DAL.Entity;

public class Library
{
	[Key]
	public int Id { get; set; }

	[Required]
	public int UserId { get; set; }

	[Required]
	public int TrackId { get; set; }

	[ForeignKey("UserId")]
	public User User { get; set; }

	[ForeignKey("TrackId")]
	public Track Track { get; set; }
}