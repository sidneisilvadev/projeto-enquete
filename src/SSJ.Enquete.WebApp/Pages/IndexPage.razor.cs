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

		protected override async Task OnParametersSetAsync()
		{
			await base.OnParametersSetAsync();
			await Repositorio.Load();
		}

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