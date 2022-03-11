namespace SSJ.Enquete.WebApp.Classes
{
	public class Setup
	{
		public string Path { get; set; }
		public string Arquivo { get; set; }
		public string Resource => $"{Path}/{Arquivo}";
	}
}