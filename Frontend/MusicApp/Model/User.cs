using Music.Enum;
using System;

namespace Music.Model;

public class UserResponce
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Image { get; set; }
	public string Email { get; set; }

	public DateTime? UpdateAt { get; set; }
	public DateTime CreateAt { get; set; }

	public UserRole Role { get; set; }

	public override string ToString()
	{
		return $"User ID: {Id}, Name: {Name}, Email: {Email}, Role: {Role}";
	}
}