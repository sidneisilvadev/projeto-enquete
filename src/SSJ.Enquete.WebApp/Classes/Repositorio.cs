using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
			Enquete = new Enquete(_serviceProvider.GetService<Sequence>());
		}

		public async Task Load()
		{
			if (Enquete.NeedDataSource)
			{
				var apiClient = new ApiClient(_serviceProvider.GetHttpClient("GitHub"));
				var setup = await apiClient.GetAsync<Setup>("datasets/setup.json");
				var candidatos = await apiClient.GetAsync<List<Candidato>>(setup.Resource);
				Enquete.Adicionar(candidatos);
			}
		}
	}
}