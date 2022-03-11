using SSJ.Enquete.WebApp.Classes;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Pages
{
    [Route("/Enquete")]
    public partial class EnquetePage
    {
        [Inject]
        private Repositorio Repositorio { get; set; }

        public async Task NotifyChange(Candidato candidato) => await Task.CompletedTask;
    }
}