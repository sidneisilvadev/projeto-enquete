using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Classes
{
	public class ApiClient
	{
		private readonly HttpClient _httpClient;

		public ApiClient()
		{
			_httpClient = new HttpClient() { BaseAddress = new Uri("https://raw.githubusercontent.com/sidneisilvadev/projeto-enquete/master/") };
		}

		public async Task<TObject> GetAsync<TObject>(string uri)
		{
			var responseMessage = await _httpClient.GetAsync(uri);
			var jsonString = await responseMessage.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TObject>(jsonString);
		}
	}
}