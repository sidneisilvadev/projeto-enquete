using System.Collections.Generic;

namespace SSJ.Enquete.WebApp.Classes
{
    public class Repositorio
    {
        public readonly List<Candidato> Candidatos = new List<Candidato>();

        public void Adicionar(string nome, string imagemUrl) => Adicionar(new Candidato { Nome = nome, ImageUrl = imagemUrl });

        public void Adicionar(Candidato candidato) => Candidatos.Add(candidato);

        public void Remover(Candidato candidato) => Candidatos.Remove(candidato);
    }
}
