using Microsoft.EntityFrameworkCore;
using MusicAPI.DAL;
using MusicAPI.DAL.Repositories.Implemetions;
using MusicAPI.DAL.Repositories.Interfaces;
using MusicAPI.HELPRES.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddControllers();
var connection = builder.Configuration.GetConnectionString("PostgreSQL");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection,
		builder => builder.MigrationsAssembly("MusicAPI")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ConditionalMiddleware>();

app.MapControllers();

app.Run();