namespace SSJ.Enquete.WebApp.Classes
{
	public class Candidato
	{
		public Enquete Enquete { get; set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string MensagemVencendo { get; set; }
		public string MensagemPerdendo { get; set; }
		public string MensagemEmpatado { get; set; }
		public string MensagemNoCentro { get; set; }
		public string Descricao { get; set; }
		public string ImageUrl { get; set; }
		public int Votos { get; set; }

		public void Add(int quantidade) => Votos += quantidade;

		public string Mensagem => ObterMensagem();

		public string ObterMensagem()
		{
			if (EstouEmpatado) return MensagemEmpatado;
			if (EstouPerdendo) return MensagemPerdendo;
			if (EstouVencendo) return MensagemVencendo;
			return MensagemNoCentro;
		}

		public bool EstouVencendo => Enquete.EstaVencendo(this);
		public bool EstouEmpatado => Enquete.EstaEmpatado(this);
		public bool EstouPerdendo => Enquete.EstaPerdendo(this);
	}
}