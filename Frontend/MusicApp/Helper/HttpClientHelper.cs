using Music.Services.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Music.Helper;

public static class HttpClientHelper
{
	private static readonly HttpClient _httpClient = new HttpClient();

	public static async Task<HttpResponseMessage> SendRequestWithTokenAsync(HttpMethod method, string endpoint, object data = null)
	{
		string token = await FileManager.ReadFromFileToken();
		_httpClient.DefaultRequestHeaders.Remove("token");
		_httpClient.DefaultRequestHeaders.Add("token", token);

		HttpRequestMessage request = new HttpRequestMessage(method, endpoint);

		if (data != null)
		{
			var content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
			request.Content = content;
		}

		return await _httpClient.SendAsync(request);
	}

	public static async Task<T> HandleResponse<T>(HttpResponseMessage response)
	{
		if (response.IsSuccessStatusCode)
		{
			var json = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(json);
		}
		else
		{
			var errorResponse = await response.Content.ReadAsStringAsync();
			var error = JsonConvert.DeserializeObject<ErrorDto>(errorResponse);
			throw new Exception(error.Message);
		}
	}
}