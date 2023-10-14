namespace Music.Services.DTO;

public class UserUpdateDto
{
	public int Id { get; set; }
	public string? Email { get; set; }
	public string? Name { get; set; }
	public string? Image { get; set; }
}