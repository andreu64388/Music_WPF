using Music.Helper;
using Music.Model;
using Music.Services.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music.Services.Implemetions;

public class LibraryService
{
	private readonly HttpClient _httpClient;
	private readonly string uri = "https://localhost:7136/api/";

	public LibraryService()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri(uri);
	}

	public async Task AddLibrary(LibraryDto libraryDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Post, $"{uri}libraries", libraryDto);
		await HttpClientHelper.HandleResponse<dynamic>(response);
	}

	public async Task DeleteFromLibrary(LibraryDto libraryDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Delete, $"{uri}libraries", libraryDto);
		await HttpClientHelper.HandleResponse<dynamic>(response);
	}

	public async Task<List<TrackResponce>> GetTracksFromLibrary(int userId)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}libraries/{userId}");
		return await HttpClientHelper.HandleResponse<List<TrackResponce>>(response);
	}
}