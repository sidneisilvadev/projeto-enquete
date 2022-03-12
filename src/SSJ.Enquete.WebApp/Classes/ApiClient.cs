using Newtonsoft.Json;
using System;
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
			var responseMessage = await _httpClient.GetAsync($"{uri}?t={DateTime.UtcNow.Ticks}");
			var jsonString = await responseMessage.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TObject>(jsonString);
		}

		public async Task<List<Candidato>> GetCandidatos(string resource)
		{
			var url = resource ?? await GetRecurso();
			return await GetAsync<List<Candidato>>(url);
		}

		public async Task<string> GetRecurso() => (await GetConfig()).Recurso;

		private async Task<Config> GetConfig() => await GetAsync<Config>("datasets/config.json") ?? new Config();
	}
}