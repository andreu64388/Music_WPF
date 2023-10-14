using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.DAL.Entity;

public class Track
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string Title { get; set; }

	[Required]
	public DateTime CreateAt { get; set; }

	[Required]
	public DateTime UpdateAt { get; set; }

	public string Image { get; set; }

	[Required]
	public int PlayCount { get; set; }

	[Required]
	[Column(TypeName = "text")]
	public string Source { get; set; }

	[ForeignKey("GenerId")]
	public int Genre { get; set; }

	public bool IsLiked { get; set; } = false;

	[Required]
	public User User { get; set; }
}