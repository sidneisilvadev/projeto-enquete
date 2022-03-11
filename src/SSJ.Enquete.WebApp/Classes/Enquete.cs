using System.Collections.Generic;
using System.Linq;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Enquete
	{
		private readonly Sequence _sequence;
		private readonly List<Candidato> _candidatos = new List<Candidato>();

		public IEnumerable<Candidato> Candidatos => _candidatos;
		public bool NeedDataSource => _sequence.GetValueFor("Candidato") == 0;

		public Enquete(Sequence sequence) => _sequence = sequence;

		public bool Adicionar(IEnumerable<Candidato> candidatos) => candidatos.All(c => Adicionar(c));

		public bool Adicionar(Candidato candidato)
		{
			candidato.Id = _sequence.NextValueFor("Candidato");
			_candidatos.Add(candidato);
			return true;
		}

		public void Remover(Candidato candidato) => _candidatos.Remove(candidato);
	}
}