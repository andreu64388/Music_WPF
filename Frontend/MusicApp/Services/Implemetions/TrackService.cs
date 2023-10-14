using Music.Helper;
using Music.Model;
using Music.Services.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music.Services.Implemetions;

public class TrackService
{
	private readonly HttpClient _httpClient;
	private readonly string uri = "https://localhost:7136/api/";

	public TrackService()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri(uri);
	}

	public async Task<TrackResponce> AddTrack(TrackDto trackDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Post, $"{uri}tracks", trackDto);
		return await HttpClientHelper.HandleResponse<TrackResponce>(response);
	}

	public async Task<TrackResponce> GetTrackById(int id)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}tracks/{id}");
		return await HttpClientHelper.HandleResponse<TrackResponce>(response);
	}

	public async Task<List<TrackResponce>> GetTopTracks()
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}tracks/top");
		return await HttpClientHelper.HandleResponse<List<TrackResponce>>(response);
	}

	public async Task<List<TrackResponce>> GetMyTracks(int userId)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}tracks/my/{userId}");
		return await HttpClientHelper.HandleResponse<List<TrackResponce>>(response);
	}

	public async Task<List<TrackResponce>> SearchTracks(string name)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}tracks/search/{name}");
		return await HttpClientHelper.HandleResponse<List<TrackResponce>>(response);
	}

	public async Task<List<TrackResponce>> GetTracksByGenreByName(string genre)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}genres/{genre}");
		return await HttpClientHelper.HandleResponse<List<TrackResponce>>(response);
	}

	public async Task<TrackResponce> UpdateTrack(TrackUpdateDto trackDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Put, $"{uri}tracks", trackDto);
		return await HttpClientHelper.HandleResponse<TrackResponce>(response);
	}

	public async Task<TrackResponce> IncrementTrackCount(int id)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Put, $"{uri}tracks/count/{id}");
		return await HttpClientHelper.HandleResponse<TrackResponce>(response);
	}

	public async Task<TrackResponce> DeleteTrack(int id)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Delete, $"{uri}tracks/{id}");
		return await HttpClientHelper.HandleResponse<TrackResponce>(response);
	}
}