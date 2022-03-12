using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using SSJ.Enquete.WebApp.Classes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Pages
{
	[Route("/")]
	public partial class IndexPage
	{
		[Inject]
		private Repositorio Repositorio { get; set; }

		[Inject]
		private JavaScriptProxy JavaScriptProxy { get; set; }

		protected override async Task OnParametersSetAsync()
		{
			await base.OnParametersSetAsync();
			await Repositorio.Enquete.Load();
		}

		private async void Adicionar()
		{
			Repositorio.Enquete.Adicionar(new Candidato());
			await Task.CompletedTask;
		}

		private async void CandidatoView_DoRemove(Candidato candidato)
		{
			Repositorio.Enquete.Remover(candidato);
			await Task.CompletedTask;
		}

		public async Task Download()
		{
			var candidatos = Repositorio.Enquete.Candidatos.OrderByDescending(c => c.Votos).ThenBy(c => c.Nome);
			var jsonString = JsonConvert.SerializeObject(candidatos, Formatting.Indented);
			var file = Encoding.UTF8.GetBytes(jsonString);
			await JavaScriptProxy.BlazorDownloadFile(file, "application/json", "enquete.json");
		}
	}
}