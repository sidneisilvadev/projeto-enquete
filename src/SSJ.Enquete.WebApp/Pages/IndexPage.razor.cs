using SSJ.Enquete.WebApp.Classes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Pages
{
    [Route("/")]
    public partial class IndexPage
    {
        [Inject]
        private Repositorio Repositorio { get; set; }

        private async void Adicionar()
        {
            Repositorio.Adicionar(new Candidato());
            await Task.CompletedTask;
        }

        private async void Remover(Candidato candidato)
        {
            Repositorio.Remover(candidato);
            await Task.CompletedTask;
        }
    }
}