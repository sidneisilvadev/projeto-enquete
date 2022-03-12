using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Repositorio
	{
		private readonly IServiceProvider _serviceProvider;
		public Enquete Enquete { get; }

		public Repositorio(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			Enquete = new Enquete(serviceProvider);
		}

		public async Task List(EventCallback onChange, string resource = null)
		{
			var httpClient = _serviceProvider.GetHttpClient("GitHub");
			var apiClient = new ApiClient(httpClient);
			try
			{
				var candidatos = await apiClient.GetCandidatos(resource);
				Enquete.Adicionar(candidatos);
			}
			catch
			{
				var candidatos = await apiClient.GetCandidatos(null);
				Enquete.Adicionar(candidatos);
			}
			await onChange.InvokeAsync(this);
		}
	}
}