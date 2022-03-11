using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Classes
{
	public class ApiClient
	{
		private readonly HttpClient _httpClient;

		public ApiClient(HttpClient httpClient) => _httpClient = httpClient;

		public async Task<TObject> GetAsync<TObject>(string uri)
		{
			var responseMessage = await _httpClient.GetAsync(uri);
			var jsonString = await responseMessage.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TObject>(jsonString);
		}

		public static ApiClient Create(IServiceProvider serviceProvider, string httpName)
		{
			var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
			var httpClient = httpClientFactory.CreateClient(httpName);
			return new ApiClient(httpClient);
		}
	}
}