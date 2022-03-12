using Microsoft.AspNetCore.Components;
using SSJ.Enquete.WebApp.Classes;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Components
{
    public partial class CandidatoLinear
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

		public async Task Reset()
		{
			Candidato.Votos = 0;
			await OnChange.InvokeAsync(Candidato);
		}

/*
		public override async Task SetParametersAsync(ParameterView parameters) => await base.SetParametersAsync(parameters);
		protected override async Task OnInitializedAsync() => await base.OnInitializedAsync();
		protected override async Task OnParametersSetAsync() => await base.OnParametersSetAsync();
		protected override bool ShouldRender() => base.ShouldRender();
		protected override async Task OnAfterRenderAsync(bool firstRender) => await base.OnAfterRenderAsync(firstRender);
*/
	}
}