using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SSJ.Enquete.WebApp.Classes;

namespace SSJ.Enquete.WebApp.Application
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddHttpClient("GitHub", http => http.BaseAddress = new Uri("https://raw.githubusercontent.com/sidneisilvadev/projeto-enquete/master/"));
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

			builder.Services.AddSingleton<JavaScriptProxy>();
			builder.Services.AddSingleton<Sequence>();
			builder.Services.AddSingleton<Repositorio>();

			var wasmHost = builder.Build();

			var repositorio = wasmHost.Services.GetRequiredService<Repositorio>();
			await repositorio.LoadConfig();

			await wasmHost.RunAsync();
		}
	}
}