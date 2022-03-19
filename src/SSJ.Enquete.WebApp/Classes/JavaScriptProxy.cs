using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SSJ.Enquete.WebApp.Classes
{
	public class JavaScriptProxy
	{
		private readonly IJSRuntime _jsRuntime;

		public JavaScriptProxy(IJSRuntime jsRuntime) => _jsRuntime = jsRuntime;

		public async Task BlazorDownloadFile(object content, string contentType, string fileName)
		{
			var jsonString = JsonConvert.SerializeObject(content, Formatting.Indented);
			await BlazorDownloadFile(jsonString, contentType, Path.GetFileName(fileName));
		}

		public async Task BlazorDownloadFile(string stringContent, string contentType, string fileName)
		{
			var content = Encoding.UTF8.GetBytes(stringContent);
			await BlazorDownloadFile(content, contentType, Path.GetFileName(fileName));
		}

		public async Task BlazorDownloadFile(string fileName, string contentType)
		{
			var fileInfo = new FileInfo(fileName);
			await BlazorDownloadFile(fileInfo, contentType, Path.GetFileName(fileName));
		}

		public async Task BlazorDownloadFile(FileInfo fileInfo, string contentType, string fileName)
		{
			using var stream = fileInfo.OpenRead();
			await BlazorDownloadFile(stream, contentType, fileName);
		}

		public async Task BlazorDownloadFile(Stream stream, string contentType, string fileName)
		{
			using var memoryStream = new MemoryStream();
			stream.CopyTo(memoryStream);
			var content = memoryStream.ToArray();
			await BlazorDownloadFile(content, contentType, fileName);
		}

		public async Task BlazorDownloadFile(byte[] content, string contentType, string fileName)
		{
			await _jsRuntime.InvokeVoidAsync("blazorDownloadFile", fileName, contentType, content);
		}
	}
}