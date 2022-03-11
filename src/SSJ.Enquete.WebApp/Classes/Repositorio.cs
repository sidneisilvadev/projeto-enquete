using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Repositorio
	{
		private readonly Sequence _sequence;
		private readonly List<Candidato> _candidatos = new List<Candidato>();
		public IEnumerable<Candidato> Candidatos => _candidatos;

		public Repositorio(Sequence sequence) => _sequence = sequence;

		public bool Adicionar(IEnumerable<Candidato> candidatos) => candidatos.All(c => Adicionar(c));

		public bool Adicionar(Candidato candidato)
		{
			candidato.Id = _sequence.NextValueFor("Candidato");
			_candidatos.Add(candidato);
			return true;
		}

		public void Remover(Candidato candidato) => _candidatos.Remove(candidato);

		public async Task Load()
		{
			if (_sequence.GetValueFor("Candidato") == 0)
			{
				var setup = await GetAsync<Setup>("datasets/setup.json");
				var candidatos = await GetAsync<List<Candidato>>(setup.Resource);
				Adicionar(candidatos);
			}
		}

		private async Task<TObject> GetAsync<TObject>(string uri)
		{
			var _httpClient = new HttpClient() { BaseAddress = new Uri("https://raw.githubusercontent.com/sidneisilvadev/projeto-enquete/master/") };
			var responseMessage = await _httpClient.GetAsync(uri);
			var jsonString = await responseMessage.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TObject>(jsonString);
		}
	}
}