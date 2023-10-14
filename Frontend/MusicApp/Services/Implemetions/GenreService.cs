using Music.Helper;
using Music.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music.Services.Implemetions;

public class GenreService
{
	private readonly HttpClient _httpClient;
	private readonly string uri = "https://localhost:7136/api/";

	public GenreService()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri(uri);
	}

	public async Task<GenreResponce> AddGenre(string genre)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Post, $"{uri}genres", genre);
		return await HttpClientHelper.HandleResponse<GenreResponce>(response);
	}

	public async Task<List<GenreResponce>> GetAllGenres()
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}genres");
		return await HttpClientHelper.HandleResponse<List<GenreResponce>>(response);
	}

	public async Task<GenreResponce> UpdateGenre(string genre)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Put, $"{uri}genres", genre);
		return await HttpClientHelper.HandleResponse<GenreResponce>(response);
	}

	public async Task<GenreResponce> DeleteGenre(string genre)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Delete, $"{uri}genres/{genre}");
		return await HttpClientHelper.HandleResponse<GenreResponce>(response);
	}
}