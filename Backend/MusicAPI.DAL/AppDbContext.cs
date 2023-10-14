using Microsoft.EntityFrameworkCore;
using MusicAPI.DAL.Entity;

namespace MusicAPI.DAL;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<User> Users { get; set; }
	public DbSet<Track> Tracks { get; set; }
	public DbSet<Genre> Genres { get; set; }
	public DbSet<Library> Libraries { get; set; }
}