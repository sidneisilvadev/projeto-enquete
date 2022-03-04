namespace SSJ.Enquete.WebApp.Classes
{
    public class Candidato
    {
        public string Nome { get; set; }
        public string ImageUrl { get; set; }
        public int Votos { get; set; }

        public void Add() => Votos += 1;
        public void Remove() => Votos -= 1;
    }
}