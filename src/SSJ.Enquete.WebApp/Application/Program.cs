using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SSJ.Enquete.WebApp.Classes;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Application
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

			builder.Services.AddHttpClient("GitHub", http => http.BaseAddress = new Uri("https://raw.githubusercontent.com/sidneisilvadev/projeto-enquete/master/"));
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton<JavaScriptProxy>();
			builder.Services.AddSingleton<Sequence>();
			builder.Services.AddSingleton<Repositorio>();

			await builder.Build().RunAsync();
		}
	}
}