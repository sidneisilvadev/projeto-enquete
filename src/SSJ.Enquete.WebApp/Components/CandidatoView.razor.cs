using Microsoft.AspNetCore.Components;
using SSJ.Enquete.WebApp.Classes;

namespace SSJ.Enquete.WebApp.Components
{
    public partial class CandidatoView
	{
		[Parameter]
		public Candidato Candidato { get; set; }

		[Parameter]
		public EventCallback<Candidato> OnRemove { get; set; }

		protected async void Remover() => await OnRemove.InvokeAsync(Candidato);
/*
		public override async Task SetParametersAsync(ParameterView parameters) => await base.SetParametersAsync(parameters);
		protected override async Task OnInitializedAsync() => await base.OnInitializedAsync();
		protected override async Task OnParametersSetAsync() => await base.OnParametersSetAsync();
		protected override bool ShouldRender() => base.ShouldRender();
		protected override async Task OnAfterRenderAsync(bool firstRender) => await base.OnAfterRenderAsync(firstRender);
*/
	}
}