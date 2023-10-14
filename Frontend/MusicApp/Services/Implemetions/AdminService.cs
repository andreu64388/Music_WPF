using Music.Helper;
using Music.Model;
using Music.Services.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music.Services.Implemetions;

public class AdminService
{
	private readonly HttpClient _httpClient;
	private readonly string uri = "https://localhost:7136/api/admin/";

	public AdminService()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri(uri);
	}

	public async Task<List<TrackResponce>> GetAllTracks()
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}tracks");
		return await HttpClientHelper.HandleResponse<List<TrackResponce>>(response);
	}

	public async Task<List<UserResponce>> GetAllUsers()
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}users");
		return await HttpClientHelper.HandleResponse<List<UserResponce>>(response);
	}

	public async Task<TrackResponce> UpdateTrack(TrackUpdateDto trackDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Put, $"{uri}track/update", trackDto);
		return await HttpClientHelper.HandleResponse<TrackResponce>(response);
	}

	public async Task<UserResponce> UpdateUser(UserUpdateDto userDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Put, $"{uri}user/update", userDto);
		return await HttpClientHelper.HandleResponse<UserResponce>(response);
	}

	public async Task<string> DeleteTrack(int id)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Delete, $"{uri}track/delete/{id}");
		return await HttpClientHelper.HandleResponse<string>(response);
	}

	public async Task<string> DeleteUser(int id)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Delete, $"{uri}user/delete/{id}");
		return await HttpClientHelper.HandleResponse<string>(response);
	}

	public async Task<string> CreateUser(RegisterDto registerDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Post, $"{uri}user/create", registerDto);
		return await HttpClientHelper.HandleResponse<string>(response);
	}

	public async Task<string> CreateTrack(TrackDto trackDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Post, $"{uri}track/create", trackDto);
		return await HttpClientHelper.HandleResponse<string>(response);
	}
}