using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicAPI.DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicAPI.DAL.Entity;

public class User
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; }

	public string Image { get; set; }

	[Required]
	[EmailAddress]
	public string Email { get; set; }

	[Required]
	[Column(TypeName = "text")]
	public string Password { get; set; }

	[DataType(DataType.DateTime)]
	public DateTime? UpdateAt { get; set; }

	[Required]
	[DataType(DataType.DateTime)]
	public DateTime CreateAt { get; set; }

	[Required]
	public Roles Role { get; set; }

	[JsonIgnore]
	public ICollection<Track>? Tracks { get; set; }

	[JsonIgnore]
	public ICollection<Library>? Libraries { get; set; }
}