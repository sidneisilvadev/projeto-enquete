using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Classes
{
	public class JavaScriptProxy
	{
		private readonly IJSRuntime _jsRuntime;

		public JavaScriptProxy(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

		public async Task BlazorDownloadFile(byte[] file, string contentType, string fileName)
		{
			await _jsRuntime.InvokeVoidAsync("BlazorDownloadFile", fileName, contentType, file);
		}
	}
}