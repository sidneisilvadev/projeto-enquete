namespace SSJ.Enquete.WebApp.Classes
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImageUrl { get; set; }
        public int Votos { get; set; }

        public void Add() => Votos += 1;
        public void Add10() => Votos += 10;
        public void Remove() => Votos -= 1;
    }
}