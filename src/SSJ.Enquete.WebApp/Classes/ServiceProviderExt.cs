using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace SSJ.Enquete.WebApp.Classes
{
	public static class ServiceProviderExt
	{
		public static HttpClient GetHttpClient(this IServiceProvider serviceProvider, string name = null)
		{
			var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
			return string.IsNullOrWhiteSpace(name) ? httpClientFactory.CreateClient() : httpClientFactory.CreateClient(name);
		}
	}
}