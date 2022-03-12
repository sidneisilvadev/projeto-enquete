using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Classes
{
	public class Repositorio
	{
		private readonly IServiceProvider _serviceProvider;
		public Enquete Enquete { get; }
		public Config Config { get; private set; }

		public Repositorio(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
			Enquete = new Enquete(serviceProvider);
		}

		public async Task LoadConfig()
		{
			var httpClient = _serviceProvider.GetHttpClient("GitHub");
			var apiClient = new ApiClient(httpClient);
			Config = await apiClient.GetConfig();
		}

		public async Task List(EventCallback onFinish, string resource = null)
		{
			var httpClient = _serviceProvider.GetHttpClient("GitHub");
			var apiClient = new ApiClient(httpClient);
			var candidatos = await apiClient.GetCandidatos(resource);
			Enquete.Adicionar(candidatos);
			await onFinish.InvokeAsync(this);
		}
	}
}