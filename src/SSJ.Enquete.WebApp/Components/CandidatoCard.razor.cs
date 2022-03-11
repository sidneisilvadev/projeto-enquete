using Microsoft.AspNetCore.Components;
using SSJ.Enquete.WebApp.Classes;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Components
{
    public partial class CandidatoCard
    {
        [Parameter]
        public Candidato Candidato { get; set; }

        [Parameter]
		public EventCallback<Candidato> OnChange { get; set; }

        public async Task Add(int quantidade)
		{
            Candidato.Add(quantidade);
            await OnChange.InvokeAsync(Candidato);
		}
	}
}