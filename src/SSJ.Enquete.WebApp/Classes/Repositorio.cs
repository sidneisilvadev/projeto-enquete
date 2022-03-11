﻿using System.Collections.Generic;
using System.Linq;
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
				var apiClient = new ApiClient();
				var setup = await apiClient.GetAsync<Setup>("datasets/setup.json");
				var candidatos = await apiClient.GetAsync<List<Candidato>>(setup.Resource);
				Adicionar(candidatos);
			}
		}
	}
}