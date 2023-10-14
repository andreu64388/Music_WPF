using Music.Helper;
using Music.Model;
using Music.Services.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music.Services.Implemetions;

public class UserService
{
	private readonly HttpClient _httpClient;
	private readonly string uri = "https://localhost:7136/api/";

	public UserService()
	{
		_httpClient = new HttpClient();
		_httpClient.BaseAddress = new Uri(uri);
	}

	public async Task<UserResponce> Register(RegisterDto registerDto)
	{
		var content = new StringContent(JsonConvert.SerializeObject(registerDto), System.Text.Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync("users/register", content);

		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();
			var responseData = JsonConvert.DeserializeObject<dynamic>(json);

			UserResponce user = responseData.user.ToObject<UserResponce>();
			string token = responseData.token;
			FileManager.WriteToFileToken(token);

			return user;
		}
		else
		{
			var errorResponse = await response.Content.ReadAsStringAsync();

			var error = JsonConvert.DeserializeObject<ErrorDto>(errorResponse);

			throw new Exception(error.Message);
		}
	}

	public async Task<UserResponce> Login(LoginDto loginDto)
	{
		var content = new StringContent(JsonConvert.SerializeObject(loginDto), System.Text.Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync("users/login", content);

		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();
			var responseData = JsonConvert.DeserializeObject<dynamic>(json);

			UserResponce user = responseData.user.ToObject<UserResponce>();
			string token = responseData.token;

			FileManager.WriteToFileToken(token);

			return user;
		}
		else
		{
			var errorResponse = await response.Content.ReadAsStringAsync();

			var error = JsonConvert.DeserializeObject<ErrorDto>(errorResponse);

			throw new Exception(error.Message);
		}
	}

	public async Task<UserResponce> GetUserById(int id)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}users/{id}");
		return await HttpClientHelper.HandleResponse<UserResponce>(response);
	}

	public async Task<UserResponce> GetMe()
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Get, $"{uri}users/get-me");
		return await HttpClientHelper.HandleResponse<UserResponce>(response);
	}

	public async Task<UserResponce> UpdateUser(UserUpdateDto userDto)
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Put, $"{uri}users", userDto);
		return await HttpClientHelper.HandleResponse<UserResponce>(response);
	}

	public async Task<string> DeleteUser()
	{
		var response = await HttpClientHelper.SendRequestWithTokenAsync(HttpMethod.Delete, $"{uri}users");
		return await HttpClientHelper.HandleResponse<string>(response);
	}
}