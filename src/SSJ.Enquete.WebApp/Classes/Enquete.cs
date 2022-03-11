using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Enquete
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly Sequence _sequence;
		private readonly List<Candidato> _candidatos = new List<Candidato>();

		public IEnumerable<Candidato> Candidatos => _candidatos;


		public Enquete(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			_sequence = _serviceProvider.GetService<Sequence>();
		}

		public void Remover(Candidato candidato) => _candidatos.Remove(candidato);

		public bool Adicionar(IEnumerable<Candidato> candidatos) => candidatos.All(c => Adicionar(c));

		public bool Adicionar(Candidato candidato)
		{
			candidato.Id = _sequence.NextValueFor("Candidato");
			candidato.Enquete = this;
			_candidatos.Add(candidato);
			return true;
		}

		public IEnumerable<Candidato> Vencedores => Candidatos.AllWithMax(c => c.Votos);

		public IEnumerable<Candidato> Perdedores => Candidatos.AllWithMin(c => c.Votos);

		public bool EstaVencendo(Candidato candidato) => Vencedores.Any(v => v.Id == candidato.Id);

		public bool EstaPerdendo(Candidato candidato) => Perdedores.Any(v => v.Id == candidato.Id);

		public bool EstaEmpatado(Candidato candidato) => Vencedores.Count() > 1 && Vencedores.Any(v => v.Id == candidato.Id);

		public async Task Load()
		{
			if (_sequence.GetValueFor("Candidato") == 0)
			{
				var apiClient = new ApiClient(_serviceProvider.GetHttpClient("GitHub"));
				var candidatos = await apiClient.GetCandidatos();
				Adicionar(candidatos);
			}
		}
	}
}