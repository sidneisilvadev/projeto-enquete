using Newtonsoft.Json;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Candidato
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public int Votos { get; set; }
		public string ImageUrl { get; set; }
		public string MensagemVencendo { get; set; }
		public string MensagemPerdendo { get; set; }
		public string MensagemEmpatado { get; set; }
		public string MensagemNoCentro { get; set; }

		[JsonIgnore]
		public Enquete Enquete { get; set; }

		[JsonIgnore]
		public string Mensagem => ObterMensagem();

		[JsonIgnore]
		public bool EstouVencendo => Enquete.EstaVencendo(this);

		[JsonIgnore]
		public bool EstouEmpatado => Enquete.EstaEmpatado(this);

		[JsonIgnore]
		public bool EstouPerdendo => Enquete.EstaPerdendo(this);

		public void Add(int quantidade) => Votos += quantidade;

		public string ObterMensagem()
		{
			if (EstouEmpatado) return MensagemEmpatado;
			if (EstouPerdendo) return MensagemPerdendo;
			if (EstouVencendo) return MensagemVencendo;
			return MensagemNoCentro;
		}
	}
}