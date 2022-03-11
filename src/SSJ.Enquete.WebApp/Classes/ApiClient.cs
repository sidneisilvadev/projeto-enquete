using Newtonsoft.Json;
using System.Collections.Generic;
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

		public async Task<List<Candidato>> GetCandidatos()
		{
			var setup = await GetAsync<Setup>("datasets/setup.json");
			return await GetAsync<List<Candidato>>(setup.Resource);
		}
	}
}