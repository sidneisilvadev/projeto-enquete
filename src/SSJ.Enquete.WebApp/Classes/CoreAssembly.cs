using System.Reflection;

namespace SSJ.Enquete.WebApp.Classes
{
	public static class CoreAssembly<TClass>
	{
		private static readonly Type Type = typeof(TClass);
		private static readonly Assembly Reference = Type.Assembly;
		private static readonly Version Version = Reference.GetName().Version;

		public static string AssemblyVersion => Version.ToString();
	}
}