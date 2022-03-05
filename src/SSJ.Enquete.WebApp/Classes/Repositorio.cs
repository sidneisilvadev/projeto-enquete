using System.Collections.Generic;

namespace SSJ.Enquete.WebApp.Classes
{
    public class Repositorio
    {
        private readonly List<Candidato> _candidatos = new List<Candidato>();
        private readonly Sequence _sequence;

        public IEnumerable<Candidato> Candidatos => _candidatos;

        public Repositorio(Sequence sequence)
        {
            _sequence = sequence;
            Adicionar(new Candidato { Nome = "Bolsonaro", ImageUrl = "https://avatars.githubusercontent.com/u/46561034?v=4" });
            Adicionar(new Candidato { Nome = "Lula", ImageUrl = "https://conteudo.imguol.com.br/c/noticias/41/2021/11/11/11nov2021---o-ex-presidente-luiz-inacio-lula-da-silva-pt-em-berlim-na-alemanha-1636644440404_v2_450x337.jpg" });
            Adicionar(new Candidato { Nome = "Moro", ImageUrl = "https://s2.glbimg.com/lBJ1jBHCtf_Ig8_V8cGxziSsG3w=/0x0:1153x783/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_63b422c2caee4269b8b34177e8876b93/internal_photos/bs/2022/Y/G/1PPs0qQdGHUWze0iWnSg/foto21pol-201-moro-a8.jpg" });
        }

        public void Adicionar(Candidato candidato)
        {
            candidato.Id = _sequence.NextValueFor("Candidato");
            _candidatos.Add(candidato);
        }

        public void Remover(Candidato candidato) => _candidatos.Remove(candidato);
    }
}