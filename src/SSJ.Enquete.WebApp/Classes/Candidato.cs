namespace SSJ.Enquete.WebApp.Classes
{
	public class Candidato
	{
		public Enquete Enquete { get; set; }
		public int Id { get; set; }
		public string Nome { get; set; }
		public string MensagemComemoracao { get; set; }
		public string MensagemIncentivo { get; set; }
		public string Descricao { get; set; }
		public string ImageUrl { get; set; }
		public int Votos { get; set; }

		public void Add(int quantidade) => Votos += quantidade;

		public string Mensagem => EstouPerdendo ? MensagemIncentivo : MensagemComemoracao;

		public bool EstouVencendo => Enquete.EstaVencendo(this);
		public bool EstouPerdendo => Enquete.EstaPerdendo(this);
	}
}