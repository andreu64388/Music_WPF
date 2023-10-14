using System;

namespace Music.Model;

public class TrackResponce
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Genre { get; set; }
	public UserResponce User { get; set; }
	public string Image { get; set; }
	public string Source { get; set; }
	public int PlayCount { get; set; }
	public bool IsLiked { get; set; }
	public bool IsSelected { get; set; }
	public DateTime CreateAt { get; set; }
	public DateTime UpdateAt { get; set; }

	public override string ToString()
	{
		return $"Track ID: {Id}, Title: {Title}, Genre: {Genre}, Artist: {User}";
	}
}